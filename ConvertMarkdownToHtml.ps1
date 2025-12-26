# Script PowerShell per convertire tutti i file Markdown in HTML
# SchoolGrades - Conversione documentazione Manual_IT
# Usa conversione regex-based compatibile con tutte le versioni PowerShell

param(
    [string]$SourceFolder = ".\Manual_IT",
    [string]$OutputFolder = ".\Manual_IT\HTML"
)

Write-Host "==================================================" -ForegroundColor Cyan
Write-Host "  SchoolGrades - Conversione Markdown -> HTML" -ForegroundColor Cyan
Write-Host "==================================================" -ForegroundColor Cyan
Write-Host ""

# Verifica che la cartella sorgente esista
if (-not (Test-Path $SourceFolder)) {
    Write-Host "ERRORE: La cartella sorgente '$SourceFolder' non esiste!" -ForegroundColor Red
    exit 1
}

# Crea la cartella di output se non esiste
if (-not (Test-Path $OutputFolder)) {
    Write-Host "Creazione cartella di output: $OutputFolder" -ForegroundColor Yellow
    New-Item -ItemType Directory -Path $OutputFolder | Out-Null
}

# Funzione per convertire Markdown in HTML (semplificata ma funzionale)
function Convert-MarkdownToHtml {
    param([string]$markdown)
    
    $html = $markdown
    
    # Escape HTML special chars (tranne quelli già in tag HTML)
    # $html = $html -replace '&(?!([a-zA-Z]+|#[0-9]+|#x[0-9a-fA-F]+);)', '&amp;'
    
    # Headers (h1-h6)
    $html = $html -replace '(?m)^######\s+(.+)$', '<h6>$1</h6>'
    $html = $html -replace '(?m)^#####\s+(.+)$', '<h5>$1</h5>'
    $html = $html -replace '(?m)^####\s+(.+)$', '<h4>$1</h4>'
    $html = $html -replace '(?m)^###\s+(.+)$', '<h3>$1</h3>'
    $html = $html -replace '(?m)^##\s+(.+)$', '<h2>$1</h2>'
    $html = $html -replace '(?m)^#\s+(.+)$', '<h1>$1</h1>'
    
    # Horizontal rules
    $html = $html -replace '(?m)^---+\s*$', '<hr>'
    $html = $html -replace '(?m)^\*\*\*+\s*$', '<hr>'
    
    # Bold and italic (prima bold+italic, poi bold, poi italic)
    $html = $html -replace '\*\*\*(.+?)\*\*\*', '<strong><em>$1</em></strong>'
    $html = $html -replace '\*\*(.+?)\*\*', '<strong>$1</strong>'
    $html = $html -replace '\*(.+?)\*', '<em>$1</em>'
    $html = $html -replace '___(.+?)___', '<strong><em>$1</em></strong>'
    $html = $html -replace '__(.+?)__', '<strong>$1</strong>'
    $html = $html -replace '_(.+?)_', '<em>$1</em>'
    
    # Inline code
    $html = $html -replace '`([^`]+?)`', '<code>$1</code>'
    
    # Links [text](url)
    $html = $html -replace '\[([^\]]+)\]\(([^\)]+)\)', '<a href="$2">$1</a>'
    
    # Images ![alt](url)
    $html = $html -replace '!\[([^\]]*)\]\(([^\)]+)\)', '<img src="$2" alt="$1">'
    
    # Code blocks (```code```)
    $html = $html -replace '(?s)```(\w*)\r?\n(.+?)\r?\n```', '<pre><code>$2</code></pre>'
    
    # Unordered lists
    $lines = $html -split "`n"
    $inList = $false
    $processedLines = @()
    
    foreach ($line in $lines) {
        if ($line -match '^\s*[\*\-\+]\s+(.+)$') {
            if (-not $inList) {
                $processedLines += '<ul>'
                $inList = $true
            }
            $processedLines += "  <li>$($matches[1])</li>"
        }
        elseif ($line -match '^\s*\d+\.\s+(.+)$') {
            if (-not $inList) {
                $processedLines += '<ol>'
                $inList = $true
            }
            $processedLines += "  <li>$($matches[1])</li>"
        }
        else {
            if ($inList) {
                # Chiudi la lista precedente
                if ($processedLines[-1] -match '<li>') {
                    # Era una lista non ordinata
                    if ($processedLines | Where-Object { $_ -match '<ul>' } | Select-Object -Last 1) {
                        $processedLines += '</ul>'
                    } else {
                        $processedLines += '</ol>'
                    }
                }
                $inList = $false
            }
            $processedLines += $line
        }
    }
    
    # Chiudi lista finale se ancora aperta
    if ($inList) {
        if ($processedLines | Where-Object { $_ -match '<ul>' } | Select-Object -Last 1) {
            $processedLines += '</ul>'
        } else {
            $processedLines += '</ol>'
        }
    }
    
    $html = $processedLines -join "`n"
    
    # Paragrafi (linee vuote separano i paragrafi)
    $html = $html -replace '(?m)^([^<\r\n].+)$', '<p>$1</p>'
    
    # Rimuovi <p> dai tag che non dovrebbero averlo
    $html = $html -replace '<p>(<h[1-6]>)', '$1'
    $html = $html -replace '(</h[1-6]>)</p>', '$1'
    $html = $html -replace '<p>(<hr>)</p>', '$1'
    $html = $html -replace '<p>(</?ul>)</p>', '$1'
    $html = $html -replace '<p>(</?ol>)</p>', '$1'
    $html = $html -replace '<p>(<li>)', '$1'
    $html = $html -replace '(</li>)</p>', '$1'
    $html = $html -replace '<p>(<pre>)', '$1'
    $html = $html -replace '(</pre>)</p>', '$1'
    
    return $html
}

