# Finestra Argomenti - Manuale Utente

## Introduzione

La finestra **Argomenti** (frmTopics) permette di visualizzare, gestire e navigare la struttura gerarchica degli argomenti del programma didattico. Utilizza una struttura ad albero che rappresenta gli argomenti e i loro sottoargomenti, permettendo una visione chiara e organizzata del curriculum.

**ATTENZIONE: QUESTO FILE E' PRELIMINARE E NON REVISIONATO.  
POTREBBE CONTENERE INFORMAZIONI NON ESATTE**  
Comunica con un ticket su GiHub eventuali errori riscontrati.

---

## Accesso alla finestra

La finestra Argomenti può essere aperta in diverse modalità, ognuna con funzionalità specifiche:

### Dalla finestra principale

Pulsante **"Argom. fatti"**: 
- Apre la finestra in modalità visualizzazione degli argomenti già svolti
- Gli argomenti effettivamente spiegati alla classe sono evidenziati a colori
- Permette di vedere a colpo d'occhio cosa è stato fatto e cosa manca

### Da altre finestre

**Dalla finestra "Scelta domanda"**:
- Pulsante **"Scegli argomento"**: apre in modalità selezione argomento
- Permette di scegliere un argomento per filtrare le domande

**Dalla finestra di gestione domande**:
- Permette di associare un argomento ad una domanda

---

## Modalità di apertura

La finestra può operare in diverse modalità:

### 1. Visualizzazione e gestione completa
- Tutti i pulsanti attivi
- Permette di modificare la struttura degli argomenti
- Aggiungere, eliminare, spostare nodi

### 2. Evidenziazione argomenti fatti
- Modalità di sola lettura
- Gli argomenti svolti dalla classe sono evidenziati (sfondo colorato)
- Utile per avere una visione d'insieme del programma svolto
- Pulsante **"Domande"** visibile per collegare argomenti e domande

### 3. Scelta argomento
- Modalità di selezione
- Pulsante **"Scegli"** attivo per confermare la selezione
- Gli argomenti già svolti sono evidenziati per facilitare la scelta
- Si chiude automaticamente dopo la selezione

### 4. Ricerca argomenti
- Modalità focalizzata su un argomento specifico
- L'argomento cercato viene automaticamente evidenziato e portato in vista

### 5. Importazione argomenti
- Modalità speciale per importare una struttura completa da file
- Opzioni per cancellare o integrare con la struttura esistente

---

## Interfaccia della finestra

### Albero degli argomenti (TreeView)

L'elemento principale è l'albero gerarchico che visualizza tutti gli argomenti.

**Struttura**:
- **Nodo radice**: rappresenta l'intero programma della materia
- **Nodi figli**: argomenti principali (es. "Algebra", "Geometria")
- **Nodi nipoti**: sottoargomenti (es. "Equazioni", "Disequazioni")
- La profondità può essere arbitraria

**Interazione**:
- **Click singolo**: seleziona un argomento e ne visualizza i dettagli
- **Doppio click**: espande/contrae il nodo per vedere/nascondere i figli
- **Freccia a sinistra del nodo**: espande/contrae i figli
- **Tasti ↑ e ↓**: navigazione tra gli argomenti
- **Tasti ← e →**: contrazione ed espansione nodi

**Evidenziazione**:
- **Sfondo colorato**: argomenti già svolti con la classe corrente
- **Sfondo bianco**: argomenti non ancora svolti
- **Selezione (blu)**: argomento attualmente selezionato

### Pannello dettagli argomento

A destra dell'albero, tre campi mostrano e permettono di modificare i dettagli dell'argomento selezionato:

**Nome argomento**:
- Titolo breve dell'argomento
- **Modificabile**: digitare direttamente per cambiare il nome
- Le modifiche vengono salvate con il pulsante "Salva albero"

**Descrizione**:
- Campo più ampio per descrizione estesa
- Può contenere:
  - Dettagli sull'argomento
  - Note per l'insegnante
  - Collegamenti a risorse
  - Prerequisiti
- **Modificabile**: digitare direttamente

**Codice argomento**:
- Numero identificativo univoco dell'argomento nel database
- **Non modificabile**: assegnato automaticamente
- Utile per riferimenti tecnici

