# ?? Guida Implementazione Multilingual SchoolGrades

## ? Stato Corrente

Sono stati creati i componenti fondamentali per il sistema multilingua:

### File Creati

1. **LocalizationManager.cs** - Gestore centrale localizzazione
2. **FormLocalizer.cs** - Helper per localizzazione automatica form
3. **LocalizedMessageBox.cs** - MessageBox localizzati
4. **Settings.Designer.cs** - Esteso con proprietà Language
5. **frmSetup.Localized.cs** - Esempio completo frmSetup localizzato

### File di Documentazione

1. **ResourceFiles-Setup-Guide.md** - Guida creazione file .resx
2. **Implementation-Guide.md** - Questa guida

---

## ?? Passi per Completare l'Implementazione

### STEP 1: Creare File .resx (MANUALE)

?? **IMPORTANTE**: Seguire la guida in `ResourceFiles-Setup-Guide.md`

1. Creare cartella `SchoolGrades/Resources`
2. Creare `Strings.resx` (italiano - default)
3. Popolare con le stringhe della guida
4. Creare `Strings.en.resx` (inglese)
5. Popolare con traduzioni inglesi
6. Verificare Build Action = "Embedded Resource"
7. Build progetto per generare `Strings.Designer.cs`

### STEP 2: Applicare Codice a frmSetup

Il file `frmSetup.Localized.cs` contiene il codice completo.

**Cosa fare**:

1. Aprire `frmSetup.cs` nell'editor
2. Copiare il contenuto da `frmSetup.Localized.cs`
3. **Sostituire completamente** il contenuto di `frmSetup.cs`
4. Salvare

**Oppure** (se più comodo):
1. Rinominare `frmSetup.cs` ? `frmSetup.cs.OLD`
2. Rinominare `Localization/frmSetup.Localized.cs` ? `SchoolGrades/frmSetup.cs`

### STEP 3: Aggiungere ComboBox Lingua al Designer

Aprire `frmSetup.Designer.cs` e aggiungere:

```csharp
private void InitializeComponent()
{
    // ...existing code...
    
    // ADD THIS:
    this.cmbLanguage = new System.Windows.Forms.ComboBox();
    this.lblLanguage = new System.Windows.Forms.Label();
    
    // Configure lblLanguage
    this.lblLanguage.AutoSize = true;
    this.lblLanguage.Location = new System.Drawing.Point(12, 20);
    this.lblLanguage.Name = "lblLanguage";
    this.lblLanguage.Size = new System.Drawing.Size(43, 13);
    this.lblLanguage.TabIndex = 100;
    this.lblLanguage.Text = "Lingua:";
    
    // Configure cmbLanguage
    this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    this.cmbLanguage.FormattingEnabled = true;
    this.cmbLanguage.Location = new System.Drawing.Point(80, 17);
    this.cmbLanguage.Name = "cmbLanguage";
    this.cmbLanguage.Size = new System.Drawing.Size(150, 21);
    this.cmbLanguage.TabIndex = 101;
    
    // Add to form controls
    this.Controls.Add(this.lblLanguage);
    this.Controls.Add(this.cmbLanguage);
    
    // ...existing code...
}

// ADD THESE FIELDS:
private System.Windows.Forms.ComboBox cmbLanguage;
private System.Windows.Forms.Label lblLanguage;
```

**Posizionamento consigliato**: In alto a destra del form, vicino ai percorsi

### STEP 4: Test Immediato

1. **Build** del progetto (F6)
2. Risolvere eventuali errori di compilazione
3. **Avviare** il programma (F5)
4. Aprire **Setup**
5. Verificare:
   - Tutti i bottoni sono in italiano
   - ComboBox lingua mostra "Italiano" selezionato
   - Cambiare a "English"
   - Confermare riavvio
   - Verificare che i bottoni sono in inglese

### STEP 5: Verifica Funzionalità

Test da eseguire:

- [ ] Cambio lingua da Italiano ? English
- [ ] Riavvio automatico applicazione
- [ ] Testi bottoni in inglese
- [ ] MessageBox in inglese
- [ ] Cambio lingua da English ? Italiano
- [ ] Preferenza salvata (riavvio manuale, lingua mantenuta)

---

## ?? Estensione ad Altri Form

Una volta che frmSetup funziona, estendere ad altri form è semplice:

### Metodo Rapido (Esempio: frmMain)

```csharp
// In frmMain.cs

using SchoolGrades.Localization;

private void frmMain_Load(object sender, EventArgs e)
{
    // ...existing code...
    
    // ADD THIS LINE:
    ApplyLocalization();
}

private void ApplyLocalization()
{
    // Form title
    this.Text = Loc.Get("Main_Title");
    
    // Buttons
    btnSaveGrade.Text = Loc.Get("Common_Save");
    btnCancel.Text = Loc.Get("Common_Cancel");
    btnDeleteGrade.Text = Loc.Get("Common_Delete");
    // ...etc for all controls
}
```

### Aggiungere Chiavi in Strings.resx

```
Main_Title              | SchoolGrades - Gestione Voti
Main_SelectStudent      | Selezionare uno studente
Main_SaveGrade          | Salva voto
// ...etc
```

E in `Strings.en.resx`:

```
Main_Title              | SchoolGrades - Grades Management
Main_SelectStudent      | Select a student
Main_SaveGrade          | Save grade
// ...etc
```

---

## ?? Priorità Form da Localizzare

