using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManamement
{
    class BookMenu
    {
        private int mode;             // 임시로 정수를 저장하기 위해 사용하는 변수
        private bool judge;           // 해당 도서의 존재유무를 참 거짓으로 나타내기 위해 사용하는 변수
        private string str;           // 임시로 문자열을 저장위해 사용하는 변수
        private UserMenu userMenu;    
        private DateTime date;        // 도서반납기한에 현재 날짜를 저장하기 위해 사용하는 DataTime 클래스
        private Book nowBook = new Book();
        private List<Book> bookList = new List<Book>();  //  도서정보를 List로 저장하기 위해 List클래스 객체정의

        public BookMenu(UserMenu u)
        {
            userMenu = u;
        }

        public void menuSelect()  // 1~8사이의 정수를 입력받아 메뉴를 선택하는 함수
        {
            userMenu.Displaying.bookMenuDisplay();
            mode = userMenu.Except.keyIntInput(1, 8);

            switch(mode)
            {
                case 1:
                    bookSearch();
                    break;
                case 2:
                    bookRegist();
                    break;
                case 3:
                    bookModify();
                    break;
                case 4:
                    bookDelete();
                    break;
                case 5:
                    bookPrint();
                    break;
                case 6:
                    bookRent();
                    break;
                case 7:
                    bookReturn();
                    break;
                case 8:
                    userMenu.logout();
                    break;
                default:
                    break;
            }
        }

        public void bookSearch()  // 도서명과 저자를 입력받아 해당도서의 정보를 출력하는 함수
        {
            Console.SetWindowSize(70, 17);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                      < 도서정보검색 >                      ");

            if (bookList.Count > 0)
            {
                nowBook = userMenu.Displaying.bookLoginDisplay(nowBook);
                judge = false;

                for (int i = 0; i < bookList.Count; i++)
                {
                    if (bookList[i].BookName == nowBook.BookName && bookList[i].BookWriter == nowBook.BookWriter)  // 입력받은 도서명과 저자가 List의 도서명과 저자와 일치한다면
                    {
                        userMenu.Displaying.bookInfoDisplay(bookList, i); // 해당 도서정보 출력
                        judge = true;
                        userMenu.Except.keyEnterInput();
                    }
                }
                if(judge == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("    일치하는 도서가 없습니다.  ");
                }
                userMenu.Displaying.countDisplay();
            }
            else{ userMenu.Displaying.noUserAlarm(); }
            menuSelect();

        }


        public void bookRegist() // 도서의 정보를 입력받아 등록하는 함수
        {
            nowBook = userMenu.Displaying.bookRegistDisplay(nowBook);

            Console.WriteLine();
            Console.Write("    등록하시겠습니까? (Y/N)  ");

            str = userMenu.Except.keyAskingInput();
           
            if (string.Equals(str, "Y") == true || string.Equals(str, "y") == true)
            {
                bookList.Add(new Book(nowBook)); // 새로운 Book클래스의 객체를 정의하여 List에 삽입
                Console.WriteLine();
                Console.WriteLine("  <  도서등록처리가 완료되었습니다! >");
                userMenu.Displaying.countDisplay();
            }

            menuSelect();
        }
        
        public void bookModify() // 도서의 정보를 수정하는 함수
        {
            Console.SetWindowSize(40, 17);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("           < 도서정보수정 >        ");

            if (bookList.Count > 0)
            {
                nowBook = userMenu.Displaying.bookLoginDisplay(nowBook);
                judge = false;

                for (int i = 0; i < bookList.Count; i++)
                {
                    if (bookList[i].BookName == nowBook.BookName && bookList[i].BookWriter == nowBook.BookWriter) // 입력받은 도서명과 저자가 List의 도서명과 저자와 일치한다면
                    {
                        userMenu.Displaying.bookModfiyDisplay();
                        mode = userMenu.Except.keyIntInput(1, 4);  // 1~4의 정수를 입력받아 변경을 원하는 값의 정보를 변경한다.
                        judge = true;

                        switch (mode)
                        {
                            case 1:
                                str = userMenu.Except.keyNameInput(Constant.BOOKNAME);
                                bookList[i].BookName = str;
                                break;
                            case 2:
                                str = userMenu.Except.keyNameInput(Constant.USERNAME);
                                bookList[i].BookWriter = str;
                                break;
                            case 3:
                                str = userMenu.Except.keyNameInput(Constant.BOOKNAME);
                                bookList[i].BookPublisher = str;
                                break;
                            case 4:
                                mode = userMenu.Except.keyPriceInput();
                                bookList[i].BookPrice = mode;
                                break;
                            default:
                                break;
                        }
                    } 
                }
                if (judge == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("    일치하는 도서가 없습니다.  ");
                }
                userMenu.Displaying.countDisplay();
            }
            else
            { userMenu.Displaying.noUserAlarm(); }

            menuSelect();
        }

        public void bookDelete()  // 도서의 정보를 삭제하는 함수
        {
            Console.SetWindowSize(40, 17);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("         < 도서정보삭제 >        ");

            if (bookList.Count > 0)
            {
                nowBook = userMenu.Displaying.bookLoginDisplay(nowBook);
                judge = false;

                for (int i = 0; i < bookList.Count; i++)
                {
                    if (bookList[i].BookName == nowBook.BookName && bookList[i].BookWriter == nowBook.BookWriter)  // 입력받은 도서명과 저자가 List의 도서명과 저자와 일치한다면
                    {
                        Console.WriteLine();
                        Console.Write("    삭제하시겠습니까? (Y/N)  ");

                        str = userMenu.Except.keyAskingInput();
                        judge = true;

                        if (string.Equals(str, "Y") == true || string.Equals(str, "y") == true)
                        {
                            bookList.RemoveAt(i); // List의 해당도서 삭제
                            Console.WriteLine();
                            Console.WriteLine("  <  도서삭제처리가 완료되었습니다! >");
                            userMenu.Displaying.countDisplay();
                        }
                    }  
                }
                if (judge == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("    일치하는 도서가 없습니다.  ");
                }
                userMenu.Displaying.countDisplay();
            }
            else
            { userMenu.Displaying.noUserAlarm(); }

            menuSelect();
        }

        public void bookPrint() // 전체도서의 정보를 출력하는 함수
        {
            userMenu.Displaying.bookInfoDisplay(bookList, Constant.ALL);

            userMenu.Except.keyEnterInput();
            menuSelect();

        }

        public void bookRent() // 도서대여를 처리하는 함수
        {
            userMenu.Displaying.bookInfoDisplay(bookList, Constant.ALL);  
            nowBook = userMenu.Displaying.bookLoginDisplay(nowBook);      // 현재 전체도서의 정보를 출력하고 대여하고자 하는 도서의 이름과 저자명을 입력받는다.
            judge = false;

            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].BookName == nowBook.BookName && bookList[i].BookWriter == nowBook.BookWriter)  // 입력받은 도서명과 저자가 List의 도서명과 저자와 일치하고
                {
                    judge = true;

                    if (bookList[i].BookAvailable == "O") // 해당도서가 대출가능상태라면 
                    {
                        date = DateTime.Now;  
                        date = date.AddDays(14);
                        str = date.ToShortDateString();           
                        bookList[i].BookReturnDate = str;          // DateTime클래스를 사용하여 반납기일을 지정하고
                        bookList[i].BookAvailable = "X";           // 해당도서의 대출가능여부를 X로 설정
                        bookList[i].BookUser = userMenu.DataUser;  // 해당도서의 대여정보가 회원 List에서 현재 로그인한 회원의 주소를 가리키게한다.
                        userMenu.DataUser.UserBook = bookList[i];  // 현재 로그인한 회원의 대여도서정보가 도서List에서 해당도서의 주소를 가리키게 한다.
                        Console.WriteLine("  <  도서대여처리가 완료되었습니다! >");
                    }
                    else  // 해당도서가 대출불가상태라면
                    {
                        Console.WriteLine("    해당도서가 현재 대출중입니다.");
                    }

                }
            }
            if (judge == false)
            {
                Console.WriteLine();
                Console.WriteLine("    일치하는 도서가 없습니다.  ");
            }
            userMenu.Displaying.countDisplay();
            menuSelect();
        }

        public void bookReturn() // 도서반납을 처리하는 함수
        {
            Console.Clear();
            Console.SetWindowSize(40, 20);

            if (userMenu.DataUser.UserBook.BookUser == userMenu.DataUser) // 현재 로그인중인 회원이 대여도서의 대여회원과 일치한다면
            {
                userMenu.DataUser.UserBook.BookAvailable = "O";          // 해당도서의 상태를를 대출가능으로 상태변경
                userMenu.DataUser.UserBook.BookReturnDate = null;        // 해당도서의 반납기일을 삭제 
                userMenu.DataUser.UserBook.BookUser = null;              // 해당도서의 대여회원을 널로 설정
                userMenu.DataUser.UserBook = userMenu.DataUser.InitBook; // 현재 로그인중인 회원의 대여도서를 초기화
                Console.Clear();
                Console.SetWindowSize(40, 20);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("  <  도서반납처리가 완료되었습니다! >");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("     <  대여중인 도서가 없습니다 >");
            }
            userMenu.Displaying.countDisplay();
            menuSelect();
        }
    }
}
