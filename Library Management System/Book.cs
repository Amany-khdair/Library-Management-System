using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    public class Book
    {
        #region properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public bool IsBorrowed { get; set; }
        #endregion

        #region constructor
        public Book(int id, string title, string author, double price)
        {
            Id = id;
            Title = title;
            Author = author;
            Price = price;
            IsBorrowed = false;
        }
        #endregion

        #region display function
        public void DisplayInfo()
        {
            Console.WriteLine($"Book ID: {Id}, Title: {Title}, Author: {Author}, Price: {Price}, IsBorrowed: {IsBorrowed}");
        }
        #endregion
    }
}
