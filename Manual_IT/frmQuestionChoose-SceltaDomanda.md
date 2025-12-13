# Finestra Scelta Domanda - Manuale Utente

## Introduzione

La finestra **Scelta Domanda** (frmQuestionChoose) permette di cercare, filtrare e selezionare domande da porre agli studenti. Questa è una delle funzionalità più potenti di SchoolGrades per la gestione delle interrogazioni e verifiche.

**ATTENZIONE: QUESTO FILE E' PRELIMINARE E NON REVISIONATO.  
POTREBBE CONTENERE INFORMAZIONI NON ESATTE**  
Comunica con un ticket su GiHub eventuali errori riscontrati.

## Accesso alla finestra

Per aprire la finestra Scelta Domanda:

1. Dalla finestra principale, fare click sul pulsante **"Scelta domanda"**
2. Oppure fare **doppio click** sul campo di testo della domanda corrente nella finestra principale

**Contesto**: la finestra si apre nel contesto della materia e classe correntemente selezionate nella finestra principale.

---

## Interfaccia della finestra

### Area superiore: Filtri di ricerca

La parte superiore contiene diversi controlli per filtrare le domande:

#### Materia
Menu a tendina per selezionare la materia. 
- Se già selezionata nella finestra principale, viene preimpostata
- Il colore di sfondo della finestra cambia in base alla materia selezionata (come nella finestra principale)

#### Tipo di domanda
Menu a tendina per filtrare per tipo:
- Vero/Falso
- Scelta multipla
- Risposta aperta
- Esercizi
- Altri tipi personalizzati

**Lasciare vuoto per visualizzare tutti i tipi di domanda**

#### Ricerca testuale
Campo **"Testo da cercare"** permette di ricercare parole chiave nel testo delle domande.

**Funzionamento**:
- Digitare almeno 4 caratteri per attivare la ricerca automatica
- La ricerca avviene mentre si digita (dopo il 4° carattere)
- Cercare nel testo della domanda

**Suggerimento**: usare parole chiave significative come "elettrone", "Rinascimento", "equazione", ecc.

### Area centrale: Argomenti

#### Argomento corrente
Due campi visualizzano l'argomento selezionato:
- **Testo argomento**: mostra il percorso completo nell'albero degli argomenti (es. "Matematica > Algebra > Equazioni lineari")
- **Codice argomento**: mostra il codice numerico identificativo

#### Pulsanti di gestione argomenti

**"Scegli argomento"**
- Apre la finestra dell'albero degli argomenti per selezionarne uno
- Evidenzia gli argomenti già svolti con la classe

**"Argomento per periodo"**
- Permette di scegliere un argomento tra quelli effettivamente svolti dalla classe in un dato periodo
- Utile per fare domande su argomenti recentemente spiegati

**"Nessun argomento"**
- Rimuove il filtro per argomento
- Visualizza tutte le domande, anche quelle senza argomento associato

#### Opzioni argomenti

Due radio button permettono di scegliere l'ampiezza della ricerca:

**"Un argomento"**
- Cerca domande associate esattamente all'argomento selezionato
- Ricerca ristretta

**"Molti argomenti"**
- Cerca domande nell'argomento selezionato E in tutti i suoi sottoargomenti
- Ricerca più ampia, include tutta la ramificazione dell'albero

**Esempio**: selezionando "Algebra" con "Molti argomenti" si ottengono domande su algebra, equazioni, disequazioni, sistemi, ecc.

### Area Tag

#### Lista tag selezionati
Mostra i tag attualmente applicati come filtro.

**Cosa sono i tag**: etichette che categorizzano le domande trasversalmente agli argomenti (es. "difficile", "teoria", "esercizio", "fondamentale", ecc.)

#### Pulsanti tag

**"Aggiungi tag"**
- Apre la finestra di selezione tag
- Permette di aggiungere un tag alla lista dei filtri
- I tag si accumulano: più tag = ricerca più specifica

