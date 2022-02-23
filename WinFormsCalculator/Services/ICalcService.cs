using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsCalculator.Models;

namespace WinFormsCalculator.Services
{
    public interface ICalcService
    {
        public List<Calc> GetCalcHistory();
        Task<List<Calc>> GetAsyncCalcHistory();
        public Calc AddNewCalc(Calc request);//Task<HttpResponseMessage>

    }
}
