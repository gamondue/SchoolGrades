# Finestra Setup - Manuale Utente

## Introduzione

La finestra **Setup** è il pannello centrale di configurazione di SchoolGrades. Permette di configurare percorsi, gestire database, accedere a tutte le finestre di amministrazione e manutenzione del sistema.

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
- **Pulsante ".."**: apre browser cartelle per selezionarne una nuova
- **Doppio click**: apre la cartella in Esplora risorse

### File database (FileDatabase)
Nome del file database (es. "SchoolGrades.sqlite").
- **Campo testo**: mostra nome file corrente
- **Pulsante ".."**: apre dialog per selezionare file database diverso
- **Doppio click**: apre il file con programma predefinito (es. Sqlite Studio)

**Importante**: cambiare file database permette di lavorare con database diversi (es. insegnanti o scuole diverse)

### Percorso immagini (PathImages)
Cartella dove sono memorizzate foto studenti, immagini lezioni, ecc.
- **Pulsante ".."**: seleziona cartella
- **Doppio click**: apre la cartella

### Percorso documenti (PathDocuments)
Cartella per documenti generati (report, export, ecc.).
- **Pulsante ".."**: seleziona cartella
- **Doppio click**: apre la cartella

Attualmente il programma non usa questa cartella.

### Checkbox "Salva backup all'uscita"
Se spuntato, crea automaticamente copia backup del database quando si chiude il programma.
- File salvato in cartella logs con timestamp
- Utile per recupero in caso di problemi, abilitatelo quando provate nuove versioni

---

## Pulsanti Gestione Dati

### Pulsante "Gestione classi"
Apre la finestra che permette di gestire le classi per:
- Creare/modificare/eliminare classi
- Gestire studenti delle classi e le loro foto
- Configurare proprietà classi (percorsi, collegamenti, ecc.)

**Uso principale**: organizzazione struttura scuola/classi

### Pulsante "Gestione materie"
Apre la finestra per la configurazione delle materie scolastiche:
- Aggiungere/modificare materie insegnate
- Impostare colori identificativi per materia
- Ordinare materie

**ATTENZIONE**: per poter usare efficemente il programma è necessario che ci siano delle materie configurate

### Pulsante "Gestione periodi"
Apre la finestra per:
- Definire periodi (quadrimestri, trimestri)
  - Configurare date inizio/fine periodi

**Uso**: setup inizio anno scolastico

### Pulsante "Gestione tabelle"
Apre la finestra che permette di modificare le tabelle per i diversi tipi di dati "fissi" del programma, come:
- Tipi di valutazione (orali, scritti, ecc.)
- Tipi di domanda
- Altre tabelle di configurazione

**Uso**: personalizzare tipi di dati nel sistema

### Pulsante "Gestione studenti"
Apre la finestra di gestione degli studenti, in modalità ricerca/gestione per:
- Cercare studenti nel database
- Creare nuovi studenti
- Modificarne dati anagrafici (NON le foto, che sono relative ad ogni classe)

**Uso**: amministrazione anagrafica studenti

---

## Pulsanti Gestione Contenuti

### Pulsante "Gestione argomenti"
Apre una pagina con l'albero degli argomanti, in modalità completa per:
- Creare nuovi argomenti
- Modificare argomenti esistenti
- Creare struttura gerarchica argomenti
- Modificare albero di tutti gli argomenti trattati in ogno materia
- Importare/esportare argomenti

**Uso**: definire gli argomenti didattici delle varie materie

### Pulsante "Gestione tag"
Apre la finestra di gestione dei Tag da associare alle domande (?? ed agli argomenti ??):
- Creare nuovi tag
- Modificare tag esistenti
- Organizzare sistema di categorizzazione domande

**ATTENZIONE**: la funzionalità è implementata e dovrebbe funzionare, ma non è garantita, perchè sono molti anni che non la uso!

**Uso**: creare vocabolario tag per domande (? e argomenti ?)

### Pulsante "Gestione domande"
Apre la finestra che gestisce le domande da fare agli allievi, per:
- Visualizzare tutte le domande
- Cercare/filtrare domande
- Creare/modificare domande
- Scegliere la domanda da fare (quando chiamata da una finestra che richiede una domanda)

**Uso**: gestione completa database domande

### Pulsante "Gestione test"
Apre la finestra di dei test (questionari, prove scritte ..), per:
- Creare verifiche scritte
- Gestire test strutturati
- Associare domande a test

