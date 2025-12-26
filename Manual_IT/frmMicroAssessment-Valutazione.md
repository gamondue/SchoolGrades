# Finestra Valutazione (Micro Assessment) - Manuale Utente

## Introduzione

La finestra **Valutazione** (frmMicroAssessment) è il cuore del sistema di registrazione dei voti in SchoolGrades. Permette di inserire valutazioni dettagliate (microvalutazioni o "voticini") che vengono poi aggregate in voti complessivi (macrovalutazioni). Questa finestra implementa un sistema sofisticato di valutazione basato su pesi e medie ponderate.

**ATTENZIONE: QUESTO FILE E' PRELIMINARE E NON REVISIONATO.  
POTREBBE CONTENERE INFORMAZIONI NON ESATTE**  
Comunica con un ticket su GiHub eventuali errori riscontrati.

## Accesso alla finestra

Per aprire la finestra Valutazione:

**Dalla finestra principale**:
1. Selezionare uno studente (tramite estrazione o dalla griglia)
2. Selezionare una materia
3. Selezionare un tipo di valutazione (es. "Orali", "Scritti")
4. Fare click sul pulsante **"Valutaz."**

**Da altre finestre**:
- Dalla finestra "Riepilogo Voti Classe" (modalità "Mancanti") con doppio click su uno studente
- Da altri contesti dove serve inserire rapidamente una valutazione

**Contesto**: la finestra si apre precompilata con studente, materia e tipo valutazione correnti.

---

## Concetti fondamentali

### Sistema di valutazione a due livelli

SchoolGrades utilizza un sistema gerarchico di valutazione:

**Microvalutazione (Voticino)**:
- Voto su una singola domanda o aspetto
- Ha un proprio valore (es. 7, 8.5)
- Ha un peso che indica l'importanza relativa (es. 1, 2, 3)
- Contribuisce alla macrovalutazione

**Macrovalutazione (Voto complessivo)**:
- Sintesi di più microvalutazioni
- Calcolata come media ponderata delle microvalutazioni
- Rappresenta la valutazione finale (es. orale, scritto)
- Ha a sua volta un peso per il calcolo della media finale

**Esempio pratico**:
```
Interrogazione orale (Macrovalutazione)
??? Domanda 1: 7 (peso 1)
??? Domanda 2: 8 (peso 2) ? più importante
??? Domanda 3: 6 (peso 1)
??? Media ponderata: (7×1 + 8×2 + 6×1) / (1+2+1) = 7.25
```

### Stati del voto

**Voto aperto**:
- Macrovalutazione in corso di formazione
- Si possono aggiungere microvalutazioni
- Non ha ancora un valore definitivo (valore = 0 o NULL)

**Voto chiuso**:
- Macrovalutazione completata
- Ha un valore definitivo salvato
- Non si possono più aggiungere microvalutazioni (senza riaprirlo)

---

## Interfaccia della finestra

### Area superiore: Informazioni studente e contesto

#### Dati studente
- **Nome studente**: visualizzato in grande (cognome e nome)
- **Foto studente**: a sinistra, se disponibile
  - **Doppio click sulla foto**: apre finestra di gestione dello studente
- **Id studente**: codice numerico identificativo
- **Checkbox "BES/DSA"**: indica se lo studente ha Bisogni Educativi Speciali

#### Contesto valutazione
- **Materia**: campo di testo con la materia corrente
- **Tipo valutazione**: (es. "Orali - Interrogazioni")
- **Tipo valutazione padre**: tipo di voto che contiene questo (struttura gerarchica)
- **Codice voto complessivo**: IdGrade della macrovalutazione corrente
  - **Sfondo rosso**: non esiste ancora un voto complessivo (crearlo con "Nuovo voto")
  - **Sfondo bianco**: voto complessivo esistente

---

## Sezione centrale: Gestione microvalutazioni

### Griglia microvalutazioni

Mostra tutte le microvalutazioni del voto complessivo correntemente aperto.

**Colonne**:
- **IdGrade**: codice della microvalutazione
- **Value**: voto numerico
- **Weight**: peso della microvalutazione
- **Date**: data di registrazione
- **Text**: testo della domanda (se associata)
- Altri campi

