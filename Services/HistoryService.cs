using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class HistoryService: Service
    {
        public HistoryService(UserModel _user) :base (_user)
        {

        }
        public List<Models.History> UserHistory()
        {
            var history = new List<Models.History>();
            var args = new List<string>();
            args.Add(User.Username);
            //args.Add(User.Password); non required
            var answer = db.Procedure("View_History_User", args);
            for (int i=0;i<answer.Count;i+=3)
            {
                var unit = new History() {
                    Name="none",
                    Amount=0,
                    Date="none"
                };
                if (answer[i] != "")
                    unit.Name = answer[i];
                if (answer[i + 1] != "")
                    unit.Amount = int.Parse(answer[i + 1]);
                if (answer[i + 2] != "")
                    unit.Date = answer[i + 2];
               
                history.Add(unit);
            }
            return history;
        }

        public bool Add(List<Models.FitModel> fit, UserModel user)
        {
            try
            {
                var args = new List<string>();
                //var history = FitToHistory(fit);
                foreach(var unit in fit)
                {
                    args = new List<string>();
                    args.Add(User.Id.ToString());
                    args.Add(unit.ProductID.Value.ToString());
                    args.Add(unit.IngredientID.Value.ToString());
                    args.Add(unit.Weight.ToString());

                    var answer = db.Procedure("Add_History_User", args);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        
    }
}
