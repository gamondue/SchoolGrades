# Finestra Lezioni - Manuale Utente

## Introduzione

La finestra **Lezioni** (frmLessons) è il registro digitale dove vengono registrate le lezioni svolte con ogni classe. Permette di documentare data, argomenti trattati, note e immagini mostrate durante la lezione, creando uno storico completo dell'attività didattica.

## Accesso alla finestra

**Dalla finestra principale**:
- Selezionare una classe
- Selezionare una materia
- Fare click sul pulsante **"Lezioni"**

**Contesto**: la finestra si apre per la classe e materia selezionate.

**Modalità sola lettura**: se si aprono più finestre Lezioni contemporaneamente, quelle dopo la prima si aprono in sola lettura per evitare conflitti.

---

## Interfaccia della finestra

### Area superiore: Informazioni contesto

- **Anno scolastico**: visualizza l'anno della classe
- **Classe**: sigla della classe (es. "4F")
- **Materia**: nome della materia corrente (determina anche il colore di sfondo della finestra)

### Sezione sinistra: Lezioni registrate

#### Griglia tutte le lezioni (dgwAllLessons)

Mostra l'elenco completo di tutte le lezioni registrate per la classe e materia correnti.

**Colonne visibili**:
- **Date**: data della lezione
- **Note**: descrizione/sommario della lezione

**Colonne nascoste**: IdLesson, IdClass, IdSchoolSubject, IdSchoolYear

**Interazione**:
- **Click su una riga**: seleziona la lezione, i suoi dettagli appaiono a destra
- **Navigazione con frecce**: spostarsi tra le lezioni
- La lezione selezionata viene caricata per modifica/visualizzazione

#### Griglia argomenti della lezione (dgwOneLesson)

Mostra gli argomenti specifici trattati nella lezione selezionata.

**Colonne visibili**:
- **Name**: nome dell'argomento
- **Description**: descrizione dell'argomento

**Interazione**:
- **Click su un argomento**: il corrispondente nodo viene evidenziato nell'albero degli argomenti

---

### Sezione centrale: Dettagli lezione corrente

#### Codice lezione
Campo di testo che mostra l'IdLesson della lezione corrente.
- Utile per riferimenti tecnici

#### Data lezione
DateTimePicker per selezionare la data della lezione.
- **Predefinito**: data odierna
- **Modificabile**: per registrare lezioni passate

#### Note/Descrizione lezione (TxtLessonDesc)
Campo di testo multi-riga per descrivere la lezione.

**Cosa scrivere**:
- Sommario degli argomenti trattati
- Attività svolte (esercizi, laboratorio, video)
- Eventuali compiti assegnati
- Note su assenze/eventi particolari

**Suggerimento**: questo campo può essere copiato per il registro elettronico

### Sezione destra: Albero argomenti

#### TreeView argomenti

Struttura gerarchica degli argomenti del programma didattico.

**Funzione principale**: selezionare gli argomenti effettivamente trattati nella lezione spuntandoli.

**Interazione**:
- **Checkbox**: spuntare gli argomenti trattati
- **Espansione nodi**: click su freccia o doppio click per espandere/contrarre
- **Selezione**: click singolo seleziona un argomento e ne mostra i dettagli

**Evidenziazione**:
- Gli argomenti già svolti precedentemente possono essere evidenziati con colori

#### Dettagli argomento selezionato

Tre campi mostrano informazioni sull'argomento selezionato nell'albero:
- **Nome argomento**: titolo breve
- **Descrizione**: dettagli estesi
- **Codice**: identificativo univoco

**Modifica argomenti**: possibile aggiungere, modificare, eliminare argomenti direttamente da questa finestra (se non in modalità sola lettura)

#### Campo "Riepilogo argomenti" (txtTopicsDigest)

Genera automaticamente un elenco testuale degli argomenti spuntati, utile per:
- Copia rapida nel registro elettronico
- Riepilogo visivo di cosa è stato fatto
- Ricerca testuale tra le lezioni

---

### Sezione immagini (in basso a destra)

#### PictureBox immagine
Mostra un'anteprima delle immagini associate alla lezione (foto della lavagna, slide, diagrammi).

**Navigazione**:
- **Pulsante ">>" (Successiva)**: mostra immagine successiva
- **Pulsante "<<" (Precedente)**: mostra immagine precedente
- **Tasti freccia destra/sinistra**: stessa funzione dei pulsanti

**Interazione**:
- **Doppio click sull'immagine**: apre il file immagine con il programma predefinito (visualizzazione full-screen)

#### Pulsante "Gestione immagini"
Apre la finestra dedicata per:
- Aggiungere nuove immagini alla lezione
- Rimuovere immagini
- Riordinare immagini
- Associare immagini esistenti

#### Pulsante "Cartella immagini"
Apre direttamente la cartella nel file system dove sono memorizzate le immagini della lezione.
- Utile per aggiungere file manualmente o verificare cosa c'è

---

## Pulsanti di azione principali

### Pulsante "Nuova lezione"

**Funzione**: crea una nuova lezione per la classe e materia correnti.

