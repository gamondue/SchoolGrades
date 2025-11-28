# Finestra Riepilogo Voti Allievo - Manuale Utente

## Introduzione

La finestra **Riepilogo Voti Allievo** (frmGradesStudentsSummary) fornisce una visione dettagliata delle valutazioni di un singolo studente. Permette di analizzare l'andamento personale, calcolare medie ponderate e gestire annotazioni specifiche sullo studente.

## Accesso alla finestra

Per aprire la finestra Riepilogo Voti Allievo:

1. Dalla finestra principale, selezionare uno studente (tramite estrazione, selezione nella griglia, o altro)
2. Selezionare una materia dal menu a tendina (opzionale, può essere cambiata dopo)
3. Selezionare un tipo di valutazione (opzionale, può essere cambiato dopo)
4. Fare click sul pulsante **"Voti allievo"**

**Contesto**: la finestra si apre con lo studente, materia e tipo valutazione preselezionati dalla finestra principale.

**Nota**: questa finestra è l'equivalente per singolo studente della finestra "Riepilogo Voti Classe", ma con maggiori dettagli e funzionalità specifiche per l'individuo.

---

## Interfaccia della finestra

### Area superiore: Informazioni studente

#### Nome studente
Etichetta prominente che mostra **cognome e nome** dello studente corrente.

**Formato**: `COGNOME Nome` (cognome in maiuscolo, nome con iniziale maiuscola)

**Immutabile**: per cambiare studente, chiudere e riaprire dalla finestra principale con studente diverso

#### Codice studente
Campo di testo che mostra l'**IdStudent** (codice numerico identificativo dello studente nel database).

**Funzione**: principalmente per riferimento tecnico, utile per supporto o debug

---

## Parametri di filtro

### Tipo di valutazione
Menu a tendina per selezionare il tipo di voto da visualizzare:
- Voticini
- Orali
- Scritti
- Pratici
- Scritto-grafici
- Altri tipi personalizzati

**Effetto**: cambiando il tipo, la griglia dei voti si aggiorna automaticamente mostrando solo i voti del tipo selezionato.

### Materia
Menu a tendina per selezionare la materia:
- Elenco di tutte le materie configurate nel sistema
- Include solo materie effettivamente utilizzate (esclude materie vuote/inutilizzate)

**Effetto visivo**: il colore di sfondo della finestra cambia in base alla materia selezionata, come nelle altre finestre del programma.

**Effetto dati**: la griglia mostra solo i voti dello studente per la materia selezionata.

### Periodo temporale

#### Periodo scolastico
Menu a tendina con periodi predefiniti:
- **Quadrimestri**: 1° quadrimestre, 2° quadrimestre
- **Trimestri**: 1° trimestre, 2° trimestre, 3° trimestre
- **Periodi personalizzati**:
  - Ultima settimana
  - Ultimo mese
  - Anno intero
  - Altri periodi configurati nell'anno scolastico

**Funzionamento automatico**: selezionando un periodo, le date di inizio e fine si aggiornano automaticamente nei date picker sottostanti.

#### Date personalizzate
Due date picker per specificare un intervallo temporale preciso:
- **Data inizio periodo**
- **Data fine periodo**

**Flessibilità**: è possibile:
1. Selezionare un periodo predefinito (le date si impostano automaticamente)
2. Poi modificare manualmente le date per un intervallo custom

**Effetto**: i voti visualizzati sono solo quelli con data compresa nell'intervallo specificato.

---

## Griglia dei voti

La sezione centrale della finestra mostra una griglia (DataGridView) con tutti i voti dello studente che corrispondono ai filtri attivi.

### Colonne visualizzate

- **IdGrade**: codice identificativo univoco del voto nel database
- **Date**: data in cui è stato registrato il voto
- **Grade**: voto numerico (es. 7, 8.5, 6-)
- **Weight**: peso del voto (importanza relativa per il calcolo della media)
- **Text**: testo o descrizione della valutazione (facoltativo)
- **IdQuestion**: codice della domanda associata al voto (se presente)
- Altri campi tecnici