---

## Pulsanti di gestione albero

### Pulsante "Aggiungi figlio" (F6)

**Funzione**: aggiunge un nuovo argomento come figlio dell'argomento selezionato

**Procedura**:
1. Selezionare l'argomento padre (es. "Algebra")
2. Fare click su "Aggiungi figlio"
3. Appare un nuovo nodo figlio con nome temporaneo "Nuovo argomento"
4. Il cursore si posiziona automaticamente nel campo "Nome argomento"
5. Digitare il nome del nuovo argomento (es. "Equazioni lineari")
6. Compilare eventualmente la descrizione
7. Il nuovo argomento sarà salvato facendo click su "Salva albero"

**Scorciatoia**: premere **F6** sulla tastiera

**Quando usarlo**:
- Per aggiungere sottoargomenti dettagliati
- Per raffinare la struttura gerarchica
- Per specializzare un argomento generale

**Esempio**:
```
Matematica
├── Algebra (← selezionato)
    ├── [NUOVO] Equazioni lineari (← aggiunto come figlio)
```

### Pulsante "Aggiungi fratello" (F7)

**Funzione**: aggiunge un nuovo argomento allo stesso livello dell'argomento selezionato

**Procedura**:
1. Selezionare un argomento (es. "Algebra")
2. Fare click su "Aggiungi fratello"
3. Appare un nuovo nodo fratello dopo quello selezionato
4. Digitare nome e descrizione come per "Aggiungi figlio"
5. Salvare con "Salva albero"

**Scorciatoia**: premere **F7** sulla tastiera

**Quando usarlo**:
- Per aggiungere argomenti allo stesso livello di importanza
- Per completare una categoria con argomenti paralleli
- Per aggiungere nuovi capitoli del programma

**Esempio**:
```
Matematica
├── Algebra (← selezionato)
├── [NUOVO] Geometria (← aggiunto come fratello)
```

### Pulsante "Elimina" (DEL)

**Funzione**: elimina l'argomento selezionato e tutti i suoi figli

**Procedura**:
1. Selezionare l'argomento da eliminare
2. Fare click su "Elimina"
3. Confermare l'eliminazione
4. L'argomento scompare dall'albero
5. Salvare con "Salva albero" per rendere permanente

**Scorciatoia**: premere **DEL** sulla tastiera

**ATTENZIONE**:
- L'eliminazione è ricorsiva: elimina anche tutti i sottoargomenti
- Le domande associate all'argomento NON vengono eliminate, ma rimangono senza argomento
- L'operazione può essere annullata chiudendo la finestra senza salvare

**Quando usarlo**:
- Per rimuovere argomenti obsoleti
- Per semplificare una struttura troppo complessa
- Per correggere errori di inserimento

### Pulsante "Salva albero" (F5)

**Funzione**: salva tutte le modifiche apportate alla struttura degli argomenti

**Procedura**:
1. Apportare tutte le modifiche desiderate (aggiunte, eliminazioni, modifiche nomi/descrizioni)
2. Fare click su "Salva albero"
3. Il programma salva la nuova struttura nel database
4. Appare un messaggio di conferma "Salvataggio fatto"

**Scorciatoia**: premere **F5** sulla tastiera

**IMPORTANTE**:
- **NON salvare automaticamente**: le modifiche sono temporanee finché non si preme questo pulsante
- Chiudendo la finestra senza salvare, tutte le modifiche vanno perse
- Il programma avvisa se ci sono modifiche non salvate solo se configurato

**Quando usarlo**:
- Dopo aver completato una serie di modifiche
- Prima di chiudere la finestra se si vogliono mantenere i cambiamenti
- Periodicamente durante modifiche estese, per non perdere il lavoro

---

## Funzioni di ricerca

### Ricerca testuale

**Campo "Cerca testo"**: permette di cercare argomenti per nome o descrizione

**Opzioni di ricerca** (checkbox):

**"Cerca nelle descrizioni"**:
- Se spuntato: cerca anche nel campo descrizione
- Se non spuntato: cerca solo nei nomi degli argomenti

