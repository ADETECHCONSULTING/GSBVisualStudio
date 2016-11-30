using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewService
{
    public class GestionDate
    {
      
        public static String moisPrecedent()
        {
            DateTime d = DateTime.Now;
            string moisPredecent = d.AddMonths(-1).ToString("yyyyMM");

            return moisPredecent;
        }

        public static String moisSuivant()
        {
            DateTime d = DateTime.Now;
            string moisPredecent = d.AddMonths(+1).ToString("yyyyMM");

            return moisPredecent;
        }

        public static Boolean dansLintervalleCL()
        {
            DateTime d = DateTime.Now;
            int leJour = Convert.ToInt32(d.ToString("dd"));

            if(leJour > 0 & leJour < 11)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean dansLintervalleRB()
        {
            DateTime d = DateTime.Now;
            int leJour = Convert.ToInt32(d.ToString("dd"));

            if (leJour > 19 & leJour < 31)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int afficheJour()
        {
            DateTime d = DateTime.Now;
            int leJour = Convert.ToInt32(d.ToString("dd"));

            return leJour;
        }
    }
}