### Interazione con la griglia

**Click singolo**:
- Seleziona una riga (voto)
- Evidenzia i dettagli per facilitare la lettura

**Doppio click su un voto**:
- Apre la finestra di dettaglio della valutazione (frmGrade)
- Mostra informazioni complete: data, voto, peso, domanda, risposta studente, commenti dell'insegnante
- **Non permette modifiche dirette** ma visualizzazione completa del contesto

**Click su intestazione colonna**:
- Ordina la griglia per quella colonna
- Primo click: ordine crescente
- Secondo click: ordine decrescente
- Utile per vedere voti cronologicamente (ordina per data) o per valore (ordina per grade)

### Modifica voti dalla griglia

**Comportamento speciale**: è possibile modificare alcuni campi direttamente dalla griglia.

**Campi modificabili**:
- **Grade**: il voto numerico può essere cambiato
- **Weight**: il peso può essere modificato
- Altri campi specifici se configurati

**Salvataggio modifiche**:
Le modifiche fatte nella griglia vengono salvate automaticamente quando:
1. Si chiude la finestra
2. Si passa ad un'altra riga
3. Il programma rileva una modifica confermata

**Importante**: modificare un voto nella griglia **crea un nuovo voto con lo stesso IdGrade ma valori aggiornati**, e il voto precedente viene mantenuto con peso 0 per storico. Questa è una funzionalità di audit per tracciare le modifiche ai voti.

---

## Campi calcolati: Medie e pesi

Nella parte inferiore della finestra, tre campi mostrano statistiche calcolate automaticamente sui voti visualizzati:

### Media ponderata
Campo di testo che mostra la **media ponderata** (weighted average) di tutti i voti visibili.

**Formula**:
```
Media Ponderata = ?(voto × peso) / ?(peso)
```

**Esempio**:
- Voto 1: 8 con peso 1 ? contributo: 8
- Voto 2: 7 con peso 2 ? contributo: 14
- Voto 3: 9 con peso 1 ? contributo: 9
- Media = (8 + 14 + 9) / (1 + 2 + 1) = 31 / 4 = **7.75**

**Formato**: numero decimale con 2 cifre dopo la virgola (es. "7.25")

**Aggiornamento**: la media si ricalcola automaticamente quando:
- Si modificano voti nella griglia
- Si cambiano i parametri di filtro (materia, periodo, tipo valutazione)
- Si conferma una modifica di un campo modificabile

### Somma pesi
Campo di testo che mostra la **somma totale dei pesi** di tutti i voti visibili.

**Utilità**:
- Indica "quanta valutazione" è stata fatta
- Permette di confrontare il "volume" di valutazione tra studenti
- Aiuta a pianificare quante valutazioni servono ancora

**Esempio**:
- 3 voti con peso 1 ciascuno ? somma pesi = 3
- 2 voti con peso 2 + 1 voto con peso 1 ? somma pesi = 5

**Formato**: numero decimale con 2 cifre dopo la virgola (es. "12.50")

### Interpretazione combinata

La combinazione di media ponderata e somma pesi fornisce informazioni preziose:

- **Media alta + Somma alta**: studente preparato e valutato abbondantemente
- **Media alta + Somma bassa**: studente promettente ma valutato poco (serve conferma)
- **Media bassa + Somma alta**: studente in difficoltà nonostante molte valutazioni
- **Media bassa + Somma bassa**: studente poco valutato e/o in difficoltà (priorità)

---

## Annotazioni sullo studente

La parte inferiore della finestra include una sezione dedicata alle **annotazioni** (note) sullo studente.

### Griglia annotazioni

Griglia separata che mostra tutte le annotazioni registrate per lo studente nell'anno scolastico corrente.

