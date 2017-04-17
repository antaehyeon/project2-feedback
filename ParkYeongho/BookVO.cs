using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class BookVO
    {
        private string bookNo = "";
        private string bookName = "";
        private string bookAuthor = "";
        private string bookPublisher = "";
        private string bookPrice = "";
        private string bookReservation = "대여 가능";
        private DateTime bookReturnDate;


        public BookVO() { }                                                                                                         // BookVO의 기본 생성자 생성
        public BookVO(string aBookNo, string aBookName, string aBookAuthor, string aBookPublisher, string aBookPrice, string aBookReservation)      // aBookNo, aBookName, aBookAuthor, aBookPublisher, aBookPrice, aBookReservation을 넘겨 받아 BookVO의 생성자 생성
        {
            this.bookNo = aBookNo;
            this.bookName = aBookName;
            this.bookAuthor = aBookAuthor;
            this.bookPublisher = aBookPublisher;
            this.bookPrice = aBookPrice;
            this.bookReservation = aBookReservation;
        }
        public string BookNo                                                                                                        // BookNo 값을 get set을 이용하여 읽고 쓰기
        {
            get { return bookNo; }
            set { bookNo = value; }
        }

        public string BookName                                                                                                      // BookName 값을 get set을 이용하여 읽고 쓰기
        {
            get { return bookName; }
            set { bookName = value; }
        }

        public string BookAuthor                                                                                                    // BookAuthor 값을 get set을 이용하여 읽고 쓰기
        {
            get { return bookAuthor; }
            set { bookAuthor = value; }
        }

        public string BookPublisher                                                                                                 // BookPublisher 값을 get set을 이용하여 읽고 쓰기
        {
            get { return bookPublisher; }
            set { bookPublisher = value; }
        }

        public string BookPrice                                                                                                     // BookPrice 값을 get set을 이용하여 읽고 쓰기
        {
            get { return bookPrice; }
            set { bookPrice = value; }
        }
        public string BookReservation                                                                                               // BookReservation 값을 get set을 이용하여 읽고 쓰기
        {
            get { return bookReservation; }
            set { bookReservation = value; }
        }

        public DateTime BookReturnDate                                                                                              // BookReturnDate 값을 get set을 이용하여 읽고 쓰기
        {
            get { return bookReturnDate; }
            set { bookReturnDate = value; }
        }
    }
}
