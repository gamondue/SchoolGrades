# Finestra Setup - Manuale Utente

## Introduzione

La finestra **Setup** (frmSetup) è il pannello di configurazione centrale di SchoolGrades. Permette di configurare percorsi, gestire database, accedere a tutte le finestre di amministrazione e manutenzione del sistema.

## Accesso

**Dalla finestra principale**: pulsante **"Setup"**

**Quando usarla**:
- Primo avvio del programma
- Cambio database o percorsi
- Accesso a funzioni di amministrazione
- Gestione classi, materie, periodi

---

## Sezione Percorsi (Paths)

### Percorso database (PathDatabase)
Cartella dove si trova il file database SQLite.
- **Campo testo**: mostra percorso corrente
- **Pulsante "..."**: apre browser cartelle per selezionarne una nuova
- **Doppio click**: apre la cartella in Esplora risorse

### File database (FileDatabase)
Nome del file database (es. "SchoolGrades.sqlite").
- **Campo testo**: mostra nome file corrente
- **Pulsante "Scegli file"**: apre dialog per selezionare file database diverso
- **Doppio click**: apre il file con programma predefinito (es. DB Browser)

**Importante**: cambiare file database permette di lavorare con database diversi (es. anni diversi, classi diverse)

### Percorso immagini (PathImages)
Cartella dove sono memorizzate foto studenti, immagini lezioni, ecc.
- **Pulsante "..."**: seleziona cartella
- **Doppio click**: apre la cartella

### Percorso documenti (PathDocuments)
Cartella per documenti generati (report, export, ecc.).
- **Pulsante "..."**: seleziona cartella
- **Doppio click**: apre la cartella

### Checkbox "Salva backup all'uscita"
Se spuntato, crea automaticamente copia backup del database quando si chiude il programma.
- File salvato in cartella logs con timestamp
- Utile per recupero in caso di problemi

---

## Pulsanti Gestione Dati

### Pulsante "Gestione classi"
Apre **frmClassesManagement** per:
- Creare/modificare/eliminare classi
- Gestire studenti delle classi
- Configurare proprietà classi (percorsi, collegamenti, ecc.)

**Uso principale**: organizzazione struttura scuola/classi

### Pulsante "Gestione materie"
Apre **frmSchoolSubjectManagement** per:
- Aggiungere/modificare materie insegnate
- Impostare colori identificativi per materia
- Ordinare materie

**Uso**: configurare materie prima di usare il programma

### Pulsante "Gestione anni e periodi"
Apre **frmSchoolYearAndPeriodsManagement** per:
- Creare nuovi anni scolastici
- Definire periodi (quadrimestri, trimestri)
- Configurare date inizio/fine periodi

**Uso**: setup inizio anno scolastico

### Pulsante "Gestione tabelle"
Apre **frmLookupTablesChoose** per modificare:
- Tipi di valutazione (orali, scritti, ecc.)
- Tipi di domanda
- Altre tabelle di configurazione

**Uso**: personalizzare tipi di dati nel sistema

### Pulsante "Gestione studenti"
Apre **frmStudent** in modalità ricerca/gestione per:
- Cercare studenti nel database
- Creare nuovi studenti
- Modificare dati anagrafici

**Uso**: amministrazione anagrafica studenti

---

## Pulsanti Gestione Contenuti

### Pulsante "Gestione argomenti"
Apre **frmTopics** in modalità completa per:
- Creare struttura gerarchica argomenti
- Modificare albero programma didattico
- Importare/esportare argomenti

**Uso**: definire programma didattico materie

### Pulsante "Gestione tag"
Apre **frmTag** per:
- Creare nuovi tag
- Modificare tag esistenti
- Organizzare sistema di categorizzazione domande

**Uso**: creare vocabolario tag per domande

### Pulsante "Gestione domande"
Apre **frmQuestionChoose** per:
- Visualizzare tutte le domande
- Cercare/filtrare domande
- Creare/modificare domande

**Uso**: gestione completa database domande

### Pulsante "Gestione test"
Apre **frmTestManagement** per:
- Creare verifiche scritte
- Gestire test strutturati
- Associare domande a test

**Uso**: preparazione verifiche (funzionalità avanzata)

### Pulsante "Gestione collegamenti"
Apre **frmStartLinksManagement** per:
- Configurare URL/file da aprire automaticamente
- Associare collegamenti a classi
- Gestire risorse esterne

**Uso**: automazione apertura risorse per lezioni

---

## Pulsanti Manutenzione

### Pulsante "Gestione backup"
Apre **frmBackupManagement** per:
- Creare backup manuale database
- Ripristinare backup precedenti
- Gestire copie di sicurezza

**Uso importante**: fare backup prima di operazioni rischiose

### Pulsante "Recupero argomenti"
Apre **frmTopicsRecover** per:
- Recuperare struttura argomenti da backup
- Importare argomenti da file
- Ricostruire albero argomenti

**Uso**: recupero dati in caso di problemi

### Pulsante "Resetta database"
**ATTENZIONE**: elimina TUTTI i dati nel database!
- Richiede conferma
- Irreversibile
- Usa solo per ricominciare da zero

**Quando usare**: solo per test o ripartire completamente

### Pulsante "Cancella file configurazione"
Elimina il file di configurazione e riavvia il programma.
- Utile se configurazione corrotta
- Richiede riconfigurazione completa dopo riavvio

---

## Pulsante "Salva configurazione"

**Funzione principale**: salva tutti i percorsi configurati nel file di configurazione.