**Interazione**:
- **Click singolo**: seleziona una microvalutazione, i suoi dati appaiono nei campi sottostanti
- **Doppio click**: (attualmente non implementato)

**Colore sfondo**:
- Le microvalutazioni contribuiscono alla media mostrata nei campi sotto la griglia

### Campi di inserimento microvalutazione

#### Voto (Value)
- Campo di testo per il voto numerico
- Valori tipici: da 1 a 10 (o scala configurata)
- **Trackbar (scorrimento)**: sotto il campo per selezione rapida
  - Muovere la barra per impostare il voto
  - Il valore si aggiorna automaticamente nel campo testo

#### Peso (Weight)
- Campo di testo per il peso della microvalutazione
- Valori tipici: 1, 2, 3 (raramente oltre 5)
- **Trackbar (scorrimento)**: sotto il campo per selezione rapida
- **Peso predefinito**: si imposta automaticamente dal tipo di valutazione o dalla domanda

**Interpretazione pesi**:
- **Peso 1**: domanda semplice o di routine
- **Peso 2**: domanda standard di media difficoltà
- **Peso 3**: domanda importante o complessa
- **Peso 4-5**: domande fondamentali o particolarmente difficili

#### Domanda associata
- **Campo testo domanda**: mostra il testo della domanda scelta
  - **Doppio click**: apre finestra di modifica della domanda
- **Pulsante "Scelta domanda"**: apre finestra di scelta domanda
  - Permette di cercare e selezionare una domanda dal database
  - La domanda viene associata alla microvalutazione
  - Il peso si imposta automaticamente da quello della domanda
- **Pulsante "Nessuna domanda"**: rimuove l'associazione con la domanda
  - Utile per valutazioni generiche senza domanda specifica

---

## Campi calcolati: Statistiche

Sotto la griglia, tre campi mostrano statistiche aggregate:

### Somma pesi
Mostra la somma totale dei pesi di tutte le microvalutazioni del voto aperto.

**Colore di sfondo**:
- **Verde**: ? 95 (molto sopra la soglia standard)
- **Giallo**: 66-94 (vicino alla soglia)
- **Arancione**: 46-65 (sotto la soglia ma accettabile)
- **Bianco**: < 46 (pochi voticini, serve interrogare di più)

**Interpretazione**:
- Valori tipici: 60-100
- Indica "quanto si è interrogato" lo studente
- Permette di confrontare l'equità: tutti gli studenti dovrebbero avere somme simili

### Media microvalutazioni
Media ponderata di tutte le microvalutazioni.

**Formula**:
```
Media = ?(voto × peso) / ?(peso)
```

**Uso**:
- Rappresenta la prestazione effettiva dello studente
- Questo valore verrà salvato come voto complessivo quando si chiude

### Peso voto complessivo
Peso predefinito per il voto complessivo (macrovalutazione).

**Funzione**:
- Indica quanto questo voto conterà nella media finale
- Tipicamente configurato nel tipo di valutazione
- Es. scritti potrebbero pesare 3, orali 2

---

## Pulsanti di azione principali

### Pulsante "Salva voticino"

**Funzione**: salva la microvalutazione corrente nella griglia.

**Procedura**:
1. Opzionalmente, scegliere una domanda con "Scelta domanda"
2. Inserire il voto (obbligatorio)
3. Verificare/modificare il peso (obbligatorio)
4. Fare click su "Salva voticino"
5. La microvalutazione appare nella griglia
6. I campi voto e peso si svuotano per la prossima

**Validazioni**:
- Se non c'è un voto complessivo aperto (sfondo rosso), viene chiesto di crearne uno
- Se il voto complessivo è chiuso, viene offerta l'opzione di riaprirlo
- Voto e peso devono essere > 0

**Effetto**:
- Aggiunge una nuova riga alla griglia
- Aggiorna automaticamente somma pesi e media
- La domanda viene registrata come "già fatta" per evitare ripetizioni

### Pulsante "Nuovo voto"

**Funzione**: crea un nuovo voto complessivo (macrovalutazione) aperto.

**Quando usarlo**:
- All'inizio di una nuova sessione di interrogazioni
- Quando il voto precedente è stato chiuso
- Per separare valutazioni di periodi diversi

