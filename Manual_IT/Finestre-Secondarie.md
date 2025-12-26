# Finestre Secondarie e Specializzate - Manuale Utente

Questa guida documenta le finestre secondarie e specializzate di SchoolGrades, organizzate per categoria funzionale.

---
**ATTENZIONE: QUESTO FILE E' PRELIMINARE E NON REVISIONATO.  
POTREBBE CONTENERE INFORMAZIONI NON ESATTE**  
Comunica con un ticket su GiHub eventuali errori riscontrati.

## GESTIONE CLASSI E ORGANIZZAZIONE

**Funzione**: gestione completa delle classi (creazione, modifica, studenti, proprietà, cancellazione).

**Accesso**: Setup -> "Gestione classi"

**Interfaccia**:
- Lista anni e lista classi (sinistra): selezionare anno e classe da gestire
- Dettagli classe (centro): dati della classe selezionata
- Lista studenti (destra): studenti nella classe
- Pulsanti: Aggiungi, Rimuovi, Salva, Nuovo

**Funzionalità**:
- **Creazione "manuale" classi**: 
	- specificare anno scolastico, sigla, denominazione, scrivendo direttamente nei combo e nelle caselle di testo
	- premere il bottone "Crea nuova classe"
	- aggiungere studenti
- **Creazione automatica classi**: 
- !!!! TODO COMPLETARE !!!!
 
- **Aggiunta studenti**: associare studenti esistenti o crearne nuovi
	- bottone "Nuovo allievo"
	- si apre la finestra "studente" nella quale si potrà ricercare e scegliere uno studente già esistente, oppure fare un nuovo studente
- **Rimozione studenti**: il bottone "Elimina allievo" toglie uno studente dalla classe
- **Modifica studente**: il bottone "Modifica allievo" apre la finestra con i dati dello studente da modificare
- **Gestione della foto dell'allievo**: 
- **Cancellazione classe**: il bottone "Elimina classe" rimuove la classe selezionata (dopo conferma)

- 
- **Percorsi personalizzati**: configurare cartelle specifiche per classe
- **Collegamenti (Start Links)**: URL/file da aprire per la classe
- **Proprietà classe**: note, configurazioni speciali

**Workflow tipico - Creare nuova classe**:

**!!!! TODO REVISIONARE QUESTA PROCEDURA !!!!**

1. Click "Nuova classe"
2. Inserire anno scolastico (es. "2024-25")
3. Inserire sigla (es. "4F")
4. Inserire denominazione completa
5. Click "Salva"
6. Aggiungere studenti con "Aggiungi studente"
7. Chiudere finestra

**Suggerimenti**:
- Creare tutte le classi all'inizio dell'anno
- Usare nomenclatura coerente per sigle
- Configurare percorsi personalizzati se ogni classe ha cartelle proprie

---

### frmSchoolYearAndPeriodsManagement - Gestione Anni e Periodi

**Funzione**: configurazione anni scolastici e periodi di valutazione.

**Accesso**: Setup ? "Gestione anni e periodi"

**Funzionalità**:
- **Anni scolastici**: creare/modificare anni (es. "2024-25")
- **Periodi valutazione**: definire quadrimestri, trimestri
- **Date periodi**: impostare inizio/fine ogni periodo
- **Tipi periodo**: "P" (parziale/quadrimestre), "F" (finale), "N" (non standard)

**Interfaccia**:
- Lista anni scolastici (sinistra)
- Lista periodi dell'anno selezionato (centro)
- Dettagli periodo (destra): date, tipo, descrizione

**Workflow - Configurare nuovo anno**:
1. Click "Nuovo anno"
2. Inserire codice (es. "24-25")
3. Inserire descrizione (es. "Anno scolastico 2024-2025")
4. Salvare
5. Selezionare anno creato
6. Aggiungere periodi:
   - 1° Quadrimestre: date 01/09/2024 - 31/01/2025
   - 2° Quadrimestre: date 01/02/2025 - 10/06/2025
