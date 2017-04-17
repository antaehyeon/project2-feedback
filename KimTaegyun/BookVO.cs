using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    class BookVO // Book Value Object 
    {
        private string BookName;
        private string BookAuthor;
        private string BookPrice;
        private int Rent;
        

        public BookVO() { }

        public BookVO(string BookName, string BookAuthor, string BookPrice, int Rent)
        {
            this.BookName = BookName;
            this.BookAuthor = BookAuthor;
            this.BookPrice = BookPrice;
            this.Rent = Rent;
        }

        public string bookname
        {
            get { return BookName; }
            set { BookName = value; }
        }

        public string bookauthor
        {
            get { return BookAuthor; }
            set { BookAuthor = value; }
        }
        public string bookprice
        {
            get { return BookPrice; }
            set { BookPrice = value; }
        }
        public int rent
        {
            get { return Rent; }
            set { Rent = value; }
        }
 
    }
}