**Procedura**:
1. Fare click su "Nuovo voto"
2. Viene creato un nuovo voto complessivo aperto
3. Il campo "Codice voto complessivo" mostra il nuovo codice (sfondo bianco)
4. La griglia si svuota (pronta per nuove microvalutazioni)
5. Si possono iniziare ad aggiungere voticini

**Blocco**:
- Se ci sono già microvalutazioni non chiuse, viene richiesto di chiudere prima il voto corrente

### Pulsante "Chiudi voto"

**Funzione**: chiude il voto complessivo salvando la media come valore definitivo.

**Quando usarlo**:
- Quando si è finito di interrogare lo studente
- Quando si ritiene la valutazione completa
- Prima di creare un nuovo voto

**Procedura**:
1. Verificare che la media sia soddisfacente
2. Fare click su "Chiudi voto"
3. Appare messaggio di conferma: "Assegnazione del voto indicato come nuovo voto complessivo"
4. Confermare con "Sì"
5. Il voto viene chiuso con il valore della media ponderata
6. La griglia si svuota (il voto è ora consultabile in altre finestre)

**Validazioni**:
- Somma pesi deve essere > 0
- Media deve essere > 0
- Deve esistere un voto complessivo aperto

**Effetto**:
- Il voto complessivo assume il valore della media
- Il voto viene "consolidato" e contribuisce alla media finale dello studente
- Non si possono più aggiungere microvalutazioni senza riaprire

### Pulsante "Salva modifica voticino"

**Funzione**: salva le modifiche a una microvalutazione esistente.

**Procedura**:
1. Selezionare una microvalutazione dalla griglia (click singolo)
2. I suoi dati appaiono nei campi di inserimento
3. Modificare voto, peso o domanda
4. Fare click su "Salva modifica voticino"
5. La modifica viene salvata e la griglia si aggiorna

**Uso**: correggere errori di digitazione o rivalutazioni

### Pulsante "Cancella voticino"

**Funzione**: elimina la microvalutazione selezionata.

**Procedura**:
1. Selezionare una microvalutazione dalla griglia
2. Fare click su "Cancella voticino"
3. La microvalutazione viene eliminata
4. La griglia, somma pesi e media si aggiornano automaticamente

**Attenzione**: operazione irreversibile, usare con cautela

### Pulsante "Azzera domanda"

**Funzione**: rimuove l'associazione tra la microvalutazione corrente e la domanda.

**Quando usarlo**:
- Se si è scelta la domanda sbagliata
- Se si vuole cambiare domanda
- Per valutazioni generiche senza domanda specifica

---

## Indicatore tempo lezione

In basso nella finestra, un'etichetta colorata **"Tempo lezione"** replica l'indicatore della finestra principale:
- Cambia colore dal verde al rosso man mano che la lezione procede
- Permette di monitorare il tempo rimanente anche durante la valutazione
- Attivo solo se l'orologio lezione è abilitato nella finestra principale

---

## Flussi di lavoro tipici

### Scenario 1: Interrogazione orale standard

**Obiettivo**: registrare un'interrogazione orale con 3-4 domande

1. La finestra si apre con studente, materia e tipo valutazione già impostati
2. **Verificare**: se campo "Codice voto complessivo" ha sfondo rosso:
   - Fare click su **"Nuovo voto"**
   - Il campo diventa bianco con un codice
3. **Prima domanda**:
   - Fare click su **"Scelta domanda"**
   - Cercare e selezionare la domanda
   - La domanda appare nel campo testo
   - Il peso si imposta automaticamente
   - Valutare la risposta e inserire il voto (es. 7)
   - Fare click su **"Salva voticino"**
4. **Seconda domanda**: ripetere il punto 3
5. **Terza domanda**: ripetere il punto 3
6. **Verifica**: controllare la media ponderata
7. **Chiusura**: fare click su **"Chiudi voto"**
8. **Conferma**: confermare nel messaggio
9. La finestra può essere chiusa o si può interrogare un altro studente

### Scenario 2: Valutazione rapida senza domande specifiche

**Obiettivo**: registrare un voto veloce senza associare domande

1. Aprire finestra Valutazione per lo studente
2. Se serve, creare "Nuovo voto"
3. **Inserire direttamente**:
   - Voto: es. 7
   - Peso: es. 2
   - **NON scegliere una domanda**
