using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManamement
{
    class Display
    {
        // Data
        private UserMenu userMenu;

        // Constructor
        public Display(UserMenu u)
        {
            userMenu = u;
        }

        // Other Method
        public void clearLine()  // 콘솔화면에서 같은줄에서 다시 출력하기 위해 기존의 출력을 비워주는 함수
        {
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        public void userMenuDisplay() // 회원관리 메뉴선택 초기화면을 출력하는 함수
        {
            Console.SetWindowSize(30, 21);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("    En# 도서관 관리프로그램    ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        1.   로그인            ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        2.   PW 찾기           ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        3.  회원등록            ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        4.  회원수정           ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        5.  회원삭제           ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        6.  회원검색           ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        7.  회원출력           ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        8.    종료             ");
            Console.WriteLine("-------------------------------");
            Console.Write("    메뉴를 선택하세요  >>  ");
        }

        public void bookMenuDisplay() // 도서관리 메뉴선택 초기화면을 출력하는 함수
        {
            Console.SetWindowSize(30, 21);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("       < 도서관리메뉴 >        ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        1.  도서찾기           ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        2.  도서등록           ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        3.  도서변경           ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        4.  도서삭제           ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        5.  도서출력           ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        6.  도서대여           ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        7.  도서반납           ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("        8.  로그아웃           ");
            Console.WriteLine("-------------------------------");
            Console.Write("    메뉴를 선택하세요  >>  ");
        }

        public User userLoginDisplay(User nowUser, int mode)  // 회원아이디, PW 또는 회원아이디, 연락처를 입력받아 리턴하는 함수, 여기서 인자 mode는 둘 중 어떤 조합으로 입력을 받을지 결정
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("     ID :  ");
            nowUser.UserID = userMenu.Except.keyIDInput();
            Console.WriteLine();
            if (mode == Constant.PASSWORD) // 로그인, 검색, 수정, 삭제시에는 아이디와 비밀번호를 입력받는다. (PASSWORD모드)
            {
                Console.Write("     PW :  ");
                nowUser.UserPW = userMenu.Except.keyPWInput();
            }
            else // PASSWORD모드가 아닌, 즉 비밀번호찾기시에는 비밀번호 대신 연락처를 입력받는다.
            {
                Console.Write("  가입시 등록한 전화번호 :  ");
                nowUser.UserCall = userMenu.Except.keyCallInput();
            }
            Console.WriteLine();

            return nowUser;
        }


        public Book bookLoginDisplay(Book nowBook)  // 도서와 저자의 이름을 입력받아 리턴하는 함수
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("    도서명 :  ");
            nowBook.BookName = userMenu.Except.keyNameInput(Constant.BOOKNAME);
            Console.WriteLine();
            Console.Write("     저자  :  ");
            nowBook.BookWriter = userMenu.Except.keyNameInput(Constant.BOOKNAME);
            Console.WriteLine();

            return nowBook;
        }

        public void userModifyDisplay()  //  회원정보수정 메뉴의 초기화면을 출력하는 함수
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("             < 회원정보수정 >        ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("          <1>     비밀번호         ");
            Console.WriteLine();
            Console.WriteLine("          <2>       이름       ");
            Console.WriteLine();
            Console.WriteLine("          <3>     전화번호   ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("      수정할 정보를 입력하세요 >> ");
        }

        public User userRegistDisplay(User nowUser, List<User> userList) //  회원가입시 화면출력과 필요한 회원정보를 입력받아 리턴하는 함수
        {                                                                //  이 때 userList는 Display클래스의 중복아이디 검색함수에 사용하기 위해 인자로 받음.
            Console.SetWindowSize(82, 32);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                  < 회원 가입 >        ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   > ID는 영소문자,숫자 조합 5~12자리이며 공백 및 특수문자를 포함할 수 없습니다.");
            Console.WriteLine();
            Console.Write("  -    ID    :    ");
            nowUser.UserID = userMenu.Except.keyIDInput(userList);
            Console.WriteLine();
            Console.WriteLine("   > PW는 영대소문,숫자 조합 8~16자리이며 공백 및 특수문자를 포함할 수 없습니다.");
            Console.WriteLine();
            Console.Write("  -  Password :   ");
            nowUser.UserPW = userMenu.Except.keyPWInput();
            Console.WriteLine();
            Console.WriteLine("   > 이름은 2~5 자리 한글로만 구성할 수 있습니다.");
            Console.WriteLine();
            Console.Write("  -   이름   :    ");
            nowUser.UserName = userMenu.Except.keyNameInput(Constant.USERNAME);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   > 연락처는 - 를 제외하고 9~11 자리 숫자로만 구성할 수 있습니다.");
            Console.WriteLine();
            Console.Write("  -  연락처 :   ");
            nowUser.UserCall = userMenu.Except.keyCallInput();

            return nowUser;
        }

        public Book bookRegistDisplay(Book nowBook)  // 도서등록시 필요한 정보를 입력받아 리턴하는 함수
        {
            Console.SetWindowSize(40, 20);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("              < 도서 등록 >        ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("   도서명  :  ");
            nowBook.BookName = userMenu.Except.keyNameInput(Constant.BOOKNAME);
            Console.WriteLine();
            Console.Write("    저자  :  ");
            nowBook.BookWriter = userMenu.Except.keyNameInput(Constant.USERNAME);
            Console.WriteLine();
            Console.Write("   출판사 :  ");
            nowBook.BookPublisher = userMenu.Except.keyNameInput(Constant.BOOKNAME);
            Console.WriteLine();
            Console.Write("  도서가격 (10만원 미만) :  ");
            nowBook.BookPrice = userMenu.Except.keyPriceInput();
            nowBook.BookAvailable = "O";  // 지금 등록되는 도서는 바로 대출가능하므로 true로 설정

            return nowBook;
        }

        public void userLogoutDisplay() //  로그아웃메뉴의 초괴화면을 출력하는 함수
        {
            Console.SetWindowSize(30, 17);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("        < 회원 로그아웃 >        ");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void userInfoDisplay(List<User> userList, int i) // 회원정보를 출력하는 함수, 이 때 인자 i는 회원정보전체를 출력할지, 특정한 회원 한명만의 정보를 출력할지 결정하기 위해 사용
        {
            Console.SetWindowSize(102, 25);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine("   < 회원아이디 >       < 이름 >         < 전화번호 >          <대여도서>            <반납기한>      ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            if (i != Constant.ALL)                       // 전체출력이 아니라면 해당 회원의 정보만 출력
                Console.WriteLine("{0,14}{1,14}{2,20}{3,18}{4,23}", userList[i].UserID, userList[i].UserName, userList[i].UserCall, userList[i].UserBook.BookName, userList[i].UserBook.BookReturnDate);
            else
            {
                for (int j = 0; j< userList.Count; j++)  // 전체출력이라면 List안의 모든 회원의 정보출력
                    Console.WriteLine("{0,14}{1,14}{2,20}{3,18}{4,23}", userList[j].UserID, userList[j].UserName, userList[j].UserCall, userList[j].UserBook.BookName, userList[j].UserBook.BookReturnDate);
            }
        }
                
        public void bookInfoDisplay(List<Book> bookList, int i)  // 도서정보를 출력하는 함수, 이 때 인자 i는 도서정보전체를 출력할지, 특정한 도서 한권만의 정보를 출력할지 결정하기 위해 사용
        {
            Console.SetWindowSize(115, 17);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("       < 도서명 >       < 저자 >      < 출판사 >       < 판매가격 >       < 대출가능여부 >        < 반납기한 >    " );
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            if (i != Constant.ALL)                         // 전체출력이 아니라면 해당 도서의 정보만 출력
                Console.WriteLine("{0,13}{1,14}{2,13}{3,17}{4,19}{5,27}", bookList[i].BookName, bookList[i].BookWriter, bookList[i].BookPublisher, bookList[i].BookPrice, bookList[i].BookAvailable, bookList[i].BookReturnDate);
            else
            {
                for (int j = 0; j < bookList.Count; j++)   // 전체출력이라면 List안의 모든 도서 정보출력
                    Console.WriteLine("{0,13}{1,14}{2,13}{3,17}{4,19}{5,27}", bookList[j].BookName, bookList[j].BookWriter, bookList[j].BookPublisher, bookList[j].BookPrice, bookList[j].BookAvailable, bookList[j].BookReturnDate);
            }
        }

        // 등록된 회원이나 도서가 없는상태를 출력하는 함수
        public void noUserAlarm() 
        {
            Console.WriteLine();
            Console.WriteLine("    < 아직 등록된 회원이 없습니다. > ");
            countDisplay();
        }

        public void noBookAlarm()
        {
            Console.WriteLine();
            Console.WriteLine("    < 아직 등록된 도서가 없습니다. > ");
            countDisplay();
        }

        public void bookModfiyDisplay()  // 회원정보수정메뉴의 초기화면을 출력하는 함수
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     <1>      도서명         ");
            Console.WriteLine();
            Console.WriteLine("     <2>       저자       ");
            Console.WriteLine();
            Console.WriteLine("     <3>      출판사   ");
            Console.WriteLine();
            Console.WriteLine("     <4>     도서가격   ");
            Console.WriteLine();
            Console.Write("     수정할 정보를 입력하세요 >>");
        }

        // 스레드를 통해 메뉴화면으로 전환까지 남은 시간을 표시
        public async Task countDown()
        {
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 3; i > 0; i--)
            {
                clearLine();
                Console.WriteLine("       >>  {0}초뒤 메뉴로 돌아갑니다", i);
                await Task.Delay(1000);
            }
        }       

        public void countDisplay()
        {
            var a = countDown();
            Task.WaitAll(a);
        }
    }
}