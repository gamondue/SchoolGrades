# Finestra Gestione Domanda - Manuale Utente

## Introduzione

La finestra **Gestione Domanda** (frmQuestion) permette di creare, modificare e gestire le domande che verranno poi utilizzate durante le interrogazioni. Ogni domanda può avere risposte multiple, essere associata ad argomenti, tag e avere caratteristiche come difficoltà, durata e peso di default.

**ATTENZIONE: QUESTO FILE E' PRELIMINARE E NON REVISIONATO.  
POTREBBE CONTENERE INFORMAZIONI NON ESATTE**  
Comunica con un ticket su GiHub eventuali errori riscontrati.
 
## Accesso alla finestra

**Dalla finestra "Scelta domanda"**:
- **Doppio click su una domanda**: apre in modalità modifica
- **Pulsante "Aggiungi domanda"**: apre in modalità creazione

**Da altre finestre**:
- Dalla finestra "Valutazione" con doppio click sul campo domanda
- Da contesti dove serve creare/modificare domande

## Modalità di apertura

### Modalità "Modifica singola domanda"
- Apre una domanda esistente per modificarla
- Pulsante **"Salva e Esci"**: salva e chiude
- **Non** visibile pulsante "Nuova domanda"

### Modalità "Creazione multiple domande"
- Permette di creare molte domande in sequenza
- Pulsante **"Salva"**: salva ma lascia finestra aperta
- Pulsante **"Nuova domanda"**: svuota campi per crearne un'altra
- Pulsante **"Salva e Scegli"**: salva, chiude e restituisce la domanda

---

## Interfaccia della finestra

### Sezione superiore: Dati principali domanda

#### Codice domanda (IdQuestion)
- Campo di testo (sola lettura) con identificativo univoco
- **Sfondo rosso**: domanda non ancora salvata (Id = 0)
- **Sfondo bianco**: domanda esistente nel database

#### Testo domanda
- Campo di testo multi-riga per il testo completo della domanda
- **Cosa scrivere**: la domanda esatta da porre allo studente
- **Lunghezza consigliata**: 1-4 righe (max 500 caratteri)
- Questo testo apparirà durante le valutazioni

**Suggerimenti**:
- Scrivere in forma interrogativa chiara
- Evitare ambiguità
- Includere dati necessari per risposta (es. "nella figura A")

#### Materia (cmbSchoolSubject)
Menu a tendina per selezionare la materia.
- **Obbligatorio**: ogni domanda deve avere una materia
- **Effetto**: cambia il colore di sfondo della finestra
- Permette poi di filtrare domande per materia

#### Tipo domanda (cmbQuestionType)
Menu a tendina per selezionare il tipo:
- Vero/Falso
- Scelta multipla
- Risposta aperta
- Esercizio
- Problema
- Altro (tipi personalizzati)

**Uso**: permette filtri e statistiche per tipo di domanda

### Sezione caratteristiche domanda

#### Peso (Weight)
Campo numerico che indica l'importanza della domanda.
- Valori tipici: 1-5
- Default: 2
- Usato come peso predefinito nelle microvalutazioni

#### Durata (Duration)
Tempo previsto in minuti per rispondere.
- Valori tipici: 2-15 minuti
- Usato per timer durante interrogazione
- Aiuta a pianificare tempi

#### Difficoltà (Difficulty)
Livello di difficoltà su scala numerica.
- Valori tipici: 1-10 (1=facile, 10=molto difficile)
- Soggettivo ma utile per filtri
- Permette interrogazioni progressive per difficoltà

#### Immagine (QuestionImage)
Nome file di un'eventuale immagine associata alla domanda.
- Percorso relativo a cartella immagini
- Es. "geometria/triangolo_rettangolo.png"
- Visualizzata durante interrogazione

**Pulsante "..." (cartella)**: apre la cartella immagini per selezionare file

---

### Sezione argomento

#### Campo testo argomento
Mostra il percorso completo dell'argomento associato (es. "Matematica > Algebra > Equazioni lineari").

#### Pulsante "Scegli argomento"
Apre la finestra Argomenti per selezionare l'argomento della domanda.
- **Importante**: associare sempre un argomento per permettere filtri efficaci

#### Pulsante "Argomento per periodo"
Permette di scegliere un argomento tra quelli effettivamente svolti dalla classe in un periodo.
- Richiede classe di riferimento
- Utile per domande su argomenti recenti

---

### Sezione tag

