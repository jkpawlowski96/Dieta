using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class FitService: Service
    {
        public FitService(UserModel _user) : base(_user)
        {

        }
        public List<FitModel> ProductsList()
        {
            var fit = new List<Models.FitModel>();
            var answer = db.View("ProductsList");
            for (int i = 0; i < answer.Count; i += 6)
            {
                var unit = new FitModel()
                {
                    Ingredient = "none",
                    Weight = 0,
                    Kcal = 0,
                    Price = 0

                };
                if (answer[i] != "")
                    unit.ProductID = int.Parse(answer[i]);
                if (answer[i +1 ] != "")
                    unit.IngredientID = int.Parse(answer[i + 1]);
                if (answer[i + 2] != "")
                    unit.Ingredient = answer[i + 2];
                if (answer[i + 3] != "")
                    unit.Weight = int.Parse(answer[i + 3]);
                if (answer[i + 4] != "")
                    unit.Kcal = int.Parse(answer[i + 4]);
                if (answer[i + 5] != "")
                    unit.Price = float.Parse(answer[i + 5]);

                fit.Add(unit);
            }
            return fit;
        }
        public List<FitModel> Fit(UserModel user)
        {
            var fit = new List<Models.FitModel>();
            var args = new List<string>();
            args.Add(IntFromBool(user.Lactose).ToString());
            args.Add(IntFromBool(user.Gluten).ToString());
            args.Add(IntFromBool(user.Vege).ToString());

            var answer = db.Procedure("ProductsFit", args);
            for (int i = 0; i < answer.Count; i += 6)
            {
                var unit = new FitModel()
                {
                    Ingredient = "none",
                    Weight = 0,
                    Kcal = 0,
                    Price = 0

                };
                if (answer[i] != "")
                    unit.ProductID = int.Parse(answer[i]);
                if (answer[i + 1] != "")
                    unit.IngredientID = int.Parse(answer[i + 1]);
                if (answer[i + 2] != "")
                    unit.Ingredient = answer[i + 2];
                if (answer[i + 3] != "")
                    unit.Weight = int.Parse(answer[i + 3]);
                if (answer[i + 4] != "")
                    unit.Kcal = int.Parse(answer[i + 4]);
                if (answer[i + 5] != "")
                    unit.Price = float.Parse(answer[i + 5]);

                fit.Add(unit);
            }
            return fit;
        }


        int IntFromBool(bool arg)
        {
            if (arg)
                return 1;
            else return 0;
        }
    }
}
