using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades.DbClasses
{
    internal static class SqlVal
    {
        #region funzioni che preparano una grandezza per essere usata in statement SQL
        public static string SqlDate(string Date)
        {
            if (Date is null)
                return "null";
            if (Date == "")
                return "null";

            DateTime? d = System.DateTime.Parse(Date);
            return ("datetime('" + ((DateTime)d).ToString("yyyy-MM-dd HH:mm:ss").Replace('.', ':') + "')");
        }

        public static string SqlDate(DateTime? Date)
        {
            if (Date != null)
                return ("datetime('" + ((DateTime)Date).ToString("yyyy-MM-dd HH:mm:ss").Replace('.', ':') + "')");
            else
                return "null"; 
        }

        //public static string SqlVal.SqlDate(Hour(string Date)
        //{
        //    try
        //    {
        //        switch (dbType)
        //        {
        //            case DbType.Access:
        //                {
        //                    // TODO ATTENZIONE: converte 13:29 in 1:29 !!!!
        //                    return ("#" + Convert.ToDateTime(Date).ToString("yyyy-MM-dd HH:mm:ss") + "#");
        //                }
        //            case DbType.MySQL:
        //                {
        //                    return "";
        //                }
        //            case DbType.MsSQL:
        //                {
        //                    return "";
        //                }
        //            default:
        //                {
        //                    return "";
        //                }
        //        }
        //    }
        //    catch
        //    {
        //        return "null";
        //    }
        //}

        public static string SqlString(string String)
        {
            string temp;
            if (!(String is null))
            {
                temp = String;

                //temp = temp.Replace("\"", "\"\"");
                temp = temp.Replace("'", "''");
                //temp = "'" + temp + "'";
            }
            else
                temp = "";
            return temp;
        }

        public static string SqlBool(object Value)
        {
            if (Value == null)
                return null; 
            if ((bool)Value == false)
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }

        internal static string SqlDouble(string Number)
        {
            try
            {
                if (Number != null)
                    return double.Parse(Number).ToString().Replace(",", ".");
                else
                    return "null"; 
            }
            catch
            {
                return "null";
            }
        }

        internal static string SqlDouble(object Number)
        {
            try
            {
                if (Number != null)
                    return Number.ToString().Replace(",", ".");
                else
                    return "null"; 
            }
            catch
            {
                return "null";
            }
        }

        internal static string SqlFloat(float? Number)
        {
            try
            {
                if (Number != null)
                    return Number.ToString().Replace(",", ".");
                else
                    return "null";
            }
            catch
            {
                return "null";
            }
        }

        internal static string SqlFloat(string Number)
        {
            try
            {
                if(Number != null)
                    return float.Parse(Number).ToString().Replace(",", ".");
                else
                    return "null";
            }
            catch
            {
                return "null";
            }
        }

        internal static string SqlInt(string Number)
        {
            try
            {
                if(Number != null)
                    return int.Parse(Number).ToString();
                else
                    return "null";
            }
            catch
            {
                return "null";
            }
        }

        internal static string SqlInt(int? Number)
        {
            if (Number == null) return "null";
            try
            {
                return Number.ToString();
            }
            catch
            {
                return "null";
            }
        }
        #endregion
    }
}
