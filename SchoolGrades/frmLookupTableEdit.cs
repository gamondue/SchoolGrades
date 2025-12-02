using SchoolGrades.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
//using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SchoolGrades.Localization;

namespace SchoolGrades
{
    public partial class frmLookupTableEdit : Form
    {
        private string tableName;
        private string tableIdName;

        //private DataSet dataSet = null;
        //private DataAdapter dataAdapter = null;

        private BindingSource bindingSource = new BindingSource();
        public frmLookupTableEdit(string TableToBeEdited, string IdOfEditedTable)
        {
            InitializeComponent();
            LocalizeForm();

            tableName = TableToBeEdited;
            tableIdName = IdOfEditedTable;
        }       
        private void frmEditLookupTable_Load(object sender, EventArgs e)
        {
            this.Text += ". " + Loc.Get("LookupTableEdit_TableLabel") + ": " + tableName + ", " + 
                         Loc.Get("LookupTableEdit_KeyLabel") + ": " + tableIdName;
            bindingSource.DataSource = Commons.bl.GetLookupTable(tableName, tableIdName);
            dgwTable.DataSource = bindingSource;
        }
        private void frmEditLookupTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            // commit changes to the grid to reflect changes on the DataTable (Dataset)
            dgwTable.EndEdit();
            bindingSource.EndEdit();
            // if the dataset has changed, we ask the user if he wants to save it
            if (Commons.bl.LookupTableDataHasChanged())
            {
                DialogResult result = MessageBox.Show(
                    Loc.Get("LookupTableEdit_SaveChanges"), 
                    Loc.Get("LookupTableEdit_Saving"),
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    BtnSalva_Click(sender, e);
                }
            }
            Commons.bl.CloseLookupTableEditing();
        }
        private void BtnSalva_Click(object sender, EventArgs e)
        {
            // we assume that the primary keys are unique, since the code has controlled before.
            // Since that previous code could not check effectively the nullity of primary keys
            // we check here
            foreach (DataGridViewRow r in dgwTable.Rows)
            {
                if ((r.Cells[tableIdName].Value == null || r.Cells[tableIdName].Value.ToString() == "")
                    && r.Index != dgwTable.Rows.Count - 1)
                {
                    MessageBox.Show(
                        string.Format(Loc.Get("LookupTableEdit_KeyNotEmpty"), tableIdName) + 
                        "\n" + Loc.Get("LookupTableEdit_DataNotSaved"));
                    return;
                }
            }
            Commons.bl.UpdateLookupTable();
        }
        private void dgwTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // we check if the key enter from usar is already in the table
            // I tried to use the DataTable bound to the DataGridView, but it is not kept
            // in sync with the DataGridView, so I have to scam manually the DataGridView Cells
            // I left in the BL_LookupTablesManagement.cs, Datalayer.cs and Lite_LookupTableManagement.cs
            // the method to check if the key exists in the DataTable and the data structures used by it 

            // index of selected row
            int selectedRowIndex = dgwTable.CurrentCell.RowIndex;
            // value of key column of selected row
            object selectedRowKey = dgwTable.Rows[selectedRowIndex].Cells[tableIdName].Value;
            // DataTable bound to DataGridView
            DataTable dataTable = (DataTable)bindingSource.DataSource;
            // if the key cell is null: do nothing
            if (selectedRowKey == null || selectedRowKey.ToString() == "")
                return;
            bool foundExistingKey = false;
            foreach (DataGridViewRow r in dgwTable.Rows)
            {
                if (r.Index != selectedRowIndex)
                {
                    if (r.Cells[tableIdName].Value != null 
                        && (r.Cells[tableIdName].Value.ToString() == selectedRowKey.ToString()))
                    {
                        foundExistingKey = true;
                        break;
                    }
                }
            }
            if (foundExistingKey)
            {
                MessageBox.Show(
                    string.Format(Loc.Get("LookupTableEdit_CodeExists"), selectedRowKey, tableName) + 
                    "\n" + Loc.Get("LookupTableEdit_ChooseDifferent"));
                dgwTable.Rows[selectedRowIndex].Cells[tableIdName].Value = "";
            }
        }
        private void dgwTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }
        private void LocalizeForm()
        {
            try
            {
                // Form title
                this.Text = Loc.Get("LookupTableEdit_Title");

                // Labels
                label1.Text = Loc.Get("LookupTableEdit_Warning");
                label2.Text = Loc.Get("LookupTableEdit_PlanCarefully");

                // Button
                BtnSalva.Text = Loc.Get("Common_Save");
            }
            catch (Exception ex)
            {
                Commons.ErrorLog($"frmLookupTableEdit.LocalizeForm: {ex.Message}");
            }
        }

    }
}
