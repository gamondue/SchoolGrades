using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolGrades
{
    internal static class Safe
    {
        #region functions that take an object (eg. a database field) ad convert it in the destination type without giving errors
        internal static int? Int(object Value)
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
        internal static string String(object Field)
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
        internal static string String(object Field, bool NullOnError)
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
        internal static Nullable<DateTime> DateTime(object Field)
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
        internal static Nullable<DateTime> DateTime(string Date)
        {
            try
            {
                return System.DateTime.Parse(Date);
            }
            catch
            {
                return null;
            }
        }
        internal static Nullable<double> Double(string DoubleValue)
        {
            try
            {
                return Convert.ToDouble(DoubleValue);
            }
            catch
            {
                return null;
            }
        }
        internal static double? Double(object Value)
        {
            try
            {
                return double.Parse(Value.ToString());
            }
            catch
            {
                return null;
            }
        }
        internal static bool? Bool(string field)
        {
            if (field == "" || field == "0")
                return true;
            else
                return false;
        }
        internal static bool? Bool(object field)
        {
            if (field == null)
            {
                return null;
            }
            if (field is bool)
                return (bool)field;
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
