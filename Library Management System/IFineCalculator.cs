using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    public interface IFineCalculator
    {
        double CalculateFine(int daysLate);
    }
}
