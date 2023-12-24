namespace SchoolGrades.BusinessObjects
{
    internal class SafeDbWpf
    {
        internal static bool? SafeBool(object field)
        {
            if (field == null)
            {
                return null;
            }
            if (field is bool)
                return (bool)field;
            //////////if (field is CheckState)
            //////////{
            //////////    CheckState f = (CheckState)field;
            //////////    if (f == CheckState.IsChecked)
            //////////        return true;
            //////////    if (f == CheckState.Unchecked)
            //////////        return false;
            //////////    if (f == CheckState.Indeterminate)
            //////////        return null;
            //////////}
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
