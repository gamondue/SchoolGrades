namespace SchoolGrades
{
    internal partial class SqlServer_DataLayer : DataLayer
    {
        private string dbName;
        private string nameDatabase;
        internal SqlServer_DataLayer(string DatabaseName)
        {
            dbName = DatabaseName;
        }
        internal string NameAndPathDatabase
        {
            get { return dbName; }
            set { nameDatabase = value; }
        }
    }
}
