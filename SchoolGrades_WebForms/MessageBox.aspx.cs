using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolGrades_WebForms
{
    public partial class MessageBox : System.Web.UI.Page
    {
        public enum MessageBoxButtons
        {
            OK,
            YesNo
            // !!!! TODO COMPLETE !!!!
        }
        public enum MessageBoxIcon
        {
            Error
            // !!!! TODO COMPLETE !!!!
        }
        public void Page_Load(object sender, EventArgs e)
        {
        }
        public void Show(string Message, string Title,
            MessageBox.MessageBoxButtons MessageBoxButtons = MessageBox.MessageBoxButtons.OK,
            MessageBoxIcon MessageBoxIcon = MessageBoxIcon.Error) // !!!! TODO check if default really is Error !!!!
        {
            string querystring = $"?Message={System.Web.HttpUtility.UrlEncode(Message)}&Title={System.Web.HttpUtility.UrlEncode(Title)}" +
                $"MessageBoxButtons={((int)MessageBoxButtons).ToString()}&MessageBoxIcon={((int)MessageBoxIcon).ToString()}";
            Page.Title = Title;
            lblMessage.Text = Message; 

            //Server.Transfer("MessageBox.aspx" + querystring);
            //Response.Redirect("MessageBox.aspx" + querystring);
        }
    }
}