7. Salvare periodi

**Importante**: i periodi sono usati in tutta l'applicazione per filtrare voti e lezioni.

---

### frmSchoolSubjectManagement - Gestione Materie

**Funzione**: configurazione materie insegnate e loro proprietà visive.

**Accesso**: Setup ? "Gestione materie"

**Funzionalità**:
- Creare/modificare/eliminare materie
- Assegnare codice identificativo (es. "MAT", "ITA")
- Assegnare nome completo (es. "Matematica")
- **Scegliere colore**: ogni materia ha un colore che identifica le finestre
- Ordinare materie nella lista

**Interfaccia**:
- Lista materie esistenti
- Campi: Codice, Nome, Colore
- Pulsanti: Nuovo, Salva, Elimina
- Selettore colore (ColorDialog)

**Workflow - Aggiungere materia**:
1. Click "Nuova materia"
2. Codice: "FIS"
3. Nome: "Fisica"
4. Click su quadrato colore ? selezionare colore (es. azzurro)
5. Salvare

**Uso colori**: ogni finestra cambia colore di sfondo in base alla materia selezionata, facilitando riconoscimento visivo.

---

## ANNOTAZIONI E COMMENTI

### frmAnnotationsAboutStudents - Annotazioni Studenti

**Funzione**: inserire annotazioni/note su uno o più studenti.

**Accesso**: Finestra principale ? "Annotaz." (con studenti selezionati)

**Funzionalità**:
- Annotazione singola o multipla (più studenti contemporaneamente)
- Testo libero dell'annotazione
- Checkbox "Attiva": se annotazione è ancora rilevante
- Checkbox "Popup": se mostrare in popup all'apertura classe
- Data automatica inserimento

**Interfaccia**:
- Lista studenti selezionati (non modificabile)
- Campo testo annotazione (multi-riga)
- Checkbox: Attiva, Popup
- Pulsanti: Salva, Annulla

**Workflow - Annotazione comportamento**:
1. Nella finestra principale, spuntare studenti coinvolti
2. Click "Annotaz."
3. Testo: "Disturbo durante lezione. Richiamato."
4. Spuntare "Attiva"
5. Spuntare "Popup" se serve ricordare
6. Salvare

**Tipi annotazioni comuni**:
- Comportamento (positivo/negativo)
- Assenze prolungate
- Situazioni familiari rilevanti
- Progressi/regressioni
- Colloqui con genitori

**Visualizzazione**: le annotazioni appaiono in "Riepilogo Voti Allievo" e in popup all'apertura classe.

---

### frmAnnotationsPopUp - Popup Annotazioni

**Funzione**: mostra annotazioni "popup" all'apertura di una classe.

**Accesso**: automatico quando si apre classe con annotazioni popup attive

**Funzionalità**:
- Visualizza tutte le annotazioni marcate "popup" per studenti della classe
- Formato tabella: studente, data, testo annotazione
- Pulsante "OK" per chiudere e procedere

**Uso**: promemoria automatico di situazioni importanti da ricordare all'inizio della lezione.

---

## TAG E CATEGORIZZAZIONE

### frmTag - Gestione Tag

**Funzione**: creare e gestire tag per categorizzare domande.

**Accesso**: 
- Setup ? "Gestione tag" (gestione completa)
- Finestre domande ? "Aggiungi tag" (selezione rapida)

**Modalità**:
- **Gestione completa**: vedere tutti i tag, creare, modificare, eliminare
- **Selezione**: scegliere tag esistente per associarlo

**Funzionalità**:
- Creare nuovo tag (nome univoco)
- Modificare nome tag esistente
- Eliminare tag (non elimina associazioni esistenti)
- Vedere numero domande associate per tag

**Interfaccia**:
- Lista tag esistenti
- Campo nome tag
- Pulsanti: Nuovo, Salva, Elimina, Scegli (solo in modalità selezione)