**"Tutte le parole"**:
- Se spuntato: trova solo argomenti che contengono TUTTE le parole cercate
- Se non spuntato: trova argomenti che contengono ALMENO UNA delle parole

**"Testo verbatim"**:
- Se spuntato: cerca la frase esatta come digitata
- Se non spuntato: cerca le parole singolarmente

**"Maiuscole/minuscole indifferenti"**:
- Se spuntato: ignora maiuscole/minuscole (consigliato)
- Se non spuntato: distinzione esatta

**"Trova tutti"**:
- Se spuntato: evidenzia tutti gli argomenti che corrispondono
- Se non spuntato: evidenzia solo il primo trovato

### Pulsanti di ricerca

**"Trova"**:
- Esegue la ricerca con le opzioni selezionate
- Evidenzia i risultati nell'albero
- Espande i nodi necessari per rendere visibili i risultati

**Scorciatoia**: premere **F3** per ripetere l'ultima ricerca

**"Trova sotto nodo"**:
- Come "Trova", ma cerca solo tra i figli dell'argomento selezionato
- Utile per ricerche mirate in una sezione del programma didattico

**Procedura ricerca tipica**:
1. Digitare il testo da cercare (es. "equazioni")
2. Selezionare le opzioni desiderate
3. Fare click su "Trova"
4. I nodi contenenti "equazioni" vengono evidenziati
5. Navigare tra i risultati per trovare quello desiderato

---

## Integrazione con domande

### Pulsante "Domande"

**Funzione**: apre la finestra "Scelta domanda" filtrata per l'argomento selezionato

**Quando è visibile**: solo in modalità "Evidenziazione argomenti fatti"

**Procedura**:
1. Navigare nell'albero e selezionare un argomento (es. "Equazioni di secondo grado")
2. Fare click su "Domande"
3. Si apre la finestra "Scelta domanda" con:
   - Argomento preselezionato
   - Griglia filtrata con domande su quell'argomento
4. Selezionare una domanda e fare click su "Scegli"
5. La domanda viene impostata come corrente nella finestra principale

**Flusso completo argomento → domanda**:
```
1. Finestra principale → "Argom. fatti"
2. Finestra Argomenti (evidenziati quelli svolti)
3. Selezionare argomento → "Domande"
4. Finestra Scelta domanda (filtrata per argomento)
5. Scegliere domanda → chiusura automatica
6. Finestra principale con domanda pronta
```

---

## Flusso di lavoro tipico

### Scenario 1: Consultare argomenti svolti

**Obiettivo**: vedere cosa è stato spiegato alla classe

1. Dalla finestra principale, fare click su **"Argom. fatti"**
2. La finestra Argomenti si apre con argomenti svolti evidenziati
3. Navigare nell'albero per vedere la copertura del programma
4. Gli argomenti colorati sono quelli già spiegati nelle lezioni
5. Gli argomenti bianchi sono da fare o in programma

**Nota**: l'evidenziazione si basa sulle lezioni registrate nel sistema. Un argomento è considerato "fatto" se è stato associato ad almeno una lezione della classe.

### Scenario 2: Aggiungere nuovi argomenti al programma

**Obiettivo**: arricchire la struttura degli argomenti

1. Aprire la finestra Argomenti in modalità gestione
2. Navigare fino al punto dove aggiungere (es. "Algebra")
3. Decidere se aggiungere un figlio o un fratello
4. Fare click su "Aggiungi figlio" o "Aggiungi fratello"
5. Digitare il nome (es. "Logaritmi")
6. Compilare la descrizione (es. "Definizione, proprietà e applicazioni dei logaritmi")
7. Ripetere per altri argomenti se necessario
8. Fare click su **"Salva albero"** (F5) per confermare
9. Messaggio "Salvataggio fatto" conferma il successo

**Suggerimento**: pianificare la struttura su carta prima di iniziare ad aggiungere molti argomenti

### Scenario 3: Riorganizzare la struttura

**Obiettivo**: modificare l'organizzazione degli argomenti (la loro posizione nell'albero)

SchoolGrades supporta il drag-and-drop degli argomenti sull'albero per cui esso si può riorganizzare trascinando un sottoalbero da un nodo padre ad un altro. 
Per farlo basta cliccare su un argomento, spostarlo  e rilascia

