using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ManageBook
{
    class Play
    {
        private Membership membership;
        private Book book;
        private Search search;
        private Exception exception = new Exception();
        private Lent lent;
        public Play() //다른 생성자에서 객체 선언을 따로 하지 않고 접근 할 수 있도록
        {
            membership = new Membership(this);
            book = new Book(this);
            search = new Search(this);
            lent = new Lent(this);
        }
        public Membership getMembership() 
        {
            return membership;
        }
        public Book getBook()
        {
            return book;
        }

        public Exception getException()
        {
            return exception;
        }

        public void aPlay() //메인 메뉴
        {
            Console.WriteLine("1. 회원 등록 및 변경");
            Console.WriteLine("2. 도서 등록 및 변경");//삭제, 수정
            Console.WriteLine("-------------");
            Console.WriteLine("3. 도서대여 및 반납");
            Console.WriteLine("4. 검색"); // 도서, 회원(전화번호 뒷자리, 책이나 회원 이름으로, 저자명으로) 
            Console.WriteLine("5. 종료\n");
            Console.Write("Put Num: ");

            int put = exception.input(1, 5); //1~5에서만 입력가능하도록 예외처리

            switch (put)
            {
                case 1:
                    Console.Clear();
                    subQuestion("M"); //회원 등록과 변경 서비스를 이용할 수 있도록 연결한다.
                    break;
                case 2:
                    Console.Clear();
                    subQuestion("B"); //도서 등록과 변경 삭제로 연결
                    break;
                case 3:
                    Console.Clear();
                    lent.lent_return(); //책을 대여하고 반납하는 클래스로 연결한다.
                    break;
                case 4:
                    Console.Clear();
                    search.searching(); //검색을 따로 하는 클래스로 이동한다.
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("서비스를 이용해주셔서 감사합니다");
                    break;

            }
        }

        public void subQuestion(string a) //중복되는 코드를 최소화하여 위에 회원과 도서를 등록,수정,삭제 
        {
            Console.WriteLine("1. 등록 2. 수정 \n3. 삭제 4. 뒤로가기");

            int put = exception.input(1, 4);

            if (a == "M")
            {

                switch (put)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("▒회원 등록 ▒\n");
                        membership.registerMem(); 
                        break;
                    case 2:
                        Console.Clear();
                        membership.memModify(); 
                        break;
                    case 3:
                        Console.Clear();
                        membership.memDel();
                        break;
                    case 4:
                        Console.Clear();
                        aPlay();
                        break;
                }
            }
            else if (a == "B")
            {
                switch (put)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("▒도서 등록 ▒\n");
                        book.registerBook();
                        break;
                    case 2:
                        Console.Clear();
                        book.modify();
                        break;
                    case 3:
                        Console.Clear();
                        book.delData();
                        break;
                    case 4:
                        Console.Clear();
                        aPlay();
                        break;
                }
            }
        }

        public void wannaBack() //작업을 끝냈지만 종료를 하지 않고 다시 메인 메뉴로 돌아가서 할 일을 하던가 종료하게끔 한다.
        {
            Console.WriteLine("처음 화면으로 되돌아가시겠습니까?(Y/N)");
            for (;;)
            {
                string a = Console.ReadLine();
                if (a == "y" || a == "Y")
                {
                    break;
                }
                else if (a == "N" || a == "n")
                {
                    Thread.Sleep(500);
                    Console.WriteLine("Yes를 선택하신 후 메인메뉴에서 종료해주십시오.");

                }
                else
                    Console.WriteLine("Only Y or N");
            }
            aPlay();
        }
    }

}