**Colonne**:
- **Date**: data dell'annotazione
- **Text**: testo dell'annotazione
- **IsActive**: se l'annotazione è ancora attiva/rilevante
- **Author**: chi ha creato l'annotazione (opzionale)
- Altri campi tecnici

**Checkbox "Mostra solo attive"**:
- Se spuntato: visualizza solo annotazioni con IsActive = true
- Se non spuntato: visualizza tutte le annotazioni, anche quelle archiviate/risolte

**Utilità**:
- Tenere traccia di eventi significativi (comportamento, assenze, situazioni familiari)
- Annotare progressi o difficoltà specifiche
- Documentare colloqui con genitori o provvedimenti disciplinari
- Registrare note positive (meriti, encomi)

### Gestione annotazioni

**Per creare nuove annotazioni**: usare il pulsante **"Annotaz."** nella finestra principale (che apre frmAnnotationsAboutStudents).

**Da questa finestra**: solo visualizzazione e consultazione, non creazione/modifica diretta.

**Doppio click su un'annotazione**: potrebbe aprire una finestra di dettaglio (se implementata), altrimenti nessun effetto.

---

## Flussi di lavoro tipici

### Scenario 1: Preparazione colloquio con genitori

**Obiettivo**: prepararsi per incontrare la famiglia dello studente

1. Dalla finestra principale, selezionare lo studente
2. Aprire "Voti allievo"
3. Verificare che la materia sia corretta (la propria materia)
4. Selezionare periodo "Anno intero" per visione completa
5. Esaminare la griglia dei voti:
   - Ordinare per data per vedere andamento temporale
   - Verificare se ci sono trend (miglioramento, peggioramento, altalenante)
6. Annotare la media ponderata
7. Scorrere la griglia annotazioni per:
   - Ricordare eventi significativi
   - Verificare assenze o problemi noti
   - Identificare punti di forza da lodare
8. Preparare documentazione stampando o esportando i dati
9. Cambiare tipo valutazione (da Orali a Scritti, ad esempio) per analisi completa

### Scenario 2: Verifica equità valutazioni

**Obiettivo**: assicurarsi che lo studente abbia un numero adeguato di valutazioni

1. Aprire "Voti allievo" per lo studente
2. Selezionare il periodo corrente (es. "1° quadrimestre")
3. Guardare il campo **"Somma pesi"**
4. Confrontare mentalmente con altri studenti (o aprire più finestre per confronto visivo)
5. Se la somma pesi è significativamente diversa:
   - Troppo bassa: programmare più valutazioni per questo studente
   - Troppo alta: eventualmente distribuire meglio le valutazioni

**Nota**: per confronto più sistematico, usare la finestra "Riepilogo Voti Classe"

### Scenario 3: Analisi andamento personale

**Obiettivo**: capire come sta evolvendo la preparazione dello studente