**Suggerimento futuro**: è prevista l'implementazione del drag-and-drop in versioni future del programma

### Scenario 4: Cercare un argomento specifico

**Obiettivo**: trovare rapidamente un argomento per nome

1. Aprire la finestra Argomenti
2. Nel campo "Cerca testo" digitare parole chiave (es. "limiti")
3. Spuntare **"Maiuscole/minuscole indifferenti"**
4. Spuntare **"Cerca nelle descrizioni"** se la parola potrebbe essere nella descrizione
5. Fare click su **"Trova"** (o premere F3)
6. Il primo argomento corrispondente viene evidenziato e portato in vista
7. Se serve, premere F3 ripetutamente per trovare altre occorrenze

### Scenario 5: Associare argomento a domanda

**Obiettivo**: collegare una domanda ad un argomento specifico

1. Aprire la finestra di modifica di una domanda (da "Scelta domanda" con doppio click)
2. Nella finestra domanda, fare click sul pulsante di scelta argomento
3. Si apre la finestra Argomenti in modalità selezione
4. Navigare nell'albero e selezionare l'argomento appropriato (es. "Teorema di Pitagora")
5. Fare click su **"Scegli"**
6. La finestra si chiude e la domanda ora è associata a quell'argomento
7. Salvare la domanda

---

## Suggerimenti e best practices

### Strutturare l'albero in modo logico

**Principi di organizzazione**:
- **Livelli chiari**: usare 2-4 livelli di profondità, non di più
- **Granularità appropriata**: non troppo dettagliato (difficile da navigare) né troppo generico (poco utile)
- **Nomi descrittivi**: usare nomi chiari e inequivocabili
- **Parallelismo**: mantenere strutture simili per capitoli analoghi

**Esempio di buona struttura**:
```
Matematica (radice)
├── Algebra
│   ├── Equazioni
│   │   ├── Lineari
│   │   ├── Secondo grado
│   │   └── Sistemi
│   └── Disequazioni
│       ├── Lineari
│       └── Secondo grado
├── Geometria
│   ├── Piana
│   │   ├── Triangoli
│   │   └── Cerchi
│   └── Solida
│       ├── Poliedri
│       └── Solidi di rotazione
└── Analisi
    ├── Limiti
    ├── Derivate
    └── Integrali
```

### Usare le descrizioni in modo efficace

Il campo descrizione è prezioso per:
- **Prerequisiti**: "Richiede conoscenza di equazioni lineari"
- **Obiettivi**: "Lo studente deve saper calcolare limiti di funzioni razionali"
- **Collegamenti**: "Vedi anche: derivate, teorema del valor medio"
- **Risorse**: "Libro pagina 234-250, dispensa online: [URL]"
- **Note didattiche**: "Argomento difficile, dedicare almeno 2 lezioni"

### Sincronizzare con il registro lezioni

Quando si registra una lezione:
- Associare sempre gli argomenti trattati
- Questo crea il collegamento che evidenzia gli argomenti "fatti"
- Permette di avere una visione precisa del programma svolto

### Evitare duplicati

Prima di aggiungere un nuovo argomento:
1. Usare la funzione "Trova" per verificare che non esista già
2. Controllare anche le descrizioni (potrebbero esserci sinonimi)
3. Se esiste già, considerare se arricchirlo invece che duplicarlo

### Salvare frequentemente

