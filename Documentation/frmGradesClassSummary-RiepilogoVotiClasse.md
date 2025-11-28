# Finestra Riepilogo Voti Classe - Manuale Utente

## Introduzione

La finestra **Riepilogo Voti Classe** (frmGradesClassSummary) fornisce una visione d'insieme delle valutazioni di un'intera classe per una specifica materia. Permette di analizzare le prestazioni collettive, identificare studenti in difficoltà e monitorare l'andamento generale.

## Accesso alla finestra

Per aprire la finestra Riepilogo Voti Classe:

1. Dalla finestra principale, selezionare una classe
2. Selezionare una materia dal menu a tendina
3. Selezionare un tipo di valutazione (es. "Orali", "Scritti")
4. Fare click sul pulsante **"Voti classe"**

**Contesto**: la finestra si apre con i parametri preselezionati dalla finestra principale (classe, materia, tipo valutazione).

---

## Interfaccia della finestra

### Area superiore: Selezione parametri

#### Classe corrente
Etichetta che mostra la classe selezionata (es. "4F 2023-24")
- **Non modificabile** da questa finestra
- Per cambiare classe, chiudere e riaprire dalla finestra principale con classe diversa

#### Tipo valutazione
Menu a tendina per selezionare il tipo di voto da analizzare:
- Voticini
- Orali
- Scritti
- Pratici
- Scritto-grafici
- Altri tipi personalizzati

**Effetto**: cambiando il tipo, i dati nella griglia si aggiornano automaticamente

#### Materia
Menu a tendina per selezionare la materia:
- Elenco di tutte le materie configurate
- Il colore di sfondo della finestra cambia in base alla materia selezionata

**Effetto**: cambiando la materia, i dati si aggiornano e il colore della finestra si adatta

### Area periodo temporale

#### Periodo scolastico
Menu a tendina con periodi predefiniti:
- **Quadrimestri**: 1° quadrimestre, 2° quadrimestre
- **Trimestri**: 1° trimestre, 2° trimestre, 3° trimestre
- **Periodi personalizzati**:
  - Ultima settimana
  - Ultimo mese
  - Anno intero
  - Altri periodi configurati

**Funzionamento**: selezionando un periodo, le date di inizio e fine si aggiornano automaticamente

#### Date personalizzate
Due date picker per specificare un intervallo temporale preciso:
- **Data inizio periodo**
- **Data fine periodo**

**Nota**: è possibile selezionare un periodo predefinito e poi modificare manualmente le date per affinare l'intervallo.

**Effetto**: i dati visualizzati includono solo le valutazioni registrate nell'intervallo specificato.

---

## Modalità di visualizzazione dati

La finestra offre 5 diverse modalità di visualizzazione, selezionabili tramite radio button nel gruppo "Tipo di query":

### 1. Studenti senza voti

**Radio button**: "Mancanti"

**Cosa mostra**: elenco degli studenti che NON hanno voti del tipo selezionato nel periodo specificato.

**Colonne griglia**:
- **IdStudent**: codice identificativo studente
- **LastName**: cognome
- **FirstName**: nome
- Altri campi anagrafici dello studente

**Quando usarla**:
- Per identificare rapidamente chi deve ancora essere interrogato/valutato
- Per pianificare le prossime interrogazioni
- Per assicurarsi che tutti abbiano almeno una valutazione nel periodo

**Azioni disponibili**:
- **Doppio click su uno studente**: apre la finestra di valutazione per inserire subito un voto per quello studente

**Suggerimento**: usare questa vista all'inizio di ogni periodo per identificare le priorità nelle interrogazioni.

### 2. Visualizza voti

**Radio button**: "Mostra voti"

**Cosa mostra**: tutti i singoli voti (microgrades) registrati per la classe nel periodo.

**Colonne griglia**:
- **IdGrade**: codice identificativo del voto
- **Date**: data della valutazione
- **Grade**: voto numerico
- **Weight**: peso del voto (importanza)
- **LastName, FirstName**: studente valutato
- **Text**: eventuale testo/commento della valutazione
- **IdQuestion**: codice domanda associata (se presente)