**Workflow - Creare sistema tag**:
1. Aprire gestione tag
2. Creare tag per **difficoltà**: "facile", "media", "difficile"
3. Creare tag per **tipo cognitivo**: "conoscenza", "comprensione", "applicazione"
4. Creare tag per **importanza**: "fondamentale", "complementare"
5. Creare tag per **modalità**: "teoria", "esercizio", "problema"

**Suggerimenti**:
- Sistema tag coerente e pianificato
- Non troppi tag (10-20 sufficienti)
- Tag descrittivi e univoci
- Preferire tag generali a specifici

---

## VISUALIZZAZIONE E UTILITÀ

### frmMosaic - Mosaico Foto Classe

**Funzione**: visualizzare tutte le foto degli studenti di una classe in griglia.

**Accesso**: Finestra principale ? "Mosaico"

**Funzionalità**:
- Griglia automatica con foto studenti
- Nome sotto ogni foto
- Click su foto: evidenzia studente
- Utile per riconoscimento rapido, appello visivo

**Interfaccia**:
- Griglia foto (dimensione automatica in base a numero studenti)
- Nomi studenti sotto foto
- Finestra ingrandibile

**Uso tipico**:
- Appello visivo (spuntare presenti)
- Riconoscimento studenti ad inizio anno
- Stampa per registro cartaceo
- Visualizzazione durante riunioni/colloqui

---

### frmRandom - Generatore Numeri Casuali

**Funzione**: generare numero casuale in un intervallo.

**Accesso**: Finestra principale ? "Numero casuale"

**Funzionalità**:
- Specificare min e max
- Generare numero casuale nell'intervallo
- Ripetere estrazioni
- Storico numeri estratti (opzionale)

**Interfaccia**:
- Campo Min (numero minimo)
- Campo Max (numero massimo)
- Pulsante "Genera"
- Display numero estratto (grande, visibile)

**Uso tipico**:
- Estrarre numero compito/esercizio
- Sorteggio ordine presentazioni
- Scelta casuale da elenco numerato
- Giochi didattici con casualità

---

### frmColorTimer - Timer a Colori

**Funzione**: timer visivo che cambia colore con lo scorrere del tempo.

**Accesso**: 
- Finestra principale ? "T.colori"
- Con tempo preimpostato (es. 5, 10, 15 minuti)

**Funzionalità**:
- Countdown da tempo impostato a 0
- Cambio graduale colore: verde ? giallo ? arancione ? rosso
- Display digitale tempo rimanente
- Opzione effetti sonori (beep a intervalli, allarme finale)
- Finestra sempre in primo piano

**Interfaccia**:
- Display tempo grande e leggibile
- Sfondo colorato (tutto lo schermo cambia colore)
- Pulsanti: Avvia, Pausa, Reset
- Checkbox: Suoni

**Uso tipico**:
- Tempo risposta studente (5-10 min)
- Esercizi a tempo
- Lavori di gruppo con deadline
- Gestione tempo lezione/attività

**Effetti sonori**:
- Beep ogni minuto (opzionale)
- Beep più frequenti ultimi 30 secondi
- Allarme sonoro a tempo scaduto

---

## DETTAGLI E APPROFONDIMENTI

### frmGrade - Dettaglio Singolo Voto

**Funzione**: visualizzare tutti i dettagli di un singolo voto (micro o macro).

**Accesso**: doppio click su voto in griglie voti

**Funzionalità**:
- Mostra: studente, data, valore, peso, tipo valutazione
- Mostra domanda associata (se presente)
- Mostra testo risposta studente
- Mostra commenti insegnante
- Collegamenti a microvalutazioni (se macrovalutazione)

**Interfaccia**:
- Sola visualizzazione (read-only) generalmente
- Campi: tutti i dati del voto
- Pulsante: Chiudi

**Uso**: consultazione dettagliata voto per chiarimenti, contestazioni, documentazione.

---

### frmAnswer - Gestione Risposta

**Funzione**: creare/modificare risposta per domanda a scelta multipla.

**Accesso**: 
- frmQuestion ? "Aggiungi risposta"
- Doppio click su risposta esistente