4. Fare click su **"Salva voticino"**
5. Ripetere per altre valutazioni rapide se necessario
6. Fare click su **"Chiudi voto"** quando completato

**Quando usare**: valutazioni al volo, partecipazione, compiti brevi

### Scenario 3: Correzione di un voto già inserito

**Obiettivo**: modificare una microvalutazione errata

1. Aprire finestra Valutazione (con voto complessivo aperto)
2. Nella griglia, fare **click singolo** sulla microvalutazione da correggere
3. I dati appaiono nei campi di inserimento
4. Modificare il voto (es. da 7 a 7.5) o il peso
5. Fare click su **"Salva modifica voticino"**
6. La griglia si aggiorna con il nuovo valore
7. La media si ricalcola automaticamente

**Nota**: se il voto è già chiuso, bisogna riaprirlo prima

### Scenario 4: Interrogazione lunga con molte domande

**Obiettivo**: interrogazione articolata con 6-8 domande

1. Creare "Nuovo voto" se necessario
2. **Per ogni domanda**:
   - Scegliere la domanda
   - Valutare e salvare voticino
   - La griglia si popola progressivamente
3. **Monitorare** la somma pesi:
   - Se supera 80-100, l'interrogazione è sufficientemente dettagliata
   - Il colore di sfondo diventa giallo/verde
4. **Valutare** la media ponderata:
   - Se soddisfacente, procedere con chiusura
   - Se insoddisfacente ma equa, chiudere comunque (riflette prestazione reale)
5. Fare click su **"Chiudi voto"**

**Suggerimento**: per interrogazioni molto lunghe, considerare di spezzare in più voti complessivi

### Scenario 5: Riapertura voto chiuso per aggiungere domande

**Obiettivo**: aggiungere microvalutazioni a un voto già chiuso

1. Aprire finestra Valutazione per lo studente
2. Il voto complessivo visualizzato è chiuso (griglia vuota, media non modificabile)
3. Tentare di salvare un nuovo voticino
4. Appare messaggio: "La macrovalutazione indicata è chiusa. Vuoi riaprirla?"
5. Rispondere **Sì**
6. Il voto si riapre: le microvalutazioni riappaiono nella griglia
7. Aggiungere le nuove microvalutazioni
8. La media si ricalcola includendo le nuove
9. Fare click su **"Chiudi voto"** per consolidare

**Quando usare**: recupero, interrogazioni suppletive, correzioni sostanziali

---

## Suggerimenti e best practices

### Pesare correttamente le domande

**Linee guida generali**:
- **Peso 1**: domande di verifica, definizioni semplici, esempi
- **Peso 2**: domande standard del curriculum, procedimenti
- **Peso 3**: domande di ragionamento, applicazioni complesse
- **Peso 4-5**: domande fondamentali, prerequisiti per proseguire

**Esempi per materie**:
- Matematica: definizione (1), esercizio standard (2), problema (3), dimostrazione (4)
- Storia: data/fatto (1), spiegazione evento (2), cause/conseguenze (3), analisi critica (4)
- Lingue: traduzione frase (1), comprensione testo (2), produzione (3), analisi grammaticale avanzata (4)

### Bilanciare numero e peso delle domande

**Regola empirica**:
- Somma pesi target: 60-100 per interrogazione completa
- Con peso medio 2: servono 30-50 domande (troppo!)
- Con peso medio 2-3: servono 20-35 domande (ragionevole)
- Con peso medio 3-4: servono 15-25 domande (ottimale)

**Strategia**: poche domande pesanti > molte domande leggere

### Scegliere se associare domande

**Associare domande quando**:
- Si vuole tracciabilità: sapere esattamente cosa è stato chiesto
- Si usano domande complesse o ricorrenti
- Serve analisi statistica: quali domande/argomenti più difficili

**Non associare domande quando**:
- Valutazione al volo, partecipazione
- Domande improvvisate non in database
- Valutazioni rapide/continue (es. esercizi alla lavagna)

**Compromesso**: usare domande "generiche" nel database (es. "Domanda orale generica matematica peso 2")

### Gestire voti aperti per periodi lunghi

**Voto aperto continuo**:
- Utile per valutazioni progressive su settimane/mesi
- Ogni lezione aggiunge microvalutazioni
- Chiudere solo a fine periodo (quadrimestre, unità didattica)