**"Rimuovi tag"**
- Rimuove il tag selezionato dalla lista
- Riattiva le domande che erano filtrate da quel tag

#### Modalità combinazione tag

Due radio button controllano come i tag vengono combinati:

**"Or"** (predefinito)
- Mostra domande che hanno ALMENO UNO dei tag selezionati
- Ricerca più ampia
- **Esempio**: con tag "teoria" OR "fondamentale" si ottengono tutte le domande teoriche PIÙ tutte quelle fondamentali

**"And"**
- Mostra solo domande che hanno TUTTI i tag selezionati
- Ricerca più ristretta
- **Esempio**: con tag "teoria" AND "fondamentale" si ottengono solo le domande che sono sia teoriche sia fondamentali

### Area periodo temporale

#### Periodo scolastico
Menu a tendina con periodi predefiniti:
- Quadrimestri (1°, 2°)
- Trimestri (1°, 2°, 3°)
- Ultimo mese
- Ultima settimana
- Anno intero

**Funzione**: filtra le domande in base a quando sono state fatte alla classe

#### Date personalizzate
Due date picker permettono di specificare:
- **Data inizio periodo**
- **Data fine periodo**

**Nota**: selezionando un periodo dal menu, le date si aggiornano automaticamente. È possibile poi modificarle manualmente.

---

## Griglia delle domande

La parte centrale/inferiore mostra la griglia con le domande che soddisfano i criteri di filtro.

### Colonne visualizzate

- **IdQuestion**: codice numerico della domanda
- **Text**: testo della domanda
- **IdSchoolSubject**: codice materia
- **IdQuestionType**: tipo di domanda
- **Weight**: peso della domanda (importanza)
- **Duration**: durata prevista in minuti
- **Difficulty**: difficoltà (scala numerica)
- **Image**: nome eventuale immagine associata
- **IdTopic**: codice argomento associato

### Interazione con la griglia

**Click singolo**: seleziona una riga

**Doppio click su una domanda**: apre la finestra di modifica della domanda selezionata, permettendo di:
- Visualizzare il testo completo
- Vedere l'argomento associato
- Modificare la domanda se necessario
- Gestire le risposte multiple se presenti

**Nota**: dopo la modifica, la griglia si aggiorna automaticamente

---

## Pulsanti di azione principali

### Pulsante "Scegli"
- Seleziona la domanda attualmente evidenziata nella griglia
- Chiude la finestra
- La domanda scelta viene impostata come domanda corrente nella finestra principale

**Scorciatoia**: fare doppio click su una domanda per modificarla, oppure selezionarla e premere "Scegli"

### Pulsante "Casuale"
- Estrae casualmente una domanda tra quelle visualizzate nella griglia
- Utile per interrogazioni imprevedibili
- La domanda estratta viene impostata come domanda corrente
- Il programma cerca di evitare domande già fatte nella stessa lezione

**Algoritmo intelligente**: se ci sono domande già poste agli studenti presenti, tenta di estrarne una diversa (con un limite di tentativi)

### Pulsante "Aggiungi domanda"
- Apre la finestra per creare una nuova domanda
- La domanda viene precompilata con:
  - Materia corrente
  - Tipo di domanda selezionato nel filtro
  - Argomento corrente (se selezionato)
- Dopo la creazione, la nuova domanda appare nella griglia

### Pulsante "Copia domanda"
**Nota**: Funzionalità non ancora implementata completamente

### Pulsante "Cerca"
- Ricarica manualmente la griglia applicando tutti i filtri correnti
- Normalmente non necessario (la ricerca è automatica), ma utile se si sospetta che la griglia non sia aggiornata

### Pulsante "Domande fatte"
- Cambia la visualizzazione per mostrare le domande GIÀ FATTE alla classe
- Opposto del comportamento normale (che mostra domande NON ancora fatte)
- Utile per:
  - Verificare cosa è già stato chiesto
  - Rivedere domande precedenti
  - Evitare ripetizioni