Quando si fanno molte modifiche:
- Salvare ogni 5-10 modifiche
- In caso di crash o errore, non si perde tutto il lavoro
- Fare backup del database prima di ristrutturazioni massive (c'è un bottone nella finestra dedi)

### Pianificare prima di implementare

Per ristrutturazioni importanti:
1. Disegnare la nuova struttura su carta o file di testo
2. Identificare cosa spostare, eliminare, aggiungere
3. Fare un backup del database
4. Implementare la ristrutturazione
5. Verificare che tutto sia come atteso prima di usare in produzione

---

## Troubleshooting

### Non riesco a modificare i nomi degli argomenti

**Problema**: cliccando sul campo nome, non posso digitare

**Soluzioni**:
- Verificare che la finestra non sia aperta in modalità sola lettura
- Controllare che sia selezionato un argomento valido (non la radice in alcuni casi)
- Assicurarsi che l'argomento esista realmente (non un nodo temporaneo)

### I cambiamenti non vengono salvati

**Problema**: dopo aver modificato e fatto click su "Salva albero", le modifiche non persistono

**Soluzioni**:
- Verificare di aver effettivamente premuto "Salva albero" (F5)
- Controllare che appaia il messaggio "Salvataggio fatto"
- Assicurarsi di avere permessi di scrittura sul database
- Controllare che il database non sia aperto da un'altra istanza del programma
- Verificare che non ci siano errori nel log (visualizzabili da Setup)

### L'argomento eliminato riappare

**Problema**: dopo aver eliminato un argomento e salvato, questo ricompare alla prossima apertura

**Soluzioni**:
- L'argomento potrebbe essere ricreato automaticamente se associato a lezioni o domande
- Verificare che non ci siano domande o lezioni che lo referenziano prima di eliminarlo
- Se l'argomento è fondamentale, considerare di lasciarlo e semplicemente non usarlo

### Gli argomenti svolti non sono evidenziati

**Problema**: nonostante ci siano lezioni registrate, gli argomenti non risultano evidenziati

**Soluzioni**:
- Verificare che le lezioni abbiano effettivamente associati gli argomenti
- Controllare che la classe selezionata nella finestra principale sia quella corretta
- Assicurarsi che la materia sia quella giusta
- Gli argomenti devono essere associati alle lezioni tramite la finestra "Lezioni"

### La ricerca non trova argomenti esistenti

**Problema**: si sa che un argomento esiste, ma la ricerca non lo trova

**Soluzioni**:
- Controllare l'ortografia del termine cercato
- Provare con **"Cerca nelle descrizioni"** spuntato
- Usare **"Maiuscole/minuscole indifferenti"**
- Provare con parole chiave più brevi o più generiche
- Verificare che l'argomento non sia sotto un nodo collassato

### Albero troppo grande, difficile da navigare

**Problema**: l'albero è diventato enorme e navigarlo è complesso

**Soluzioni**:
- Usare la funzione di ricerca invece di navigare manualmente
- Collassare i nodi principali e espandere solo quello di interesse
- Considerare di suddividere per materie se c'è un unico albero condiviso
- Valutare una ristrutturazione per ridurre la profondità o il numero di nodi per livello

---

## Integrazione con il sistema

### Relazione con le lezioni

Gli argomenti sono il cuore del collegamento tra programma e attività:
- Ogni **lezione** può avere uno o più argomenti associati
- Quando si registra una lezione (finestra "Lezioni"), si selezionano gli argomenti trattati
- Questo crea lo storico: "quando è stato spiegato cosa"
- L'evidenziazione nella finestra Argomenti riflette questo storico

### Relazione con le domande

Le domande possono essere associate a un argomento:
- Ogni **domanda** ha un campo "IdTopic" che contiene il codice dell'argomento
- Questo permette di filtrare domande per argomento nella finestra "Scelta domanda"
- Permette interrogazioni mirate su specifici argomenti
- Facilita la gestione di un ampio database di domande

### Relazione con i voti

Indirettamente, gli argomenti sono collegati ai voti:
- Una **valutazione** può avere una domanda associata
- La domanda ha un argomento associato
- Quindi si può tracciare quali argomenti sono stati valutati e con quali risultati
- Questo permette analisi dettagliate: "su quali argomenti gli studenti sono più deboli?"

---

## Funzionalità future

Possibili miglioramenti in sviluppo:
- **Drag-and-drop**: spostare argomenti nell'albero trascinandoli
- **Import/export**: esportare l'albero in formati standard (XML, JSON, Markdown)
- **Condivisione**: importare alberi da altri insegnanti o fonti online
- **Visualizzazione alternativa**: vista piatta (lista), vista mindmap
- **Collegamento a risorse esterne**: link diretti a video, PDF, siti web per ogni argomento
- **Statistiche**: vedere quante domande, lezioni, studenti per ogni argomento

---

*Questa documentazione fa parte del Manuale Utente di SchoolGrades*
