using System;
using System.Windows.Forms;

namespace SchoolGrades.Localization
{
    /// <summary>
    /// Helper class to automatically localize Windows Forms controls
    /// </summary>
    public static class FormLocalizer
    {
        /// <summary>
        /// Localizes all controls in a form using resource keys based on control names
        /// </summary>
        /// <param name="form">Form to localize</param>
        /// <param name="formPrefix">Resource key prefix (e.g., "Setup" for Setup_xxx keys)</param>
        public static void LocalizeForm(Form form, string formPrefix)
        {
            if (form == null)
                throw new ArgumentNullException(nameof(form));
            if (string.IsNullOrEmpty(formPrefix))
                throw new ArgumentNullException(nameof(formPrefix));
            
            try
            {
                // Localize form title
                string titleKey = $"{formPrefix}_Title";
                string title = LocalizationManager.GetString(titleKey);
                if (!title.StartsWith("["))
                    form.Text = title;
                
                // Localize all controls recursively
                LocalizeControlsRecursive(form, formPrefix);
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"FormLocalizer: Error localizing form '{form.Name}': {ex.Message}");
            }
        }
        
        /// <summary>
        /// Recursively localizes all controls in a container
        /// </summary>
        private static void LocalizeControlsRecursive(Control container, string formPrefix)
        {
            foreach (Control control in container.Controls)
            {
                // Recursion for child containers
                if (control.HasChildren)
                    LocalizeControlsRecursive(control, formPrefix);
                
                // Try to localize this control
                LocalizeControlByName(control, formPrefix);
            }
        }
        
        /// <summary>
        /// Localizes a single control based on its name
        /// </summary>
        private static void LocalizeControlByName(Control control, string formPrefix)
        {
            // Skip controls without name or with generic names
            if (string.IsNullOrEmpty(control.Name) || 
                control.Name.StartsWith("panel") ||
                control.Name.StartsWith("splitContainer") ||
                control.Name.StartsWith("tableLayoutPanel"))
                return;
            
            // Build resource key from form prefix and control name
            // E.g., "Setup" + "btnSave" ? "Setup_btnSave"
            string key = $"{formPrefix}_{control.Name}";
            string localizedText = LocalizationManager.GetString(key);
            
            // Only apply if key exists (doesn't start with [)
            if (localizedText.StartsWith("["))
                return; // Key not found, skip
            
            // Apply localized text based on control type
            if (control is Button || 
                control is Label || 
                control is CheckBox || 
                control is RadioButton ||
                control is GroupBox)
            {
                control.Text = localizedText;
            }
            else if (control is TabPage tabPage)
            {
                tabPage.Text = localizedText;
            }
            // Note: ColumnHeader is not a Control, it's a ListViewItem.ListViewSubItem
            // If you need to localize ListView columns, handle it separately
        }
        
        /// <summary>
        /// Manually localize a specific control with a resource key
        /// </summary>
        /// <param name="control">Control to localize</param>
        /// <param name="resourceKey">Full resource key</param>
        public static void LocalizeControl(Control control, string resourceKey)
        {
            if (control == null || string.IsNullOrEmpty(resourceKey))
                return;
            
            string localizedText = LocalizationManager.GetString(resourceKey);
            if (!localizedText.StartsWith("["))
                control.Text = localizedText;
        }
        
        /// <summary>
        /// Set up a form to respond to language changes at runtime
        /// </summary>
        /// <param name="form">Form to setup</param>
        /// <param name="formPrefix">Resource key prefix</param>
        public static void EnableRuntimeLanguageChange(Form form, string formPrefix)
        {
            LocalizationManager.LanguageChanged += (s, e) =>
            {
                if (!form.IsDisposed && form.IsHandleCreated)
                {
                    try
                    {
                        // Re-localize the form when language changes
                        form.Invoke(new Action(() => LocalizeForm(form, formPrefix)));
                    }
                    catch (Exception ex)
                    {
                        Commons.ErrorLog($"FormLocalizer: Error re-localizing form '{form.Name}' on language change: {ex.Message}");
                    }
                }
            };
        }
    }
    
    /// <summary>
    /// Extension methods for easier localization
    /// </summary>
    public static class LocalizationExtensions
    {
        /// <summary>
        /// Localizes a form with automatic form prefix detection
        /// </summary>
        public static void Localize(this Form form)
        {
            // Try to infer prefix from form name
            // E.g., "frmSetup" ? "Setup"
            string formName = form.Name;
            string prefix = formName.StartsWith("frm") ? formName.Substring(3) : formName;
            FormLocalizer.LocalizeForm(form, prefix);
        }
        
        /// <summary>
        /// Localizes a form with specified prefix
        /// </summary>
        public static void Localize(this Form form, string prefix)
        {
            FormLocalizer.LocalizeForm(form, prefix);
        }
        
        /// <summary>
        /// Enables runtime language change for this form
        /// </summary>
        public static void EnableLanguageChange(this Form form, string prefix = null)
        {
            if (prefix == null)
            {
                string formName = form.Name;
                prefix = formName.StartsWith("frm") ? formName.Substring(3) : formName;
            }
            FormLocalizer.EnableRuntimeLanguageChange(form, prefix);
        }
    }
}
