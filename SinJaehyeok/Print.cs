using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensharp_study_assignment2_1v
{
    class Print
    {
        const int CONFIRM_YES = 1;
        const int CONFIRM_NO = 2;

        Exceptions Exc = new Exceptions();
        //첫 시작 페이지
        public void StartPage()
        {
            Console.Clear();
            Console.Title = "Library Management System _ JaeHyuk Shin";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("< Library Management System >");
            Console.WriteLine();
            Console.WriteLine("1. Sign In\n");
            Console.WriteLine("2. Member Management\n");
            Console.WriteLine("3. Book Management\n");
            Console.WriteLine("4. Loan Book\n");
            Console.WriteLine("5. Exit\n");
            Console.Write("Select Mode : ");
        }
        //로그인 모드 페이지
        public void SignPage()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("< Library Management System >");
            Console.WriteLine();
            Console.WriteLine("1. Sign In\n");
            Console.WriteLine("2. Sign Up\n");
            Console.WriteLine("3. Back\n");
            Console.Write("Select Mode : ");
        }
        //회원관리 모드 페이지
        public void MemberPage()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("< Library Management System >");
            Console.WriteLine();
            Console.WriteLine("1. Update Member Data\n");
            Console.WriteLine("2. Delete Member Data\n");
            Console.WriteLine("3. Search Member Data\n");
            Console.WriteLine("4. Back\n");
            Console.Write("Select Mode : ");
        }
        //회원관리 모드에서 회원정보수정 기능 페이지
        public void MemberUpdatePage()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("< Library Management System >");
            Console.WriteLine();
            Console.WriteLine("1. Update ID\n");
            Console.WriteLine("2. Update PW\n");
            Console.WriteLine("3. Update Name\n");
            Console.WriteLine("4. Back\n");
            Console.Write("Select Mode : ");
        }
        //회원관리 모드에서 회원정보검색 기능 페이지
        public void MemberSearchPage()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("< Library Management System >");
            Console.WriteLine();
            Console.WriteLine("1. Search by ID\n");
            Console.WriteLine("2. Search by Name\n");
            Console.WriteLine("3. Search All Members' Data\n");
            Console.WriteLine("4. Back\n");
            Console.Write("Select Mode : ");
        }
        //도서관리 모드 페이지
        public void BookPage()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("< Library Management System >");
            Console.WriteLine();
            Console.WriteLine("1. Register Book Data\n");
            Console.WriteLine("2. Update Book Data\n");
            Console.WriteLine("3. Delete Book Data\n");
            Console.WriteLine("4. Search Book Data\n");
            Console.WriteLine("5. Back\n");
            Console.Write("Select Mode : ");
        }
        //도서관리 모드에서 도서정보수정 기능 페이지
        public void BookUpdatePage()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("< Library Management System >");
            Console.WriteLine();
            Console.WriteLine("1. Update Name\n");
            Console.WriteLine("2. Update Author\n");
            Console.WriteLine("3. Update Price\n");
            Console.WriteLine("4. Update Quantity\n");
            Console.WriteLine("5. Back\n");
            Console.Write("Select Mode : ");
        }
        //도서관리 모드에서 도서정보검색 기능 페이지
        public void BookSearchPage()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("< Library Management System >");
            Console.WriteLine();
            Console.WriteLine("1. Search by Name\n");
            Console.WriteLine("2. Search by Author\n");
            Console.WriteLine("3. Search by Price\n");
            Console.WriteLine("4. Search All Books\n");
            Console.WriteLine("5. Back\n");
            Console.Write("Select Mode : ");
        }
        //도서대여반납 모드 페이지
        public void LoanPage()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("< Library Management System >");
            Console.WriteLine();
            Console.WriteLine("1. Loan Book\n");
            Console.WriteLine("2. Return Book\n");
            Console.WriteLine("3. Back\n");
            Console.Write("Select Mode : ");
        }
        //기본 페이지
        public void BasePage()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("< Library Management System >");
            Console.WriteLine();
        }
        //기능 마치고 ENTER입력 시 이전 페이지로 돌아감
        public void EnterReturn()
        {
            Console.WriteLine();
            Console.WriteLine("Input ENTER");
            Console.ReadLine();
        }
        //확인 절차 페이지
        public int ConfirmingProcess()
        {
            int ConfirmSelect;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("< Library Management System >");
            Console.WriteLine();
            Console.WriteLine("Are you sure ?\n");
            Console.WriteLine("1. Yes   2. No\n");
            Console.Write("Input number : ");

            ConfirmSelect = Exc.CheckNumberInput(CONFIRM_YES, CONFIRM_NO);

            if (ConfirmSelect == CONFIRM_YES)
                return CONFIRM_YES;
            else
                return CONFIRM_NO;
        }
        //프로그램 종료 페이지
        public void ExitPage()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("< Library Management System >");
            Console.WriteLine();
            Console.WriteLine("Program Terminated. Bye");
            Console.WriteLine();
        }
    }
}