**Quando usarla**:
- Per vedere lo storico completo delle valutazioni
- Per verificare quando è stato dato un certo voto
- Per controllare la distribuzione dei voti nel tempo
- Per identificare valutazioni specifiche da rivedere

**Azioni disponibili**:
- **Click su una riga**: seleziona il voto
- **Doppio click su un voto**: apre la finestra di dettaglio/modifica della singola valutazione

**Ordinamento**: è possibile ordinare per qualsiasi colonna facendo click sull'intestazione

### 3. Medie ponderate

**Radio button**: "Mostra medie pond."

**Cosa mostra**: le medie ponderate (weighted averages) di ogni studente, calcolate considerando i pesi dei singoli voti.

**Colonne griglia**:
- **IdStudent**: codice studente
- **LastName, FirstName**: nome studente
- **WeightedAverage**: media ponderata calcolata
- **SumWeights**: somma totale dei pesi dei voti considerati
- **NumberOfGrades**: numero di voti inclusi nel calcolo
- **GradesFraction**: frazione del "giro" di voti completato
- **LeftToCloseAssessments**: quanti voti mancano per completare il giro

**Formula media ponderata**:
```
Media = (voto1 × peso1 + voto2 × peso2 + ... + votoN × pesoN) / (peso1 + peso2 + ... + pesoN)
```

**Campo "Mancanti a fine giro"**: mostra un calcolo statistico:
- Somma i voti mancanti per completare un "giro" di valutazioni per ogni studente
- Divide per il numero previsto di giri
- Indica mediamente quanti studenti mancano ancora da valutare per giro

**Quando usarla**:
- Per avere una visione sintetica delle prestazioni di ogni studente
- Per identificare studenti in difficoltà (media bassa)
- Per verificare che i voti siano equamente distribuiti
- Per preparare scrutini o colloqui con genitori

**Ordinamento**: tipicamente ordinata per media (dal migliore al peggiore o viceversa)

### 4. Pesi su voti aperti

**Radio button**: "Mostra pesi su voti aperti"

**Cosa mostra**: i pesi totali accumulati da ogni studente considerando solo i voti "aperti" (non ancora chiusi/consolidati).

**Colonne griglia**:
- **IdStudent**: codice studente
- **LastName, FirstName**: nome studente
- **TotalWeight**: somma dei pesi dei voti aperti
- Altri campi di dettaglio

**Cosa sono i voti "aperti"**:
- Voti temporanei, non ancora consolidati per la media finale
- Permettono aggiustamenti o integrazioni prima della chiusura del periodo
- Utili per valutazioni in itinere che potrebbero essere riviste

**Quando usarla**:
- Durante un periodo di valutazione continua
- Per monitorare chi ha accumulato più "materiale" di valutazione
- Per decidere chi ha bisogno di ulteriori verifiche prima della chiusura

**Numerazione righe**: in questa modalità, le righe sono numerate progressivamente (1, 2, 3...) sulla sinistra

### 5. Voti ponderati per media

**Radio button**: "Mostra voti ponderati per media"

**Cosa mostra**: una vista che combina i voti con le medie, ordinata per media ponderata.

**Colonne griglia**:
- **IdStudent**: codice studente
- **LastName, FirstName**: nome studente
- **WeightedAverage**: media ponderata
- Dettagli dei singoli voti che contribuiscono alla media

**Differenza con "Mostra medie pond."**:
- Questa vista include anche i dettagli dei voti, non solo la media
- Ordinamento predefinito per media
- Utile per analisi più approfondite

**Quando usarla**:
- Per preparare classifiche o graduatorie
- Per identificare il range di prestazione (dal migliore al peggiore)
- Per discussioni con la classe sulle performance generali

---

## Pulsanti e azioni

### Pulsante "Leggi dati"

**Funzione**: ricarica i dati dalla database applicando tutti i filtri correnti.

**Quando usarlo**:
- Dopo aver modificato periodo, materia o tipo valutazione
- Se si sospetta che i dati non siano aggiornati
- Dopo aver inserito nuovi voti da altre finestre

**Nota**: normalmente i dati si aggiornano automaticamente quando si cambiano i parametri, ma questo pulsante forza un refresh manuale.

### Pulsante "Salva su file"

**Funzione**: esporta i dati della griglia corrente in un file CSV (Comma Separated Values).

