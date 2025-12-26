# Finestra Gruppi - Manuale Utente

## Introduzione

La finestra **Gruppi** permette di organizzare gli studenti presenti in classe in gruppi di lavoro secondo diversi criteri. Questa funzionalità è utile per attività collaborative, lavori di gruppo e organizzazione della classe.

**ATTENZIONE: QUESTO FILE E' PRELIMINARE E NON REVISIONATO.  
POTREBBE CONTENERE INFORMAZIONI NON ESATTE**  
Comunica con un ticket su GiHub eventuali errori riscontrati.

## Accesso alla finestra

Per aprire la finestra Gruppi:

1. Selezionare una classe dalla finestra principale
2. Spuntare gli studenti presenti che si desidera raggruppare
3. Fare click sul pulsante **"Gruppi"** nella finestra principale

**Importante**: solo gli studenti spuntati nella lista verranno considerati per la formazione dei gruppi.

---

## Interfaccia della finestra

### Informazioni di base

Nella parte superiore della finestra vengono visualizzate:

- **Classe**: sigla e anno scolastico della classe corrente
- **Totale studenti da raggruppare**: numero di studenti selezionati che verranno divisi in gruppi

### Configurazione dei gruppi

Due campi di testo collegati permettono di specificare come suddividere gli studenti:

- **N° gruppi**: numero di gruppi da formare
- **Studenti per gruppo**: numero di studenti da inserire in ciascun gruppo

**Funzionamento automatico**: quando si inserisce un valore in uno dei due campi, l'altro viene calcolato automaticamente in base al numero totale di studenti presenti. Ad esempio:
- Se ci sono 24 studenti e si imposta "Studenti per gruppo = 4", il programma calcola automaticamente "N° gruppi = 6"
- Se si imposta "N° gruppi = 8", il programma calcola "Studenti per gruppo = 3"

### Criteri di raggruppamento

Il programma offre tre modalità di formazione gruppi:

#### 1. Gruppi casuali
Gli studenti vengono assegnati ai gruppi in modo completamente casuale. Questa è la modalità più semplice e imparziale.

**Quando usarla**: 
- Attività ludiche o di conoscenza reciproca
- Quando si vuole evitare qualsiasi bias nella formazione
- Per variare frequentemente la composizione dei gruppi

#### 2. Voti migliori insieme
Gli studenti vengono raggruppati in base ai loro voti, mettendo insieme studenti con prestazioni simili.

**Quando usarla**:
- Attività differenziate per livello
- Quando si vuole creare gruppi omogenei per difficoltà

**Configurazione periodo**: 
Quando si seleziona questa opzione, diventa attivo il gruppo "Periodo degli argomenti e domande", che permette di specificare:
- **Periodo scolastico**: selezionare un periodo predefinito (quadrimestre, trimestre, ecc.)
- **Data inizio/fine**: specificare manualmente un intervallo temporale per considerare solo i voti in quel periodo

#### 3. Voti bilanciati
Il programma cerca di creare gruppi equilibrati, distribuendo studenti con livelli di prestazione diversi in ciascun gruppo. Ogni gruppo conterrà una mix di studenti con voti alti, medi e bassi.

**Quando usarla**:
- Attività di peer tutoring (studenti forti aiutano quelli più deboli)
- Progetti di gruppo dove si vuole equità tra i team
- Quando si desidera che ogni gruppo abbia risorse simili

**Configurazione periodo**: come per "Voti migliori insieme", è necessario specificare il periodo di riferimento per i voti.

### Periodo degli argomenti e domande

Questa sezione viene abilitata quando si scelgono criteri basati sui voti. Permette di:

- Selezionare un **periodo scolastico** dal menu a tendina:
  - Quadrimestri (1°, 2°)
  - Trimestri (1°, 2°, 3°)
  - Periodi personalizzati (settimana, mese, anno)
  
- Visualizzare e modificare le **date di inizio e fine** del periodo selezionato

**Nota**: i voti considerati per la formazione dei gruppi saranno solo quelli registrati nel periodo specificato e per la materia correntemente selezionata nella finestra principale.

---

## Procedura per creare gruppi

### Passo 1: Configurare i parametri

1. Decidere il numero di gruppi o il numero di studenti per gruppo
2. Scegliere il criterio di raggruppamento (casuale, voti migliori insieme, voti bilanciati)
3. Se necessario, selezionare il periodo di riferimento per i voti

### Passo 2: Generare i gruppi

Fare click sul pulsante **"Crea gruppi"**. 

Il programma:
- Applica il criterio selezionato
- Distribuisce gli studenti nei gruppi
- Visualizza il risultato nell'area di testo "Gruppi formati"

### Passo 3: Visualizzare i risultati

Nell'area di testo "Gruppi formati" apparirà l'elenco dei gruppi con i nomi degli studenti assegnati a ciascuno, nel formato:

```
Gruppo 1:
- Cognome Nome
- Cognome Nome
- Cognome Nome

Gruppo 2:
- Cognome Nome
- Cognome Nome
- Cognome Nome

...
```

