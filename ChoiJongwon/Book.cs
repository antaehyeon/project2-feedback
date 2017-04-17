using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManamement
{
    class Book
    {
        // Data
        private string bookName;              //  도서명
        private string bookWriter;            //  저자
        private string bookPublisher;         //  도서출판사
        private int bookPrice;                //  도서가격
        private string bookReturnDate;        //  도서반납기한을 이후에 DateTime클래스를 통해 string형으로 변환하여 저장하는 string형 변수
        private string bookAvailable;         //  도서 대출여부 'O' or 'X'
        private User bookUser;                //  도서를 대여한 사용자 정보를 담고있는 User(V/O)클래스의 객체

        // Constructor
        public Book() {}
        public Book(string bookName, string bookWriter, string bookPublisher, int bookPrice, string bookReturnDate, string bookAvailable, User user)
        {
            this.bookName = bookName;
            this.bookWriter = bookWriter;
            this.bookPublisher = bookPublisher;
            this.bookPrice = bookPrice;
            this.bookReturnDate = bookReturnDate;
            this.bookAvailable = bookAvailable;
            this.bookUser = user;
        }

        public Book(Book book)
        {
            bookName = book.BookName;
            bookWriter = book.BookWriter;
            bookPublisher = book.BookPublisher;
            bookPrice = book.BookPrice;
            bookReturnDate = book.BookReturnDate;
            bookAvailable = book.BookAvailable;
            bookUser = book.BookUser;
        }

        // Get / Set
        public User BookUser
        {
            get { return bookUser; }
            set { bookUser = value; }
        }

        public string BookAvailable
        {
            get { return bookAvailable; }
            set { bookAvailable = value; }
        }

        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }

        public string BookWriter
        {
            get { return bookWriter; }
            set { bookWriter = value; }
        }

        public string BookPublisher
        {
            get { return bookPublisher; }
            set { bookPublisher = value; }
        }

        public int BookPrice
        {
            get { return bookPrice; }
            set { bookPrice = value; }
        }

        public string BookReturnDate
        {
            get { return bookReturnDate; }
            set { bookReturnDate = value; }
        }
    }
}
