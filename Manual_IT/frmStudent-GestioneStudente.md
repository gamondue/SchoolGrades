# Finestra Gestione Studente - Manuale Utente

## Introduzione

La finestra **Gestione Studente** (frmStudent) permette di visualizzare, modificare, creare e cercare i dati anagrafici e amministrativi degli studenti. È l'anagrafica centralizzata di SchoolGrades per tutti i dati degli allievi.

**ATTENZIONE: QUESTO FILE E' PRELIMINARE E NON REVISIONATO.  
POTREBBE CONTENERE INFORMAZIONI NON ESATTE**  
Comunica con un ticket su GiHub eventuali errori riscontrati.

## Accesso alla finestra

**Dalla finestra principale**:
- **Doppio click sulla foto dello studente**: apre con studente corrente
- **Doppio click sul nome studente**: apre con studente corrente

**Da altre finestre**:
- Dalla finestra "Valutazione" con doppio click sulla foto
- Da finestra "Riepilogo Voti Allievo"
- Da contesti dove servono dati studente

## Modalità di apertura

### Modalità "Consultazione/Modifica"
- Aperta con uno studente specifico
- Campi precompilati con i suoi dati
- Pulsante **"Salva"**: aggiorna i dati
- Pulsante **"Scegli"**: **non visibile**

### Modalità "Selezione" (Dialog)
- Aperta per scegliere uno studente
- Pulsante **"Scegli"**: **visibile** - conferma e chiude
- Pulsante **"Esci senza scegliere"**: annulla selezione

---

## Interfaccia della finestra

### Sezione sinistra: Dati anagrafici principali

#### Codice studente (IdStudent)
Campo numerico identificativo univoco.
- Assegnato automaticamente alla creazione
- Usato come chiave in tutte le operazioni

#### Cognome (LastName)
Campo di testo per il cognome.
- **Obbligatorio**: non può essere vuoto
- Visualizzato in maiuscolo nella maggior parte delle finestre

#### Nome (FirstName)
Campo di testo per il nome.
- **Obbligatorio**: non può essere vuoto

#### Sesso/Genere (Gender)
Campo di testo libero (es. "M", "F").
- Usato per statistiche o filtri

#### Data di nascita (BirthDate)
Campo data in formato gg/mm/aaaa.
- Usato per calcolare età
- Usato per auguri di compleanno automatici

#### Luogo di nascita (BirthPlace)
Campo di testo per comune di nascita.

---

### Sezione centrale: Residenza e contatti

#### Indirizzo (StreetAddress)
Via e numero civico.

#### CAP (ZipCode)
Codice di avviamento postale.

#### Città (City)
Comune di residenza.

#### Provincia (County)
Sigla provincia (es. "FO", "RM").

#### Stato (State)
Nazione (es. "Italia", "Svizzera").

#### Origine (Origin)
Campo libero per annotare provenienza geografica o etnica (opzionale).

#### Telefono fisso (Telephone)
Numero di telefono (es. famiglia).

#### Cellulare (MobileTelephone)
Numero di cellulare studente.

#### Email
Indirizzo email dello studente o famiglia.

---

### Sezione destra: Flags e caratteristiche

#### Checkbox "Disabile" (Disabled)
Indica se lo studente ha disabilità certificate.
- Usato per adattamenti didattici
- Informazione sensibile (privacy)

#### Checkbox "BES/DSA" (HasSpecialNeeds)
Indica se lo studente ha Bisogni Educativi Speciali o Disturbi Specifici dell'Apprendimento.
- Importante per PDP (Piano Didattico Personalizzato)
- Visibile nelle finestre di valutazione per ricordare adattamenti

#### Foto studente (picStudent)
Mostra la foto dello studente se disponibile.
- Caricata dalla cartella immagini configurata
- Formato: JPG, PNG
- Nome file tipicamente legato a IdStudent

---

### Sezione inferiore: Ricerca e griglia risultati

#### Pulsanti di ricerca

