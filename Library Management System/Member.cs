using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    public abstract class Member
    {
        #region properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Book[] BorrowedBooks { get; set; }
        public int BorrowIndex { get; set; }
        #endregion

        #region constructor
        public Member(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
            BorrowedBooks = new Book[10];
            BorrowIndex = 0;
        }
        #endregion

        public abstract int GetMaxBorrowLimit();

        #region Borrow function
        public void BorrowBook(Book book)
        {
            if (BorrowIndex < GetMaxBorrowLimit())
            {
                BorrowedBooks[BorrowIndex] = book;
                BorrowIndex++;
                book.IsBorrowed = true;
                Console.WriteLine($"{Name} borrowed: {book.Title}");
            }
            else
            {
                Console.WriteLine($"{Name} has reached the max borrow limit!");
                return;
            }
        }
        #endregion

        #region Return function
        public void ReturnBook(Book book)
        {
            for (int i = 0; i < BorrowIndex; i++)
            {
                if (BorrowedBooks[i] != null && BorrowedBooks[i].Id == book.Id)
                {
                    BorrowedBooks[i] = BorrowedBooks[BorrowIndex - 1];
                    BorrowedBooks[BorrowIndex - 1] = null;
                    BorrowIndex--;
                    book.IsBorrowed = false;

                    Console.WriteLine($"{Name} returned: {book.Title}");
                    return;
                }
            }
            Console.WriteLine($"{Name} did not borrow: {book.Title}");
        }
        #endregion

        #region Operator overloading
        public static bool operator >(Member m1, Member m2)
        {
            return m1.BorrowIndex > m2.BorrowIndex;
        }
        public static bool operator <(Member m1, Member m2)
        {
            return m1.BorrowIndex < m2.BorrowIndex;
        }
        public static int operator +(Member m1, Member m2)
        {
            return m1.BorrowIndex + m2.BorrowIndex;
        }
        #endregion
    }
}