# Conta i file Markdown
$mdFiles = Get-ChildItem -Path $SourceFolder -Filter *.md
$totalFiles = $mdFiles.Count

if ($totalFiles -eq 0) {
    Write-Host "ATTENZIONE: Nessun file .md trovato in '$SourceFolder'" -ForegroundColor Yellow
    exit 0
}

Write-Host "Trovati $totalFiles file Markdown da convertire`n" -ForegroundColor Green

# Stile CSS per la documentazione italiana
$cssStyle = @"
body { 
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; 
    max-width: 1000px; 
    margin: 40px auto; 
    padding: 20px 40px; 
    line-height: 1.7;
    background-color: #f8f9fa;
    color: #212529;
}
h1 { 
    color: #1a4d2e; 
    border-bottom: 3px solid #4f772d; 
    padding-bottom: 15px; 
    margin-top: 40px;
    font-size: 2.5em;
}
h2 { 
    color: #2d5016; 
    margin-top: 35px; 
    margin-bottom: 15px;
    padding-bottom: 8px;
    border-bottom: 2px solid #90a955;
    font-size: 1.8em;
}
h3 { 
    color: #3d6628; 
    margin-top: 25px;
    font-size: 1.4em;
}
h4 {
    color: #4a7c32;
    margin-top: 20px;
    font-size: 1.2em;
}
code { 
    background-color: #e9ecef; 
    padding: 3px 8px; 
    border-radius: 4px; 
    font-family: 'Consolas', 'Monaco', monospace;
    color: #d63384;
    font-size: 0.9em;
}
pre { 
    background-color: #2d2d2d; 
    color: #f8f8f2;
    padding: 20px; 
    border-radius: 6px; 
    overflow-x: auto;
    border-left: 4px solid #4f772d;
    margin: 20px 0;
}
pre code {
    background-color: transparent;
    color: #f8f8f2;
    padding: 0;
}
a {
    color: #4f772d;
    text-decoration: none;
    border-bottom: 1px dotted #4f772d;
}
a:hover {
    color: #2d5016;
    border-bottom: 1px solid #2d5016;
}
img { 
    max-width: 100%; 
    height: auto; 
    border-radius: 8px;
    box-shadow: 0 4px 6px rgba(0,0,0,0.1);
    margin: 20px 0;
}
table { 
    border-collapse: collapse; 
    width: 100%; 
    margin: 25px 0;
    background-color: white;
    box-shadow: 0 2px 4px rgba(0,0,0,0.1);
}
th, td { 
    border: 1px solid #dee2e6; 
    padding: 12px 15px; 
    text-align: left; 
}
th { 
    background-color: #4f772d; 
    color: white;
    font-weight: 600;
}
tr:nth-child(even) {
    background-color: #f8f9fa;
}
tr:hover {
    background-color: #e9ecef;
}
blockquote {
    border-left: 4px solid #4f772d;
    margin: 20px 0;
    padding: 10px 20px;
    background-color: #f1f8f4;
    font-style: italic;
}
ul, ol {
    margin: 15px 0;
    padding-left: 30px;
}
li {
    margin: 8px 0;
}
strong {
    color: #1a4d2e;
    font-weight: 600;
}
em {
    color: #4a7c32;
}
hr {
    border: none;
    border-top: 2px solid #90a955;
    margin: 40px 0;
}
.header-nav {
    background-color: #4f772d;
    color: white;
    padding: 10px 20px;
    border-radius: 6px;
    margin-bottom: 30px;
    text-align: center;
}
.footer {
    margin-top: 60px;
    padding-top: 20px;
    border-top: 2px solid #dee2e6;
    text-align: center;
    color: #6c757d;
    font-size: 0.9em;
}
"@

