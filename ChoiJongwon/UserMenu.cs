using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryManamement
{
    // Constant class
    static class Constant 
    {
        public const int ALL = 100;
        public const int USERNAME = 2;
        public const int BOOKNAME = 3;
        public const int PASSWORD = 4;
        public const int USERCALL = 5;
    }

    class UserMenu
    {
        // Data
        private int mode;                 // switch문을 위해 사용하는 임시저장 변수
        private string str;               // 임시로 문자열을 받기위해 사용하는 변수
        private bool judge;               // 해당 유저의 존재유무를 참 거짓으로 나타내기 위해 사용하는 변수
        private Display display;          
        private Exception except;          
        private User nowUser = new User();
        private User dataUser;
        private BookMenu bookMenu;        
        private List<User> userList = new List<User>(); // 회원정보를 List로 저장하기 위해 List클래스 객체정의

        // Constructor
        public UserMenu()
        {
            display = new Display(this);
            bookMenu = new BookMenu(this);
            except = new Exception(this);
        }

        // Get/Set
        public User NowUser
        {
            get { return nowUser; }
            set { nowUser = value; }
        }

        public User DataUser
        {
            get { return dataUser; }
            set { dataUser = value; }
        }

        public Display Displaying
        {
            get { return display; }
            set { display = value; }
        }

        public Exception Except
        {
            get { return except; }
            set { except = value; }
        }

        // Other Method
        public void menuSelect()  // 메뉴선택함수
        {
            display.userMenuDisplay();
            mode = except.keyIntInput(1, 8);   //  1~8사이의 정수를 입력받음

            switch (mode)
            {
                case 1:
                    login();
                    break;
                case 2:
                    userFindPW();
                    break;
                case 3:
                    userRegist();
                    break;
                case 4:
                    userModify();
                    break;
                case 5:
                    userDelete();
                    break;
                case 6:
                    userSearch();
                    break;
                case 7:
                    userPrint();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        public void login()  //  회원로그인 함수
        {
            Console.SetWindowSize(45, 17);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                < 회원 로그인 >        ");

            if (userList.Count > 0) // 회원정보가 1개라도 존재한다면
            {
                nowUser = display.userLoginDisplay(nowUser,Constant.PASSWORD);   //  아이디와 패스워드를 입력받는다.
                judge = false;
            

                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i].UserID == nowUser.UserID && userList[i].UserPW == nowUser.UserPW)  //  입력된 ID, PW가 List에 저장된 User의 ID, PW와 일치한다면
                    {
                        dataUser = userList[i];  // List의 해당회원정보를 dataUser가 가르키게 한다.
                        bookMenu.menuSelect();   // 도서관리메뉴선택 함수로 이동
                        judge = true;
                    }
                }

                if(judge == false)  //  입력된 ID, PW가 List에 저장된 User의 ID, PW와 일치하지 않는다면
                {
                    Console.WriteLine("  < 회원정보가 일치하지 않습니다. >");
                    display.countDisplay();
                    menuSelect();
                }
            }
            else // 회원정보가 1개라도 없다면 초기메뉴화면으로 전환
            {
                display.noUserAlarm();
                menuSelect();
            }
        }

        public void userFindPW()  //  회원 비밀번호찾기 함수
        {
            Console.SetWindowSize(45, 20);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                  < 비밀번호찾기 >        ");

            if (userList.Count > 0)  // 회원정보가 1개라도 존재한다면
            {
                nowUser = display.userLoginDisplay(nowUser,Constant.USERCALL); //  아이디와 연락처를 입력받는다. 
                judge = false;

                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i].UserID == nowUser.UserID && userList[i].UserCall == nowUser.UserCall)  //  입력된 ID, 연락처가 List에 저장된 User의 ID, 연락처와 일치한다면
                    {
                        judge = true;
                        Console.WriteLine();
                        Console.WriteLine("  < 고객님의 PW는  {0}  입니다 >", userList[i].UserPW);  // 해당 User의 비밀번호를 출력한다
                        except.keyEnterInput();
                    }
                }

                if (judge == false)  //  입력된 ID, 연락처가 List에 저장된 User의 ID, 연락처와 일치하지 않는다면 
                {
                    Console.WriteLine("     일치하는 회원정보가 없습니다.  ");
                    display.countDisplay();
                }
            }
            else { display.noUserAlarm(); } // 회원정보가 1개라도 없다면 초기메뉴화면으로 전환
            menuSelect();
        }

        public void userRegist()  //  회원등록 함수
        {
            nowUser = display.userRegistDisplay(nowUser, userList); // 회원등록정보(ID, PW, 이름, 연락처)를 입력받는다.
            
            Console.WriteLine();
            Console.Write("    가입하시겠습니까? (Y/N)  ");

            str = except.keyAskingInput();

            if (string.Equals(str, "Y") == true || string.Equals(str, "y") == true) // Y키(yes)의 경우 가입처리, 알림 후 초기메뉴화면으로 돌아간다.
            {
                userList.Add(new User(nowUser)); // 입력된 정보로 새로운 User객체를 만들어서 List에 저장한다.
                Console.WriteLine();
                Console.WriteLine("  <  En# 도서관회원이 되신 걸 축하드립니다!  가입처리가 완료되었습니다. >");
                display.countDisplay();
            }
            // n키의 경우 별도의 알림없이 바로 초기메뉴화면으로 돌아간다.
            menuSelect();           
        }

        public void userModify()  //  회원정보수정 함수
        {
            Console.SetWindowSize(45, 20);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                < 회원정보수정 >        ");

            if (userList.Count>0)  // 회원정보가 1개라도 존재한다면
            {
                nowUser = display.userLoginDisplay(nowUser, Constant.PASSWORD);  //  아이디와 패스워드를 입력받는다.
                judge = false;

                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i].UserID == nowUser.UserID && userList[i].UserPW == nowUser.UserPW)  //  입력된 ID, PW가 List에 저장된 User의 ID, PW와 일치한다면
                    {
                        display.userModifyDisplay();
                        mode = except.keyIntInput(1, 3); 
                        judge = true;
                        Console.WriteLine();

                        switch (mode)   // 1~3의 정수를 입력받아 해당정보를 변경해준다.
                        {
                            case 1:
                                Console.Write("      새로운 비밀번호 : ");
                                userList[i].UserPW = except.keyPWInput();
                                break;
                            case 2:
                                Console.Write("     새로운 사용자이름 : ");
                                userList[i].UserName = except.keyNameInput(Constant.USERNAME);
                                break;
                            case 3:
                                Console.Write("       새로운 전화번호 : ");
                                userList[i].UserCall = except.keyCallInput();
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine();
                        Console.WriteLine("     < 회원정보가 수정되었습니다! >");
                    }
                }

                if (judge == false) { Console.WriteLine("     일치하는 회원정보가 없습니다.  "); }  //  입력된 ID, PW가 List에 저장된 User의 ID, PW와 일치하지 않는다면 
                display.countDisplay();
            }
            else { display.noUserAlarm(); } // 회원정보가 1개라도 없다면 초기메뉴화면으로 전환
            menuSelect();
        }

        public void userDelete()  //  회원정보삭제 함수
        {
            Console.SetWindowSize(40, 17);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("            < 회원정보삭제 >        ");

            if (userList.Count > 0)  // 회원정보가 1개라도 존재하고
            {
                nowUser = display.userLoginDisplay(nowUser, Constant.PASSWORD);  //  아이디와 패스워드를 입력받는다.
                judge = false;

                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i].UserID == nowUser.UserID && userList[i].UserPW == nowUser.UserPW)  //  입력된 ID, PW가 List에 저장된 User의 ID, PW와 일치한다면
                    {
                        Console.WriteLine();
                        Console.Write("    삭제하시겠습니까? (Y/N)  ");

                        judge = true;
                        str = except.keyAskingInput();

                        if (string.Equals(str, "Y") == true || string.Equals(str, "y") == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("    < 회원정보가 삭제되었습니다! >");
                            userList.RemoveAt(i);
                        }
                    }
                    
                }
                if (judge == false) { Console.WriteLine("     일치하는 회원정보가 없습니다.  "); } //  입력된 ID, PW가 List에 저장된 User의 ID, PW와 일치하지 않는다면 
                display.countDisplay();
            }
            else { display.noUserAlarm(); }  // 회원정보가 1개라도 없다면 초기메뉴화면으로 전환
            menuSelect();
        }

        public void userSearch()  //  회원정보검색 함수
        {
            Console.SetWindowSize(45, 17);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("              < 회원정보검색 >                      ");

            if (userList.Count > 0)  // 회원정보가 1개라도 존재하고
            {
                nowUser = display.userLoginDisplay(nowUser, Constant.PASSWORD);  //  아이디와 패스워드를 입력받는다.
                judge = false;

                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i].UserID == nowUser.UserID && userList[i].UserPW == nowUser.UserPW)  //  입력된 ID, PW가 List에 저장된 User의 ID, PW와 일치한다면
                    {
                        display.userInfoDisplay(userList, i);  // 해당 유저의 정보를 출력한다.
                        judge = true;
                        except.keyEnterInput();
                    }
                }
                if (judge == false) //  입력된 ID, PW가 List에 저장된 User의 ID, PW와 일치하지 않는다면 
                {
                    Console.WriteLine("     일치하는 회원정보가 없습니다.  ");
                    display.countDisplay();
                }
            }
            else{ display.noUserAlarm(); }  // 회원정보가 1개라도 없다면 초기메뉴화면으로 전환
            menuSelect();
        }

        public void userPrint()  // 회원정보출력(전체) 함수
        {
            display.userInfoDisplay(userList, Constant.ALL);            
            except.keyEnterInput();
            menuSelect();
        }

        public void logout()  // 회원로그아웃 함수
        {
            display.userLogoutDisplay();
            dataUser = null; // 리스트간 연결을 위해 사용했던 dataUser를 다음 로그인을 위해 NULL로 초기화한다
            menuSelect();    // 초기메뉴화면으로 전환
        }
    }
}