#### Lista tag associati
Mostra i tag attualmente associati alla domanda.

**Cosa sono i tag**: etichette che categorizzano trasversalmente le domande.

**Esempi**: "teoria", "esercizio", "fondamentale", "difficile", "prerequisito", "esame"

#### Pulsante "Aggiungi tag"
Apre finestra per selezionare e aggiungere un tag.
- I tag aggiunti appaiono nella lista
- Si possono aggiungere più tag alla stessa domanda

#### Pulsante "Rimuovi tag"
Rimuove il tag selezionato nella lista.

**Uso strategico tag**: creare un sistema coerente di tag per filtrare domande efficacemente.

---

### Sezione risposte

#### Griglia risposte (dgwAnswers)
Mostra le risposte associate alla domanda (per domande a scelta multipla o vero/falso).

**Colonne**:
- **IdAnswer**: codice risposta
- **Text**: testo della risposta
- **IsCorrect**: se la risposta è corretta (vero/falso)

**Interazione**:
- **Doppio click su una risposta**: apre finestra per modificarla

#### Pulsante "Aggiungi risposta"
Apre finestra per creare una nuova risposta per la domanda.
- Inserire testo risposta
- Spuntare se corretta o errata
- Salvare

**Uso**: per domande a scelta multipla, creare 4-5 risposte di cui 1 corretta. Per domande aperte, le risposte sono opzionali (possono essere risposte di esempio o parole chiave attese).

---

## Pulsanti di azione principali

### Pulsante "Salva" / "Salva e Esci"

**Funzione**: salva tutti i dati della domanda nel database.

**Procedura**:
1. Compilare tutti i campi obbligatori (testo, materia)
2. Fare click su "Salva"
3. Se IdQuestion era 0 (rosso), viene assegnato un Id univoco
4. Tutti i campi vengono salvati
5. Tag e risposte vengono associati
6. In modalità "Salva e Esci", la finestra si chiude

**Validazione**: testo domanda non può essere vuoto

### Pulsante "Nuova domanda"

**Funzione**: svuota i campi per creare una nuova domanda mantenendo alcuni valori.

**Procedura**:
1. Fare click su "Nuova domanda"
2. IdQuestion torna a 0 (sfondo rosso)
3. Testo domanda si svuota (campo beige per indicare "nuovo")
4. Peso, durata, difficoltà, tipo e materia rimangono (per domande simili)
5. Tag rimangono (utile per serie di domande con stessi tag)
6. Compilare nuova domanda e salvare

**Uso**: creare rapidamente molte domande simili senza ricompilare ogni volta materia, tipo, ecc.

### Pulsante "Salva e Scegli"

**Funzione**: salva la domanda, chiude la finestra e restituisce la domanda alla finestra chiamante.

**Uso**: quando serve creare una domanda al volo e usarla subito in una valutazione.

---

## Flussi di lavoro tipici

### Scenario 1: Creare una domanda singola

**Obiettivo**: inserire una nuova domanda per interrogazioni

1. Dalla finestra "Scelta domanda", fare click su **"Aggiungi domanda"**
2. La finestra si apre in modalità creazione
3. **Compilare**:
   - Testo: "Enuncia il teorema di Pitagora"
   - Materia: Matematica
   - Tipo: Risposta aperta
   - Peso: 2
   - Durata: 3
   - Difficoltà: 3
4. Fare click su **"Scegli argomento"** → selezionare "Matematica > Geometria > Teoremi > Pitagora"
5. Fare click su **"Aggiungi tag"** → selezionare "teoria"
6. Fare click su **"Aggiungi tag"** → selezionare "fondamentale"
7. Fare click su **"Salva e Esci"**
8. La domanda è creata e disponibile

### Scenario 2: Creare molte domande simili

**Obiettivo**: inserire 10 domande di esercizi simili

1. Aprire finestra in modalità creazione
2. Impostare:
   - Materia: Matematica
   - Tipo: Esercizio
   - Peso: 1
   - Durata: 5
   - Difficoltà: 2
   - Argomento: "Algebra > Equazioni lineari"
   - Tag: "esercizio"
3. Testo prima domanda: "Risolvi: 2x + 3 = 7"
4. Fare click su **"Salva"**
5. Fare click su **"Nuova domanda"** (materia, tipo, peso, ecc. rimangono)
6. Testo seconda domanda: "Risolvi: 5x - 2 = 13"
7. Fare click su **"Salva"**
8. Ripetere per tutte le 10 domande
9. Chiudere finestra al termine