# Contatore per i progressi
$currentFile = 0

# Converti tutti i file .md
foreach ($file in $mdFiles) {
    $currentFile++
    $mdFile = $file.FullName
    $baseName = $file.BaseName
    $htmlFile = Join-Path $OutputFolder ($baseName + ".html")
    
    Write-Host "[$currentFile/$totalFiles] Conversione: " -NoNewline -ForegroundColor Cyan
    Write-Host $file.Name -ForegroundColor White
    
    try {
        # Leggi il contenuto Markdown
        $markdownContent = Get-Content -Path $mdFile -Raw -Encoding UTF8
        
        # Converti Markdown in HTML
        $htmlBody = Convert-MarkdownToHtml -markdown $markdownContent
        
        # Crea un documento HTML completo con stile
        $htmlContent = @"
<!DOCTYPE html>
<html lang="it">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Documentazione SchoolGrades - $baseName">
    <meta name="author" content="SchoolGrades">
    <title>$baseName - SchoolGrades</title>
    <style>
$cssStyle
    </style>
</head>
<body>
    <div class="header-nav">
        <h3 style="margin: 0; color: white;">?? SchoolGrades - Documentazione</h3>
    </div>
    
$htmlBody
    
    <div class="footer">
        <p>Documentazione generata da SchoolGrades | .NET 10</p>
        <p>File sorgente: <code>$($file.Name)</code></p>
        <p>Data generazione: $(Get-Date -Format "dd/MM/yyyy HH:mm")</p>
    </div>
</body>
</html>
"@
        
        # Salva il file HTML
        Set-Content -Path $htmlFile -Value $htmlContent -Encoding UTF8
        Write-Host "  ? Salvato: " -NoNewline -ForegroundColor Green
        Write-Host "$htmlFile" -ForegroundColor Gray
    }
    catch {
        Write-Host "  ? ERRORE durante la conversione: $($_.Exception.Message)" -ForegroundColor Red
    }
}

Write-Host ""
Write-Host "==================================================" -ForegroundColor Cyan
Write-Host "  Conversione completata!" -ForegroundColor Green
Write-Host "==================================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "File convertiti: $currentFile/$totalFiles" -ForegroundColor Yellow
Write-Host "Cartella output: " -NoNewline -ForegroundColor White
Write-Host $OutputFolder -ForegroundColor Cyan
Write-Host ""

# Crea un file index.html con l'elenco di tutti i documenti
Write-Host "Creazione index.html..." -ForegroundColor Yellow

