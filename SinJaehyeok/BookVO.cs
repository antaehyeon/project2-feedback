using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensharp_study_assignment2_1v
{
    class BookVO
    {
        //등록된 책을 관리하기 위한 Value Object(도서명, 저자, 가격, 수량, 빌려간 사람)
        //BookLoan은 책 빌려간 사람으로 수량에 따라, 여러사람도 빌려갈 수 있기 때문에 리스트로 여러 값을 저장하게 만듬
        private string BookName;
        private string BookAuthor;
        private int BookPrice;
        private int BookQuantity;
        private List<string> BookLoan = new List<string>();

        public BookVO(string BookName, string BookAuthor, int BookPrice, int BookQuantity)
        {
            this.BookName = BookName;
            this.BookAuthor = BookAuthor;
            this.BookPrice = BookPrice;
            this.BookQuantity = BookQuantity;
        }
        public string BookNAME
        {
            get { return BookName; }
            set { BookName = value; }
        }
        public string BookAUTHOR
        {
            get { return BookAuthor; }
            set { BookAuthor = value; }
        }
        public int BookPRICE
        {
            get { return BookPrice; }
            set { BookPrice = value; }
        }
        public int BookQUANTITY
        {
            get { return BookQuantity; }
            set { BookQuantity = value; }
        }
        public List<string> BookLOAN
        {
            get { return BookLoan; }
            set { BookLoan = value; }
        }
    }
}
