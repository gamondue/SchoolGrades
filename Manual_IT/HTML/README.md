# SchoolGrades - Documentazione HTML

Questa cartella contiene la documentazione HTML generata automaticamente dai file Markdown sorgente.

## 📁 Struttura

- **index.html** - Pagina principale con l'indice di tutti i documenti
- **Manuale-Utente-SchoolGrades.html** - Manuale utente principale
- **Altri file HTML** - Documentazione delle singole finestre e funzionalità

## 🔄 Generazione

La documentazione viene generata automaticamente eseguendo lo script PowerShell:

```powershell
.\ConvertMarkdownToHtml.ps1
```

Lo script converte tutti i file `.md` presenti nella cartella `Manual_IT` in file HTML statici con stile CSS integrato.

## 📦 Distribuzione

Durante l'installazione di SchoolGrades tramite InnoSetup:
- Tutti i file di questa cartella vengono copiati in `%USERPROFILE%\Documents\SchoolGrades\Manual_IT\`
- Viene creato un collegamento nel menu Start chiamato "Manuale Utente"
- Il pulsante "?" nell'applicazione apre automaticamente `index.html`

## 🎨 Personalizzazione

Il CSS è embedded in ogni file HTML. Per modificare lo stile:
1. Modifica il template CSS nello script `ConvertMarkdownToHtml.ps1`
2. Rigenera la documentazione eseguendo lo script

## 🔗 Collegamenti

I link tra i documenti HTML sono relativi e funzionano correttamente sia:
- Nella cartella di sviluppo
- Nella cartella di installazione
- Quando aperti direttamente dal browser

## ⚙️ Manutenzione

### Aggiornare la documentazione:
1. Modifica i file `.md` nella cartella `Manual_IT`
2. Esegui `.\ConvertMarkdownToHtml.ps1`
3. Verifica che `index.html` si apra correttamente
4. Committa sia i file `.md` che gli `.html` generati

### Prima del rilascio:
1. Assicurati che tutti i file `.md` siano aggiornati
2. Rigenera tutti gli HTML
3. Verifica che i link funzionino
4. Esegui la build di InnoSetup per includere la documentazione aggiornata

## 📝 Note

- La documentazione è in italiano
- I file HTML sono autonomi (CSS e contenuto embedded)
- Non richiedono connessione internet
- Compatibili con tutti i browser moderni

---

*Ultimo aggiornamento: $(Get-Date -Format "dd/MM/yyyy")*