**Procedura**:
1. Modificare percorsi desiderati
2. Selezionare/deselezionare checkbox
3. Fare click su **"Salva configurazione"**
4. Il programma:
   - Salva le impostazioni
   - Mostra messaggio "File di configurazione salvato"
   - **Riavvia automaticamente** per applicare modifiche

**Importante**: il riavvio è necessario per caricare nuovo database o percorsi

---

## Pulsante "Apri cartella configurazione"

Apre la cartella dove sono memorizzati:
- File di configurazione (.txt)
- Logs eventuali errori
- File temporanei del programma

**Uso**: debug, verifica configurazione, recupero informazioni

---

## Flussi di lavoro tipici

### Scenario 1: Primo avvio programma

**Obiettivo**: configurare il programma per la prima volta

1. Il programma apre automaticamente Setup al primo avvio
2. **Verificare/modificare**:
   - Percorso database (dove salvare dati)
   - File database (nome, es. "SchoolGrades_2024.sqlite")
   - Percorso immagini (dove salvare foto)
   - Percorso documenti (dove salvare export)
3. Fare click **"Salva configurazione"**
4. Il programma si riavvia
5. **Configurare dati di base**:
   - "Gestione anni e periodi" ? creare anno scolastico
   - "Gestione materie" ? aggiungere materie insegnate
   - "Gestione classi" ? creare classi
6. Chiudere Setup, iniziare a usare il programma

### Scenario 2: Cambiare database (es. nuovo anno)

**Obiettivo**: usare database diverso per nuovo anno scolastico

1. Aprire Setup
2. Fare click **"Scegli file"** per database
3. Selezionare nuovo file (es. "SchoolGrades_2024-25.sqlite")
4. Oppure: modificare **Percorso database** per cambiare cartella
5. Fare click **"Salva configurazione"**
6. Il programma si riavvia con nuovo database
7. Se database nuovo/vuoto, configurare come Scenario 1

### Scenario 3: Backup prima di operazione rischiosa

**Obiettivo**: creare copia sicurezza prima di modifiche importanti

1. Aprire Setup
2. Fare click **"Gestione backup"**
3. Creare backup manuale con timestamp
4. Chiudere gestione backup
5. Procedere con operazione rischiosa
6. In caso di problemi, usare "Gestione backup" per ripristinare

### Scenario 4: Configurare nuova materia

**Obiettivo**: aggiungere materia non presente

1. Aprire Setup
2. Fare click **"Gestione materie"**
3. Aggiungere nuova materia (nome, colore)
4. Chiudere gestione materie
5. Fare click **"Gestione argomenti"**
6. Creare struttura argomenti per la nuova materia
7. Chiudere Setup, materia disponibile

---

## Suggerimenti e best practices

### Organizzazione percorsi
- **Database**: cartella dedicata, facile da trovare e backuppare
- **Immagini**: cartella capiente (le foto occupano spazio)
- **Documenti**: separata da database per gestione indipendente

### Backup regolari
- Abilitare "Salva backup all'uscita" per sicurezza automatica
- Fare backup manuale prima di:
  - Aggiornamenti programma
  - Modifiche massive (es. eliminazione classi)
  - Fine anno scolastico

### Gestione multi-anno
- **Opzione A**: database separato per anno (es. "SG_2023.sqlite", "SG_2024.sqlite")
  - Pro: file più piccoli, meno confusione
  - Contro: bisogna cambiare database, dati separati
- **Opzione B**: un database per tutti gli anni
  - Pro: storico completo, confronti facili
  - Contro: file grande, più lento nel tempo

### Configurazione classi e materie
- Configurare tutto prima di iniziare a usare il programma
- Modifiche successive possibili ma meno comode

---

## Troubleshooting

### Il programma non si avvia dopo "Salva configurazione"

**Problema**: dopo salvataggio, il programma non riparte

**Soluzioni**:
- Verificare che percorso database sia valido
- Controllare che file database esista nel percorso
- Se persistente, eliminare file configurazione manualmente e ripartire

### Non trovo il file di configurazione

**Problema**: serve modificare configurazione ma non si trova il file

**Soluzioni**:
- Fare click **"Apri cartella configurazione"** da Setup
- Cercare file .txt nella cartella

### Doppio click su percorsi non apre cartelle

**Problema**: doppio click su campi percorso non fa nulla

**Soluzioni**:
- Verificare che percorso sia valido (esista)
- Aprire manualmente da Esplora risorse
- Percorsi errati potrebbero causare errori

### Gestione classi/materie bloccata

**Problema**: non si riesce a modificare classi o materie

**Soluzioni**:
- Verificare permessi scrittura database
- Chiudere altre finestre che potrebbero bloccare
- Verificare che database non sia aperto da altro programma (es. DB Browser)

---

## Sicurezza e best practices

### Percorsi sicuri
- **Non** usare percorsi di rete se non necessario (lentezza)
- Evitare cartelle sincronizzate (Dropbox, OneDrive) durante uso (conflitti)
- Permessi scrittura necessari su tutte le cartelle

### Protezione dati
- Database contiene dati sensibili (studenti)
- Backuppare regolarmente in luogo sicuro
- Non condividere database senza anonimizzare

### Prestazioni
- Database grandi (>100MB) possono rallentare
- Considerare divisione per anno se troppo grande
- Immagini: ottimizzare dimensioni (non serve alta risoluzione)

---

## Limitazioni note

- **Riavvio obbligatorio**: ogni modifica configurazione richiede restart
- **Un database alla volta**: non si possono usare contemporaneamente database diversi
- **Modifica percorsi**: riavvio chiude tutte le finestre, salvare lavori in corso

---

*Questa documentazione fa parte del Manuale Utente di SchoolGrades*