**Funzionalità**:
- Testo risposta
- Checkbox "Corretta": se è la risposta giusta
- Salva e associa a domanda

**Workflow - Domanda 4 risposte**:
1. Creare domanda a scelta multipla
2. "Aggiungi risposta" ? Testo: "Opzione A: ..." ? Corretta: No ? Salva
3. "Aggiungi risposta" ? Testo: "Opzione B: ..." ? Corretta: Sì ? Salva
4. Ripetere per C e D

---

### frmTopicChooseByPeriod - Scelta Argomento per Periodo

**Funzione**: scegliere argomento tra quelli effettivamente svolti in un periodo.

**Accesso**: frmQuestionChoose ? "Argomento per periodo"

**Funzionalità**:
- Selezionare periodo temporale (date o periodo predefinito)
- Mostra solo argomenti svolti con la classe in quel periodo
- Evidenziazione colorata per frequenza
- Selezione argomento e conferma

**Uso**: creare domande su argomenti recenti, interrogazioni su programma svolto.

---

### frmKnotsToTheComb - Nodi al Pettine

**Funzione**: identificare argomenti/domande problematiche per uno studente.

**Accesso**: frmQuestionChoose ? "Nodi al pettine"

**Funzionalità**:
- Analizza voti studente per argomento
- Identifica argomenti con voti bassi ripetuti
- Mostra domande sbagliate più volte
- Suggerisce domande per recupero mirato

**Interfaccia**:
- Lista argomenti problematici (ordinati per gravità)
- Lista domande sbagliate
- Pulsante: Scegli domanda (per interrogazione recupero)

**Uso**: interrogazioni mirate di recupero, identificazione lacune.

---

## MANUTENZIONE E AMMINISTRAZIONE

### frmBackupManagement - Gestione Backup

**Funzione**: creare e ripristinare backup del database.

**Accesso**: Setup ? "Gestione backup"

**Funzionalità**:
- **Creare backup manuale**: copia database con timestamp
- **Elencare backup**: tutti i backup disponibili con date
- **Ripristinare backup**: sostituire database corrente con backup
- **Eliminare backup**: rimuovere backup vecchi

**Interfaccia**:
- Lista backup esistenti (con data/ora)
- Pulsanti: Crea backup, Ripristina selezionato, Elimina

**Workflow - Backup e ripristino**:
1. Prima di operazione rischiosa: "Crea backup"
2. Inserire descrizione opzionale
3. Backup creato con nome timestampato
4. Eseguire operazione
5. Se problemi: selezionare backup ? "Ripristina"
6. Confermare ripristino (sovrascrive database corrente)
7. Riavviare programma

**IMPORTANTE**: backup è copia completa database, può essere molto grande (50-500 MB).

---

### frmImages - Gestione Immagini Lezione

**Funzione**: associare immagini a una lezione.

**Accesso**: frmLessons ? "Gestione immagini"

**Funzionalità**:
- Aggiungere immagini da file system
- Rimuovere immagini dalla lezione
- Riordinare immagini
- Anteprima immagini

**Interfaccia**:
- Lista immagini associate alla lezione
- Anteprima immagine selezionata
- Pulsanti: Aggiungi, Rimuovi, Su, Giù

**Workflow - Aggiungere foto lavagna**:
1. Aprire finestra lezioni
2. Selezionare/creare lezione
3. "Gestione immagini"
4. "Aggiungi" ? selezionare file foto
5. Ripetere per altre foto
6. Ordinare se necessario (su/giù)
7. Salvare

**Formati supportati**: JPG, PNG, BMP, GIF

---

### frmLookupTablesChoose - Scelta Tabelle Lookup

**Funzione**: selezionare quale tabella di configurazione modificare.

**Accesso**: Setup ? "Gestione tabelle"

**Funzionalità**:
- Lista di tutte le tabelle configurabili:
  - Tipi valutazione (GradeTypes)
  - Tipi domanda (QuestionTypes)
  - Tipi periodo (PeriodTypes)
  - Altri lookup
