using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class Optimizer
    {
        public List<Models.FitModel>  Rand5(List<Models.FitModel> fit)
        {
            return fit.GetRange(0, 9);
        }
        public int SumKcal(List<Models.FitModel> fit)
        {
            return 1;
        }
        public int SumWeight(List<Models.FitModel> fit)
        {
            return 1;
        }
        public int SumPrice(List<Models.FitModel> fit)
        {
            return 1;
        }
    }
}