**Procedura**:
1. Fare click su "Nuova lezione"
2. Appare messaggio di conferma: "Creare una nuova lezione nella data di oggi (Sì) \n Non salvare nulla (No)"
3. Confermare con **Sì**
4. Viene creata una nuova lezione con:
   - Data: oggi (o data impostata nel DatePicker)
   - Classe e materia correnti
   - IdLesson univoco
5. I campi si svuotano per l'inserimento
6. Albero argomenti si deseleziona (nessun argomento spuntato)

**Validazione**: 
- Non si possono creare due lezioni con la stessa data per la stessa classe/materia
- Se già esiste, appare avviso: "Il programma non registra due lezioni diverse nello stesso giorno"

**Data diversa**: se si cambia la data prima di fare click, viene chiesta conferma per creare in quella data

### Pulsante "Salva lezione"

**Funzione**: salva tutti i dati della lezione corrente (descrizione, argomenti, immagini).

**Procedura**:
1. Compilare descrizione lezione
2. Spuntare gli argomenti trattati nell'albero
3. Fare click su "Salva lezione"
4. Se ci sono modifiche agli argomenti nell'albero, vengono salvate
5. La descrizione viene salvata
6. Gli argomenti spuntati vengono associati alla lezione
7. Le griglie si aggiornano

**Validazioni**:
- Deve esistere una lezione (campo "Codice lezione" non vuoto)
- Se la data non è oggi, viene chiesta conferma
- Se gli argomenti nell'albero sono stati modificati, viene chiesto se salvare

**Effetto**: la lezione è registrata e contribuisce allo storico; gli argomenti risulteranno "svolti"

### Pulsante "Cancella lezione"

**Funzione**: elimina la lezione corrente dal database.

**Procedura**:
1. Selezionare la lezione da eliminare dalla griglia
2. Fare click su "Cancella lezione"
3. Appare messaggio di conferma: "Vuole davvero eliminare la lezione: [codice], '[descrizione]'?"
4. Confermare con **Sì**
5. La lezione viene eliminata
6. La griglia si aggiorna rimuovendo la riga

**Attenzione**: 
- Operazione irreversibile
- Gli argomenti associati rimangono nel sistema
- Le immagini possono rimanere sul disco (opzione da implementare)

---

## Pulsanti gestione argomenti

### Pulsante "Aggiungi figlio" (Ctrl+F6)
Aggiunge un nuovo argomento come figlio dell'argomento selezionato nell'albero.
- Stesso comportamento della finestra Argomenti standalone

### Pulsante "Aggiungi fratello" (Ctrl+F7)
Aggiunge un nuovo argomento allo stesso livello dell'argomento selezionato.

### Pulsante "Elimina" (DEL)
Elimina l'argomento selezionato e tutti i suoi figli.

### Pulsante "Salva albero" (F5)
Salva le modifiche alla struttura degli argomenti.

**Nota**: modificare la struttura argomenti da questa finestra è possibile ma sconsigliato; usare preferibilmente la finestra Argomenti dedicata.

---

## Funzioni di ricerca argomenti

### Campo "Cerca testo"
Permette di cercare argomenti nell'albero per nome o descrizione.

### Checkbox ricerca
- **"Cerca nelle descrizioni"**: estende la ricerca ai campi descrizione
- **"Testo verbatim"**: cerca la frase esatta
- **"Tutte le parole"**: trova solo se presenti tutte le parole
- **"Maiuscole/minuscole indifferenti"**: ignora maiuscole/minuscole
- **"Trova tutti"**: evidenzia tutti i risultati (invece del primo)

### Pulsante "Trova" (F3)
Esegue la ricerca con le opzioni selezionate.

### Pulsante "Trova sotto nodo"
Cerca solo tra i figli dell'argomento selezionato.

---

## Pulsanti avanzati

### Pulsante "Argomenti fatti"
Evidenzia nell'albero gli argomenti che sono stati effettivamente svolti con la classe.
- Richiede di selezionare un argomento di partenza
- Evidenzia tutti gli argomenti sotto di esso già trattati

### Pulsante "Argomenti NON fatti"
Opposto del precedente: evidenzia gli argomenti non ancora svolti.
- Utile per vedere cosa manca del programma

### Pulsante "Start Links"
Apre automaticamente i collegamenti (URL, file, cartelle) associati alla classe.
- Utile per lezioni con materiali digitali ricorrenti
- Es. sito libro di testo, cartella cloud, applicazioni specifiche

### Pulsante "Copia in clipboard"
Copia nel clipboard la concatenazione di:
- Descrizione lezione
- Riepilogo argomenti

**Uso**: incolla rapido nel registro elettronico

### Pulsante "Cerca tra lezioni"
Cerca il testo inserito nel campo "Riepilogo argomenti" nelle descrizioni di tutte le lezioni.
- Utile per trovare quando è stato trattato un certo argomento

---

## Indicatore tempo lezione

Etichetta colorata in basso che replica l'indicatore della finestra principale.
- Cambia colore dal verde al rosso durante la lezione
- Attivo solo se orologio lezione abilitato

---

## Flussi di lavoro tipici

### Scenario 1: Registrare lezione appena svolta