**Pulsante "Cerca studente"**:
- Cerca studenti che corrispondono ai criteri inseriti nei campi
- Cerca per: cognome, nome, città, ecc.
- Ricerca "LIKE" (parziale): "Ros" trova "Rossi", "Rosetti", "De Rosis"

**Pulsante "Cerca omonimo"**:
- Cerca studenti con esatto cognome e nome inseriti
- Utile per verificare duplicati o trovare omonimi in classi diverse

#### Griglia studenti cercati (dgwSearchedStudents)

Mostra i risultati della ricerca.

**Colonne**:
- **IdStudent**: codice
- **LastName, FirstName**: nome completo
- **ClassAbbreviation**: sigla classe corrente
- **SchoolYear**: anno scolastico
- Altri dati anagrafici

**Interazione**:
- **Click su riga** (RowEnter): carica i dati dello studente nei campi sopra
  - I campi si popolano automaticamente
  - La foto (se presente) si carica
- **Doppio click su riga**: apre la finestra di gestione della classe dello studente
  - Permette di vedere/modificare la classe in cui è inserito
  - Utile per verificare composizione classe

---

## Pulsanti di azione principali

### Pulsante "Salva"

**Funzione**: salva i dati dello studente nel database.

**Procedura**:
1. Compilare/modificare i campi desiderati
2. Fare click su **"Salva"**
3. Se IdStudent è vuoto o 0:
   - Viene creato un nuovo studente
   - Assegnato Id univoco
4. Se IdStudent esiste:
   - I dati vengono aggiornati

**Validazione**:
- Cognome e Nome devono essere compilati
- Se entrambi vuoti, appare: "Immettere Nome e Cognome del nuovo allievo"

### Pulsante "Nuovo"

**Funzione**: svuota tutti i campi per inserire un nuovo studente.

**Procedura**:
1. Fare click su **"Nuovo"**
2. Tutti i campi si svuotano (IdStudent torna a vuoto)
3. La foto scompare
4. Compilare i dati del nuovo studente
5. Fare click su **"Salva"**

**Uso**: quando serve creare un nuovo studente da zero

### Pulsante "Aggiungi studente"

**Funzione**: equivalente a **"Nuovo" + "Salva"** in un unico passaggio.

**Procedura**:
1. Compilare i campi con i dati del nuovo studente
2. Fare click su **"Aggiungi studente"**
3. Lo studente viene salvato
4. Appare automaticamente nella griglia di ricerca

**Uso**: inserimento rapido senza dover fare "Nuovo" e poi "Salva"

### Pulsante "Elimina studente"

**Funzione**: elimina lo studente corrente dal database.

**Procedura**:
1. Caricare lo studente da eliminare (nei campi)
2. Fare click su **"Elimina studente"**
3. Appare messaggio: "Eliminare lo studente [Nome]?"
4. Confermare con **Sì**
5. Appare secondo messaggio: "Eliminare lo studente anche dalle tabelle in cui viene riferito?"
   - **Sì**: elimina anche da classi, voti, annotazioni (eliminazione completa)
   - **No**: elimina solo dalla tabella studenti (rimangono riferimenti orfani)

**ATTENZIONE**:
- Operazione irreversibile
- Scegliere "Sì" al secondo messaggio solo se si è sicuri
- Eliminare un studente con voti può causare perdita di dati

**Limitazione**: TODO - dovrebbe bloccare eliminazione se studente ha voti (da implementare)

### Pulsante "Scegli"

**Funzione**: conferma la scelta dello studente e chiude la finestra (solo in modalità Dialog).

**Visibilità**: visibile solo se finestra aperta in modalità selezione

**Procedura**:
1. Cercare e selezionare lo studente desiderato
2. Fare click su **"Scegli"**
3. La finestra si chiude
4. Lo studente scelto viene restituito alla finestra chiamante

**Validazione**: deve esserci uno studente valido caricato (IdStudent > 0)

### Pulsante "Esci senza scegliere"

**Funzione**: chiude la finestra senza selezionare studente (solo in modalità Dialog).

**Uso**: annullare operazione di selezione

### Pulsante "Copia clipboard"

**Funzione**: copia il nome completo dello studente (Cognome Nome) negli appunti.