1. Aprire "Voti allievo"
2. Selezionare periodo "Anno intero"
3. Ordinare la griglia per **"Date"** (click sull'intestazione)
4. Leggere i voti cronologicamente:
   - Inizio anno: come era partito?
   - Metà anno: ci sono stati cambiamenti?
   - Recente: qual è la situazione attuale?
5. Identificare pattern:
   - **Trend positivo**: voti crescenti nel tempo (recupero, impegno)
   - **Trend negativo**: voti decrescenti (perdita motivazione, difficoltà accumulate)
   - **Altalenante**: studio discontinuo o argomenti più/meno congeniali
   - **Stabile**: prestazione costante (positiva o negativa)
6. Pianificare interventi:
   - Se trend negativo: colloquio, recupero, strategie di studio
   - Se trend positivo: incoraggiamento, mantenimento sforzo
   - Se altalenante: regolarizzazione studio, supporto metodologico

### Scenario 4: Controllo voti dopo modifica

**Obiettivo**: verificare che una modifica ai voti sia stata applicata correttamente

1. Dopo aver modificato un voto in un'altra finestra (es. frmMicroAssessment)
2. Aprire "Voti allievo"
3. Cercare il voto modificato nella griglia (per data o valore)
4. Verificare che:
   - Il nuovo voto appaia correttamente
   - La media ponderata si sia aggiornata
   - La somma pesi sia corretta
5. Se necessario, ordinare per data per vedere i voti più recenti in cima
6. Controllare la griglia annotazioni se la modifica doveva essere annotata

### Scenario 5: Documentazione per scrutinio

**Obiettivo**: preparare dati per lo scrutinio finale

1. Aprire "Voti allievo" per ogni studente da scrutinare
2. Selezionare il periodo esatto dello scrutinio (es. "2° quadrimestre")
3. Per ogni tipo di valutazione (Orali, Scritti, ecc.):
   - Annotare la media ponderata
   - Verificare il numero di voti (tramite somma pesi e conteggio visivo)
   - Identificare voti particolarmente alti o bassi che richiedono spiegazione
4. Consultare le annotazioni per eventuali situazioni particolari da segnalare
5. Ripetere per ogni studente della classe
6. Compilare la proposta di voto considerando:
   - Medie ponderate dei vari tipi
   - Trend durante il periodo
   - Situazioni particolari annotate

---

## Suggerimenti e best practices

### Usare i filtri in combinazione

Non limitarsi a un solo tipo di valutazione:
- Cambiare tra Orali, Scritti, Pratici per visione completa
- Ogni tipo può dare indicazioni diverse sulle competenze dello studente
- Uno studente può essere forte negli orali ma debole negli scritti o viceversa

### Sfruttare l'ordinamento

Ordinare la griglia strategicamente:
- **Per data**: per vedere evoluzione temporale
- **Per voto**: per identificare picchi positivi e negativi
- **Per peso**: per vedere quali voti "contano di più"

### Prestare attenzione alle annotazioni

Le annotazioni sono memoria storica preziosa:
- Leggere sempre prima di colloqui o decisioni importanti
- Non affidarsi solo ai voti numerici: le annotazioni danno contesto
- Esempi di contesto: "voto basso per assenza prolungata per malattia", "voto alto dopo percorso di recupero"

### Confrontare periodi diversi

Per vedere cambiamenti:
1. Annotare la media del 1° quadrimestre
2. Cambiare a 2° quadrimestre
3. Confrontare le due medie: c'è stato miglioramento? Peggioramento?

### Modificare con cautela

Se si modificano voti direttamente dalla griglia:
- Fare attenzione a non cambiare accidentalmente voti scorrendo
- Ricordare che ogni modifica crea un nuovo record (per audit)
- Documentare il motivo della modifica in un'annotazione se significativa

### Colore di sfondo come promemoria

Il colore della finestra cambia con la materia:
- Aiuta a riconoscere subito quale materia si sta consultando
- Evita errori quando si aprono più finestre contemporaneamente
- Utile in scuole con molte materie simili (es. Matematica e Fisica)

---

## Troubleshooting

### La griglia dei voti è vuota

**Problema**: nessun voto appare nella griglia

**Soluzioni**:
- Verificare che lo studente abbia effettivamente voti per la combinazione materia/tipo/periodo
- Provare ad allargare il periodo (selezionare "Anno intero")
- Cambiare tipo di valutazione per vedere se ci sono voti di altro tipo
- Verificare nella finestra "Riepilogo Voti Classe" se lo studente appare tra quelli senza voti

### La media non si aggiorna dopo modifica

**Problema**: ho modificato un voto ma la media rimane uguale

**Soluzioni**:
- Assicurarsi di aver confermato la modifica (premuto Invio o cambiato riga)
- Chiudere e riaprire la finestra per forzare il ricalcolo
- Verificare che il voto modificato sia effettivamente cambiato nella griglia
- Controllare il peso: se si è cambiato solo il peso di un voto esistente, l'effetto sulla media potrebbe essere minimo

### Le annotazioni non appaiono

**Problema**: la griglia annotazioni è vuota anche se so che ci sono annotazioni

**Soluzioni**:
- Verificare il checkbox **"Mostra solo attive"**: se spuntato, le annotazioni archiviate non appaiono
- Controllare che le annotazioni siano effettivamente per questo studente
- Verificare che le annotazioni siano registrate nell'anno scolastico corrente
- Se le annotazioni sono di altri insegnanti/utenti, potrebbero non essere visibili (dipende da configurazione privacy)

### Doppio click non apre dettaglio voto

**Problema**: facendo doppio click su un voto, nessuna finestra si apre

**Soluzioni**:
- Assicurarsi di fare doppio click sulla riga, non sull'intestazione
- Verificare che la riga contenga effettivamente un voto valido (non riga vuota)
- Alcuni voti particolari (es. voti "chiusi" o "archiviati") potrebbero non aprire dettagli
- Provare prima con singolo click per selezionare, poi doppio click

### Il colore di sfondo non cambia

**Problema**: cambiando materia, il colore della finestra rimane uguale

**Soluzioni**:
- Verificare che le materie abbiano effettivamente colori diversi configurati nel sistema
- Alcune materie potrebbero avere lo stesso colore
- Se tutte le materie hanno colore bianco, configurare i colori da menu Setup ? Materie

### La somma pesi sembra sbagliata

**Problema**: la somma pesi non corrisponde alle aspettative

**Soluzioni**:
- Verificare il periodo: potrebbero esserci voti fuori dal periodo che non vengono conteggiati
- Controllare che tutti i voti visibili abbiano peso > 0 (peso 0 li esclude)
- Alcuni voti potrebbero essere "nascosti" o "chiusi" e non apparire nella somma
- Ricalcolare manualmente sommando i pesi visibili nella colonna Weight

---

## Modifiche ai voti: sistema di audit

### Come funziona il sistema di audit

Quando si modifica un voto dalla griglia:

1. Il programma **non cancella** il voto originale
2. Crea un **nuovo record** nel database con:
   - Stesso IdGrade (per tracciabilità)
   - Nuovo valore del voto
   - Nuovo peso (se modificato)
   - Data/ora di modifica
3. Il voto originale viene mantenuto con **peso = 0** (non conta più nelle medie ma rimane per storico)

### Vantaggi del sistema

- **Tracciabilità completa**: si può sempre vedere com'era il voto prima
- **Protezione da errori**: se si modifica accidentalmente, il valore originale non è perso
- **Audit per verifiche**: in caso di contestazioni, si può dimostrare quando e come i voti sono stati modificati
- **Compliance normativa**: soddisfa requisiti di trasparenza e inalterabilità dei dati scolastici

### Implicazioni pratiche

- Le modifiche sono **sicure**: non si rischia di perdere dati
- Ogni modifica è **tracciata**: timestamp e valore precedente conservati
- Il database **cresce nel tempo**: ogni modifica aggiunge un record (considerare backup e pulizia periodica)
- Le query potrebbero essere **più complesse**: devono filtrare voti con peso 0 per vedere solo quelli "attivi"

---

## Limitazioni note

- **Modifica singola**: la finestra mostra un solo studente alla volta; per confronti, aprire più istanze o usare "Riepilogo Voti Classe"
- **Grafici non disponibili**: non ci sono visualizzazioni grafiche dell'andamento; esportare i dati in CSV e usare Excel per grafici
- **Annotazioni in sola lettura**: da questa finestra non si possono creare/modificare annotazioni, solo consultarle
- **Statistiche limitate**: solo media ponderata e somma pesi; altre metriche (mediana, deviazione standard, ecc.) non sono calcolate
- **Export non diretto**: non c'è un pulsante "Salva su file" come nella finestra Classe; bisogna copiare i dati manualmente o usare screenshot

---

## Integrazione con altre finestre

### Da finestra principale

Il pulsante **"Voti allievo"** apre questa finestra con parametri preimpostati:
- Studente correntemente selezionato/estratto
- Materia correntemente selezionata
- Tipo valutazione correntemente selezionato
- Anno scolastico corrente

### Verso finestra Dettaglio Voto (frmGrade)

**Doppio click su un voto**:
- Apre la finestra di visualizzazione completa del voto
- Mostra: data, voto, peso, domanda posta, risposta studente, commenti insegnante, eventuali allegati
- Permette di comprendere il contesto completo della valutazione

### Relazione con finestra Annotazioni

Le annotazioni visualizzate sono create da:
- Finestra principale ? pulsante **"Annotaz."**
- Finestra frmAnnotationsAboutStudents

Da questa finestra si possono solo **consultare**, non creare/modificare.

### Relazione con finestra Valutazione (frmMicroAssessment)

I voti visualizzati sono creati da:
- Finestra principale ? pulsante **"Valutaz."**
- Finestra frmMicroAssessment (inserimento nuovo voto)

Dopo aver inserito un voto, si può subito controllare in "Voti allievo" che sia stato registrato correttamente.

---

## Casi d'uso avanzati

### Analisi comparativa per tipologia

**Obiettivo**: capire in quali tipi di valutazione lo studente eccelle o ha difficoltà

**Procedura**:
1. Aprire "Voti allievo"
2. Selezionare "Anno intero" come periodo
3. Selezionare "Orali" come tipo
4. Annotare media ponderata (es. 7.5)
5. Cambiare a "Scritti"
6. Annotare media ponderata (es. 6.2)
7. Cambiare a "Pratici" (se applicabile)
8. Annotare media ponderata (es. 8.0)

**Interpretazione**:
- Media Orali > Media Scritti: studente più bravo nell'esposizione che nella produzione scritta
- Media Scritti > Media Orali: studente più preparato nella riflessione che nell'improvvisazione
- Media Pratici alta: buone competenze applicative, potrebbe essere studente con intelligenza cinestesica

**Azione**: personalizzare approccio didattico in base ai punti di forza dello studente

### Verifica recupero dopo insufficienza

**Obiettivo**: controllare se uno studente ha recuperato dopo un periodo di difficoltà

**Procedura**:
1. Aprire "Voti allievo"
2. Selezionare periodo del recupero (es. "2° quadrimestre")
3. Ordinare griglia per data
4. Confrontare voti recenti con voti del periodo precedente:
   - Se media attuale > media precedente: recupero avvenuto
   - Se voti recenti tutti > 6: recupero consolidato
   - Se ancora voti insufficienti: recupero non riuscito

**Documentazione**: aggiungere annotazione per tracciare l'esito del recupero

### Preparazione documenti per BES/DSA

**Obiettivo**: documentare le prestazioni di studenti con Bisogni Educativi Speciali

**Procedura**:
1. Aprire "Voti allievo" per lo studente BES/DSA
2. Selezionare "Anno intero"
3. Per ogni tipo di valutazione:
   - Verificare se le misure compensative/dispensative hanno avuto effetto
   - Confrontare prestazioni con e senza supporti
   - Annotare progressi o criticità persistenti
4. Consultare annotazioni per:
   - Registrare utilizzo strumenti compensativi
   - Documentare situazioni particolari (es. "verifica orale invece di scritta")
   - Tracciare colloqui con famiglia e specialisti
5. Preparare relazione per:
   - Aggiornamento PDP (Piano Didattico Personalizzato)
   - Riunioni GLI (Gruppo di Lavoro per l'Inclusione)
   - Confronti con équipe medica

**Attenzione privacy**: le annotazioni devono rispettare normative su dati sensibili

---

*Questa documentazione fa parte del Manuale Utente di SchoolGrades*