**Obiettivo**: documentare la lezione odierna

1. Aprire finestra "Lezioni" per la classe
2. Fare click su **"Nuova lezione"**
3. Confermare creazione per data odierna
4. Nel campo **Descrizione**, scrivere: "Spiegazione teorema di Pitagora con dimostrazione. Esercizi guidati 1-5 pagina 120."
5. Nell'albero argomenti, spuntare: "Geometria ? Triangoli ? Teorema di Pitagora"
6. Se disponibili, aggiungere immagini: **"Gestione immagini"** ? foto della lavagna
7. Fare click su **"Salva lezione"**
8. La lezione è registrata

### Scenario 2: Registrare lezione passata

**Obiettivo**: registrare una lezione fatta giorni fa ma dimenticata

1. Aprire finestra "Lezioni"
2. Nel DatePicker, impostare la data passata (es. lunedì scorso)
3. Fare click su **"Nuova lezione"**
4. Confermare creazione per la data specificata
5. Compilare descrizione e spuntare argomenti
6. Salvare

**Nota**: utile per recuperare lezioni non registrate subito

### Scenario 3: Consultare storico lezioni

**Obiettivo**: vedere cosa è stato fatto in un periodo

1. Aprire finestra "Lezioni"
2. Scorrere la griglia "Tutte le lezioni" per data
3. Click su lezioni specifiche per vederne dettagli
4. La griglia "Argomenti della lezione" mostra cosa è stato trattato
5. Eventualmente, usare "Cerca tra lezioni" per trovare argomento specifico

### Scenario 4: Preparare lezione successiva

**Obiettivo**: vedere argomenti fatti e pianificare i prossimi

1. Aprire finestra "Lezioni"
2. Fare click su **"Argomenti fatti"** (selezionare radice albero)
3. Gli argomenti evidenziati sono quelli svolti
4. Gli argomenti bianchi sono da fare
5. Pianificare lezioni successive su argomenti non fatti

---

## Suggerimenti e best practices

### Registrare lezioni regolarmente
- Idealmente subito dopo ogni lezione
- Massimo entro la giornata
- Se si accumulano ritardi, diventa difficile ricordare i dettagli

### Descrizioni concise ma informative
- Includere argomenti principali
- Tipo di attività (spiegazione, esercizi, laboratorio, verifica)
- Eventuali compiti o materiali
- Lunghezza ideale: 2-4 righe

### Spuntare argomenti con precisione
- Spuntare solo argomenti effettivamente trattati
- Se solo accennato, considerare di non spuntare
- Livello di dettaglio: spuntare il nodo più specifico possibile

### Usare immagini strategicamente
- Foto lavagna con schemi importanti
- Screenshot slide chiave
- Diagrammi usati per spiegazioni
- Non serve fotografare tutto, solo materiale di riferimento

### Sincronizzare con registro elettronico
- Usare "Copia in clipboard" per trasferimento rapido
- Adattare il testo alle convenzioni del registro
- Mantenere coerenza tra i due sistemi

---

## Troubleshooting

### Non riesco a creare nuova lezione

**Problema**: click su "Nuova lezione" da errore

**Soluzioni**:
- Verificare che non esista già lezione per quella data
- Cambiare data se necessario
- Verificare di non essere in modalità sola lettura

### Gli argomenti non si salvano

**Problema**: argomenti spuntati non appaiono nella griglia dopo salvataggio

**Soluzioni**:
- Verificare di aver fatto click su "Salva lezione" (non solo "Salva albero")
- Controllare che la lezione sia stata creata (campo "Codice lezione" pieno)
- Riavviare finestra e verificare

### Le immagini non si vedono

**Problema**: dopo aver aggiunto immagini, la PictureBox rimane vuota

**Soluzioni**:
- Verificare che le immagini siano nel percorso corretto
- Provare "Cartella immagini" per vedere se i file esistono
- Formati supportati: .jpg, .png, .bmp, .gif
- Salvare la lezione dopo aver gestito le immagini

### La finestra si apre in sola lettura

**Problema**: tutti i pulsanti di modifica sono disabilitati

**Causa**: è già aperta un'altra finestra Lezioni per la stessa classe/materia

**Soluzione**:
- Chiudere altre finestre Lezioni aperte
- Oppure usare quella esistente

---

## Integrazione con altre finestre

### Da finestra principale
Pulsante **"Lezioni"** apre questa finestra per classe e materia selezionate.

### Verso finestra Argomenti
Modifiche all'albero argomenti in questa finestra si riflettono nella finestra Argomenti standalone.

### Verso finestra Immagini
Pulsante **"Gestione immagini"** apre frmImages per gestire in dettaglio le immagini della lezione.

---

## Limitazioni note

- **Una lezione per data**: non si possono registrare più lezioni nello stesso giorno per stessa classe/materia
- **Modifiche argomenti**: possibili ma scomode, meglio usare finestra dedicata
- **Immagini grandi**: possono rallentare il caricamento
- **Sola lettura**: necessaria se si aprono più finestre contemporaneamente

---

*Questa documentazione fa parte del Manuale Utente di SchoolGrades*
