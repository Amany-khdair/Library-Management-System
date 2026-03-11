using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    public class StudentMember: Member
    {
        #region constructor
        public StudentMember(int id, string name, string phone) : base(id, name, phone)
        {
        }
        #endregion
        public override int GetMaxBorrowLimit()
        {
            return 3;
        }    
    }
}
