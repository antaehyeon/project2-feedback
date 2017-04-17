using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class BookVO
    {
        
        private string bookName;
        private string bookAuthor;
        private int bookPrice;
        private int bookQuantity;
        private int bookNum;
        private BookVO Book;

        

        public BookVO()
        { }
        public BookVO(BookVO Book, string BookName,string BookAuthor, int BookPrice, int BookQuantity, int BookNum)
        {
            this.Book = Book;
            this.bookNum = BookNum;
            this.bookName = BookName;
            this.BookAuthor = BookAuthor;
            this.bookPrice = BookPrice;
            this.bookQuantity = BookQuantity;

        }
        public int BookNum
        {
            get { return bookNum; }
            set { bookNum = value; }
        }
        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }
        public string BookAuthor
        {
            get { return bookAuthor; }
            set { bookAuthor = value; }
        }
        public int BookPrice
        {
            get { return bookPrice; }
            set { bookPrice = value; }
        }
        public int BookQuantity
        {
            get { return bookQuantity; }
            set { bookQuantity = value; }
        }
        
    }
}
