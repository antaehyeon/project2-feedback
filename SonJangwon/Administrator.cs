using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Administrator
    {
        Menu menu;
        BasicScreen basicScreen;
        Exception exception;
        public BookVO bookvo;
        public List<BookVO> bookVolist;
        int ChooseNum, i;
        string breaker;
        
        public Administrator(Menu come)
        {
            exception = new Exception();
            menu = come;
            basicScreen = new BasicScreen();
            bookvo = new BookVO();
            bookVolist = new List<BookVO>();

            bookVolist.Add(new BookVO(bookvo, "운영체제", "안용학", 60000, 500, 3));                       //서점에 책을 저장합니다.
            bookVolist.Add(new BookVO(bookvo, "컴퓨터그래픽스1", "김진구", 30000, 200, 1));
            bookVolist.Add(new BookVO(bookvo, "데이터베이스", "김종국", 20000,100, 1));
            bookVolist.Add(new BookVO(bookvo, "확률및통계", "유성준", 40000, 500, 3));
            bookVolist.Add(new BookVO(bookvo, "멀티미디어", "조상욱", 50000, 200, 2));
            bookVolist.Add(new BookVO(bookvo, "빅데이터", "김선웅", 10000, 200, 1));
            bookVolist.Add(new BookVO(bookvo, "통계학개론", "유승호", 20000, 300, 1));
        }
        
        public Administrator()
        {   
        }
        public void Administrators()
        {
            basicScreen.AdminScreen();
            ChooseNum = exception.exceptionnum(7);
            switch (ChooseNum)
            {
                case 1:
                    ShowUser();
                    break;
                case 2:
                    DelUser();
                    break;
                case 3:
                    PrintAll();
                    break;
                case 4:
                    EnrollBook();
                    break;
                case 5:
                    ModifyBook();
                    break;
                case 6:
                    DelBook();
                    break;
                case 7:
                    menu.menus();
                    break;

            }
        }
        public void ShowUser()                              //전체 회원 정보를 출력합니다. 
        {
            Console.WriteLine("");
            Console.Clear();
            Console.WriteLine("전체 회원 정보 출력");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" 회원 아이디       회원 전화번호       회원 생년월일   ");
            for (i = 0; i < menu.getRegister().memberVolist.Count; i++)
            {
                
                Console.Write(("  "+menu.getRegister().memberVolist[i].MemberId + "                 ").Substring(0, 20));
                Console.Write((menu.getRegister().memberVolist[i].MemberPhonenum + "              ").Substring(0, 23));
                Console.WriteLine((menu.getRegister().memberVolist[i].MemberBirthday + "              ").Substring(0, 20));
                
            }
            Console.ReadKey();
            this.Administrators();
        }
        public void DelUser()
        {
            while (true)
            {
                this.ShowUser();
                Console.WriteLine("어떤 회원을 삭제하시겠습니까?");
                Console.WriteLine("아이디를 입력해주세요");
                string selectName = Console.ReadLine();
                for (i = 0; i < menu.getRegister().memberVolist.Count; i++)
                {
                    if (menu.getRegister().memberVolist[i].MemberId == selectName)                      //삭제할 회원을 찾았습니다.
                    {
                        breaker = "GoOut";
                        break;
                    }
                    if (i == menu.getRegister().memberVolist.Count - 1)                 //맨마지막 회원까지 돌아도 입력한 회원이 없는 경우 입니다.
                    {
                        if (selectName != menu.getRegister().memberVolist[i].MemberId)
                        {
                            Console.WriteLine("제대로 된 아이디를 입력해주세요");
                        }
                    }
                }
                if (breaker == "GoOut")
                    break;
            }
            Console.Write(("  " + menu.getRegister().memberVolist[i].MemberId + "                 ").Substring(0, 20));         //삭제할 회원정보를 출력합니다.
            Console.Write((menu.getRegister().memberVolist[i].MemberPhonenum + "              ").Substring(0, 23));
            Console.WriteLine((menu.getRegister().memberVolist[i].MemberBirthday + "              ").Substring(0, 20));
            Console.WriteLine("정말 {0}을 삭제하시겠습니까?", menu.getRegister().memberVolist[i].MemberId);
            Console.WriteLine("1. 네  2.아니오 ");
            ChooseNum = exception.exceptionnum(2);
            switch (ChooseNum)
            {
                case 1:
                    menu.getRegister().memberVolist.RemoveAt(i);                    //회원정보를 삭제했습니다.
                    Console.WriteLine("삭제 되었습니다.");
                    Console.ReadKey();
                    break;
                case 2:
                    this.Administrators();
                    break;
            }
            this.Administrators();
        }
        public void PrintAll()
        {
            Console.WriteLine("출력");
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" 도서 이름       도서 저자       도서 가격       페이지 수       도서 수량  ");
            for (i = 0; i < menu.getAdmin().bookVolist.Count; i++)
            {
                Console.Write((menu.getAdmin().bookVolist[i].BookName + "                 ").Substring(0, 13));         //도서정보를 출력합니다.
                Console.Write((menu.getAdmin().bookVolist[i].BookAuthor + "              ").Substring(0, 13));
                Console.Write((menu.getAdmin().bookVolist[i].BookPrice + "              ").Substring(0, 13));
                Console.Write((menu.getAdmin().bookVolist[i].BookQuantity + "            ").Substring(0, 13));
                Console.WriteLine((menu.getAdmin().bookVolist[i].BookNum + "             ").Substring(0, 13));

            }
            Console.ReadKey();
            this.Administrators();
        }
        public void EnrollBook()                                //책을 등록합니다.
        {
            string name, author;
            int price, quantity;
            Console.WriteLine("도서 등록");
            Console.WriteLine("책 이름 입력");
            name = Console.ReadLine();
            Console.WriteLine("책 저자 입력");
            author = Console.ReadLine();
            Console.WriteLine("책 가격 입력");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out price))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("책 가격 입력");
                    Console.WriteLine("숫자로만 입력바랍니다. (예: 6만원 -> 60000) ");
                }
            }
            Console.WriteLine("책 페이지 수 입력");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out quantity))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("책 페이지 수 입력");
                    Console.WriteLine("숫자로만 입력바랍니다. (예: 300페이지 -> 300) ");
                }
            }
            
                for (i = 0; i < bookVolist.Count; i++)
                {
                    if (bookVolist[i].BookName == name)
                    {
                        if (bookVolist[i].BookAuthor == author)
                        {
                            if (bookVolist[i].BookPrice == price)
                            {
                                if (bookVolist[i].BookQuantity == quantity)                     //기존의 책과 정보가 동일한 경우 수량을 1개증가.
                                {
                                    bookVolist[i].BookNum++;
                                    break;
                                }
                                else
                                {
                                    bookvo.BookName = name;
                                    bookvo.BookAuthor = author;                                 //기존의 책과 정보가 같지 않은 경우 새롭게 정보 추가
                                    bookvo.BookPrice = price;
                                    bookvo.BookQuantity = quantity;
                                    bookvo.BookNum = 1;
                                    bookVolist.Add(new BookVO(bookvo, bookvo.BookName, bookvo.BookAuthor, bookvo.BookPrice, bookvo.BookQuantity, bookvo.BookNum));
                                    break;
                                }
                            }
                            else
                            {
                                bookvo.BookName = name;
                                bookvo.BookAuthor = author;                                      //기존의 책과 정보가 같지 않은 경우 새롭게 정보 추가
                            bookvo.BookPrice = price;
                                bookvo.BookQuantity = quantity;
                                bookvo.BookNum = 1;
                                bookVolist.Add(new BookVO(bookvo, bookvo.BookName, bookvo.BookAuthor, bookvo.BookPrice, bookvo.BookQuantity, bookvo.BookNum));
                                break;
                            }
                        }
                        else
                    {                                                                            //기존의 책과 정보가 같지 않은 경우 새롭게 정보 추가
                        bookvo.BookName = name;
                            bookvo.BookAuthor = author;
                            bookvo.BookPrice = price;
                            bookvo.BookQuantity = quantity;
                            bookvo.BookNum = 1;
                            bookVolist.Add(new BookVO(bookvo, bookvo.BookName, bookvo.BookAuthor, bookvo.BookPrice, bookvo.BookQuantity, bookvo.BookNum));
                            break;
                        }
                    }
                    else
                {                                                                                        //기존의 책과 정보가 같지 않은 경우 새롭게 정보 추가
                    bookvo.BookName = name;
                        bookvo.BookAuthor = author;
                        bookvo.BookPrice = price;
                        bookvo.BookQuantity = quantity;
                        bookvo.BookNum = 1;
                        bookVolist.Add(new BookVO(bookvo, bookvo.BookName, bookvo.BookAuthor, bookvo.BookPrice, bookvo.BookQuantity, bookvo.BookNum));
                        break;
                    }

                }
            
            Console.ReadKey();
        }
        public void ModifyBook()
        {
            string name, author;
            int price, quantity, j;

            Console.WriteLine("변경");
            Console.WriteLine("어떤 책을 변경하시겠습니까?");
            Console.WriteLine("1. 도서명으로 선택하기 2.저자로 선택하기 3. 이전 메뉴로 이동");
            ChooseNum = exception.exceptionnum(3);
            switch (ChooseNum)
            {
                case 1:
                    while (true)
                    {
                        Console.WriteLine("도서명을 입력해주세요");
                        string selectName = Console.ReadLine();
                        for (i = 0; i < bookVolist.Count; i++)
                        {
                            if (bookVolist[i].BookName == selectName)
                            {
                                breaker = "GoOut";
                                break;
                            }
                            if (i == bookVolist.Count - 1)                 //맨마지막 책까지 돌아도 입력한 책이 없는 경우
                            {
                                if (selectName != bookVolist[i].BookName)
                                {
                                    Console.WriteLine("제대로 된 도서명을 입력해주세요");
                                }
                            }
                        }
                        if (breaker == "GoOut")
                            break;
                    }

                    
                    Console.WriteLine(bookVolist[i].BookName + "   " + bookVolist[i].BookAuthor + "   " + bookVolist[i].BookPrice + "   " + bookVolist[i].BookQuantity);
                    Console.WriteLine("도서명 변경");
                    name = Console.ReadLine();
                    Console.WriteLine("저자 변경");
                    author = Console.ReadLine();
                    Console.WriteLine("가격 변경");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out price))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("책 가격 변경");
                            Console.WriteLine("숫자로만 입력바랍니다. (예: 6만원 -> 60000) ");
                        }
                    }
                    Console.WriteLine("책 페이지 수  변경");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out quantity))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("책 페이지 수 변경");
                            Console.WriteLine("숫자로만 입력바랍니다. (예: 300페이지 -> 300) ");
                        }
                    }
                    //
                    
                    for (j = 0; j < bookVolist.Count; j++)
                    {
                        if (bookVolist[j].BookName == name)
                        {
                            if (bookVolist[j].BookAuthor == author)
                            {
                                if (bookVolist[j].BookPrice == price)
                                {
                                    if (bookVolist[j].BookQuantity == quantity)
                                    {
                                        if (i == j)                             
                                            continue;
                                        else
                                        {
                                            bookVolist[j].BookNum++;                                        //기존에 있는 책으로 변경하는 경우 둘중 하나는 정보를 삭제 하고 다른것의 개수를 증가
                                            bookVolist.RemoveAt(i);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        bookVolist[i].BookName = name;                                  //새롭게 정보를 수정
                                        bookVolist[i].BookAuthor = author;
                                        bookVolist[i].BookPrice = price;
                                        bookVolist[i].BookQuantity = quantity;
                                        break;
                                    }
                                }
                                else
                                {
                                    bookVolist[i].BookName = name;                                                //새롭게 정보를 수정
                                    bookVolist[i].BookAuthor = author;
                                    bookVolist[i].BookPrice = price;
                                    bookVolist[i].BookQuantity = quantity;
                                    break;
                                }
                            }
                            else
                            {
                                bookVolist[i].BookName = name;
                                bookVolist[i].BookAuthor = author;                                                //새롭게 정보를 수정
                                bookVolist[i].BookPrice = price;
                                bookVolist[i].BookQuantity = quantity;
                                break;
                            }
                        }
                        else
                        {
                            bookVolist[i].BookName = name;                                                            //새롭게 정보를 수정
                            bookVolist[i].BookAuthor = author;
                            bookVolist[i].BookPrice = price;
                            bookVolist[i].BookQuantity = quantity;
                            break;
                        }

                    }
                    Console.ReadKey();
                    break;
                case 2:
                    while (true)
                    {
                        Console.WriteLine("저자를 입력해주세요");
                        string selectAuthor = Console.ReadLine();
                        for (i = 0; i < bookVolist.Count; i++)
                        {
                            if (selectAuthor == bookVolist[i].BookAuthor)
                            {
                                break;
                            }

                            if (i == bookVolist.Count - 1)                 //맨마지막 책까지 돌아도 입력한 책이 없는 경우
                            {
                                if (selectAuthor != bookVolist[i].BookAuthor)
                                {
                                    Console.WriteLine("제대로 된 저자를 입력해주세요");
                                }
                            }
                        }
                        if (breaker == "GoOut")
                            break;
                    }

                    Console.WriteLine(bookVolist[i].BookName + "   " + bookVolist[i].BookAuthor + "   " + bookVolist[i].BookPrice + "   " + bookVolist[i].BookQuantity);
                    Console.WriteLine("도서명 변경");
                    name = Console.ReadLine();
                    Console.WriteLine("저자 변경");
                    author = Console.ReadLine();
                    Console.WriteLine("가격 변경");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out price))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("책 가격 변경");
                            Console.WriteLine("숫자로만 입력바랍니다. (예: 6만원 -> 60000) ");
                        }
                    }
                    Console.WriteLine("책 페이지 수  변경");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out quantity))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("책 페이지 수 변경");
                            Console.WriteLine("숫자로만 입력바랍니다. (예: 300페이지 -> 300) ");
                        }
                    }
                    
                    for (j = 0; j < bookVolist.Count; j++)
                    {
                        if (bookVolist[j].BookName == name)
                        {
                            if (bookVolist[j].BookAuthor == author)
                            {
                                if (bookVolist[j].BookPrice == price)
                                {
                                    if (bookVolist[j].BookQuantity == quantity)
                                    {
                                        if (i == j)
                                            continue;
                                        else
                                        {
                                            bookVolist[j].BookNum++;                             //기존에 있는 책으로 변경하는 경우 둘중 하나는 정보를 삭제 하고 다른것의 개수를 증가
                                            bookVolist.RemoveAt(i);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        bookVolist[i].BookName = name;
                                        bookVolist[i].BookAuthor = author;
                                        bookVolist[i].BookPrice = price;                                          //새롭게 정보를 수정
                                        bookVolist[i].BookQuantity = quantity;
                                        break;
                                    }
                                }
                                else
                                {
                                    bookVolist[i].BookName = name;                                                //새롭게 정보를 수정
                                    bookVolist[i].BookAuthor = author;
                                    bookVolist[i].BookPrice = price;
                                    bookVolist[i].BookQuantity = quantity;
                                    break;
                                }
                            }
                            else
                            {
                                bookVolist[i].BookName = name;
                                bookVolist[i].BookAuthor = author;
                                bookVolist[i].BookPrice = price;
                                bookVolist[i].BookQuantity = quantity;                                                    //새롭게 정보를 수정
                                break;
                            }
                        }
                        else
                        {
                            bookVolist[i].BookName = name;
                            bookVolist[i].BookAuthor = author;                                                                        //새롭게 정보를 수정
                            bookVolist[i].BookPrice = price;
                            bookVolist[i].BookQuantity = quantity;
                            break;
                        }

                    }
                    Console.ReadKey();

                    break;
                case 3:
                    this.Administrators();
                    break;

            }
            Console.ReadKey();
            this.Administrators();
        }
        public void DelBook()
        {
            Console.WriteLine("어떤 책을 삭제하시겠습니까?");
            while (true)
            {
                Console.WriteLine("도서명을 입력해주세요");
                string selectName = Console.ReadLine();
                for (i = 0; i < bookVolist.Count; i++)
                {
                    if (bookVolist[i].BookName == selectName)
                    {
                        breaker = "GoOut";
                        break;
                    }
                    if (i == bookVolist.Count - 1)                 //맨마지막 책까지 돌아도 입력한 책이 없는 경우
                    {
                        if (selectName != bookVolist[i].BookName)
                        {
                            Console.WriteLine("제대로 된 도서명을 입력해주세요");
                        }
                    }
                }
                if (breaker == "GoOut")
                    break;
            }
            Console.WriteLine(bookVolist[i].BookName + "   " + bookVolist[i].BookAuthor + "   " + bookVolist[i].BookPrice + "   " + bookVolist[i].BookQuantity);
            Console.WriteLine("정말 {0}을 삭제하시겠습니까?", bookVolist[i].BookName);
            Console.WriteLine("1. 네  2.아니오 ");
            ChooseNum = exception.exceptionnum(2);
            switch (ChooseNum)
            {
                case 1:
                    bookVolist.RemoveAt(i);
                    Console.WriteLine("삭제 되었습니다.");
                    break;
                case 2:
                    this.Administrators();
                    break;
            }
            Console.ReadKey();
            this.Administrators();

        }
    }
}
