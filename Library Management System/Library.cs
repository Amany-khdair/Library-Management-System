using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    public class Library
    {
        #region Properties
        public Book[] Books { get; set; }
        public Member[] Members { get; set; }
        public Transaction[] Transactions { get; set; }

        private int bookIndex;
        private int memberIndex;
        private int transactionIndex;

        public static int TotalBorrowedBooks { get; set; }
        private IFineCalculator fineCalculator;
        #endregion

        #region Constructor
        public Library(int bookCapacity, int memberCapacity, int transactionCapacity)
        {
            Books = new Book[bookCapacity];
            Members = new Member[memberCapacity];
            Transactions = new Transaction[transactionCapacity];

            bookIndex = 0;
            memberIndex = 0;
            transactionIndex = 0;
            TotalBorrowedBooks = 0;
            fineCalculator = new FineCalculator();
        }
        #endregion

        #region Add Book
        public void AddBook(Book book)
        {
            if (bookIndex < Books.Length)
            {
                Books[bookIndex] = book;
                bookIndex++;
                Console.WriteLine($"Added Book: {book.Title}");
            }
            else
            {
                Console.WriteLine("Book capacity reached!");
            }
        }
        #endregion

        #region Add Member
        public void AddMember(Member member)
        {
            Members[memberIndex] = member;
            memberIndex++;
        }
        #endregion

        #region Borrow Book
        public void BorrowBook(int memberId, int bookId)
        {
            Member member = Array.Find(Members, m => m != null && m.Id == memberId);
            Book book = Array.Find(Books, b => b != null && b.Id == bookId);
            if (member == null)
            {
                Console.WriteLine("Member not found!");
                return;
            }
            if (book == null)
            {
                Console.WriteLine("Book not found!");
                return;
            }
            if (book.IsBorrowed)
            {
                Console.WriteLine("Book is already borrowed!");
                return;
            }
            member.BorrowBook(book);
            book.IsBorrowed = true;
            Transactions[transactionIndex] = new Transaction(transactionIndex + 1, book.Title, member.Name, TransactionType.Borrow);
            transactionIndex++;
            TotalBorrowedBooks++;
        }
        #endregion

        #region Return Book
        public void ReturnBook(int memberId, int bookId, int daysLate)
        {
            Member member = Array.Find(Members, m => m != null && m.Id == memberId);
            Book book = Array.Find(Books, b => b != null && b.Id == bookId);
            if (member == null)
            {
                Console.WriteLine("Member not found!");
                return;
            }
            if (book == null)
            {
                Console.WriteLine("Book not found!");
                return;
            }
            member.ReturnBook(book);
            book.IsBorrowed = false;
            double fine = fineCalculator.CalculateFine(daysLate);
            Console.WriteLine($"Late by {daysLate} days. Fine: ${fine}");

            Transactions[transactionIndex] = new Transaction(transactionIndex + 1, book.Title, member.Name, TransactionType.Return);
            transactionIndex++;
            TotalBorrowedBooks--;
        }
        #endregion

        #region Print Transactions
        public void PrintTransactions()
        {
            Console.WriteLine("\n===== Transactions =====");
            for (int i = 0; i < transactionIndex; i++)
            {
                if (Transactions[i] != null)
                    Transactions[i].DisplayInfo();
            }
        }
        #endregion
    }
}
