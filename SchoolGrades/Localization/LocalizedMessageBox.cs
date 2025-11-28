using System;
using System.Windows.Forms;

namespace SchoolGrades.Localization
{
    /// <summary>
    /// Localized MessageBox wrapper for consistent multilingual messages
    /// </summary>
    public static class LocalizedMessageBox
    {
        /// <summary>
        /// Show a localized message box
        /// </summary>
        /// <param name="messageKey">Resource key for the message</param>
        /// <param name="titleKey">Resource key for the title (default: "Messages_Information")</param>
        /// <param name="buttons">MessageBox buttons</param>
        /// <param name="icon">MessageBox icon</param>
        /// <returns>DialogResult from the message box</returns>
        public static DialogResult Show(
            string messageKey, 
            string titleKey = "Messages_Information",
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            string message = Loc.Get(messageKey);
            string title = Loc.Get(titleKey);
            
            return MessageBox.Show(message, title, buttons, icon);
        }
        
        /// <summary>
        /// Show a localized message box with formatted parameters
        /// </summary>
        public static DialogResult Show(
            string messageKey,
            object[] formatArgs,
            string titleKey = "Messages_Information",
            MessageBoxButtons buttons = MessageBoxButtons.OK,
            MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            string message = Loc.Get(messageKey, formatArgs);
            string title = Loc.Get(titleKey);
            
            return MessageBox.Show(message, title, buttons, icon);
        }
        
        /// <summary>
        /// Show an error message
        /// </summary>
        public static DialogResult ShowError(string messageKey)
        {
            return Show(messageKey, "Messages_Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        /// <summary>
        /// Show an error message with formatted parameters
        /// </summary>
        public static DialogResult ShowError(string messageKey, params object[] formatArgs)
        {
            return Show(messageKey, formatArgs, "Messages_Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        /// <summary>
        /// Show a warning message
        /// </summary>
        public static DialogResult ShowWarning(string messageKey)
        {
            return Show(messageKey, "Messages_Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        /// <summary>
        /// Show a warning message with Yes/No buttons
        /// </summary>
        public static DialogResult ShowWarningYesNo(string messageKey)
        {
            return Show(messageKey, "Messages_Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
        
        /// <summary>
        /// Show an information message
        /// </summary>
        public static DialogResult ShowInformation(string messageKey)
        {
            return Show(messageKey, "Messages_Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        /// <summary>
        /// Show a question with Yes/No buttons
        /// </summary>
        public static DialogResult ShowQuestion(string messageKey)
        {
            return Show(messageKey, "Messages_Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        
        /// <summary>
        /// Show a confirmation dialog (Yes/No with Warning icon)
        /// </summary>
        public static DialogResult ShowConfirmation(string messageKey)
        {
            return Show(messageKey, "Messages_Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
    }
}
