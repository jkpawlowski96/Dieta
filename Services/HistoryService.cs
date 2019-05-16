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
            var answer = db.Query("View_History_User", args);
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
    }
}
