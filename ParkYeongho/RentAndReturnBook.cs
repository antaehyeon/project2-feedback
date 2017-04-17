using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class RentAndReturnBook
    {
        private MainPage mainPage;
        private Display display;
        private Exception exception;
        public RentAndReturnBook() { }                                                                  // RentAndReturnBook 클래스 기본 생성자 생성
        public RentAndReturnBook(MainPage aMainPage, Display aDisplay, Exception aException)            // MainPage, Display, Exception 클래스 매개변수를 넘겨 받아 생성자 생성
        {
            this.mainPage = aMainPage;
            this.display = aDisplay;
            this.exception = aException;
        }

        public void RunRentAndReturnBook(ArrayList memberArrayList, ArrayList bookArrayList)            // 도서 대여 및 반납 메뉴 실행
        {
            string rentAndReturnBookInput = Console.ReadLine();

            switch (rentAndReturnBookInput)
            {
                case "1": RentBook(memberArrayList, bookArrayList); break;                              // 입력값이 1인 경우 도서 대여 기능 실행
                case "2": ReturnBook(memberArrayList, bookArrayList); break;                            // 입력값이 2인 경우 도서 반납 기능 실행
                case "3": PrintRentAndReturnBookList(memberArrayList, bookArrayList); break;            // 입력값이 3인 경우 대여 내역 기능 실행
                case "4": display.PrintMainPage();                                                      // 입력값이 4인 경우 메인 페이지로 이동
                          mainPage.RunMainPage(memberArrayList, bookArrayList);
                          break;
                default:  Console.SetCursorPosition(104, 22);                                           // 입력값이 지정된 번호가 아닌 경우 '잘못된 입력' 출력
                          Console.Write("잘못된 입력");
                          System.Threading.Thread.Sleep(1000);
                          display.PrintRentAndReturnBook();
                          RunRentAndReturnBook(memberArrayList, bookArrayList);
                          break;
            }
        }

        public void RentBook(ArrayList memberArrayList, ArrayList bookArrayList)                        // 도서 대여 기능 실행
        {
            display.Outline();                                                                          // 기본 네모 Outline 출력
            Console.SetCursorPosition(36, 11);
            Console.Write("대여할 도서의 번호를 입력하세요. :");
            string rentBookNo = "";
            rentBookNo = exception.NumberInput(rentBookNo);                                             // 대여할 도서의 번호 입력값이 숫자인지 확인
            foreach(BookVO bookList in bookArrayList)
            {
                if(bookList.BookNo == rentBookNo && bookList.BookReservation == "대여 가능")            // 대여할 도서의 번호가 이미 등록된 도서의 번호 중 일치하는 값이 있고 해당 도서의 대여 정보가 '대여 가능'인 경우
                {
                    bookList.BookReservation = "대여중";                                                // 해당 도서의 대여 정보를 '대여중'으로 변경
                    bookList.BookReturnDate = DateTime.Today.AddDays(7);                                // 반납 예정일을 현재 날짜에서 7을 더한 값으로 변경
                    display.Outline();
                    Console.SetCursorPosition(34, 11);
                    Console.Write(bookList.BookName + "을(를) " + bookList.BookReturnDate.Year + "년" + bookList.BookReturnDate.Month + "월" + bookList.BookReturnDate.Day + "일까지 대여합니다.");
                    Console.SetCursorPosition(80, 22);
                    Console.Write("뒤로 가려면 'q'를 입력하세요.");                                     // 'q' 또는 'ㅂ'을 입력 받으면 도서 대여 및 반납 페이지로 이동
                    ConsoleKeyInfo key;

                    while (true)
                    {
                        key = Console.ReadKey(true);
                        if (key.KeyChar == 'q' || key.KeyChar == 'ㅂ')
                        {
                            display.PrintRentAndReturnBook();
                            RunRentAndReturnBook(memberArrayList, bookArrayList);
                            break;
                        }
                        else
                        {
                            Console.Write("");
                        }
                    }
                    
                } else if(bookList.BookNo == rentBookNo && bookList.BookReservation == "대여중")       // 대여할 도서의 번호가 이미 등록된 도서의 번호 중 일치하는 값이 있고 해당 도서의 대여 정보가 '대여중'인 경우
                {
                    display.Outline();
                    Console.SetCursorPosition(34, 11);
                    Console.Write("현재 " + bookList.BookName + "은(는) " + bookList.BookReturnDate.Year + "년" + bookList.BookReturnDate.Month + "월" + bookList.BookReturnDate.Day + "일까지 대여중입니다.");    // 이미 대여중이기 때문에 해당 도서의 반납예정일을 출력
                    Console.SetCursorPosition(80, 22);
                    Console.Write("뒤로 가려면 'q'를 입력하세요.");                                    // 'q' 또는 'ㅂ'을 입력 받으면 뒤로 가기
                    ConsoleKeyInfo key;
                    while (true)
                    {
                        key = Console.ReadKey(true);
                        if (key.KeyChar == 'q' || key.KeyChar == 'ㅂ')
                        {
                            display.PrintRentAndReturnBook();
                            RunRentAndReturnBook(memberArrayList, bookArrayList);
                            break;
                        }
                        else
                        {
                            Console.Write("");
                        }
                    }
                    
                }
            }
            display.Outline();                                                                          // 대여할 도서의 번호가 이미 등록된 도서의 번호 중 일치하는 값이 없는 경우
            Console.SetCursorPosition(34, 11);
            Console.Write(rentBookNo + "번의 도서 정보를 찾을 수 없습니다.");
            System.Threading.Thread.Sleep(2000);
            display.PrintRentAndReturnBook();                                                           // 도서 대여 및 반납 페이지로 이동
            RunRentAndReturnBook(memberArrayList, bookArrayList);
        }

        public void ReturnBook(ArrayList memberArrayList, ArrayList bookArrayList)                      // 도서 반납 기능 실행
        {
            display.Outline();
            Console.SetCursorPosition(36, 11);
            Console.Write("반납할 도서의 번호를 입력하세요. :");
            string returnBookNo = "";
            returnBookNo = exception.NumberInput(returnBookNo);                                         // 반납할 도서의 번호 입력값이 숫자인지 확인
            foreach(BookVO bookList in bookArrayList)
            {
                if(bookList.BookNo == returnBookNo && bookList.BookReservation == "대여중" && DateTime.Now <= bookList.BookReturnDate)     // 반납할 도서의 번호가 이미 등록된 도서의 번호 중 일치하는 값이 있고 현재날짜가 반납예정일보다 값이 작은 경우 
                {
                    bookList.BookReservation = "대여 가능";                                             // 해당 도서의 대여 정보를 '대여 가능'으로 변경
                    display.Outline();
                    Console.SetCursorPosition(34, 11);
                    Console.Write(bookList.BookName + "가 기한 내에 반납되었습니다.");                  // 해당 도서가 기한 내에 반납되었다고 출력
                    System.Threading.Thread.Sleep(2000);
                    display.PrintRentAndReturnBook();                                                   // 도서 대여 및 반납 페이지로 이동
                    RunRentAndReturnBook(memberArrayList, bookArrayList);
                    break;
                }else if(bookList.BookNo == returnBookNo && bookList.BookReservation == "대여중" && DateTime.Now > bookList.BookReturnDate)    // 반납할 도서의 번호가 이미 등록된 도서의 번호 중 일치하는 값이 있고 현재날짜가 반납예정일보다 값이 큰 경우
                {
                    bookList.BookReservation = "대여 가능";                                             // 해당 도서의 대여 정보를 '대여 가능'으로 변경
                    display.Outline();
                    Console.SetCursorPosition(34, 11);
                    Console.Write(bookList.BookName + "가 연체되어 반납되었습니다.");                   // 해당 도서가 연체되어 반납되었다고 출력
                    System.Threading.Thread.Sleep(2000);
                    display.PrintRentAndReturnBook();                                                   // 도서 대여 및 반납 페이지로 이동
                    RunRentAndReturnBook(memberArrayList, bookArrayList);
                }
                else if(bookList.BookNo == returnBookNo && bookList.BookReservation == "대여 가능")     // 반납할 도서의 번호가 이미 등록된 도서의 번호 중 일치하는 값이 있고 해당 도서의 대여 정보가 '대여 가능'인 경우
                {
                    display.Outline();
                    Console.SetCursorPosition(34, 11);
                    Console.Write(bookList.BookName + "을(를) 대여 가능합니다.");                       // 해당 도서의 대여 정보가 원래 '대여 가능'이기 때문에 대여 가능하다고 출력
                    System.Threading.Thread.Sleep(2000);
                    display.PrintRentAndReturnBook();                                                   // 도서 대여 및 반납 페이지로 이동
                    RunRentAndReturnBook(memberArrayList, bookArrayList);
                    break;
                }
            }
            display.Outline();                                                                          // 반납할 도서의 번호가 이미 등록된 도서의 번호 중 일치하는 값이 없는 경우
            Console.SetCursorPosition(34, 11);
            Console.Write(returnBookNo + "번의 도서 정보를 찾을 수 없습니다.");
            System.Threading.Thread.Sleep(2000);
            display.PrintRentAndReturnBook();                                                           // 도서 대여 및 반납 페이지로 이동
            RunRentAndReturnBook(memberArrayList, bookArrayList);
        }

        public void PrintRentAndReturnBookList(ArrayList memberArrayList, ArrayList bookArrayList)      // 대여 내역 기능 실행
        {
            BookVO bookVO = new BookVO();
            int row = 5;                                                                                // 대여 내역을 출력할 첫 번째 행을 저장
            display.BookUpperOutline();                                                                 // 도서 정보 카테고리 Outline 출력
            foreach (BookVO bookList in bookArrayList)
            {
                if (bookList.BookReservation == "대여 가능")                                            // 먼저 등록된 도서의 대여 정보가 '대여 가능'인 도서만 출력
                {
                    Console.SetCursorPosition(5, row);
                    Console.Write(bookList.BookNo);
                    Console.SetCursorPosition(12, row);
                    Console.Write(bookList.BookName);
                    Console.SetCursorPosition(34, row);
                    Console.Write(bookList.BookAuthor);
                    Console.SetCursorPosition(53, row);
                    Console.Write(bookList.BookPublisher);
                    Console.SetCursorPosition(74, row);
                    Console.Write(bookList.BookPrice);
                    Console.SetCursorPosition(86, row);
                    Console.Write(bookList.BookReservation);
                    row = row + 2;                                                                      // 행의 값을 2씩 증가
                }
            }
            foreach(BookVO bookList in bookArrayList)
            {
                if (bookList.BookReservation == "대여중")                                               // 대여 정보가 '대여중'인 도서 출력
                {
                    if(row == 5) display.BookUpperOutline();                                            // 등록된 모든 도서가 대여중인 경우 도서 정보 카테고리 Outline 출력
                    Console.SetCursorPosition(5, row);
                    Console.Write(bookList.BookNo);
                    Console.SetCursorPosition(12, row);
                    Console.Write(bookList.BookName);
                    Console.SetCursorPosition(34, row);
                    Console.Write(bookList.BookAuthor);
                    Console.SetCursorPosition(53, row);
                    Console.Write(bookList.BookPublisher);
                    Console.SetCursorPosition(74, row);
                    Console.Write(bookList.BookPrice);
                    Console.SetCursorPosition(86, row);
                    Console.Write(bookList.BookReservation);
                    Console.SetCursorPosition(97, row);
                    Console.Write(bookList.BookReturnDate.Year + "년 " + bookList.BookReturnDate.Month + "월 " + bookList.BookReturnDate.Day + "일");      // 대여정보가 '대여중'인 도서는 반납예정일도 출력
                    row = row + 2;
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("뒤로 가려면 'q'를 입력하세요.");
            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey(true);
                if (key.KeyChar == 'q' || key.KeyChar == 'ㅂ')
                {
                    display.PrintRentAndReturnBook();
                    RunRentAndReturnBook(memberArrayList, bookArrayList);
                    break;
                }
                else
                {
                    Console.Write("");
                }
            }
        }
    }
}
