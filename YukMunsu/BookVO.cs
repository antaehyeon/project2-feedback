using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 도서관리
{
    class BookVO
    {
        private string bookNo; // 도서번호
        private string bookName; // 도서명
        private string bookPublisher; // 출판사명
        private string bookAuthor; // 저자명
        private string bookPrice; // 가격
        private string bookQuantity; // 수량

        public BookVO()
        {
            // 생성자
        }

        public BookVO(string bookNo, string bookName, string bookPublisher, string bookAuthor, string bookPrice, string bookQuantity) // 매개변수 있는 생성자
        {
            this.bookNo = bookNo;
            this.bookName = bookName;
            this.bookPublisher = bookPublisher;
            this.bookPrice = bookPrice;
            this.bookQuantity = bookQuantity;
        }

        public string BookNo // get set 프로퍼티
        {
            get { return bookNo; }
            set { bookNo = value; }
        }

        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }

        public string BookPublisher
        {
            get { return bookPublisher; }
            set { bookPublisher = value; }
        }

        public string BookAuthor
        {
            get { return bookAuthor; }
            set { bookAuthor = value; }
        }

        public string BookPrice
        {
            get { return bookPrice; }
            set { bookPrice = value; }
        }

        public string BookQuantity
        {
            get { return bookQuantity; }
            set { bookQuantity = value; }
        }
    }
}