### Passo 4: Salvare su file (opzionale)

Se si desidera conservare l'elenco dei gruppi:

1. Fare click sul pulsante **"Crea file gruppi"**
2. Il programma creerà un file di testo nella cartella del database
3. Il file si aprirà automaticamente nel programma predefinito per i file .txt
4. Il nome del file includerà la sigla della classe, l'anno scolastico e la data

**Formato nome file**: `Groups_[Sigla Classe]_[Anno].txt`  
**Esempio**: `Groups_4F_2023-24.txt`

---

## Suggerimenti e best practices

### Variare i criteri

Non usare sempre lo stesso criterio. Alternare tra:
- Gruppi casuali per attività brevi e frequenti
- Gruppi bilanciati per progetti lunghi e impegnativi
- Gruppi omogenei (voti simili) per attività differenziate

### Considerare il periodo

Quando si usano criteri basati sui voti:
- Per gruppi all'inizio dell'anno, usare i voti dell'anno precedente o un periodo breve
- Per gruppi a metà anno, considerare l'intero periodo trascorso
- Aggiornare periodicamente la composizione dei gruppi in base ai progressi

### Salvare i gruppi importanti

Per progetti lunghi o gruppi che si mantengono nel tempo:
- Salvare sempre il file dei gruppi
- Annotare la data di formazione
- Tenere traccia delle composizioni per evitare ripetizioni indesiderate

### Gestire studenti dispari

Se il numero di studenti non è divisibile esattamente:
- L'ultimo gruppo avrà un numero diverso (maggiore o minore) di membri
- Il programma arrotonda per eccesso quando necessario
- Considerare di aggiustare manualmente l'ultimo gruppo se molto sbilanciato

### Modificare manualmente

Dopo la generazione automatica:
- È possibile modificare manualmente il testo nell'area "Gruppi formati"
- Spostare studenti tra gruppi secondo necessità didattiche o relazionali
- Salvare la versione modificata con "Crea file gruppi"

---

## Limitazioni e note tecniche

- La funzionalità richiede che almeno alcuni studenti siano spuntati nella finestra principale
- I criteri basati sui voti richiedono che esistano valutazioni nel periodo selezionato
- Se non ci sono voti sufficienti, il programma potrebbe comportarsi come il criterio "casuale"
- Il numero minimo di studenti per gruppo è 1 (ma è sconsigliato avere "gruppi" di una sola persona)

---

## Troubleshooting

### Non riesco a creare gruppi

**Problema**: il pulsante "Crea gruppi" non produce risultati

**Soluzioni**:
- Verificare di aver spuntato almeno 2 studenti nella finestra principale
- Controllare di aver inserito un numero valido in "N° gruppi" o "Studenti per gruppo"
- Assicurarsi di aver selezionato un criterio di raggruppamento

### I gruppi non sembrano bilanciati

**Problema**: usando "Voti bilanciati" i gruppi non appaiono equilibrati

**Soluzioni**:
- Verificare che il periodo selezionato contenga effettivamente dei voti
- Controllare che i voti siano relativi alla materia corrente
- Considerare che l'algoritmo fa del suo meglio ma potrebbe non essere perfetto con numeri piccoli

### Il file non si crea

**Problema**: cliccando "Crea file gruppi" non succede nulla

**Soluzioni**:
- Assicurarsi di aver prima generato i gruppi con "Crea gruppi"
- Verificare di avere permessi di scrittura sulla cartella del database
- Controllare che non ci siano caratteri speciali nel nome della classe che potrebbero causare problemi nel nome file

---

## Casi d'uso tipici

### Esempio 1: Gruppi per lavoro di laboratorio

**Scenario**: 20 studenti, laboratorio con 5 postazioni

1. Spuntare i 20 studenti presenti
2. Impostare "N° gruppi = 5"
3. Selezionare "Gruppi casuali"
4. Fare click su "Crea gruppi"
5. Salvare il file per riferimento futuro

### Esempio 2: Gruppi bilanciati per progetto

**Scenario**: 24 studenti, progetto di gruppo da 4 persone

1. Spuntare i 24 studenti
2. Impostare "Studenti per gruppo = 4"
3. Selezionare "Voti bilanciati"
4. Scegliere "1° quadrimestre" dal menu periodo
5. Fare click su "Crea gruppi"
6. Verificare che ogni gruppo abbia un mix di livelli
7. Salvare il file dei gruppi

### Esempio 3: Gruppi omogenei per recupero

**Scenario**: 15 studenti, alcuni necessitano di recupero

1. Spuntare i 15 studenti
2. Impostare "N° gruppi = 3"
3. Selezionare "Voti migliori insieme"
4. Selezionare periodo "Ultimo mese"
5. Fare click su "Crea gruppi"
6. Il gruppo con voti più bassi riceverà attività di recupero
7. I gruppi con voti medi e alti riceveranno attività di approfondimento

[Pagina principale](Manuale-Utente-SchoolGrades.md)
---

*Questa documentazione fa parte del Manuale Utente di SchoolGrades*