**Uso**: incolla rapido in altre applicazioni (es. email, documenti)

---

## Flussi di lavoro tipici

### Scenario 1: Consultare dati studente

**Obiettivo**: vedere informazioni complete di uno studente

1. Dalla finestra principale, **doppio click sulla foto** dello studente
2. La finestra si apre con i suoi dati
3. Consultare campi anagrafici, contatti, flags
4. Eventualmente modificare e **"Salva"** se necessario
5. Chiudere finestra

### Scenario 2: Creare nuovo studente

**Obiettivo**: inserire uno studente nuovo nell'anagrafica

1. Aprire finestra Gestione Studente
2. Fare click su **"Nuovo"** (campi si svuotano)
3. Compilare:
   - Cognome: Rossi
   - Nome: Mario
   - Data nascita: 15/03/2010
   - Città: Bologna
   - Provincia: BO
   - Stato: Italia
   - Email: mario.rossi@example.com
4. Spuntare **"BES/DSA"** se applicabile
5. Fare click su **"Salva"** (o **"Aggiungi studente"**)
6. Lo studente è creato (assegnato IdStudent)

**Nota**: per associarlo a una classe, usare finestra "Gestione Classi"

### Scenario 3: Cercare studente per nome parziale

**Obiettivo**: trovare uno studente di cui si ricorda solo parte del cognome

1. Aprire finestra Gestione Studente
2. Nel campo **Cognome**, digitare: "Ros"
3. Fare click su **"Cerca studente"**
4. La griglia mostra tutti gli studenti con cognome contenente "Ros" (Rossi, Rosetti, De Rosis, ecc.)
5. Fare click su riga per caricare dati completi
6. **Doppio click** per vedere la classe dello studente

### Scenario 4: Verificare omonimi

**Obiettivo**: controllare se esistono studenti con stesso nome

1. Nel campo **Cognome**, digitare: "Bianchi"
2. Nel campo **Nome**, digitare: "Luca"
3. Fare click su **"Cerca omonimo"**
4. La griglia mostra tutti gli studenti chiamati esattamente "Bianchi Luca"
5. Verificare classi e anni per distinguerli
6. Eventualmente aggiungere suffissi o middle name per disambiguare

### Scenario 5: Aggiornare contatti studente

**Obiettivo**: modificare numero di telefono o email

1. Cercare lo studente (es. con "Cerca studente")
2. Click su riga per caricare nei campi
3. Modificare **Cellulare** o **Email**
4. Fare click su **"Salva"**
5. I nuovi contatti sono aggiornati

### Scenario 6: Attivare flag BES/DSA

**Obiettivo**: registrare che uno studente ha certificazione DSA

1. Cercare e caricare lo studente
2. Spuntare checkbox **"BES/DSA"**
3. Fare click su **"Salva"**
4. D'ora in poi, nelle finestre di valutazione apparirà il flag BES/DSA per ricordare adattamenti necessari

### Scenario 7: Selezionare studente per operazione

**Obiettivo**: scegliere uno studente da una lista (modalità Dialog)

1. La finestra si apre in modalità selezione (pulsante "Scegli" visibile)
2. Digitare parte del cognome
3. Fare click su **"Cerca studente"**
4. Click su riga dello studente desiderato
5. Fare click su **"Scegli"**
6. La finestra si chiude e lo studente è selezionato

---

## Suggerimenti e best practices

### Dati anagrafici completi
- Compilare il più possibile: facilita ricerche e comunicazioni
- Email è importante per contatti digitali
- Telefoni utili per emergenze

### Uso flags BES/DSA e Disabile
- Attivare sempre se applicabile
- Informazione cruciale per valutazioni e adattamenti
- Rispettare privacy: non condividere informazioni sensibili

### Gestione omonomi
- Verificare sempre con "Cerca omonimo" prima di creare nuovo studente
- Se omonimi in classi diverse, distinguere nei dati (es. middle name, suffissi)

### Ricerche efficienti
- Usare ricerca parziale per trovare rapidamente (es. "Mar" trova "Mario", "Marta", "Marco")
- Cercare per città/provincia se si ricorda provenienza ma non nome

