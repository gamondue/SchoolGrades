# Manuale Utente - SchoolGrades

## Indice

1. [Introduzione](#introduzione)
1. [Avvio e configurazione iniziale](#avvio-e-configurazione-iniziale)
1. [Interfaccia e funzionalità della finestra principale](#interfaccia-e-funzionalità-della-finestra-principale)
1. [Gestione classi e studenti](#gestione-classi-e-studenti)
1. [Valutazioni e voti](#valutazioni-e-voti)
1. [Gestione lezioni e argomenti](#gestione-lezioni-e-argomenti)
1. [Suggerimenti e scorciatoie](#suggerimenti-e-scorciatoie)
1. [Documentazione finestre specifiche](#documentazione-finestre-specifiche)

---

## Introduzione

**SchoolGrades** è un'applicazione Windows Forms progettata per supportare gli insegnanti nella gestione quotidiana delle attività didattiche in classe. Il programma permette di:

- Gestire classi e studenti
- Registrare valutazioni di diversi tipi (orali, scritti, pratici, ecc.)
- Tenere traccia degli argomenti svolti nelle lezioni
- Effettuare sorteggi e ordinamenti degli studenti secondo vari criteri
- Visualizzare riepiloghi di voti e statistiche
- Gestire annotazioni sugli studenti
- Utilizzare timer e strumenti per l'organizzazione della lezione

### Importante: la potenza del doppio click

**SchoolGrades realizza molte funzionalità attraverso il doppio click su elementi dell'interfaccia utente.**  
Queste funzionalità sono estremamente comode, ma solo se si sa che esistono. **Vi incoraggiamo caldamente a sperimentare il doppio click**, in particolare sulle **griglie** e sugli **elenchi**, per scoprire funzioni rapide e scorciatoie che renderanno l'uso del programma molto più efficiente.  
Il singolo file click di solito provvede alla selezione di un elemento nella griglia o nella lista.

Ad esempio:
- **Doppio click su una riga della griglia studenti** apre la finestra di gestione della classe dello studente selezionato
- **Doppio click sulla lista delle classi** apre la finestra di gestione della classe selezionata
- **Doppio click sul campo della domanda corrente** apre la finestra di scelta domanda

---

## Avvio e configurazione iniziale

### Primo avvio

Al primo avvio, il programma richiede la sua di configurazione, a tal scopo si aprirà la pagina setup, nella quale bisogna scegliere il file di database.  
Per cominciare ad usare il programma bisogna configurare:

1. **Percorso del database**: nella pagina "Setup" selezionare un database **locale** SQLite dove verranno memorizzati tutti i dati.  (nel codice attuale sono presenti classi e metodi che utilizzano SQL server, ma non è possibile usarli perchè sono incompleti e non testati).  Attualmente il programma sceglie per default un database vuoto presente nel file zip di distribuzione, ma questa parte dovrebbe ssere cambiata per rendere automatica la prima esecuzione con database vuoto.
2. **Anno scolastico**: scegliere o creare l'anno scolastico interessato (pagina "gestione classi" in "Setup").
3. **Classi**: inserire le classi che si intendono gestire (vedi "Gestione classi" nella pagina "Setup").

### Finestra Setup

Dal pulsante **"Setup"** nella schermata principale è possibile accedere alle opzioni di configurazione del programma, tra cui:

- Impostazioni di connessione al database
- Preferenze generali dell'interfaccia
- Configurazione dei tipi di valutazione
- Gestione delle materie insegnate
- Configurazione dei periodi scolastici

Alla chiusura della finestra "Setup" il programma deve salvare un file di testo, nel quale scrive i dati di configurazione. Pertanto, dopo aver effettuato la prima configurazione ed anche dopo aver cambiato una configurazione, è necessario premere il bottone "Salva config.".

---

## Interfaccia e funzionalità della finestra principale

L'interfaccia principale di SchoolGrades è divisa in diverse aree funzionali:

### Area superiore sinistra

- **Anno scolastico**: menu a tendina per selezionare l'anno scolastico corrente
- **Elenco classi**: lista delle classi dell'anno selezionato  
  *Importante*: fare doppio click su una classe per aprire la finestra di gestione completa della classe
- Zona di definizione dei timer e della visualizzazione degli elementi sottostanti
- Pulsante "Gruppi", per la formazione di gruppi di studenti fra quelli attualmente selezionati

### Area inferiore sinistra

- **Nome e foto dello studente estratto/selezionato**  
oppure
- **Griglia studenti**: visualizzazione tabulare degli studenti della classe corrente con segni di spunta per la selezione multipla.  
  *Importante*: fare doppio click su uno studente per selezionarlo e per vederne la foto

  Le due modalità di visualizzazione sono controllate anche dal segno di spunta "Lista visibile"

### Bottoni e segni di spunta centrali
- **Bottone "Setup"**: lancia la finestra di configurazione del programma
- **Segno "lezioni"**: prende fra le immagini delle lezioni fatte l'immagine da visualizzare a caso con il bottone "Immagine casuale"
- **Segno "cartella"**: prende nella cartella indicata a sinistra l'immagine da visualizzare a caso con il bottone "Immagine casuale"
- **Bottone "Immagine casuale"**: fa aprire un'immagine a caso fra quelle della cartella selezionata sopra
- **Bottone "Numero casuale"**: fa aprire una finestra che permette si generare un numero casuale"
- **Bottone "Start Links"**: fa aprire automaticamente un insieme di URL, cartelle o file che viene configurato nel database della classe, nella finestra "gestione classi" (vedere in seguito)
- **Bottone "Mosaico"**: fa aprire una finestra con in una griglia di tutte le foto degli studenti della classe corrente
- Bottoni per la selezione massiva degli studenti (vedi in seguito)

### Area a destra

- **Criteri di sorteggio/ordinamento**: gruppo di opzioni alternative per scegliere il criterio
- **Materia**: menu a tendina per selezionare la materia di insegnamento della classe corrente
- **Tipo valutazione**: menu a tendina per selezionare il tipo di voto (orale, scritto, pratico, ecc.)
- **Pulsanti di azione**: numerosi pulsanti per le operazioni principali (vedi in seguito)

---

### Gestione classi e studenti

#### Selezione della classe

1. Selezionare l'anno scolastico dal menu a tendina in alto a sinistra
2. Fare click su una classe nell'elenco per visualizzare gli studenti
3. **Doppio click sulla classe** per aprire la finestra di gestione completa

#### Visualizzazione studenti

Gli studenti della classe selezionata vengono visualizzati nella griglia centrale. È possibile:

- **Selezionare uno o più studenti** tramite checkbox
- **Ordinare per colonna** cliccando sull'intestazione
- **Doppio click su uno studente** per aprire la finestra di gestione classe dello studente

#### Gestione della visibilità

Tre checkbox permettono di controllare cosa visualizzare:

- **Nome visibile**: mostra/nasconde il nome dello studente estratto
- **Foto visibile**: mostra/nasconde la foto dello studente estratto
- **Lista visibile**: mostra/nasconde la griglia degli studenti

#### Selezione studenti (checkbox)

Diversi pulsanti permettono di modificare rapidamente la selezione:

- **X tutti**: seleziona tutti gli studenti
- **X nessuno**: deseleziona tutti gli studenti
- **cambio X**: inverte la selezione corrente
- **X no voti**: seleziona solo gli studenti senza voti del tipo selezionato
- **X di vendetta**: applica il fattore di vendetta agli studenti selezionati

---

### Valutazioni e voti

#### Tipi di valutazione

SchoolGrades supporta diversi tipi di valutazione selezionabili dal menu **"Tipo valutazione"**:

- **Voticini**: piccole valutazioni formative
- **Orali**: interrogazioni orali
- **Scritti**: verifiche scritte
- **Pratici**: prove pratiche
- **Scritto-grafici**: elaborati grafici o tecnici

#### Inserimento voti

1. Selezionare la materia
2. Selezionare il tipo di valutazione
3. Fare click sul pulsante **"Valutaz."** per aprire la finestra di inserimento voti

#### Consultazione voti

- **Voti allievo**: visualizza tutti i voti dello studente corrente con possibilità di consultare anche le annotazioni
- **Voti classe**: visualizza un riepilogo dei voti di tutta la classe per la materia e il tipo di valutazione selezionati

#### Fattore di vendetta

SchoolGrades include un meccanismo di "fattore di vendetta" per tenere traccia degli studenti interrogati di recente:

- **FV++**: aumenta il fattore di vendetta dello studente corrente
- **FV--**: diminuisce il fattore di vendetta dello studente corrente
- Il fattore viene visualizzato nel campo **F.V.**

Il sorteggio "Tremenda vendetta" dà maggiore probabilità agli studenti con fattore di vendetta più alto.

---

### Gestione lezioni e argomenti

#### Registro lezioni

Il pulsante **"Lezioni"** apre la finestra di gestione delle lezioni per la materia selezionata, dove è possibile:

- Inserire nuove lezioni con data, durata e argomenti trattati
- Consultare lo storico delle lezioni
- Associare argomenti del programma alle lezioni

#### Argomenti svolti

- **Argom. fatti**: apre la pagina di ricerca degli argomenti già spiegati nel programma didattico
- **File arg. anno**: crea un file di testo con tutti gli argomenti svolti nell'anno scolastico corrente

#### Timer e orologio lezione

Il programma include strumenti per gestire il tempo durante la lezione:

**Orologio lezione**:
- Imposta il minuto di inizio lezione
- Imposta i minuti di durata della lezione
- Imposta i minuti di anticipo per l'allarme di fine lezione
- Il pulsante **"Inizio lezione"** cambia colore in base al tempo trascorso
- **Checkbox "Orologio lezione"**: abilita/disabilita la colorazione automatica
- **Checkbox "Allarme fine lezione"**: abilita/disabilita l'allarme sonoro

**Timer per risposte**:
- La barra di progresso sotto cambia di dimensione con lo scorrere del tempo (della risposta)
- **Click su "T.barra"** per avviare il cronometro (dopo aver scelto il tempo scrivendolo o cliccando su un valore della lista)
- Il tempo scorre fino al completamento della barra

**Timer a colori e a barra**:
- **T.colori**: avvia un cronometro a colori che cambia tonalità con il passare del tempo
- **T.barra**: avvia un cronometro con visualizzazione a barra di progresso
- **Checkbox "Suoni"**: abilita/disabilita i suoni nel timer a colori, ma anche nelle estrazioni casuali
- **Lista intervalli di tempo**:si usa per delezionare rapidamente una la durata del timer (5, 10, 15, 30, 45, 60 minuti)

---

### Funzionalità avanzate

#### Sorteggio e ordinamento studenti

**Modalità di sorteggio/ordinamento**:

Selezionare tra le due opzioni principali:
- **Sorteggio**: estrazione casuale secondo il criterio scelto
- **Ordinam.**: ordinamento deterministico degli studenti

**Criteri disponibili**:

- **Probabilità uguali**: sorteggio equiprobabile fra tutti gli studenti selezionati
- **Peso totale dei voti**: ordinamento secondo il peso totale del tipo di voto selezionato
- **Numero voti**: ordinamento in base al numero di voti del tipo selezionato
- **Alfabetico**: ordinamento alfabetico per cognome e nome
- **Prima voti bassi**: ordinamento per voto crescente (dal più basso)
- **Prima voti vecchi**: ordinamento con precedenza ai voti più datati
- **Tremenda vendetta**: sorteggio con probabilità proporzionale al fattore di vendetta

**Pulsanti di sorteggio/ordinamento**:

- **Sortegg. o ordin.**: esegue il sorteggio o l'ordinamento secondo il criterio selezionato
- **Costretto**: sceglie automaticamente il prossimo studente dell'elenco ordinato o casuale
- **Voto più vecchio**: sceglie lo studente con il voto più vecchio del tipo selezionato

**Checkbox "suspence"**: attiva una pausa e una musica prima dell'estrazione per aumentare la suspense

#### Domande e test

- **Scelta domanda**: apre la finestra per selezionare una domanda da porre allo studente/i che verrà/anno selezionato/i in seguito
- **Campo domanda corrente**: visualizza il testo della domanda selezionata (doppio click per cambiarla)
- **Checkbox "Domande pop up"**: abilita la visualizzazione casuale di domande durante la lezione
- **Campo tempo pop up**: imposta l'intervallo medio (in minuti) tra una domanda pop-up e l'altra

*Suggerimento*: doppio click per aprire la finestra di scelta domanda
 
#### Immagini e foto

**Foto studenti**:
- Le foto degli studenti vengono visualizzate automaticamente quando estratti o selezionati
- **Doppio click sulla foto** per aprire la finestra con i dati di quello studente

**Immagini casuali**:
- **Sorgente immagini**: scegliere tra "lezioni" (immagini mostrate durante le lezioni) o "cartella" (da una cartella specifica)
- **Campo cartella**: percorso della cartella contenente le immagini  
  *Suggerimento*: click per aprire un file nella cartella, doppio click per sfogliare
- Pulsante **".."**: seleziona una nuova cartella
- **Immagine casuale**: visualizza un'immagine casuale dalla sorgente selezionata

**Mosaico**:
- Il pulsante **"Mosaico"** visualizza tutte le foto della classe in una griglia

#### Gruppi

Il pulsante **"Gruppi"** apre la finestra per la formazione di gruppi di studenti secondo vari criteri (casuali, bilanciati per voti, ecc.).

#### Annotazioni

- **Annotaz.**: apre la finestra per assegnare annotazioni di gruppo agli studenti selezionati
- Le annotazioni possono essere consultate anche dalla finestra "Voti allievo"

#### Collegamenti esterni (Start links)

Il pulsante **"Start links"** permette di lanciare programmi, siti web o file associati alla classe corrente. Ad esempio:

- Collegamenti a registri elettronici
- Materiali didattici online
- Risorse specifiche per la classe

#### Numero casuale

Il pulsante **"Numero casuale"** estrae un numero casuale nell'intervallo specificato, utile per sorteggi rapidi o domande numerate.

---

## Suggerimenti e scorciatoie

### Doppio click (da provare!)

Come menzionato all'inizio, **il doppio click è la chiave per sbloccare molte funzioni rapide**:

- **Griglia studenti**: doppio click su uno studente apre la finestra di gestione classe
- **Lista classi**: doppio click su una classe apre la gestione completa
- **Foto studente**: doppio click apre la scheda per la gestione delle informazioni sullo studente
- **Campo domanda corrente**: doppio click apre la finestra di scelta domanda
- **Campo cartella immagini**: doppio click apre la finestra di selezione cartella
- **Lista intervalli tempo**: doppio click imposta immediatamente l'intervallo selezionato

### Tooltip informativi

**Posizionare il mouse sui controlli per qualche istante** per visualizzare suggerimenti contestuali che descrivono la funzione del controllo.

### Salvataggio automatico in background

Un piccolo indicatore visivo (rettangolo grigio/rosso) in basso a sinistra diventa rosso quando il programma sta salvando dati in background. Non è necessario salvare manualmente; SchoolGrades gestisce automaticamente la persistenza dei dati.

### Personalizzazione

Molte impostazioni di visualizzazione e comportamento possono essere personalizzate dalla finestra **"Setup"**. Esplorare le varie sezioni per adattare il programma alle proprie esigenze.

### Campo Id allievo e Id classe

I campi **"Id allievo"** e **"Id classe"** sono visibili principalmente per scopi di debug e supporto tecnico. Normalmente non è necessario interagire con essi.

### Pulsante "Test"

Il pulsante rosso **"Test"** (visibile solo in modalità debug) viene utilizzato dagli sviluppatori per testare nuove funzionalità. Gli utenti finali possono ignorarlo.

---

## Risoluzione problemi comuni

### Il database non si apre

Verificare che:
- Il file del database esista nel percorso specificato
- Si disponga dei permessi di lettura/scrittura sulla cartella contenente il database
- Il database non sia aperto da un'altra istanza del programma

### Le foto degli studenti non vengono visualizzate

Controllare che:
- Il percorso della cartella immagini sia configurato correttamente in Setup
- I file immagine abbiano estensione riconosciuta (.jpg, .png, .bmp)
- Il nome del file immagine corrisponda al codice studente o alla convenzione configurata

### L'orologio lezione non funziona

Assicurarsi che:
- La checkbox "Orologio lezione" sia attivata
- I valori di minuto inizio, durata e anticipo siano corretti
- Il timer non sia stato disabilitato nelle impostazioni

---

## Documentazione finestre specifiche

Per informazioni dettagliate sulle finestre specifiche del programma, consultare i seguenti documenti:

### Configurazione e amministrazione
- **[Finestra Setup](frmSetup-Configurazione.md)** - Pannello di configurazione centrale e accesso a tutte le funzioni amministrative
- **[Finestre Secondarie e Specializzate](Finestre-Secondarie.md)** - Guida completa a tutte le finestre di supporto (gestione classi, materie, backup, annotazioni, tag, mosaico, timer, e molte altre)

### Gestione studenti e gruppi
- **[Finestra Gruppi](frmGroups-Gruppi.md)** - Formazione di gruppi di lavoro tra gli studenti presenti
- **[Finestra Gestione Studente](frmStudent-GestioneStudente.md)** - Anagrafica e dati completi degli studenti

### Gestione domande e argomenti
- **[Finestra Scelta Domanda](frmQuestionChoose-SceltaDomanda.md)** - Ricerca e selezione di domande da porre agli studenti
- **[Finestra Gestione Domanda](frmQuestion-GestioneDomanda.md)** - Creazione e modifica domande per interrogazioni
- **[Finestra Argomenti](frmTopics-Argomenti.md)** - Gestione della struttura gerarchica degli argomenti del programma didattico

### Valutazioni e registro
- **[Finestra Valutazione](frmMicroAssessment-Valutazione.md)** - Inserimento e gestione valutazioni dettagliate (microvalutazioni)
- **[Finestra Lezioni](frmLessons-Lezioni.md)** - Registro lezioni con argomenti, note e immagini

### Visualizzazione e analisi voti
- **[Finestra Riepilogo Voti Classe](frmGradesClassSummary-RiepilogoVotiClasse.md)** - Analisi delle valutazioni dell'intera classe
- **[Finestra Riepilogo Voti Allievo](frmGradesStudentsSummary-RiepilogoVotiAllievo.md)** - Analisi dettagliata delle valutazioni di un singolo studente

### Nota sui documenti
Ogni documento fornisce:
- Guida completa all'uso della finestra
- Spiegazione dei controlli e delle funzionalità
- Flussi di lavoro tipici con esempi pratici
- Suggerimenti e best practices
- Risoluzione dei problemi comuni
- Integrazione con altre finestre del programma

Il documento **Finestre Secondarie e Specializzate** raccoglie in modo organizzato la documentazione di oltre 20 finestre di supporto, catalogate per funzione (gestione dati, annotazioni, visualizzazione, utilità, manutenzione).

---
## Supporto e contributi

SchoolGrades è un progetto open source. Per segnalare problemi, richiedere funzionalità o contribuire allo sviluppo, visitare il repository GitHub del progetto.

**L'interfaccia utente è completamente in italiano**, mentre il codice sorgente è in inglese per facilitare la collaborazione internazionale.

Contributi alla documentazione, traduzioni e segnalazioni di errori sono sempre benvenuti!

---

*Manuale aggiornato per la versione .NET 10 di SchoolGrades*
