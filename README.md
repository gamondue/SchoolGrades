# SchoolGrades
SchoolGrades manages a teacher's daily life in the classroom, with a focus on assessing and tracking topics. It is also helpful for the student to know about his grades, the questions he has answered, the grades he has had and the topics covered by the teacher during his teaching.

SchoolGrades is written in C# with Windows Forms, currently in .Net 10.

## 🌍 Internationalization

SchoolGrades now supports multiple languages! The multilingual infrastructure has been implemented and is ready for use.

### Currently Supported Languages
- 🇮🇹 **Italian** (default)
- 🇬🇧 **English**

### Changing Language
1. Go to **Setup** (Configurazione)
2. Select desired language from the **Language** dropdown
3. Click **Save Configuration**
4. The application will automatically restart in the selected language

### Want to Contribute to translations?

I welcome translations to other languages! If you'd like to contribute send me a message and I will send you a spreadsheet for translation. In case of big requests for translations, I could arrange a smoother way.

## Documentation

SchoolGrades has an Operation Manual in Italian: 

📖 **[Manuale Utente in Italiano](Manual_IT/Manuale-Utente-SchoolGrades.md)** - Complete guide in Italian to using SchoolGrades

The documentation covers:
- All main windows and their functions
- Step-by-step workflows
- Best practices and tips
- Troubleshooting common issues

Contributions to documentation and questions about the use of the program are welcomed and encouraged.

## Development Status

The SchoolGrades user interface was written in Italian and has been translated to English, but the translation is not thouroghly revised.
   
The source code of the program is in English.

All error reports and feature requests will be taken into consideration. Don't expect that they will be addressed quickly, but now, being retired, I have more time to do it..

Of course, I will be grateful to you if you do pull requests with the code that fixes the bug or implements the new functionality.

N.B.: In the spring of 2021 and in the Fall of 2023 I used the program and GitHub as school exercises for some of my classes, so many of the pull requests are only instrumental to those school exercises.

## 🚀 Technical Notes

- **Framework**: .NET 10
- **UI**: Windows Forms
- **Database**: SQLite
- **Architecture**: Layered (Business Layer, Data Layer, UI)
- **Localization**: Resource files (.resx) with runtime language switching