**Procedura**:
1. Configurare la vista desiderata (tipo di query, periodo, ecc.)
2. Fare click su "Salva su file"
3. Il programma crea un file CSV nella cartella del database
4. Appare un messaggio con il nome del file creato

**Nome file generato**:
```
[Data]_[Classe]_[Materia]_[Tipo valutazione]_[Tipo query]_[Periodo].csv
```

**Esempio**:
```
2024.03.15_4F_Matematica_Orali_Mostra medie pond._2024.01.01_2024.03.15.csv
```

**Formato CSV**:
- File di testo con campi separati da virgola (o punto e virgola)
- Apribile con Excel, LibreOffice Calc, Google Sheets
- Prima riga contiene le intestazioni delle colonne
- Righe successive contengono i dati

**Quando usarlo**:
- Per archiviare snapshot dei voti in momenti specifici (es. fine quadrimestre)
- Per elaborare i dati con altri strumenti (es. creare grafici in Excel)
- Per condividere dati con altri software
- Per backup dei dati di valutazione
- Per preparare report da stampare o inviare

---

## Interazione con la griglia

### Click singolo
- Seleziona una riga
- Evidenzia i dati per una rapida lettura

### Doppio click

Il comportamento del doppio click dipende dalla modalità visualizzazione:

**In modalità "Mancanti"**:
- Si apre la finestra di valutazione per lo studente selezionato
- Permette di inserire subito un voto
- Precompila classe, studente, materia e tipo valutazione

**In altre modalità**:
- Si apre la finestra di dettaglio del singolo voto (microassessment)
- Permette di vedere tutti i dettagli: domanda, risposta, commenti
- Permette eventualmente di modificare il voto

**Messaggio di errore**: se si fa doppio click su una riga non valida o incompleta, appare "Selezionare un voto da visualizzare."

### Ordinamento colonne

- **Click sull'intestazione di una colonna**: ordina la griglia per quella colonna
- **Primo click**: ordine crescente
- **Secondo click**: ordine decrescente
- **Terzo click**: ritorna all'ordine originale

**Suggerimento**: ordinare per media per vedere subito chi è il migliore/peggiore, per data per vedere le valutazioni cronologicamente, per cognome per ordine alfabetico.

---

## Campi informativi

### Campo "N° studenti"
Mostra il numero di righe attualmente visualizzate nella griglia.

**Interpretazione varia con la modalità**:
- In "Mancanti": quanti studenti non hanno voti
- In "Mostra voti": quanti singoli voti ci sono
- In "Mostra medie pond.": quanti studenti hanno almeno un voto
- Ecc.

### Campo "Mancanti a fine giro"
Visibile solo in modalità "Mostra medie pond."

Indica mediamente quanti studenti per "giro" devono ancora essere valutati per completare una distribuzione equa dei voti.

**Esempio di interpretazione**:
- Valore 2.5: significa che mediamente mancano 2-3 studenti per completare ogni giro di valutazioni
- Valore 0: tutti gli studenti hanno completato il giro previsto di valutazioni

**Utilità**: pianificare le prossime interrogazioni per bilanciare il numero di voti tra gli studenti.

---

## Flussi di lavoro tipici

### Scenario 1: Preparazione scrutinio

**Obiettivo**: ottenere le medie ponderate di fine periodo

1. Aprire la finestra "Riepilogo Voti Classe"
2. Verificare che classe e materia siano corrette
3. Selezionare il tipo di valutazione appropriato (es. "Orali")
4. Selezionare il periodo dello scrutinio (es. "1° quadrimestre")
5. Selezionare radio button **"Mostra medie pond."**
6. Verificare le medie nella griglia
7. Fare click su **"Salva su file"** per esportare
8. Aprire il file CSV in Excel per eventuali elaborazioni
9. Ripetere per ogni tipo di valutazione (Orali, Scritti, ecc.)

### Scenario 2: Identificare studenti da interrogare

**Obiettivo**: trovare chi non ha voti nel periodo corrente

1. Aprire la finestra "Riepilogo Voti Classe"
2. Selezionare il periodo appropriato (es. "Ultimo mese")
3. Selezionare radio button **"Mancanti"**
4. La griglia mostra gli studenti senza voti
5. Prendere nota degli studenti o esportare la lista con "Salva su file"
6. Pianificare le interrogazioni per questi studenti

