
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
using WinFormsCalculator.Services;

namespace WinFormsCalculator.Models
{
    /// <summary>
    /// </summary>
    public sealed class HistoryViewModel : ViewModelBase
    {
        private readonly ICalcService _calcService;

        #region Private fields
        private List<Calc> _calculations;            

        #endregion

        #region Public Properties
        /// <summary>

        public List<Calc> Calculations
        {
            get => _calculations;
        }

        #endregion

        #region Ctor
        /// <summary>
        /// ViewModel responsible for the Example form.
        /// </summary>
        public HistoryViewModel()
        {
            _calcService = new CalcService();
            _calculations = _calcService.GetCalcHistory();
        }

        #endregion
    }
}
