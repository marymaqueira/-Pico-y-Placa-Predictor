using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PredictorProject.Services
{
    public class PlateNumberService
    {
      private string StorePredictor(char ult_dig_placa)
        {
            var restrictions = new Dictionary<char, string>();

            restrictions.Add('1', "Mon");
            restrictions.Add('2', "Mon");
            restrictions.Add('3', "Tue");
            restrictions.Add('4', "Tue");
            restrictions.Add('5', "Wed");
            restrictions.Add('6', "Wed");
            restrictions.Add('7', "Thu");
            restrictions.Add('8', "Thu");
            restrictions.Add('9', "Fri");
            restrictions.Add('0', "Fri");

            var ver = restrictions[ult_dig_placa];
            return restrictions[ult_dig_placa];
        }
        public bool ValidateHour(DateTime hour)
        {
            DateTime start_hour_morning = Convert.ToDateTime("07:00");
            DateTime end_hour_morning = Convert.ToDateTime("09:30");
            DateTime start_hour_afternoons = Convert.ToDateTime("16:00");
            DateTime end_hour_afternoons = Convert.ToDateTime("19:30");
            var com = hour.CompareTo(start_hour_morning);
            var comp2 = hour.CompareTo(end_hour_morning);
            if (hour.CompareTo(start_hour_morning) >= 0 && hour.CompareTo(end_hour_morning) <= 0)
            {
                return true;

            }
            else if (hour.CompareTo(start_hour_afternoons) >= 0 && hour.CompareTo(end_hour_afternoons) <= 0)
            {
                return true;

            }
            {
                return false;
            }
        }

        public string getResult(char lastDig, string day, DateTime hour)
        {
            var _val = StorePredictor(lastDig);
            var  _isHourValid = ValidateHour(hour);
            // string[] areValidated = new string[] { "SAT", "SUN" };

            if (_val.Equals(day) && _isHourValid)
                return "Be careful!! If you drive you can be fined.";
            else
                return "Ok, you can circulate without problem.";
        }

    }
}