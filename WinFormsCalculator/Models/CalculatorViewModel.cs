using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsCalculator.Services;

namespace WinFormsCalculator.Models
{
    public sealed class CalculatorViewModel : ViewModelBase
    {


        #region Private fields
        //private StringBuilder _otherFunText;            
        #endregion

        #region Public Properties
        /// <summary>
        /// Property we will be allowing our Example Form to bind to.
        /// </summary>
        public CalcService CalcService
        {
            get => new CalcService();
        }
        #endregion

        #region Ctor
        /// <summary>
        /// ViewModel responsible for the Example form.
        /// </summary>
        public CalculatorViewModel()
        {
            // Initialize backing fields
            //_otherFunText = new StringBuilder();
        }

        #endregion
    }
}