**Vantaggi**:
- Visione completa del percorso studente
- Media riflette tutte le prestazioni
- Equità nel confronto tra studenti

**Svantaggi**:
- Voto finale molto posticipato
- Difficile per studenti capire "come stanno andando"

**Alternativa**: voti complessivi più frequenti (ogni 2-3 lezioni)

### Interpretare colore somma pesi

- **Verde brillante** (>95): forse troppo, rischio "sovra-interrogazione"
- **Verde/Giallo** (66-95): range ottimale, equo e rappresentativo
- **Arancione** (46-65): accettabile ma sul limite inferiore
- **Bianco** (<46): insufficiente, serve interrogare di più

**Attenzione**: confrontare somma pesi tra studenti della stessa classe per equità

### Salvare frequentemente

Durante interrogazioni lunghe:
- Salvare voticino dopo ogni domanda (non aspettare la fine)
- Se crash/problema, i voticini già salvati restano
- Si può sempre correggere/modificare dopo

---

## Troubleshooting

### Non riesco a salvare il voticino

**Problema**: click su "Salva voticino" non funziona o da errore

**Soluzioni**:
- **Sfondo rosso "Codice voto complessivo"**: creare prima "Nuovo voto"
- **Voto o peso vuoti**: inserire valori validi (> 0)
- **Voto complessivo chiuso**: appare messaggio, confermare riapertura
- **Nessuna domanda**: se si vuole associare una domanda, sceglierla prima

### La media sembra sbagliata

**Problema**: la media ponderata non corrisponde alle aspettative

**Soluzioni**:
- Verificare i pesi di ogni microvalutazione nella griglia
- Ricalcolare manualmente: ?(voto × peso) / ?(peso)
- Controllare che tutte le microvalutazioni siano visibili nella griglia
- Verificare che non ci siano voti con peso 0 (non contano)

### Il voto non si chiude

**Problema**: click su "Chiudi voto" da errore o non fa nulla

**Soluzioni**:
- Verificare che somma pesi > 0 (almeno una microvalutazione)
- Verificare che media > 0
- Controllare che il codice voto complessivo sia valido (non "----")
- Se persistente, provare a riavviare il programma e ricaricare

### Le microvalutazioni non appaiono nella griglia

**Problema**: dopo salvataggio, la griglia resta vuota

**Soluzioni**:
- Verificare che il codice voto complessivo sia corretto
- Controllare che il voto non sia stato chiuso per errore
- Provare a chiudere e riaprire la finestra
- Verificare in "Riepilogo Voti Allievo" se i voti sono stati salvati

### Non trovo la domanda giusta

**Problema**: nella finestra "Scelta domanda" non si trova la domanda desiderata

**Soluzioni**:
- Usare i filtri (argomento, tipo, tag) per restringere
- Se la domanda non esiste, creare una nuova domanda dalla finestra "Scelta domanda"
- In alternativa, procedere senza associare domanda (valutazione generica)

### Confusione tra più voti aperti

**Problema**: non si capisce quale voto complessivo si sta modificando

**Soluzioni**:
- Il codice nel campo "Codice voto complessivo" identifica univocamente il voto
- Chiudere sempre i voti completati per evitare confusione
- Usare "Riepilogo Voti Allievo" per vedere tutti i voti dello studente

---

## Integrazione con altre finestre

### Da finestra principale

Il pulsante **"Valutaz."** apre questa finestra con:
- Studente correntemente estratto/selezionato
- Materia correntemente selezionata
- Tipo valutazione correntemente selezionato

**Doppia direzione**: la domanda scelta in questa finestra si propaga alla finestra principale nel campo domanda corrente

### Verso finestra Scelta Domanda

Il pulsante **"Scelta domanda"** apre frmQuestionChoose:
- Filtrata per materia e classe correnti
- Se presente, anche per studente (evita domande già fatte)
- La domanda scelta torna a questa finestra

### Verso finestra Domanda

**Doppio click** sul campo testo domanda:
- Apre frmQuestion per modificare la domanda associata
- Utile per correggere errori nel testo della domanda
- Le modifiche si riflettono immediatamente

### Verso finestra Studente