### Scenario 3: Modificare domanda esistente

**Obiettivo**: correggere errore o aggiornare domanda

1. Dalla finestra "Scelta domanda", cercare la domanda
2. **Doppio click** sulla domanda
3. Si apre in modalità modifica
4. Correggere il testo o modificare caratteristiche
5. Eventualmente aggiungere/rimuovere tag
6. Fare click su **"Salva e Esci"**
7. Le modifiche sono applicate

### Scenario 4: Creare domanda a scelta multipla

**Obiettivo**: domanda con 4 risposte di cui 1 corretta

1. Creare domanda come al Scenario 1
2. Tipo: Scelta multipla
3. Fare click su **"Aggiungi risposta"**
4. Testo risposta: "Opzione A: ..."
5. Spuntare "Corretta" se è quella giusta
6. Salvare risposta
7. Ripetere per le altre 3 opzioni (B, C, D)
8. Solo una deve essere marcata "Corretta"
9. Salvare la domanda

---

## Suggerimenti e best practices

### Scrivere domande chiare
- Evitare domande ambigue o a trabocchetto
- Includere tutti i dati necessari nel testo
- Usare linguaggio appropriato al livello studenti

### Categorizzare sistematicamente
- Associare sempre argomento specifico (non generico)
- Usare tag in modo coerente
- Mantenere classificazione omogenea tra domande simili

### Pesare realisticamente
- Peso 1: domande semplici di verifica
- Peso 2-3: domande standard del programma
- Peso 4-5: domande fondamentali o complesse

### Stimare durate ragionevoli
- 2-3 minuti: definizioni, fatti
- 4-6 minuti: spiegazioni, procedimenti
- 7-10 minuti: problemi, ragionamenti articolati
- >10 minuti: domande complesse che meritano più microvalutazioni

### Creare serie omogenee
- Quando si creano molte domande simili (esercizi), usare "Nuova domanda" per mantenere caratteristiche comuni
- Numerare eventualmente (es. "Esercizio 1:", "Esercizio 2:")

---

## Troubleshooting

### Non riesco a salvare la domanda

**Problema**: click su "Salva" non funziona o da errore

**Soluzioni**:
- Verificare che testo domanda non sia vuoto
- Verificare che materia sia selezionata
- Controllare che i valori numerici siano validi (peso, durata, difficoltà)

### L'argomento non si associa

**Problema**: dopo aver scelto argomento, non appare nel campo

**Soluzioni**:
- Verificare di aver confermato scelta nella finestra Argomenti
- Controllare che l'argomento esista e sia selezionato
- Salvare la domanda per rendere persistente l'associazione

### Le risposte non appaiono

**Problema**: dopo aver aggiunto risposte, la griglia è vuota

**Soluzioni**:
- Salvare prima la domanda (serve IdQuestion valido)
- Poi aggiungere risposte
- Le risposte vengono associate all'IdQuestion

### Il colore di sfondo cambia

**Nota**: questo è normale! Il colore di sfondo cambia in base alla materia selezionata (come in altre finestre del programma).

---

## Integrazione con altre finestre

### Da finestra Scelta Domanda
- **Doppio click**: apre questa finestra in modalità modifica
- **Pulsante "Aggiungi domanda"**: apre in modalità creazione

### Da finestra Valutazione
- **Doppio click su campo domanda**: apre in modalità modifica la domanda associata

### Verso finestra Argomenti
- **Pulsante "Scegli argomento"**: apre frmTopics per selezionare argomento

### Verso finestra Tag
- **Pulsante "Aggiungi tag"**: apre frmTag per selezionare/creare tag

### Verso finestra Risposta
- **Pulsante "Aggiungi risposta"**: apre frmAnswer per creare risposta
- **Doppio click su risposta**: apre frmAnswer per modificarla

---

## Limitazioni note

- **Un argomento per domanda**: non si possono associare più argomenti (ma si possono usare tag per categorizzazioni trasversali)
- **Immagini esterne**: le immagini devono essere nella cartella configurata, non embedded
- **Modifica risposte**: bisogna riaprire la finestra Answer per ogni risposta
- **Ordinamento risposte**: non c'è controllo sull'ordine di visualizzazione delle risposte

[Pagina principale](Manuale-Utente-SchoolGrades.md)
---

*Questa documentazione fa parte del Manuale Utente di SchoolGrades*
