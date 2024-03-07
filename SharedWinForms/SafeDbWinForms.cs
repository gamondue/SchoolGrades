using System.Windows.Forms;

namespace SchoolGrades.BusinessObjects
{
    internal static class SafeDbWinForms
    {
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
    }
}