- Selezionare tabella ? apre frmLookupTableEdit

**Uso**: accesso centralizzato a tutte le tabelle di configurazione.

---

### frmLookupTableEdit - Modifica Tabella Lookup

**Funzione**: modificare contenuti tabella di configurazione selezionata.

**Accesso**: frmLookupTablesChoose ? selezionare tabella

**Funzionalità**:
- Visualizzare record tabella
- Aggiungere nuovo record
- Modificare record esistente
- Eliminare record (se non usato)

**Interfaccia**:
- Griglia con record tabella
- Campi specifici per tipo tabella
- Pulsanti: Nuovo, Salva, Elimina

**Esempio - Aggiungere tipo valutazione**:
1. Setup ? Gestione tabelle ? GradeTypes
2. "Nuovo"
3. Codice: "PRAT"
4. Nome: "Pratico"
5. Peso default: 2
6. Salvare

---

### frmStartLinksManagement - Gestione Collegamenti Avvio

**Funzione**: configurare URL/file da aprire automaticamente per una classe.

**Accesso**: Setup ? "Gestione collegamenti" o frmClassesManagement ? Start Links

**Funzionalità**:
- Aggiungere URL (es. registro elettronico classe)
- Aggiungere percorsi file/cartelle
- Ordinare collegamenti
- Test apertura collegamenti

**Interfaccia**:
- Classe selezionata
- Lista collegamenti della classe
- Campo nuovo collegamento
- Pulsanti: Aggiungi, Rimuovi, Test

**Esempio - Collegamenti classe 4F**:
- https://registro.scuola.it/classe/4F
- C:\Materiali\4F\ProgrammaAnno.pdf
- C:\Materiali\4F\Cartella_Condivisa

**Uso**: click "Start Links" in finestra principale o lezioni apre tutti i collegamenti della classe automaticamente.

---

### frmTopicsRecover - Recupero Argomenti

**Funzione**: recuperare/importare struttura argomenti da backup o file.

**Accesso**: Setup ? "Recupero argomenti"

**Funzionalità**:
- Importare struttura argomenti da:
  - Backup database
  - File esterno (XML, JSON)
  - Database diverso
- Opzioni:
  - Sovrascrivere argomenti esistenti
  - Integrare (aggiungere senza cancellare)
- Preview prima di importare

**Uso**: 
- Recupero dopo perdita dati
- Import struttura da collega
- Sincronizzazione tra database

---

### frmNewYear - Nuovo Anno Scolastico

**Funzione**: wizard per configurare nuovo anno scolastico.

**Accesso**: Setup (in sviluppo/avanzato)

**Funzionalità**:
- Creare nuovo anno
- Copiare struttura anno precedente (classi, materie)
- Promuovere studenti (es. 3F ? 4F)
- Configurare periodi nuovo anno

**Stato**: funzionalità in sviluppo, usare configurazione manuale per ora.

---

## RIEPILOGO ACCESSI RAPIDI

### Da Finestra Principale
- **Mosaico**: bottone diretto
- **Numero casuale**: bottone diretto
- **Timer colori**: bottone "T.colori"
- **Annotazioni**: selezionare studenti + "Annotaz."

### Da Setup
- **Classi**: Gestione classi
- **Materie**: Gestione materie
- **Anni/Periodi**: Gestione anni e periodi
- **Tabelle**: Gestione tabelle ? scegliere
- **Backup**: Gestione backup
- **Tag**: Gestione tag
- **Collegamenti**: Gestione collegamenti

### Da Altre Finestre
- **Dettaglio voto**: doppio click su voto in griglie
- **Risposta**: da finestra domanda
- **Argomento per periodo**: da scelta domanda
- **Nodi al pettine**: da scelta domanda
- **Immagini**: da finestra lezioni

[Pagina principale](Manuale-Utente-SchoolGrades.md)
---

*Questa documentazione fa parte del Manuale Utente di SchoolGrades*
