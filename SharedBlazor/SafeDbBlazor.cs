namespace SchoolGrades.BusinessObjects
{
    internal static class SafeDbBlazor
    {
        internal static bool? SafeBool(object field)
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
    }
}