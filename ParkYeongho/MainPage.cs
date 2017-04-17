using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class MainPage
    {
        private Member member;
        private Book book;
        private RentAndReturnBook rentAndReturnBook;
        private Display display;
        private Exception exception;
        public MainPage()                                                                                           // MainPage 생성자 생성
        {
            display = new Display();
            exception = new Exception();
            member = new Member(this, display, exception);
            book = new Book(this, display, exception);
            rentAndReturnBook = new RentAndReturnBook(this, display, exception);
        }
        static bool isCalledBefore = true;                                                                          // MainPage가 처음으로 실행됐는지 확인하는 값을 저장
        public void RunMainPage(ArrayList memberArrayList, ArrayList bookArrayList)                                 // MainPage 실행
        {
            if(isCalledBefore == true)                                                                              // MainPage가 처음으로 실행된 경우 회원 및 도서 데이터를 저장
            {
                MemberAndBookData memberAndBookData = new MemberAndBookData();
                memberAndBookData.InitMemberAndBookData(memberArrayList, bookArrayList);                            // 회원 및 도서 데이터를 초기화
                isCalledBefore = false;                                                                             // MainPage가 한번 실행됐기 때문에 값을 false로 변경
            }
            string mainMenuInput = Console.ReadLine();

            switch (mainMenuInput)
            {
                case "1": display.PrintMemberPage();                                                                // 입력값이 1인 경우 회원 관리 페이지 실행
                          member.RunMemberPage(memberArrayList, bookArrayList);
                          break;
                case "2": display.PrintBookPage();                                                                  // 입력값이 2인 경우 도서 관리 페이지 실행
                          book.RunBookPage(memberArrayList, bookArrayList);
                          break;
                case "3": display.PrintRentAndReturnBook();                                                         // 입력값이 3인 경우 도서 대여 및 반납 페이지 실행
                          rentAndReturnBook.RunRentAndReturnBook(memberArrayList, bookArrayList);
                          break;  
                case "4": Environment.Exit(0); break;
                default:  Console.SetCursorPosition(104, 22);                                                       // 입력값이 지정된 번호가 아닌 경우 '잘못된 입력' 출력
                          Console.WriteLine("잘못된 입력");
                          System.Threading.Thread.Sleep(1000);
                          display.PrintMainPage();
                          RunMainPage(memberArrayList, bookArrayList);
                          break;
            }
        }
    }
}