### Pulsante "Nodi al pettine"
- Mostra le domande su cui lo studente corrente ha avuto difficoltà o voti bassi
- Permette di tornare su argomenti problematici
- Richiede che sia selezionato uno studente specifico

**Quando usarlo**: per interrogazioni mirate di recupero o per verificare se le lacune sono state colmate

---

## Indicatore tempo lezione

In basso a sinistra della finestra, una piccola area colorata **"Tempo lezione"** replica l'indicatore della finestra principale:
- Cambia colore dal verde al rosso man mano che la lezione procede
- Permette di tenere d'occhio il tempo anche quando si cerca una domanda

**Nota**: l'indicatore è attivo solo se l'orologio lezione è abilitato nella finestra principale

---

## Flusso di lavoro tipico

### Scenario 1: Interrogazione programmata su argomento specifico

1. Aprire la finestra "Scelta domanda"
2. Verificare che la materia sia corretta
3. Fare click su **"Scegli argomento"**
4. Navigare nell'albero e selezionare l'argomento (es. "Equazioni di secondo grado")
5. Selezionare **"Molti argomenti"** per includere anche i sottotemi
6. La griglia si popola con le domande pertinenti
7. Scorrere la griglia e fare click su una domanda interessante
8. Fare click su **"Scegli"** per confermare
9. La finestra si chiude e la domanda è pronta per essere posta

### Scenario 2: Interrogazione casuale sul programma recente

1. Aprire la finestra "Scelta domanda"
2. Selezionare dal menu periodo **"Ultimo mese"**
3. Fare click su **"Nessun argomento"** (per non limitare ad un solo argomento)
4. La griglia mostra tutte le domande sugli argomenti svolti nell'ultimo mese
5. Fare click su **"Casuale"**
6. Il programma estrae una domanda a sorpresa
7. La finestra si chiude con la domanda estratta

### Scenario 3: Recupero su difficoltà dello studente

1. Selezionare uno studente dalla finestra principale
2. Aprire la finestra "Scelta domanda"
3. Fare click su **"Nodi al pettine"**
4. Il programma mostra domande su argomenti dove lo studente ha avuto problemi
5. Selezionare una domanda per verificare il recupero
6. Fare click su **"Scegli"**

### Scenario 4: Creare domanda al volo durante lezione

1. Aprire la finestra "Scelta domanda"
2. Selezionare **"Aggiungi domanda"**
3. Compilare il testo della domanda nella finestra che si apre
4. Selezionare tipo, difficoltà, durata
5. Associare l'argomento se necessario
6. Salvare
7. La domanda appare nella griglia e può essere subito scelta

---

## Suggerimenti e best practices

### Usare i filtri progressivamente

Non applicare troppi filtri contemporaneamente:
1. Iniziare con la materia
2. Aggiungere l'argomento
3. Eventualmente raffinare con tag o tipo
4. Se la griglia è vuota, rimuovere filtri uno alla volta

### Sfruttare i tag in modo intelligente

Creare un sistema di tag coerente:
- **Difficoltà**: "facile", "media", "difficile", "avanzata"
- **Tipo cognitivo**: "conoscenza", "comprensione", "applicazione", "analisi"
- **Modalità**: "teoria", "esercizio", "problema"
- **Importanza**: "fondamentale", "complementare", "approfondimento"

### Aggiornare le domande

Quando si visualizzano le domande con doppio click:
- Correggere errori di battitura
- Aggiornare riferimenti obsoleti
- Aggiustare difficoltà o durata in base all'esperienza
- Aggiungere note o commenti

### Bilanciare casualità e controllo

- Usare **"Casuale"** per varietà e imprevedibilità
- Usare **"Scegli"** (selezione manuale) per controllo preciso
- Alternare le due modalità per mantenere alta l'attenzione degli studenti

### Evitare ripetizioni

- Controllare periodicamente con **"Domande fatte"** quali domande sono state già poste
- Usare l'estrazione casuale che tenta automaticamente di evitare ripetizioni nella stessa lezione
- Creare nuove domande regolarmente per ampliare il database

