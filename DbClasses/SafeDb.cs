using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Windows.Forms;

namespace SchoolGrades.DbClasses
{

    #region funzioni che prendono un campo di database e lo mettono nella destinazione senza inchiodarsi
    /// <summary>
    /// funzioni che prendono un campo di database e lo mettono nella destinazione senza inchiodarsi
    /// </summary>
    public static class SafeDb
    {
        internal static int? SafeInt(object Value)
        {
            try
            {
                return int.Parse(Value.ToString().Trim());
            }
            catch
            {
                return null;
            }
        }

        internal static string? SafeString(DbDataReader r, int FieldNumber)
        {
            try
            {
                return r.GetString(FieldNumber).Trim();
            }
            catch
            {
                return null;
            }
        }

        internal static string? SafeString(object Field)
        {
            if (Field == null)
                return null; 
            try
            {
                return Field.ToString().Trim();
            }
            catch
            {
                return null;
            }
        }
        
        internal static string SafeString(object Field, bool NullOnError)
        {
            try
            {
                return Field.ToString().Trim();
            }
            catch
            {
                if (NullOnError)
                    return null;
                else
                    return "";
            }
        }

        internal static Nullable<DateTime> SafeDateTime(object Field)
        {
            try
            {
                return Convert.ToDateTime(Field);
                //return DateTime.ParseExact(Campo.ToString(), "yyyy-MM-dd HH:mm:ss",
                //    System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                //return Comuni.DateNull;
                return null;
            }
        }

        internal static Nullable<DateTime> SafeDateTime(string Date)
        {
            try
            {
                return DateTime.Parse(Date);
            }
            catch
            {
                return null;
            }
        }

        internal static Nullable<double> SafeDouble(string d)
        {
            try
            {
                return Convert.ToDouble(d);
            }
            catch
            {
                return null;
            }
        }

        internal static double? SafeDouble(object Value)
        {
            try
            {
                return Double.Parse(Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        internal static bool? SafeBool(string field)
        {
            if (field == "" || field == "0")
                return true;
            else
                return false;
        }

        internal static bool? SafeBool(object field)
        {
            if (field == null)
            {
                return null;
            }
            if (field is bool)
                return (bool)field;
            if (field is CheckState)
            {
                CheckState f = (CheckState)field;
                if (f == CheckState.Checked)
                    return true;
                if (f == CheckState.Unchecked)
                    return false;
                if (f == CheckState.Indeterminate)
                    return null;
            }
            try
            {
                string f = field.ToString();
                if (f == "")
                    return null;
                if (byte.Parse(f) == 0)
                    return false;
                else
                    return true;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
