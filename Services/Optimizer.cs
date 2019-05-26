using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class Optimizer
    {
        public int UserKcal { get; set; }
        public List<Models.FitModel>  Rand5(List<Models.FitModel> fit)
        {
            return fit.GetRange(0, 9);
        }
        public List<Models.FitModel> Fit(List<Models.FitModel> all)
        {
            var result = new List<Models.FitModel>();
            Random rnd = new Random();
            int Length = all.Count;
            int TempWeight;
            float TempPrice;
            int TempKcal;
            int sumkcal = 0;
            int NumOfIngredients = 0;
            do
            {

                result.Add(all[rnd.Next(Length)]); //wylosowanie jednego elementu nie działa
                TempWeight = rnd.Next(2, 8); //Losowanie Wagi co 100 gram
                TempPrice = TempWeight * result[NumOfIngredients].Price;
                TempKcal = TempWeight * result[NumOfIngredients].Kcal;
                sumkcal += TempKcal;
                result[NumOfIngredients].Price = TempPrice;
                result[NumOfIngredients].Kcal = TempKcal;
                result[NumOfIngredients].Weight = TempWeight * 100;

                NumOfIngredients++;
            }
            while (sumkcal < UserKcal);


            return result;
        }
        public int SumKcal(List<Models.FitModel> result)
        {
            int sum1 = 0;
            foreach (var Item in result)
            {
                sum1 += Item.Kcal;
            }
            return sum1;
        }
        public int SumWeight(List<Models.FitModel> result)
        {
            int sum2 = 0;
            foreach (var Item in result)
            {
                sum2 += Item.Weight;
            }
            return sum2;
        }
        public float SumPrice(List<Models.FitModel> result)
        {
            float sum3 = 0;
            foreach (var Item in result)
            {
                sum3 += Item.Price;
            }
            return sum3;
        }
    }
}
