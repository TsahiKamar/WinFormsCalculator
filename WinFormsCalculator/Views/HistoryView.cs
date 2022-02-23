using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsCalculator.Models;
using WinFormsCalculator.Services;

namespace WinFormsCalculator.Views
{
    public sealed partial class HistoryView : ViewBase
    {
        #region Private fields
        private HistoryViewModel _model;               

        #endregion

        #region Ctor
        /// <summary>
        /// Construct our ExampleView and use Dependancy Injection to use a passed Model.
        /// </summary>
        /// <param name="model">ExampleViewModel to use for Binding</param>
        public HistoryView(HistoryViewModel model = null)
        {
              
            // Check if a ViewModel was passed to the ctor
            if (model != null)
            {
                //Todo: Todo: Add type checking here to ensure that types of model valid only for this View type are assigend, otherwise create a default model (ExampleViewModel).
                // Assign a local reference to the model.
                _model = model;
            }
            else
            {
                // Create a new instance of the ViewModel for this specific View, as one was not provided to the ctor
                _model = new HistoryViewModel();
            }

            InitializeComponent();
            this.sDataGridView.ScrollBars = ScrollBars.Both;

            this.sDataGridView.DataSource = _model.Calculations;
            
            // Bind the controls for this View to their Model's properties.
            //PerformBinding();
        }




        #endregion


        //private void sDataGridView_CellFormatting(object sender,
        //    System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        //{
        //    if (e != null)
        //    {
        //        //if (this.sDataGridView.Columns[e.ColumnIndex].Name == "Release Date")
        //        //{
        //        //    if (e.Value != null)
        //        //    {
        //        //        try
        //        //        {
        //        //            //e.Value = DateTime.Parse(e.Value.ToString())
        //        //            //    .ToLongDateString();
        //        //            //e.FormattingApplied = true;
        //        //        }
        //        //        catch (FormatException)
        //        //        {
        //        //            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
        //        //        }
        //        //    }
        //        //}
        //    }
        //}

        //private void addNewRowButton_Click(object sender, EventArgs e)
        //{
        //    this.sDataGridView.Rows.Add();
        //}

        //private void deleteRowButton_Click(object sender, EventArgs e)
        //{
        //    if (this.sDataGridView.SelectedRows.Count > 0 &&
        //        this.sDataGridView.SelectedRows[0].Index !=
        //        this.sDataGridView.Rows.Count - 1)
        //    {
        //        this.sDataGridView.Rows.RemoveAt(
        //            this.sDataGridView.SelectedRows[0].Index);
        //    }
        //}

        private void SetupLayout()
        {
            this.Size = new Size(800, 650);
        }

        private void SetupDataGridView()
        {
            this.Controls.Add(sDataGridView);

            sDataGridView.ColumnCount = 5;

            sDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            sDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            sDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(sDataGridView.Font, FontStyle.Bold);

            sDataGridView.Name = "sDataGridView";
            sDataGridView.Location = new Point(8, 8);
            sDataGridView.Size = new Size(800, 500);
            sDataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            sDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            sDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            sDataGridView.GridColor = Color.Black;
            sDataGridView.RowHeadersVisible = false;

            sDataGridView.Columns[0].Name = "Num1";
            sDataGridView.Columns[1].Name = "Num2";
            sDataGridView.Columns[2].Name = "Oper";
            sDataGridView.Columns[3].Name = "Result";

            sDataGridView.ScrollBars = ScrollBars.Horizontal;

            //sDataGridView.Columns[4].DefaultCellStyle.Font =
            //    new Font(sDataGridView.DefaultCellStyle.Font, FontStyle.Italic);

            sDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            sDataGridView.MultiSelect = false;
            sDataGridView.Dock = DockStyle.Fill;

            //sDataGridView.CellFormatting += new
            //    DataGridViewCellFormattingEventHandler(
            //    sDataGridView_CellFormatting);
        }

   
        /// <summary>
        /// Sets up binding for the tbName and lblName controls used in this ExampleView.
        /// <para>You might want to also implement an interface that ensures all of your View types implement PerformBinding() to keep everything predictable.</para>
        /// </summary>
        public sealed override void PerformBinding()
        {
 
        }


    }
}