**ATTENZIONE**: questa funzionalità è **INCOMPLETA E MALFUNZIONANTE** non c'è da fidarsi! Se qualcuno la vuole aggiustare lo faccia (poi PULL REQUEST!). Le idee ci sono ma non sono finite, se non si capisce cosa fare, chiedere a me.

**Uso**: preparazione verifiche (funzionalità incompleta)

### Pulsante "Gestione collegamenti"
Apre la gestioen dei collegamenti "operativi" per:
- Configurare URL/file da aprire automaticamente
- Associare collegamenti a classi

**Uso**: automazione apertura risorse per lezioni, legare a ciascuna classe

---

## Pulsanti Manutenzione

### Pulsante "Backup e gen.file"
Apre per il backup :
- Creare backup manuale database (copia il file di database con un timestamp iniziale nel nome del file)
- Ripristinare backup precedenti
- Creare un database da distribuire ad una classe, nel quale vengono rimosse automaticamente tutte le informazioni che non pertengono strettamente a quella classe (studenti, voti, ecc.)
- Creare un database demo, con dati "farloccati" a partire da dati reali

**Uso importante**: fare backup prima di operazioni rischiose

**ATTENZIONE**: alcune di queste funzionalità non sono usate da parecchio tempo (in particolare quelle nei bottoni in alto), per cui potrebbero essersi rotte; vanno usate con cautela.  
Provare i ripristini solo su database di prova, non sul database "di produzione"!

### Pulsante "Recover argomenti" (Recupero argomenti)
Apre una finestra che contronta gli alberi degli argomenti contenuti in due file, per:
- Cercare e recuperare argomenti che sono in un albero, ma si sono persi in un altro
- Copiare argomenti da un albero ad un altro (PERICOLO)
- Visualizzare differenze tra alberi argomenti

Le differenze sono mostrate con colori diversi dei nodi dei due alberi. I colori dovrebbero funzionare secondo la legenda che si vede nella finestra, ma bisognerebbe provare con il debugger..

**Uso**: recupero dati in caso di problemi

**ATTENZIONE**: fare il backiup del database PRIMA di salvare in questa finestra!

**ATTENZIONE**: questa funzionalità è assolutamente **SPERIMENTALE** e potrebbe non funzionare come previsto. Usatela con cautela e salvate solo dopo aver guardato il codice e capito che funziona!

### Pulsante "Resetta database"
**ATTENZIONE**: elimina TUTTI i dati nel database!
- Richiede conferma
- Irreversibile
- Usa solo per ricominciare da zero

**Quando usare**: solo per test o ripartire completamente dopo aver fatto molti errori all'inizio dell'uso del programma

### Pulsante "Cancella config."
Elimina i file di configurazione del programma e lo riavvia.
- Utile se la configurazione è corrotta
- Richiede riconfigurazione dopo il riavvio

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
   - **Riavvia automaticamente** per applicare modifiche in modo controllato

**Importante**: il riavvio è proferibile per caricare un nuovo database o nuovi percorsi, per cui viene forzato dal programma.

---

## Pulsante "Cartella config."

Apre la cartella dei dati di configurazione, dove sono memorizzati:
- nella cartella Config: file di configurazione (schgrd.cfg (SchoolGrades.configure))
- nella cartella Config: file di configurazione per debug (schgrd_DEBUG.cfg). Usata dal programma solo quando funziona in modalità debug. Gli utenti finali non sviluppatori non dovrebbero avere questa cartella.
- nella cartella Logs (che sta "sopra" a Config): file gamon-Errori.txt, il log degli errori del programma
- nella cartella Logs: file di tipo frm*_parameters.txt, che il programma usa per salvare i parametri usati nella finestra l'ultima volta che è stata chiusa

**Uso**: debug, verifica configurazione, recupero informazioni di errore

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
   - "Gestione classi" ? creare classi, ma aanche anni scolatici (a partire dalle classi dell'anno precedente)
   - "Gestione periodi" ? creare un periodo (es. primo quadrimestre)
   - "Gestione materie" ? aggiungere materie insegnate

6. Chiudere Setup, iniziare a usare il programma

### Scenario 2: Cambiare database (es. nuovo anno o scuola)

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
  - Contro: file grande, più lento nel'esecuzione

Personalmente, io uso l'opzione B.

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

[Pagina principale](Manuale-Utente-SchoolGrades.md)
---

*Questa documentazione fa parte del Manuale Utente di SchoolGrades*
