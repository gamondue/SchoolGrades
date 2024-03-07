namespace SchoolGrades.BusinessObjects
{
    public class Answer
    {
        private int? idAnswer = 0;
        private int? idQuestion = 0;
        private string text ="";
        private int? errorCost = 100;
        private bool? isCorrect = false;
        private bool? isOpenAnswer = false;
        private bool? isMutex = false;

        public int? IdAnswer { get => idAnswer; set => idAnswer = value; }
        public int? IdQuestion { get => idQuestion; set => idQuestion = value; }
        public string Text { get => text; set => text = value; }
        public int? ErrorCost { get => errorCost; set => errorCost = value; }
        public bool? IsCorrect { get => isCorrect; set => isCorrect = value; }
        public bool? IsOpenAnswer { get => isOpenAnswer; set => isOpenAnswer = value; }
        public int? ShowingOrder { get; internal set; }
        public bool? IsMutex { get => isMutex; set => isMutex = value; }
    }
}