### Alta Priorità (uso frequente)
1. ? frmSetup (FATTO)
2. frmMain
3. frmMicroAssessment
4. frmStudent
5. frmQuestionChoose

### Media Priorità
6. frmQuestion
7. frmLessons
8. frmTopics
9. frmGradesClassSummary
10. frmGradesStudentsSummary

### Bassa Priorità (raramente usati)
11-30. Tutti gli altri form

---

## ??? Tool e Automazioni

### Script PowerShell per Estrarre Testi (Opzionale)

Creare `Extract-Strings.ps1`:

```powershell
# Extract all hardcoded strings from a form
param([string]$FormFile)

$content = Get-Content $FormFile
$strings = $content | Select-String -Pattern '"\w+"' -AllMatches | 
    ForEach-Object { $_.Matches } | 
    ForEach-Object { $_.Value } | 
    Sort-Object -Unique

Write-Host "Strings found in $FormFile:"
$strings
```

Uso:
```powershell
.\Extract-Strings.ps1 -FormFile "SchoolGrades\frmMain.cs"
```

---

## ?? Aggiungere Nuove Lingue

### Per Francese:

1. **Creare** `Strings.fr.resx`
2. **Copiare** tutte le chiavi da `Strings.resx`
3. **Tradurre** i valori in francese
4. **Aggiornare** `LocalizationManager.cs`:
   ```csharp
   { "fr-FR", "Français" }
   ```
5. **Build** e testare

### Per Spagnolo:

Stesso processo con `Strings.es.resx` e `{ "es-ES", "Español" }`

---

## ?? Problemi Comuni e Soluzioni

### Problema: Chiave non trovata (es. "[Common_Save]")

**Causa**: Chiave non esiste nel file .resx corrente

**Soluzione**:
1. Aprire `Strings.resx` (o `Strings.en.resx`)
2. Aggiungere la chiave mancante
3. Rebuild progetto

### Problema: Lingua non cambia

**Causa**: File .resx non configurato correttamente

**Soluzione**:
1. Verificare Build Action = "Embedded Resource"
2. Verificare nome file esatto (es. `Strings.en.resx`)
3. Rebuild completo (Clean + Build)

### Problema: Applicazione non si riavvia

**Causa**: Exception nel codice di chiusura

**Soluzione**:
1. Controllare Event Viewer per exceptions
2. Verificare che `Application.Restart()` sia chiamato
3. Aggiungere try-catch in `OnFormClosing`

### Problema: ComboBox non appare

**Causa**: Non aggiunto al designer o non posizionato

**Soluzione**:
1. Verificare che `cmbLanguage` sia dichiarato in Designer.cs
2. Verificare che sia aggiunto a `this.Controls`
3. Controllare Location e Size

---

## ?? Metriche e Progresso

### Stimare Effort per Form

Formula empirica:
- **Form semplice** (5-10 controlli): 15-30 minuti
- **Form medio** (10-20 controlli): 30-60 minuti
- **Form complesso** (20+ controlli): 1-2 ore

Tempo totale stimato per 25 form: **20-40 ore**

### Tracking Progresso

Creare file `Localization-Progress.md`:

```markdown
# Localization Progress

## Completed ?
- [x] frmSetup (100%)

## In Progress ??
- [ ] frmMain (0%)

## To Do ??
- [ ] frmMicroAssessment
- [ ] frmStudent
- [ ] ...etc
```

---

## ?? Best Practices

### 1. Nomenclatura Chiavi

- **Prefisso form**: `[FormName]_[ControlPurpose]`
- **Elementi comuni**: `Common_[Action]`
- **Messaggi**: `Messages_[Context]`
- **Labels**: `Labels_[Field]`

### 2. Organizzazione .resx

Raggruppare chiavi per categoria con commenti:

```xml
<!-- Common UI Elements -->
<data name="Common_Save">...</data>

<!-- Setup Form -->
<data name="Setup_Title">...</data>

<!-- Messages -->
<data name="Messages_Error">...</data>
```

### 3. Testing

- Testare cambio lingua avanti e indietro
- Verificare TUTTI i controlli localizzati
- Testare con testi più lunghi (tedesco, russo)
- Verificare layout non rotto

### 4. Manutenzione

- Tenere `Strings.resx` come riferimento (italiano)
- Aggiungere nuove chiavi in TUTTI i file lingua contemporaneamente
- Usare `[TODO]` come valore temporaneo per traduzioni mancanti

---

## ?? Risorse Utili

- [.NET Localization Docs](https://learn.microsoft.com/en-us/dotnet/core/extensions/localization)
- [Culture Codes](https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-lcid/)
- [ResX Format](https://learn.microsoft.com/en-us/dotnet/framework/resources/working-with-resx-files)

---

## ? Prossimi Passi

1. ? Creare file .resx
2. ? Applicare codice a frmSetup
3. ? Test funzionamento base
4. ?? Estendere a frmMain
5. ?? Estendere a form uso frequente
6. ?? Completare tutti i form
7. ?? Aggiungere altre lingue (francese, spagnolo, tedesco)
8. ?? Documentazione tradotta (EN version of README)

---

## ?? Contribuire

Per contribuire traduzioni:

1. Fork del progetto
2. Creare `Strings.[lingua].resx`
3. Tradurre tutte le chiavi
4. Test completo
5. Pull Request con descrizione

**Lingue richieste**: Francese, Spagnolo, Tedesco, Portoghese

---

*Implementazione multilingual system by SchoolGrades Team*
*Last updated: 2025-01-28*
