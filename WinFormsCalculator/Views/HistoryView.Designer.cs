using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using WinFormsCalculator.Models;


namespace WinFormsCalculator.Views
{
    partial class HistoryView
    {
        #region Designer Created
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;             // When doing this properly, you would want to make a collection of your components within this UserControl.

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container(); 

            this.lblName = new System.Windows.Forms.Label();

            this.sDataGridView = new DataGridView();

            this.SuspendLayout();

            //Grid
            sDataGridView.Location = new Point(24, 50);
            sDataGridView.Size = new Size(400, 400);
 
           this.Controls.Add(sDataGridView);

            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Name = "History View";
            this.Size = new System.Drawing.Size(420, 314);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblName;
        private DataGridView sDataGridView = new DataGridView();


        #endregion
    }
}