**Doppio click** sulla foto studente:
- Apre frmStudent per visualizzare/modificare dati anagrafici
- Utile per verificare BES/DSA o altri flag rilevanti per la valutazione

### Da finestra Riepilogo Voti Classe

Doppio click su uno studente in modalità "Mancanti":
- Apre questa finestra per lo studente selezionato
- Permette inserimento immediato del voto mancante
- Contesto ottimale per equilibrare le valutazioni

---

## Casi d'uso avanzati

### Interrogazioni differenziate (BES/DSA)

**Scenario**: studente con BES/DSA necessita di interrogazione adattata

**Approccio**:
1. Verificare che checkbox "BES/DSA" sia spuntato (visibile nella finestra)
2. Scegliere domande appropriate (più semplici o con aiuti)
3. Considerare di usare pesi più bassi se le domande sono facilitate
4. Oppure: usare pesi standard ma domande meno numerose
5. Documentare nelle annotazioni l'adattamento effettuato

**Nota legale**: le valutazioni devono comunque riflettere le competenze acquisite secondo PDP

### Valutazione continua con voto aperto tutto l'anno

**Scenario**: tenere un voto complessivo aperto per tutto l'anno, aggiungendo microvalutazioni ad ogni lezione

**Procedura**:
1. A inizio anno, creare "Nuovo voto" per ogni studente
2. Ad ogni lezione/interrogazione, riaprire la finestra Valutazione per lo studente
3. Aggiungere le nuove microvalutazioni al voto aperto
4. NON chiudere il voto
5. Monitorare costantemente somma pesi per equità tra studenti
6. A fine anno/quadrimestre, chiudere tutti i voti

**Vantaggi**:
- Visione olistica del percorso annuale
- Media molto rappresentativa (decine di microvalutazioni)
- Equità massima (tutti stessa "quantità" di valutazioni)

**Svantaggi**:
- Studenti non hanno voti intermedi visibili
- Gestione più complessa (voti aperti per mesi)
- Somma pesi può diventare molto alta (>200)

### Interrogazioni di gruppo con valutazioni individuali

**Scenario**: interrogazione di gruppo dove ogni studente risponde a domande specifiche

**Procedura**:
1. Aprire finestra Valutazione per primo studente del gruppo
2. Creare "Nuovo voto" se necessario
3. Durante interrogazione, prendere appunti su chi risponde a cosa
4. Salvare voticini per il primo studente (solo sue domande)
5. **Chiudere finestra**, riaprire per secondo studente
6. Salvare voticini per il secondo studente
7. Ripetere per tutti i membri del gruppo
8. Ogni studente ha voticini solo sulle proprie domande

**Alternativa**: usare domande comuni ma voti diversi in base alla qualità risposta

### Recupero debiti con integrazione voti

**Scenario**: studente con debito deve recuperare con interrogazione integrativa

**Procedura**:
1. Aprire "Riepilogo Voti Allievo" per vedere voto insufficiente
2. Annotare IdGrade del voto da integrare
3. Aprire finestra Valutazione per lo studente
4. Il sistema potrebbe caricare automaticamente l'ultimo voto (verificare IdGrade)
5. Se il voto è chiuso, riaprirlo quando richiesto
6. Aggiungere nuove microvalutazioni (interrogazione di recupero)
7. La media si ricalcola includendo le nuove
8. Se media ora sufficiente, chiudere il voto
9. Il voto originariamente insufficiente è ora sufficiente

**Trasparenza**: le microvalutazioni mostrano chiaramente quali erano insufficienti e quali di recupero

---

## Limitazioni e note tecniche

- **Un solo voto aperto per volta**: per studente/materia/tipo, normalmente c'è un solo voto aperto
- **Chiusura irreversibile (con riapertura)**: chiudere un voto lo consolida, ma è possibile riaprirlo
- **Pesi massimi**: tecnicamente illimitati, ma consigliabile restare sotto 10
- **Numero microvalutazioni**: illimitato, ma oltre 50-60 per voto diventa difficile da gestire
- **Modifiche ai voti chiusi**: possibile riaprire, ma attenzione alle medie già comunicate
- **Domande multiple**: una microvalutazione può avere una sola domanda associata

[Pagina principale](Manuale-Utente-SchoolGrades.md)
---

*Questa documentazione fa parte del Manuale Utente di SchoolGrades*