$indexContent = @"
<!DOCTYPE html>
<html lang="it">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SchoolGrades - Indice Documentazione</title>
    <style>
$cssStyle
.doc-list {
    list-style: none;
    padding: 0;
}
.doc-list li {
    margin: 15px 0;
    padding: 15px;
    background-color: white;
    border-radius: 6px;
    box-shadow: 0 2px 4px rgba(0,0,0,0.1);
    transition: transform 0.2s;
}
.doc-list li:hover {
    transform: translateX(5px);
    box-shadow: 0 4px 8px rgba(0,0,0,0.15);
}
.doc-list a {
    font-size: 1.1em;
    font-weight: 500;
    border-bottom: none;
}
.main-doc {
    background-color: #f1f8f4 !important;
    border-left: 5px solid #4f772d;
}
    </style>
</head>
<body>
    <div class="header-nav">
        <h1 style="margin: 0; color: white;">?? SchoolGrades</h1>
        <h3 style="margin: 10px 0 0 0; color: white; font-weight: 300;">Documentazione Completa</h3>
    </div>
    
    <h2>Benvenuto nella documentazione di SchoolGrades</h2>
    <p>SchoolGrades è un'applicazione Windows Forms progettata per supportare gli insegnanti nella gestione quotidiana delle attività didattiche in classe.</p>
    
    <h3>?? Documenti Disponibili</h3>
    <ul class="doc-list">
"@

# Ordina i file HTML: prima il manuale principale, poi gli altri in ordine alfabetico
$htmlFiles = Get-ChildItem -Path $OutputFolder -Filter *.html | Where-Object { $_.Name -ne "index.html" }
$mainManual = $htmlFiles | Where-Object { $_.Name -eq "Manuale-Utente-SchoolGrades.html" }
$otherFiles = $htmlFiles | Where-Object { $_.Name -ne "Manuale-Utente-SchoolGrades.html" } | Sort-Object Name

# Aggiungi il manuale principale per primo
if ($mainManual) {
    $indexContent += @"
        <li class="main-doc">
            <strong>?? Manuale Principale:</strong><br>
            <a href="$($mainManual.Name)">$($mainManual.BaseName -replace '-', ' ')</a>
        </li>
"@
}

# Aggiungi gli altri documenti
if ($otherFiles.Count -gt 0) {
    $indexContent += "        <li><strong>?? Documentazione Finestre:</strong></li>`n"
    foreach ($htmlFile in $otherFiles) {
        $displayName = $htmlFile.BaseName -replace '-', ' '
        $indexContent += @"
        <li>
            <a href="$($htmlFile.Name)">$displayName</a>
        </li>
"@
    }
}

$indexContent += @"
    </ul>
    
    <h3>?? Informazioni</h3>
    <p>Questa documentazione è stata generata automaticamente dai file Markdown sorgente.</p>
    <p>Per contribuire alla documentazione o segnalare errori, visitare il <a href="https://github.com/gamondue/SchoolGrades" target="_blank">repository GitHub</a>.</p>
    
    <div class="footer">
        <p><strong>SchoolGrades</strong> - Gestione didattica per insegnanti</p>
        <p>Framework: .NET 10 | Database: SQLite</p>
        <p>Documentazione generata il: $(Get-Date -Format "dd/MM/yyyy HH:mm")</p>
    </div>
</body>
</html>
"@

# Salva index.html
$indexPath = Join-Path $OutputFolder "index.html"
Set-Content -Path $indexPath -Value $indexContent -Encoding UTF8
Write-Host "? Index creato: $indexPath" -ForegroundColor Green

Write-Host ""
Write-Host "Per visualizzare la documentazione, apri:" -ForegroundColor Yellow
Write-Host "  $indexPath" -ForegroundColor Cyan
Write-Host ""

# Chiedi se aprire il browser
$response = Read-Host "Vuoi aprire la documentazione nel browser? (S/N)"
if ($response -eq 'S' -or $response -eq 's' -or $response -eq 'Y' -or $response -eq 'y') {
    Start-Process $indexPath
}
