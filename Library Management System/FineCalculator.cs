using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    public class FineCalculator: IFineCalculator
    {
        public double CalculateFine(int daysLate)
        {
            if (daysLate <= 0)
                return 0;
            else if (daysLate <= 5)
                return daysLate * 1.5;
            else
                return 5 * 1.5 + (daysLate - 5) * 2.5; // $1.5 per day for first 5 days, then $2.5 per day for additional days
        }       
    }
}
