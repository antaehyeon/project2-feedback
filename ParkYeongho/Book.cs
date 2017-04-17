using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Book
    {
        private MainPage mainPage;
        private Display display;
        private Exception exception;
        public Book() { }
        public Book(MainPage aMainPage, Display aDisplay, Exception aException)                                     // MainPage, Display, Exception 클래스를 넘겨받아 생성자 생성
        {
            this.mainPage = aMainPage;
            this.display = aDisplay;
            this.exception = aException;
        }
        static int countBookNo = 5;                                                                                 // 도서번호 count값. 도서 번호를 static으로 지정하여 도서 번호를 계속해서 저장하여 중복되는 것을 막는다.
        public void RunBookPage(ArrayList memberArrayList, ArrayList bookArrayList)
        {
            string bookPageInput = Console.ReadLine();

            switch (bookPageInput)
            {
                case "1": RegisterBook(memberArrayList, bookArrayList);break;                                       // 1번 입력 시 '도서 등록' 실행
                case "2": ModifyBook(memberArrayList, bookArrayList);break;                                         // 2번 입력 시 '도서 수정' 실행
                case "3": DeleteBook(memberArrayList, bookArrayList);break;                                         // 3번 입력 시 '도서 삭제' 실행
                case "4": SelectBook(memberArrayList, bookArrayList);break;                                         // 4번 입력 시 '도서 검색' 실행
                case "5": PrintBookList(memberArrayList, bookArrayList);break;                                      // 5번 입력 시 '도서 내역' 실행
                case "6": display.PrintMainPage();                                                                  // 6번 입력 시 메인 페이지로 이동
                          mainPage.RunMainPage(memberArrayList, bookArrayList);
                          break;
                default:  Console.SetCursorPosition(104, 22);                                                       // 지정된 번호 이외의 입력이 들어왔을 때 알림 메세지 출력
                          Console.Write("잘못된 입력");
                          System.Threading.Thread.Sleep(1000);
                          display.PrintBookPage();
                          RunBookPage(memberArrayList, bookArrayList);
                          break;
            }
        }

        public void RegisterBook(ArrayList memberArrayList, ArrayList bookArrayList)                                 // '도서 등록' 기능 실행
        {
            BookVO bookVO = new BookVO();

            display.PrintBookRegisterOrModify("등", "록");                                                           // '도서 등록' 페이지 출력
            Console.SetCursorPosition(46, 9);
            bookVO.BookName = exception.EnglishOrKoreanOrNumberInput(bookVO.BookName);                               // 도서 제목 입력값이 영문자 혹은 한글 혹은 숫자인지 확인
            Console.SetCursorPosition(46, 11);
            bookVO.BookAuthor = exception.EnglishOrKoreanOrNumberInput(bookVO.BookAuthor);                           // 도서 저자 입력값이 영문자 혹은 한글 혹은 숫자인지 확인
            Console.SetCursorPosition(46, 13);
            bookVO.BookPublisher = exception.EnglishOrKoreanOrNumberInput(bookVO.BookPublisher);                     // 도서 출판사 입력값이 영문자 혹은 한글 혹은 숫자인지 확인
            Console.SetCursorPosition(46, 15);
            bookVO.BookPrice = exception.NumberInput(bookVO.BookPrice);                                              // 도서 가격 입력값이 숫자인지 확인
            bookVO.BookNo = countBookNo.ToString();                                                                  // 도서 번호를 저장
            countBookNo++;                                                                                           // 도서 번호 count를 1씩 증가
            bookArrayList.Add(bookVO);                                                                               // bookArrayList에 도서 등록 정보 추가
            display.Outline();                                                                                       // 기본 네모 Outline 출력
            Console.SetCursorPosition(45, 11);
            Console.Write("도서 등록을 완료했습니다.");
            System.Threading.Thread.Sleep(2000);
            display.PrintBookPage();                                                                                 // 도서 관리 페이지로 이동
            RunBookPage(memberArrayList, bookArrayList);
        }

        public void ModifyBook(ArrayList memberArrayList, ArrayList bookArrayList)                                   // '도서 수정' 기능 실행
        {
            display.Outline();                                                                                       // 기본 네모 Outline 출력
            Console.SetCursorPosition(30, 11);
            Console.Write("수정할 도서의 번호를 입력하세요. : ");
            string modifyBookNo = "";
            string modifyBookName = "";
            modifyBookNo = exception.NumberInput(modifyBookNo);                                                      // 수정할 도서의 번호가 숫자인지 확인
            foreach(BookVO bookList in bookArrayList)
            {
                if(bookList.BookNo == modifyBookNo)                                                                  // 수정할 도서의 번호가 이미 등록된 도서 정보의 번호와 같은 값이 있으면 도서 정보 수정
                {
                    bookList.BookName = "";
                    bookList.BookAuthor = "";
                    bookList.BookPublisher = "";
                    bookList.BookPrice = "";
                    modifyBookName = bookList.BookName;
                    display.PrintBookRegisterOrModify("수", "정");
                    Console.SetCursorPosition(46, 9);
                    bookList.BookName = exception.EnglishOrKoreanOrNumberInput(bookList.BookName);                   // 수정할 도서의 제목의 입력값이 영문자 혹은 한글 혹은 숫자인지 확인
                    Console.SetCursorPosition(46, 11);
                    bookList.BookAuthor = exception.EnglishOrKoreanOrNumberInput(bookList.BookAuthor);               // 수정할 도서의 저자 입력값이 영문자 혹은 한글 혹은 숫자인지 확인
                    Console.SetCursorPosition(46, 13);
                    bookList.BookPublisher = exception.EnglishOrKoreanOrNumberInput(bookList.BookPublisher);         // 수정할 도서의 출판사 입력값이 영문자 혹은 한글 혹은 숫자인지 확인
                    Console.SetCursorPosition(46, 15);
                    bookList.BookPrice = exception.NumberInput(bookList.BookPrice);                                 // 수정할 도서의 가격 입력값이 숫자인지 확인
                    display.Outline();                                                                               // 기본 네모 Outline 출력
                    Console.SetCursorPosition(45, 11);
                    Console.Write("도서 내용을 수정했습니다.");
                    System.Threading.Thread.Sleep(2000);
                    display.PrintBookPage();                                                                         // 도서 관리 페이지로 이동
                    RunBookPage(memberArrayList, bookArrayList);
                    break;
                }
            }
            display.Outline();                                                                                       // 수정할 도서 번호를 찾을 수 없는 경우
            Console.SetCursorPosition(45, 11);
            Console.Write(modifyBookNo + "번의 도서 정보를 찾을 수 없습니다.");
            System.Threading.Thread.Sleep(2000);
            display.PrintBookPage();                                                                                 // 도서 관리 페이지로 이동
            RunBookPage(memberArrayList, bookArrayList);
        }

        public void DeleteBook(ArrayList memberArrayList, ArrayList bookArrayList)                                   // '도서 삭제' 기능 실행
        {
            display.Outline();                                                                                       // 기본 네모 Outline 출력
            Console.SetCursorPosition(30, 11);
            Console.Write("삭제할 도서의 번호를 입력하세요. : ");
            
            string deleteBookNo = "";
            string deleteBookName = "";
            deleteBookNo = exception.NumberInput(deleteBookNo);                                                      // 삭제할 도서의 번호가 숫자인지 확인
            foreach(BookVO bookList in bookArrayList)
            {
                if(bookList.BookNo == deleteBookNo)                                                                  // 삭제할 도서의 번호가 이미 등록된 도서의 번호 중 같은 값이 있는 경우
                {
                    deleteBookName = bookList.BookName;
                    bookArrayList.Remove(bookList);                                                                  // 해당 번호의 도서 정보 삭제
                    display.Outline();
                    Console.SetCursorPosition(40, 11);
                    Console.Write(deleteBookName + "의 도서 정보가 삭제되었습니다.");
                    System.Threading.Thread.Sleep(2000);
                    display.PrintBookPage();                                                                         // 도서 관리 페이지로 이동
                    RunBookPage(memberArrayList, bookArrayList);
                    break;
                }
            }
            display.Outline();                                                                                       // 삭제할 도서의 번호를 찾을 수 없는 경우
            Console.SetCursorPosition(40, 11);
            Console.Write(deleteBookNo + "번의 도서 정보를 찾을 수 없습니다.");
            System.Threading.Thread.Sleep(2000);
            display.PrintBookPage();                                                                                 // 도서 관리 페이지로 이동
            RunBookPage(memberArrayList, bookArrayList);
        }

        public void SelectBook(ArrayList memberArrayList, ArrayList bookArrayList)                                   // '도서 검색' 기능 실행
        {
            display.Outline();
            Console.SetCursorPosition(30, 11);
            Console.Write("검색할 도서의 제목 입력하세요. : ");
            string selectBookName = "";
            selectBookName = exception.EnglishOrKoreanOrNumberInput(selectBookName);                                                      // 검색할 도서의 제목이 영문자 혹은 한글 혹은 숫자인지 확인
            foreach(BookVO bookList in bookArrayList)
            {
                if(bookList.BookName.Contains(selectBookName))                                                                  // 이미 등록된 도서의 제목 중 검색할 도서의 제목을 포함하는 도서가 있는 경우
                {
                    display.BookUpperOutline();                                                                      // 검색한 도서의 정보 출력
                    Console.SetCursorPosition(5, 5);
                    Console.Write(bookList.BookNo);
                    Console.SetCursorPosition(12, 5);
                    Console.Write(bookList.BookName);
                    Console.SetCursorPosition(34, 5);
                    Console.Write(bookList.BookAuthor);
                    Console.SetCursorPosition(53, 5);
                    Console.Write(bookList.BookPublisher);
                    Console.SetCursorPosition(74, 5);
                    Console.Write(bookList.BookPrice);
                    Console.SetCursorPosition(86, 5);
                    Console.Write(bookList.BookReservation);
                    if (bookList.BookReservation == "대여중")                                                         // 검색한 도서가 대여중이라면 '반납예정일'도 출력
                    {
                        Console.SetCursorPosition(97, 5);
                        Console.Write(bookList.BookReturnDate.Year + "년 " + bookList.BookReturnDate.Month + "월 " + bookList.BookReturnDate.Day + "일");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("뒤로 가려면 'q'를 입력하세요.");
                    ConsoleKeyInfo key;
                    while (true)
                    {
                        key = Console.ReadKey(true);                                                                  // 입력값의 ConsoleKey가 'q' 혹은 'ㅂ'이면 회원 관리 페이지로 이동
                        if (key.KeyChar == 'q' || key.KeyChar == 'ㅂ')
                        {
                            display.PrintMemberPage();
                            RunBookPage(memberArrayList, bookArrayList);
                            break;
                        }
                        else
                        {
                            Console.Write("");
                        }
                    }
                    break;
                }
            }
            display.Outline();                                                                                         // 검색할 도서 번호가 이미 등록된 도서의 번호 중 일치하는 값이 없는 경우
            Console.SetCursorPosition(40, 11);
            Console.Write(selectBookName + "의 도서 정보를 찾을 수 없습니다.");
            System.Threading.Thread.Sleep(2000);
            display.PrintBookPage();
            RunBookPage(memberArrayList, bookArrayList);
        }

        public void PrintBookList(ArrayList memberArrayList, ArrayList bookArrayList)                                   // '도서 내역' 기능 실행
        {
            int row = 5;                                                                                                // 첫 번째로 출력할 행의 위치 5로 저장
            display.BookUpperOutline();                                                                                 // 도서 내역의 카테고리 출력
            foreach(BookVO bookList in bookArrayList)                                                                   // 도서 내역 출력
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
                if(bookList.BookReservation == "대여중")                                                                // 도서가 대여중이라면 '반납예정일'도 출력
                {
                    Console.SetCursorPosition(97, row);
                    Console.Write(bookList.BookReturnDate.Year + "년 " + bookList.BookReturnDate.Month + "월 " + bookList.BookReturnDate.Day + "일");
                }
                row = row + 2;                                                                                          // row 값을 1씩 증가시켜 다음 행에 커서가 위치하도록 해서 차례로 다음 행에 memberList 출력
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("뒤로 가려면 'q'를 입력하세요.");
            ConsoleKeyInfo key;                                                                                         // 'q' 또는 'ㅂ'을 입력하면 뒤로 가기
            while(true)
            {
                key = Console.ReadKey(true);
                if (key.KeyChar == 'q' || key.KeyChar == 'ㅂ')
                {
                    display.PrintBookPage();
                    RunBookPage(memberArrayList, bookArrayList);
                    break;
                } else
                {
                    Console.Write("");
                }
            }
        }
    }
}
