using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ensharp_study_assignment2_1v
{
    class MainFrame
    {
        //ConfirmingProcess()에서의 return값이 1이면 확인한 것이고, 2이면 취소한 것임
        const int CONFIRM_YES = 1;
        const int SELECTMODE_RANGE_START = 1;
        const int SELECTMODE_RANGE_END = 5;

        Exceptions Exc = new Exceptions();
        Print print = new Print();

        //상위클래스에서 유지하는 종합회원정보 리스트와 종합도서정보 리스트
        //하위클래스와 상위클래스를 왔다갔다 할 때마다, 계속 최신으로 업데이트된 정보로 변경해줌
        List<MemberVO> MemberInfoListTop = new List<MemberVO>();
        List<BookVO> BookInfoListTop = new List<BookVO>();
        //MainPage()에서 로그인 했는지 여부 판단
        bool SignedIn = false;

        public void MainPage()
        {
            //임시로 회원과 도서정보를 넣어둠
            MemberVO Manager = new MemberVO("wogur6782", "123456789", "신재혁", null, null);
            MemberInfoListTop.Add(Manager);
            BookVO test = new BookVO("Leading", "Alex Ferguson", 12000, 1);
            BookInfoListTop.Add(test);
            BookVO test1 = new BookVO("About Mac", "Steve Jobs", 12000, 1);
            BookInfoListTop.Add(test1);
            BookVO test2 = new BookVO("Learn C#", "Lionel Messi", 1000, 1);
            BookInfoListTop.Add(test2);

            SignInProcess signIn = new SignInProcess(MemberInfoListTop, SignedIn);
            MemberManageProcess memberManage = new MemberManageProcess(MemberInfoListTop);
            BookManageProcess bookManage = new BookManageProcess(BookInfoListTop);
            LoanManageProcess loanManage = new LoanManageProcess(MemberInfoListTop, BookInfoListTop);

            int SelectMode;

            print.StartPage();
            SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
            while(true)
            {
                switch(SelectMode)
                {
                    case 1://로그인 기능 및 회원 등록(가입)
                        signIn.SignInPage();
                        MemberInfoListTop = signIn.getMemberInfoListBot();
                        SignedIn = signIn.getSignedIn();
                        break;
                    case 2://로그인 했을 시 회원관리모드로 들어갈 수 있음
                        if(SignedIn == true)
                        {
                            memberManage.MemberPage();
                            MemberInfoListTop = memberManage.getMemberInfoListBot();
                        }
                        else
                        {
                            print.BasePage();
                            Console.WriteLine("Sign In First");
                            print.EnterReturn();
                        }
                        break;
                    case 3://로그인 했을 시 도서관리모드로 들어갈 수 있음
                        if(SignedIn == true)
                        {
                            bookManage.BookPage();
                            BookInfoListTop = bookManage.getBookInfoListBot();
                        }
                        else
                        {
                            print.BasePage();
                            Console.WriteLine("Sign In First");
                            print.EnterReturn();
                        }
                        break;
                    case 4://로그인 했을 시 도서대출반납모드로 들어갈 수 있음
                        if(SignedIn == true)
                        {
                            loanManage.LoanPage();
                            MemberInfoListTop = loanManage.getMemberInfoListBot();
                            BookInfoListTop = loanManage.getBookInfoListBot();
                        }
                        else
                        {
                            print.BasePage();
                            Console.WriteLine("Sign In First");
                            print.EnterReturn();
                        }
                        break;
                    case 5://프로그램 종료
                        if (print.ConfirmingProcess() == CONFIRM_YES)
                        {
                            print.ExitPage();
                            Environment.Exit(1);
                        }
                        else
                            break;
                        break;
                }
                print.StartPage();
                SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
            }
        }
    }
}
