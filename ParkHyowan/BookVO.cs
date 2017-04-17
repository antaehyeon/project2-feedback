using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBook
{
    class BookVO
    {
        private string bookNo;
        private string bookName;
        private string bookWriter;
        private string bookPrice;
        private bool lent;
        private BookVO book;

        public BookVO(BookVO book, string bName, string author, string price, bool lending) //수정되면 안 되는 정보들이기에 private로 선언하고 값을 빼서 쓴다.
        {
            this.book = book;
            this.bookName = bName;
            this.bookWriter = author;
            this.bookPrice = price;
            this.lent = lending;
        }
        public string bNo
        {
            get
            {
                return this.bookNo;
            }
            set { this.bookNo = value; }
        }

        public string bName
        {
            get { return this.bookName; }
            set { this.bookName = value; }
        }
        public string author
        {
            get { return this.bookWriter; }
            set { this.bookWriter = value; }
        }

        public string price
        {
            get { return this.bookPrice; }
            set { this.bookPrice = value; }
        }

        public bool lending
        {
            get {return this.lent; }
            set { this.lent = value; }
        }
    }
}