---

## Troubleshooting

### La griglia è vuota

**Problema**: nessuna domanda appare nella griglia

**Soluzioni**:
- Verificare che esistano domande per la materia selezionata
- Rimuovere i filtri troppo restrittivi (argomento, tag, tipo)
- Fare click su **"Nessun argomento"** per vedere tutte le domande
- Controllare il periodo: se troppo ristretto, potrebbe escludere tutto
- Usare **"Domande fatte"** per vedere se le domande ci sono ma sono già state usate

### Il pulsante "Casuale" non funziona

**Problema**: cliccando "Casuale" non succede nulla o si sente solo un beep

**Soluzioni**:
- Verificare che la griglia contenga almeno una domanda
- Se la griglia ha domande ma sono tutte già state poste nella lezione corrente, il programma non trova domande "nuove" dopo vari tentativi

### Le domande non sembrano filtrare correttamente per argomento

**Problema**: selezionando un argomento appaiono domande che sembrano non pertinenti

**Soluzioni**:
- Verificare se si sta usando **"Molti argomenti"**: in tal caso sono inclusi tutti i sottoargomenti
- Controllare che le domande abbiano effettivamente l'argomento associato (alcune domande potrebbero non avere argomento)
- Alcune domande potrebbero essere trasversali a più argomenti

### Modifiche alle domande non si salvano

**Problema**: dopo aver modificato una domanda con doppio click, le modifiche non persistono

**Soluzioni**:
- Assicurarsi di aver premuto il pulsante "Salva" nella finestra di modifica domanda
- Verificare i permessi di scrittura sul database
- Controllare che il database non sia aperto in sola lettura

---

## Integrazione con altre finestre

### Con finestra Argomenti

La finestra "Scelta domanda" si integra strettamente con la finestra **"Argomenti"**:
- Da "Scelta domanda", il pulsante **"Scegli argomento"** apre la finestra Argomenti in modalità selezione
- Nella finestra Argomenti, si può usare il pulsante **"Domande"** per tornare a "Scelta domanda" con l'argomento preselezionato

### Con finestra Valutazione

Dopo aver scelto una domanda:
- La domanda diventa la domanda corrente nella finestra principale
- Facendo click su **"Valutaz."** nella finestra principale, la finestra di valutazione si apre già con la domanda selezionata
- Lo studente estratto vede automaticamente la domanda scelta

### Con finestra Nodi al pettine

Il pulsante **"Nodi al pettine"**:
- Apre una finestra specializzata che mostra domande problematiche per lo studente
- Dalla finestra "Nodi al pettine" si può scegliere una domanda che torna a "Scelta domanda"
- Permette interrogazioni mirate di recupero

---

## Casi d'uso avanzati

### Interrogazione progressiva per difficoltà

1. Iniziare con domande facili: applicare tag "facile" o impostare difficoltà bassa
2. Scegliere 2-3 domande facili per lo studente
3. Se lo studente risponde bene, passare a difficoltà media: cambiare filtro
4. Continuare ad aumentare la difficoltà finché lo studente risponde correttamente
5. Registrare il livello massimo raggiunto come indicatore di preparazione

### Interrogazione tematica trasversale

1. Usare i tag invece degli argomenti per creare interrogazioni tematiche
2. **Esempio**: tag "Rinascimento" può includere domande su arte, letteratura, storia, filosofia
3. Applicare il tag e selezionare "Or" se si vuole ampiezza
4. Permette interrogazioni interdisciplinari senza vincoli di argomenti rigidi

### Simulazione verifica orale

1. Estrarre 5-10 domande casuali filtrate per argomenti del periodo
2. Copiarle in un documento (usando "Crea file" o copia-incolla dal database)
3. Distribuire le domande agli studenti in anticipo come preparazione
4. Durante le interrogazioni, scegliere da quelle 5-10 domande
5. Gli studenti sanno l'ambito ma non la domanda specifica

---

*Questa documentazione fa parte del Manuale Utente di SchoolGrades*