### Verificare classe studente
- **Doppio click** su riga in griglia apre gestione classe
- Utile per vedere chi è in classe con lo studente
- Verificare anno scolastico corretto

### Foto studenti
- Caricare foto facilita riconoscimento nelle finestre
- Nome file dovrebbe corrispondere a IdStudent (es. "123.jpg" per studente 123)
- Foto nelle cartella immagini configurata

---

## Troubleshooting

### Non trovo lo studente cercando

**Problema**: ricerca non restituisce risultati

**Soluzioni**:
- Verificare ortografia (cognome corretto?)
- Provare ricerca parziale (es. "Ros" invece di "Rossi")
- Cercare per nome invece che cognome
- Cercare per città se si ricorda provenienza
- Lo studente potrebbe non essere ancora inserito nel sistema

### Non riesco a salvare nuovo studente

**Problema**: click su "Salva" o "Aggiungi" non funziona

**Soluzioni**:
- Verificare che Cognome e Nome siano compilati (obbligatori)
- Controllare formato data nascita (gg/mm/aaaa)
- Verificare permessi scrittura database

### La foto non si vede

**Problema**: campo foto vuoto anche se file esiste

**Soluzioni**:
- Verificare che nome file corrisponda a IdStudent o convenzione configurata
- Controllare che file sia in cartella immagini corretta
- Formati supportati: .jpg, .png
- Verificare che anno scolastico studente sia corretto (la cartella foto può essere organizzata per anno)

### Doppio click non apre classe

**Problema**: doppio click su studente in griglia non fa nulla

**Soluzioni**:
- Verificare che lo studente abbia classe associata (colonna ClassAbbreviation piena)
- Controllare che anno scolastico sia valido
- Se studente non ha classe, non può aprire gestione classe

### Eliminazione non riesce

**Problema**: tentativo di eliminare studente da errore

**Cause possibili**:
- Studente ha voti associati (vincoli integrità database)
- Studente è in classe corrente
- Permessi insufficienti

**Soluzione**: scegliere "Sì" al secondo messaggio per eliminazione completa, oppure rimuovere prima manualmente da classi e voti

---

## Integrazione con altre finestre

### Da finestra principale
- **Doppio click foto**: apre con studente corrente
- **Doppio click nome**: apre con studente corrente

### Da finestra Valutazione
- **Doppio click foto**: apre con studente in valutazione

### Verso finestra Gestione Classi
- **Doppio click su studente in griglia**: apre frmClassesManagement con classe dello studente

### Modalità Dialog da altre finestre
- Finestre che necessitano selezione studente possono aprire questa finestra in modalità Dialog
- Pulsante "Scegli" conferma e restituisce studente selezionato

---

## Privacy e dati sensibili

**ATTENZIONE**: questa finestra gestisce dati personali sensibili.

**Obblighi**:
- Rispettare normative privacy (GDPR in Europa)
- Non condividere schermate con dati visibili
- Proteggere accesso al database
- Informare famiglie sull'uso dei dati

**Dati sensibili**:
- Flags Disabile e BES/DSA sono dati sulla salute
- Richiedono consenso informato
- Accesso limitato a personale autorizzato

**Buone pratiche**:
- Compilare solo campi necessari
- Non inserire informazioni mediche dettagliate (usare annotazioni protette)
- Verificare consenso per foto
- Backup regolari e sicuri del database

---

## Limitazioni note

- **Modifiche in massa**: non si possono modificare più studenti contemporaneamente
- **Import/export**: non c'è funzione nativa per importare elenchi da file (es. CSV)
- **Storico modifiche**: non c'è tracciamento di chi ha modificato cosa e quando
- **Validazione limitata**: pochi controlli automatici su correttezza dati (es. email valida, CAP corretto)
- **Eliminazione con voti**: TODO - dovrebbe essere bloccata se studente ha voti

[Pagina principale](Manuale-Utente-SchoolGrades.md)
---

*Questa documentazione fa parte del Manuale Utente di SchoolGrades*
