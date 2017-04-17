using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBook
{
    class Book
    {
        Play play; //클래스 play의 변수명을 선언하고
        //Play play = new Play();
        public List<BookVO> bookList = new List<BookVO>(); //클래스 play를 통해서 접근할 수 있도록 public으로 선언한다
        public BookVO bookvo = new BookVO(null, null, null, null, false);
        public Book(Play p) //클래스 play와 연결; 괄호 속 안 파라미터가 클래스play에서 본인을 받는다.
        {
            play = p;
        }

        public void registerBook() //도서등록
        {

            Console.Write("도서명: "); //영어나 한글,특수기호 되게, 엔터 되면 안됨.
            bookvo.bName = Console.ReadLine();
            Console.Write("저자: ");
            bookvo.author = Console.ReadLine();
            Console.Write("가격: "); //숫자만 가능하게
            bookvo.price = Console.ReadLine();
            bookvo.lending = false; //책이 대출가능한지 불가능한지 알기 위하여 VO클래스에서 bool함수로 선언하였다. false면 대출가능 true면 대출불가능
            bookList.Add(new BookVO(bookvo, bookvo.bName, bookvo.author, bookvo.price, bookvo.lending)); //도서등록 할 때마다 Add를 하는데 stack이 쌓이게끔 새로운 객체선언을 하여 추가하여 넣는다

            Console.WriteLine("{0}이(가) 등록되었습니다", bookvo.bName);
            play.aPlay();
        }

        public void modify()
        {
            Console.Write("수정하고 싶은 도서이름을 입력하세요: ");
            for (;;)
            {
                string n = Console.ReadLine(); //문자열로 선언하여 입력하였다
                if (n == bookvo.bName) //그렇기에 내가 저장한 도서 이름과 같으면 멈추고 다시 수정이 가능하게 한다.
                {
                    break;
                }
                else
                    Console.WriteLine("등록한 책 이름을 정확하게 써주세요"); //내가 입력한 문자열과 bookvo.bName에 저장된 문자열과 같지 않으면 선언 될 문장
            }
            Console.WriteLine("▒책 정보 수정▒");
            registerBook();
        }

        public void delData()
        {
            ableList();
            Console.Write("\n지우고 싶은 도서이름을 입력하세요: ");
            for (;;)
            {

                string n = Console.ReadLine();
                if (n == bookvo.bName) //내가 삭제하고자 하는 도서이름을 찾아 맞으면
                {
                    for (int i = 0; i < bookList.Count; i++) //리스트요소 수 만큼 읽어서
                    {
                        n = bookList[i].bName; //인덱스를 찾는다.
                        if (bookList[i].bName == bookvo.bName) //찾은 인덱스와 도서명과 같으면
                        {
                            int a = i; bookList.RemoveAt(a); //특정 인덱스 위치를 지운다
                        }
                    }
                    break;
                }
                else
                    Console.WriteLine("등록한 책 이름을 정확하게 써주세요");

            }
            Console.WriteLine("삭제되었습니다");
            play.aPlay();
        }

        public void bookOutput()
        {
            Console.WriteLine("무엇으로 검색하시겠습니까?");
            Console.WriteLine("1. 저자 2. 도서명  3.가격  4. 전체조회");

            int n = (play.getException()).input(1,4);
            bookSample();
            switch (n)
            {
                case 1:
                    string a = Console.ReadLine(); //예외처리하기
                    foreach (BookVO booklist in bookList)
                    {
                        if (booklist.author == a)
                        {

                            Console.WriteLine("저자: " + booklist.author);
                            Console.WriteLine("책 이름: " + booklist.bName);
                            Console.WriteLine("책 가격:" + booklist.price);
                            if (booklist.lending == false) Console.WriteLine("대출가능");
                            else
                                Console.WriteLine("대출불가능");
                        }
                    }
                    break;
                case 2:
                    string b = Console.ReadLine(); //예외처리하기
                    foreach (BookVO booklist in bookList)
                    {
                        if (booklist.bName == b)
                        {
                            Console.WriteLine("책 이름: " + booklist.bName);
                            Console.WriteLine("저자: " + booklist.author);
                            Console.WriteLine("책 가격:" + booklist.price);
                            if (booklist.lending == false) Console.WriteLine("대출가능");
                            else
                                Console.WriteLine("대출불가능");
                        }
                    }
                    break;
                case 3:
                    string c = Console.ReadLine(); //예외처리하기
                    foreach (BookVO booklist3 in bookList)
                    {
                        if (booklist3.price == c)
                        {
                            Console.WriteLine("책 가격:" + booklist3.price);
                            Console.WriteLine("저자: " + booklist3.author);
                            Console.WriteLine("책 이름: " + booklist3.bName);
                            if (booklist3.lending == false) Console.WriteLine("대출가능");
                            else
                                Console.WriteLine("대출불가능");
                        }
                    }
                    break;
                case 4:
                    ableList();
                    break;
            }play.wannaBack();
        }

        public void bookSample()
        {
            bookList.Add(new BookVO(bookvo, "대학수학", "   이용신", "     19,000", false));
            bookList.Add(new BookVO(bookvo, "오만과 편견", "제인 오스틴", "12,000", false));
            bookList.Add(new BookVO(bookvo, "파우스트", "   괴테", "       15,000", false));
        }

        public void ableList() //코드 최소화를 위해 메서드로, 도서목록을 보고 삭제하거나 대여하게끔 
        {
            Console.WriteLine("대출여부" + "      " + "책 이름" + "        " + "저자" + "            " + "가격"); //줄맞추기
            foreach (BookVO booklist in bookList)
            {
                if (booklist.lending == false) { Console.Write("대출가능"); }
                else
                {
                    Console.Write("대출불가능");
                }
                Console.WriteLine("    " + booklist.bName + "    " + booklist.author + "               " + booklist.price + " ");


            }
        }
    }
}
    

