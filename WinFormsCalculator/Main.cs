using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsCalculator.Models;
using WinFormsCalculator.Services;
using WinFormsCalculator.Views;

namespace WinFormsCalculator
{
    public partial class Main : Form
    {
        #region Private Fields
        private ViewBase _view;          // Field used to store our View
        private ViewModelBase _model;    // Field used to store our ViewModel
        #endregion

      

        #region Private Methods
        /// <summary>
        /// Change the View this form is displaying.
        /// </summary>
        /// <param name="view">View type to display.</param>
        private void SwapView(ViewBase view = null)
        {
            // Check the passed View is a real object.
            if (view != null)
            {
                // Remove the current View from the Form's control collection, as its going to be swapped for the new View.
                this.Controls.Remove(_view);

                // Is the View an ExampleView
                if (view is HistoryView)
                {
                    _model = new HistoryViewModel();
                    _view = new HistoryView(_model as HistoryViewModel);
                }

                // If the View an OtherView
                if (view is CalculatorView)
                {
                    _model = new CalculatorViewModel();
                    _view = new CalculatorView(_model as CalculatorViewModel);
                }
              
            }
            else
            {
                // Todo: Perhaps implement some error handling here too, as well as just displaying an ExampleView as default?
                _model = new HistoryViewModel();
                _view = new HistoryView(_model as HistoryViewModel);
            }

            this.Controls.Add(_view);

        }

 
        #endregion

        #region Ctor
        public Main(ViewBase view = null)
        {
            // Load the View for this Form's initial state.
            SwapView(new HistoryView());

            InitializeComponent();
        }


        #endregion

        /// <summary>
        /// Event Handler for the 'Load ExampleView' Button.
        /// </summary>
        private void btnLoadExampleView_Click(object sender, EventArgs e)
        {
            SwapView(new HistoryView());
        }

        private void btnLoadOtherView_Click(object sender, EventArgs e)
        {
            SwapView(new CalculatorView());

        }

      
    }
}