**Azione diretta**: fare doppio click su uno studente per aprire subito la finestra di valutazione e inserire un voto.

### Scenario 3: Analisi andamento classe

**Obiettivo**: capire come sta andando la classe nel complesso

1. Aprire la finestra "Riepilogo Voti Classe"
2. Selezionare **"Mostra voti"** per vedere tutti i voti
3. Ordinare per data (click su intestazione "Date")
4. Verificare la distribuzione temporale: ci sono periodi con pochi voti?
5. Ordinare per voto (click su intestazione "Grade")
6. Verificare la distribuzione: ci sono troppi voti bassi? Troppi alti? Equilibrata?
7. Cambiare a **"Mostra medie pond."**
8. Verificare quali studenti sono sotto la sufficienza
9. Pianificare azioni di recupero per chi è in difficoltà

### Scenario 4: Colloquio con genitori

**Obiettivo**: preparare dati per incontro con famiglia di uno studente

1. Aprire la finestra "Riepilogo Voti Classe"
2. Selezionare **"Mostra voti"**
3. Selezionare periodo "Anno intero" per avere panoramica completa
4. Nella griglia, identificare i voti dello studente specifico (cercare per cognome)
5. Fare doppio click su voti significativi per vedere dettagli
6. Preparare commenti su punti di forza e debolezza
7. Opzionalmente, esportare con "Salva su file" e filtrare in Excel solo lo studente

**Alternativa**: per focus su singolo studente, è più adatta la finestra "Voti allievo" (frmGradesStudentsSummary)

### Scenario 5: Bilanciare le valutazioni

**Obiettivo**: assicurarsi che tutti gli studenti abbiano un numero simile di voti

1. Aprire la finestra "Riepilogo Voti Classe"
2. Selezionare **"Mostra medie pond."**
3. Guardare la colonna **"NumberOfGrades"** (numero di voti)
4. Ordinare per questa colonna
5. Identificare studenti con significativamente meno voti degli altri
6. Pianificare di interrogarli/valutarli per equilibrare

**Indicatore automatico**: il campo "Mancanti a fine giro" dà già questa informazione in forma aggregata

---

## Suggerimenti e best practices

### Esportare regolarmente

Creare snapshot periodici dei voti:
- Inizio, metà e fine di ogni periodo valutativo
- Prima di ogni scrutinio
- Dopo modifiche massive ai voti

**Vantaggi**:
- Tracciabilità delle modifiche nel tempo
- Backup dei dati
- Possibilità di confrontare l'andamento

### Usare periodi significativi

Non sempre serve vedere "anno intero":
- Per monitoraggio corrente: "ultimo mese" o "ultima settimana"
- Per preparazione verifica: periodo da ultima verifica
- Per scrutinio: periodo quadrimestre/trimestre esatto

### Combinare le viste

Per un'analisi completa:
1. Iniziare con "Mancanti" per vedere chi interrogare
2. Passare a "Mostra voti" per vedere distribuzione
3. Concludere con "Mostra medie pond." per sintesi finale

### Attenzione ai pesi

Nella modalità "Mostra medie pond.":
- La media ponderata dà più importanza ai voti con peso maggiore
- Verificare che i pesi riflettano effettivamente l'importanza relativa
- Un voto di verifica scritta spesso ha peso maggiore di un'orale breve

### Interpretare "Mancanti a fine giro"

Valore alto (es. >3): molti studenti devono ancora essere valutati, programmare più interrogazioni/verifiche

Valore basso (es. <1): classe sostanzialmente coperta, focus su studenti specifici o consolidamento

Valore negativo (possibile in alcune situazioni): alcuni studenti hanno troppi voti rispetto ad altri, non procedere con nuovi fino a bilanciare

### Colori di sfondo per materie

Sfruttare il cambio colore della finestra:
- Permette di riconoscere subito la materia a colpo d'occhio
- Utile quando si hanno aperte più finestre contemporaneamente
- Evita confusione tra materie diverse

---

## Troubleshooting

### La griglia è vuota

**Problema**: nessun dato appare nella griglia

