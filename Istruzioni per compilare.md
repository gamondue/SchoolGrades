# Vorrei compilare il programma Windows Forms SchoolGrades per poi distribuirlo in un unico file di installazione in Windows, ma non non riesco a fare qualcosa che funzioni senza problemi. Puoi aiutarmi ?


Di seguito i passi pratici, verificati per .NET 10 WinForms, per ottenere una cartella publish funzionante e poi creare un singolo file di installazione (.exe) usando Inno Setup. Segui nell'ordine e testa su una macchina pulita (VM). Indicherò anche i punti critici del tuo progetto (SQLite).

1.	Compilazione e pubblicazione single-file (consigliata) 
- Dalla riga di comando (PowerShell o terminale) nella cartella della soluzione esegui questo comando per creare un pacchetto self-contained single-file per Windows x64 (release). Non attivare il trimming perché WinForms, reflection e SQLite possono rompersi:

dotnet publish -c Release -r win-x64 --nologo --no-self-contained:false -p:PublishSingleFile=true -p:SelfContained=true -p:PublishTrimmed=false -p:IncludeNativeLibrariesForSelfExtract=true -o publish\win-x64\release

Spiegazione rapida:
-	-r win-x64 genera binari per Windows x64. Usa win-x86 se serve 32-bit.
-	PublishSingleFile=true crea un singolo eseguibile (ma alcuni file nativi possono essere estratti).
-	SelfContained=true include il runtime .NET (nessuna dipendenza dal .NET installato).
-	IncludeNativeLibrariesForSelfExtract=true aiuta con librerie native (SQLite).
-	PublishTrimmed=false disabilita il trimming che può interrompere WinForms o riflessione.

2.	Casi particolari del tuo progetto
-	SQLite: usi SQLitePCLRaw.bundle_e_sqlite3. L'opzione IncludeNativeLibrariesForSelfExtract=true nella publish gestisce l'estrazione delle librerie native; testare il DB su macchina pulita.
-	Localizzazione (satellite assemblies): le risorse localizzate producono sottocartelle (es. it, en) con assembly satellite. Assicurati che il contenuto della cartella publish\win-x64\release includa queste cartelle  Inno Setup dovrà includerle.
3.	Opzione: impostare valori di publish di default nel progetto.  
  Se preferisci avere questi valori sempre, aggiungi questo PropertyGroup nel tuo SchoolGrades.csproj (inseriscilo dentro il file .csproj):

 xml SchoolGrades\SchoolGrades.csproj
  <PropertyGroup>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    <PublishSingleFile>true</PublishSingleFile>
    <SelfContained>true</SelfContained>
    <PublishTrimmed>false</PublishTrimmed>
    <IncludeNativeLibrariesForSelfExtract>true</IncludeNativeLibrariesForSelfExtract>
    <PublishReadyToRun>false</PublishReadyToRun>
  </PropertyGroup>

Modifica RuntimeIdentifier se serve win-x86. Questo semplifica l'uso di Publish da Visual Studio (vedi sotto).

4.	Usare Visual Studio (Publish)
- In Visual Studio 2026: tasto destro sul progetto -> Publish....
- Crea un profilo di tipo Folder; seleziona Runtime target win-x64; Deployment mode Self-contained; abilita Produce single file e Include native libraries for self-extract.
- Premi Publish.

 5.	Creare l'installer singolo (esempio Inno Setup).  
  Dopo il publish, usa Inno Setup (facile e produce un .exe unico).  
  Esempio di script Inno Setup (installer\SchoolGrades.iss):

[Setup]
AppName=SchoolGrades
AppVersion=0.60.0
DefaultDirName={pf}\SchoolGrades
DefaultGroupName=SchoolGrades
OutputBaseFilename=SchoolGrades_Installer
Compression=lzma
SolidCompression=yes
ArchitecturesInstallIn64BitMode=x64

[Files]
; Includi tutta la cartella pubblicata (esempio path relativo alla soluzione)
Source: "publish\win-x64\release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\SchoolGrades"; Filename: "{app}\SchoolGrades.exe"

[Run]
Filename: "{app}\SchoolGrades.exe"; Description: "Avvia SchoolGrades"; Flags: nowait postinstall skipifsilent

[Setup]
AppName=SchoolGrades
AppVersion=0.60.0
DefaultDirName={pf}\SchoolGrades
DefaultGroupName=SchoolGrades
OutputBaseFilename=SchoolGrades_Installer
Compression=lzma
SolidCompression=yes
ArchitecturesInstallIn64BitMode=x64

[Files]
; Includi tutta la cartella pubblicata (esempio path relativo alla soluzione)
Source: "publish\win-x64\release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\SchoolGrades"; Filename: "{app}\SchoolGrades.exe"

[Run]
Filename: "{app}\SchoolGrades.exe"; Description: "Avvia SchoolGrades"; Flags: nowait postinstall skipifsilent

- Compila lo script con Inno Setup e otterrai un singolo EXE installabile.
- Assicurati che `publish\win-x64\release` includa i file e le sottocartelle di lingua.

6. Test finale e controlli
- Testare linstaller su macchina pulita (VM) Windows 10/11 x64.
- Verifica: apertura, funzionalità che usano SpeechLib, accesso al DB SQLite, localizzazione.
- Se qualcosa non funziona, eseguire il publish senza single-file per controllare quali file mancano: `-p:PublishSingleFile=false` e confrontare cartelle.

7. Problemi comuni e come diagnosticarli
- Errori di native dependency: controlla il log di publish e la presenza di .dll native nella cartella publish. Aggiungi `-v diag` al `dotnet publish` per log dettagliati.
- Risorse mancanti (lingua): assicurati che i satelliti (`it\`, `en\`) siano copiati in installer.
- COM non trovato: verifica presenza SAPI o valuta alternative (usare API .NET gestite o rimuovere dipendenza se non è critica).
