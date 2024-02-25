namespace SchoolGrades
{
    internal partial class SqLite_DataLayer : DataLayer
    {
        private string dbName;
        private string nameAndPathDatabase;
        #region constructors
        /// <summary>
        /// Constructor of DataLayer class that uses the default database of the program
        /// Assumes that the file exists.
        /// </summary>
        internal SqLite_DataLayer()
        {
            // ???? is next if() useful ????
            if (!System.IO.File.Exists(Commons.PathAndFileDatabase))
            {
                string err = @"[" + Commons.PathAndFileDatabase + " not in the current nor in the dev directory]";
                Commons.ErrorLog(err);
                throw new System.IO.FileNotFoundException(err);
            }
            dbName = Commons.PathAndFileDatabase;
        }
        /// <summary>
        /// Constructor of DataLayer class that get from outside the databases to use
        /// Assumes that the file exists.
        /// </summary>
        internal SqLite_DataLayer(string PathAndFile)
        {
            dbName = PathAndFile;
        }
        #endregion
        internal string NameAndPathDatabase
        {
            get { return dbName; }
            set { nameAndPathDatabase = value; }
        }
    }
}