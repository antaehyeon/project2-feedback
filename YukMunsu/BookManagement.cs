using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 도서관리
{
    class BookManagement
    {
        Display display;
        Exception exception;
        private BookVO bookData;
        public ArrayList bookNoList; // 도서 정보를 저장하는 ArrayList
        public ArrayList bookNameList;
        public ArrayList bookPublisherList;
        public ArrayList bookAuthorList;
        public ArrayList bookPriceList;
        public ArrayList bookQuantityList;
        string num = "";
        string book = "";
        bool exist = true; // 로그인 상태
        int exceptionNumber = 0; // 예외 변수
        int count = 0; // 등록 변수

        public BookManagement(Display display) // 생성자
        {
            this.display = display;
            exception = new Exception(display);
            bookData = new BookVO(); // 도서 정보 객체 생성
            bookNoList = new ArrayList();
            bookNameList = new ArrayList();
            bookPublisherList = new ArrayList();
            bookAuthorList = new ArrayList();
            bookPriceList = new ArrayList();
            bookQuantityList = new ArrayList();

            bookNoList.Add("13-73000491");
            bookNameList.Add("C#프로그래밍");
            bookPublisherList.Add("한빛미디어"); // 테스트용
            bookAuthorList.Add("안철수");
            bookPriceList.Add("35000");
            bookQuantityList.Add("2");
            bookNoList.Add("13-76002315");
            bookNameList.Add("C++프로그래밍");
            bookPublisherList.Add("오렌지미디어");
            bookAuthorList.Add("문재인");
            bookPriceList.Add("28000");
            bookQuantityList.Add("1");
            bookNoList.Add("13-73001245");
            bookNameList.Add("데이터구조론");
            bookPublisherList.Add("세종대학교");
            bookAuthorList.Add("안희정");
            bookPriceList.Add("40000");
            bookQuantityList.Add("2");
        }

        public void enrollmentBook() // 도서 등록 메소드
        {
            Console.Clear();
            while (count < 6)
            {
                if (count == 0) // 입력 실패 했을때 그 부분만 반복하기 위해 카운트 사용
                {
                    display.inputDisplay("xx-xxxxxxxx 로 입력해주세요", 2);
                    display.inputDisplay("도서번호", 1);
                    bookData.BookNo = Console.ReadLine();
                    exceptionNumber = exception.bookNoException(bookData.BookNo); // 예외처리후 정수값 리턴받는다

                    if (exceptionNumber == 0) // 예외처리 통과했을때
                    {
                        bookNoList.Add(bookData.BookNo); // 값을 추가한다
                        count++; // 카운트를 증가시켜서 다음단계로 넘어감
                    }
                }
                else if (count == 1)
                {
                    display.inputDisplay("도서명", 1);
                    bookData.BookName = Console.ReadLine();
                    
                    if (exception.intException(bookData.BookName, "도서명을 제대로 입력하세요"))
                    {
                        bookNameList.Add(bookData.BookName);
                        count++;
                    }
                }
                else if (count == 2)
                {
                    display.inputDisplay("출판사", 1);
                    bookData.BookPublisher = Console.ReadLine();
                    
                    if (exception.intException(bookData.BookPublisher, "출판사명을 제대로 입력하세요"))
                    {
                        bookPublisherList.Add(bookData.BookPublisher);
                        count++;
                    }
                }
                else if (count == 3)
                {
                    display.inputDisplay("저자명", 1);
                    bookData.BookAuthor = Console.ReadLine();
                    exceptionNumber = exception.nameException(bookData.BookAuthor);

                    if (exceptionNumber == 0)
                    {
                        bookAuthorList.Add(bookData.BookAuthor);
                        count++;
                    }
                }
                else if (count == 4)
                {
                    display.inputDisplay("가격", 1);
                    bookData.BookPrice = Console.ReadLine();
                    exceptionNumber = exception.priceException(bookData.BookPrice);

                    if (exceptionNumber == 0)
                    {
                        bookPriceList.Add(bookData.BookPrice);
                        count++;
                    }
                }
                else if (count == 5)
                {
                    display.inputDisplay("수량", 1);
                    bookData.BookQuantity = Console.ReadLine();
                    exceptionNumber = exception.priceException(bookData.BookQuantity);

                    if (exceptionNumber == 0)
                    {
                        bookQuantityList.Add(bookData.BookQuantity);
                        count++;
                    }
                }
            }
            display.printDisplay("등록 되었습니다");
            count = 0;
        }
       
        public void searchBook() // 도서 검색 메소드
        {
            while (num != "1" && num != "2" && num != "3" && num != "4" && num != "5")
            {
                display.inputDisplay("검색할 방법", 2);
                display.inputDisplay("1.도서번호 2.도서명 3.출판사 4.저자 5.가격", 2);
                display.inputDisplay("입력", 1);
                num = Console.ReadLine();

                switch (num)
                {
                    case "1":
                        display.inputDisplay("도서번호", 1);
                        bookData.BookNo = Console.ReadLine();
                        bookSearch(bookNoList, bookData.BookNo); // 도서번호로 검색
                        break;
                    case "2":
                        display.inputDisplay("도서명", 1);
                        bookData.BookName = Console.ReadLine();
                        bookSearch(bookNameList, bookData.BookName); // 도서명으로 검색
                        break;
                    case "3":
                        display.inputDisplay("출판사명", 1);
                        bookData.BookPublisher = Console.ReadLine();
                        bookSearch(bookPublisherList, bookData.BookPublisher); // 출판사로 검색
                        break;
                    case "4":
                        display.inputDisplay("저자명", 1);
                        bookData.BookAuthor = Console.ReadLine();
                        bookSearch(bookAuthorList, bookData.BookAuthor); // 저자로 검색
                        break;
                    case "5":
                        display.inputDisplay("가격", 1);
                        bookData.BookPrice = Console.ReadLine();
                        bookSearch(bookPriceList, bookData.BookPrice); // 가격으로 검색                        
                        break;
                    default:
                        display.printDisplay("제대로 입력하세요");
                        break;
                }
            }
            num = "";
        }

        public void bookSearch(ArrayList bookList, string bookInfo) // 도서 검색 방법 메소드
        {
            display.bookDisplay();
            for (int i = 0; i < bookNoList.Count; i++)
            {
                book = Convert.ToString(bookList[i]); // ArrayList 값을 String 으로 변환
                exist = book.Contains(bookInfo); // 문자열에 입력받은 값이

                if (exist) // 존재한다면
                {
                    display.bookPrint(bookNoList[i], bookNameList[i], bookPublisherList[i], bookAuthorList[i], bookPriceList[i], bookQuantityList[i]);
                }
            }
        }

        public void printBook() // 도서 출력 메소드
        {
            for (int i = 0; i < bookNameList.Count; i++) // ArrayList 순회 한다
            {
                Console.Write("\t{0}" + "\t\t{1}" + "\t\t{2}" + "\t\t{3}" + "\t\t{4}" + "\t\t{5}", bookNoList[i], bookNameList[i], bookPublisherList[i], bookAuthorList[i], bookPriceList[i], bookQuantityList[i]);
                Console.WriteLine();
            }
        }

        public void deleteBook() // 도서 삭제 메소드
        {
            Console.Clear();
            display.inputDisplay("삭제할 도서명", 1);
            bookData.BookName = Console.ReadLine();

            for (int j = 0; j < bookNameList.Count; j++)
            {
                if (Convert.ToString(bookNameList[j]) == bookData.BookName) // 입력받은 값이 존재한다면
                {
                    bookNoList.RemoveAt(j);
                    bookNameList.RemoveAt(j);
                    bookPublisherList.RemoveAt(j); // ArrayList값 전부 삭제
                    bookAuthorList.RemoveAt(j);
                    bookPriceList.RemoveAt(j);
                    bookQuantityList.RemoveAt(j);
                    display.printDisplay("삭제 되었습니다");
                }
            }
        }

        public void updateBook() // 도서 수정 메소드
        {
            Console.Clear();
            while (num != "1" && num != "2" && num != "3" && num != "4" && num != "5" && num != "6")
            {
                display.printDisplay("수정할 항목");
                Console.WriteLine("             1. 도서번호 2. 도서명 3. 출판사 4. 저자명 5. 가격 6. 수량");
                display.inputDisplay("입력", 1);
                num = Console.ReadLine();

                switch (num)
                {
                    case "1":
                        display.inputDisplay("도서명", 1);
                        bookData.BookName = Console.ReadLine();
                        bookUpdate(bookNoList, bookData.BookName, "변경할 도서번호"); // 도서번호 수정
                        break;
                    case "2":
                        display.inputDisplay("기존 도서명", 1);
                        bookData.BookName = Console.ReadLine();
                        bookUpdate(bookNameList, bookData.BookName, "변경할 도서명"); // 도서명 수정
                        break;
                    case "3":
                        display.inputDisplay("도서명", 1);
                        bookData.BookName = Console.ReadLine();
                        bookUpdate(bookPublisherList, bookData.BookName, "변경할 출판사명"); // 출판사명 수정
                        break;
                    case "4":
                        display.inputDisplay("도서명", 1);
                        bookData.BookName = Console.ReadLine();
                        bookUpdate(bookAuthorList, bookData.BookName, "변경할 저자명"); // 저자명 수정             
                        break;
                    case "5":
                        display.inputDisplay("도서명", 1);
                        bookData.BookName = Console.ReadLine();
                        bookUpdate(bookPriceList, bookData.BookName, "변경할 가격"); // 가격 수정
                        break;   
                    case "6":
                        display.inputDisplay("도서명", 1);
                        bookData.BookName = Console.ReadLine();
                        bookUpdate(bookQuantityList, bookData.BookName, "변경할 수량"); // 수량 수정
                        break;
                    default:
                        display.printDisplay("제대로 입력하세요");
                        break;
                }
            }
            num = "";
        }

        public void bookUpdate(ArrayList bookList, string book, string str) // 도서 수정 방법 메소드
        {
            for (int i = 0; i < bookNameList.Count; i++)
            {
                if (Convert.ToString(bookNameList[i]) == book) // 책이름이 같다면
                {
                    display.inputDisplay(str, 1);
                    book = Console.ReadLine(); // 입력받은 값으로
                    bookList[i] = book; // 어레이리스트값을 바꿔준다
                    display.printDisplay("수정 되었습니다");
                }
            }
        }
    }
}