**Soluzioni**:
- Verificare che esistano effettivamente voti per la combinazione classe/materia/tipo/periodo
- Controllare il periodo selezionato: potrebbe essere troppo ristretto
- Provare a selezionare "Anno intero" per vedere se ci sono voti fuori dal periodo
- Verificare che la classe e materia siano quelle corrette
- Fare click su "Leggi dati" per forzare un refresh

### I dati non si aggiornano

**Problema**: dopo aver modificato parametri, la griglia non cambia

**Soluzioni**:
- Fare click esplicito su "Leggi dati"
- Verificare che il radio button della modalità sia effettivamente selezionato
- Chiudere e riaprire la finestra
- Se il problema persiste, potrebbe essere un bug: riavviare il programma

### Il doppio click non apre nulla

**Problema**: facendo doppio click su una riga, nessuna finestra si apre

**Soluzioni**:
- Assicurarsi di fare doppio click sulla riga, non sull'intestazione
- Verificare che la riga contenga effettivamente dati validi (IdGrade per voti, IdStudent per studenti)
- Provare prima con singolo click per selezionare, poi doppio click
- Se appare il messaggio "Selezionare un voto da visualizzare", la riga selezionata non è valida

### Il file CSV non viene creato

**Problema**: cliccando "Salva su file" non succede nulla o non trovo il file

**Soluzioni**:
- Verificare di avere permessi di scrittura sulla cartella del database
- Guardare attentamente il messaggio che appare: contiene il percorso completo del file
- Il file è nella cartella del database, non nella cartella corrente
- Aprire la cartella database dal menu Setup per localizzare il file
- Controllare che non ci siano caratteri speciali nel nome che causano problemi (es. "/" in nome materia)

### Le medie sembrano sbagliate

**Problema**: la media ponderata calcolata non corrisponde a quanto atteso

**Soluzioni**:
- Verificare i pesi dei singoli voti: potrebbero essere diversi da quanto pensato
- Controllare che tutti i voti nel periodo abbiano peso > 0 (peso 0 li esclude dalla media)
- Ricalcolare manualmente con la formula: ?(voto × peso) / ?(peso)
- Verificare che non ci siano voti "nascosti" o "chiusi" che influenzano il calcolo in modo inatteso
- Controllare nella modalità "Mostra voti" tutti i voti dello studente per capire

### Il campo "Mancanti a fine giro" è vuoto

**Problema**: in modalità "Mostra medie pond.", il campo risulta vuoto

**Soluzioni**:
- Questo è normale se non ci sono ancora abbastanza dati per calcolare statistiche significative
- Serve un numero minimo di voti distribuiti tra gli studenti
- Il calcolo potrebbe fallire se la distribuzione è troppo irregolare
- Non è un campo critico: usare altre metriche se non disponibile

---

## Limitazioni note

- **Modifica voti**: non è possibile modificare i voti direttamente dalla griglia; bisogna usare il doppio click per aprire la finestra di dettaglio
- **Filtri avanzati**: non ci sono filtri per studente singolo (usare la finestra "Voti allievo" per quello)
- **Grafici**: il programma non genera grafici; esportare in CSV e usare Excel/Calc per visualizzazioni grafiche
- **Statistiche avanzate**: mediana, deviazione standard e altre metriche statistiche non sono calcolate automaticamente
- **Confronto con altre classi**: non è possibile visualizzare più classi contemporaneamente

---

## Integrazione con altre finestre

### Da finestra principale

Il pulsante **"Voti classe"** apre questa finestra con parametri preimpostati:
- Classe correntemente selezionata
- Materia correntemente selezionata
- Tipo valutazione correntemente selezionato

### Verso finestra Valutazione

**Doppio click** in modalità "Mancanti":
- Apre frmMicroAssessment per lo studente selezionato
- Precompila classe, studente, materia, tipo valutazione
- Permette inserimento immediato del voto

### Verso finestra Dettaglio Voto

**Doppio click** su un voto in altre modalità:
- Apre frmMicroAssessment per il voto specifico
- Mostra tutti i dettagli: domanda, risposta, commenti, data, peso
- Permette eventuale modifica (con creazione nuovo voto e azzeramento peso del vecchio)

---

*Questa documentazione fa parte del Manuale Utente di SchoolGrades*
