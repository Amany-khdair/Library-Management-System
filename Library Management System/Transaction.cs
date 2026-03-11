using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    public enum TransactionType
    {
        Borrow,
        Return
    }
    public class Transaction
    {
        #region properties
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string MemberName { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        #endregion

        #region constructor
        public Transaction(int id, string bookTitle, string memberName, TransactionType type)
        {
            Id = id;
            BookTitle = bookTitle;
            MemberName = memberName;
            Date = DateTime.Now;
            Type = type;
        }
        #endregion

        public void DisplayInfo()
        {
            Console.WriteLine($"Transaction ID: {Id}, Book: {BookTitle}, Member: {MemberName}, Date: {Date}, Type: {Type}");
        }
    }
}
