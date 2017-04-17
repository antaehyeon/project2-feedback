using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections;

namespace 도서관리
{
    class Rental
    {
        private MemberVO memberData;
        private BookVO bookData;
        SelectMenu selecMenu;
        Display display;
        MemberManagement memberManagement;
        BookManagement bookManagement;
        DateTime localDate; // DateTime class
        ArrayList noList; // 대여한 도서정보를 저장하는 ArrayList
        ArrayList nameList;
        ArrayList quantityList;
        string rentalTime = ""; // 대여시간
        string returnTime = ""; // 반납시간
        string menu = "";
        bool login = false; // 초기는 비로그인
        int num = 0;
        int i = 0;
        int bookNum = 0;
        int count = 0;

        public Rental(Display display, MemberManagement memberManagement, BookManagement bookManagement, SelectMenu selectMenu) // 생성자
        {
            this.selecMenu = selectMenu;
            this.display = display;
            this.memberManagement = memberManagement;
            this.bookManagement = bookManagement;
            memberData = new MemberVO();
            bookData = new BookVO();
            noList = new ArrayList();
            nameList = new ArrayList();
            quantityList = new ArrayList();
        }

        public bool memberLogin() // 회원 로그인 메소드
        {
            login = false;
            while (!login) // 로그인 될때까지 반복
            {
                display.printDisplay("로그인이 필요한 서비스입니다. 주민등록번호를 입력하세요");
                display.inputDisplay("입력", 1);
                memberData.ResidentNumber = display.hideResidentNumber(); // 주민 번호 입력할때 *** 처리

                if (Convert.ToString(memberManagement.residentNumberList[i]) == memberData.ResidentNumber)
                {
                    display.printDisplay("로그인 성공");
                    memberData.ResidentNumber = "";
                    return login = false; // 로그인 성공시 false 로
                }
                else
                {
                    display.printDisplay("없는 회원입니다");
     
                    if (count > 1)
                    {
                        display.inputDisplay("로그인 시도횟수 초과", 2);
                        break;
                    }
                    count++;
                    return login = true;
                }
            }
            count = 0;
            return login;
        }

        public void bookRental(bool login) // 도서 대여 메소드
        {
            Console.Clear();
            if (login == false)
            {
                display.printDisplay("대여할 도서명");
                display.inputDisplay("입력", 1);
                bookData.BookName = Console.ReadLine();

                for (int i = 0; i < bookManagement.bookNameList.Count; i++)
                {
                    if (Convert.ToString(bookManagement.bookNameList[i]) == bookData.BookName)
                    {
                        if (Convert.ToInt32(bookManagement.bookQuantityList[i]) < 1) // 도서목록에 수량이 0이면 대여 불가능
                        {
                            display.inputDisplay("수량부족으로 대여가 불가합니다", 2);
                            break;
                        }
                        else if (Convert.ToInt32(bookManagement.bookQuantityList[i]) > 0)
                        {
                            bookNum = i; // 대여 했을때 도서를 저장했던 인덱스
                            num = Convert.ToInt32(bookManagement.bookQuantityList[i]); // ArrayList에 string 값으로 저장되어있으므로 int형 변환
                            --num; // 도서 목록에서 수량1 감소
                            string number = num.ToString(); //  int를 다시 string으로 형변환 한뒤
                            number = number.Replace(number, num.ToString()); // replace 함수를 써서 수량을 바꿈
                            bookManagement.bookQuantityList[i] = number; // 바뀐값을 다시 ArrayList에 저장
                            noList.Add(bookManagement.bookNoList[i]); // 대여한 책이 무엇인지 저장
                            nameList.Add(bookManagement.bookNameList[i]); // 새로운 ArrayList에 대여한 책만 저장
                            quantityList.Add(1); // 대여한 수량 증가
                            localDate = DateTime.Now; // 현재시간
                            display.inputDisplay("대여 완료", 2);
                            display.inputDisplay(localDate.ToString(), 2);
                            rentalTime = localDate.ToString(); // 대여시간 저장
                            returnTime = Convert.ToString(localDate.AddDays(7)); // 대여기간은 1주일이므로 7일 더해서 반납기한 저장
                            count++;
                        }   
                    }
                    else if (Convert.ToString(bookManagement.bookNameList[i]) != bookData.BookName)
                    {
                        count--;
                    }
                    if (count < -2 && i == 1)
                    {
                        display.inputDisplay("그런 도서는 없습니다", 2);
                    }
                }
            }
            else if (login == true) // 로그인 상태가 아니면 대여 불가능
            {
                display.printDisplay("로그인 상태가 아닙니다");
            }
            count = 0;
        }

        public void bookList() // 현재 도서정보 목록
        {
            for (int i = 0; i < bookManagement.bookQuantityList.Count; i++)
            {
                Console.Write("\t{0}" + "\t\t{1}" + "\t\t{2}" + "\t\t{3}" + "\t\t{4}" + "\t\t{5}", bookManagement.bookNoList[i], bookManagement.bookNameList[i], bookManagement.bookPublisherList[i], bookManagement.bookAuthorList[i], bookManagement.bookPriceList[i], bookManagement.bookQuantityList[i]);
                Console.WriteLine();
            }
        }

        public bool rentalList() // 현재 대여 목록
        {
            if (!login) // 로그인 상태
            {
                for (int i = 0; i < noList.Count; i++)
                {
                    Console.WriteLine("\t{0}" + "\t\t{1}" + "\t\t{2}" + "\t\t{3}", noList[i], nameList[i], rentalTime, returnTime);
                }
                return login = false;
            }

            else // 로그인 안되어있는 상태
            {
                display.inputDisplay("로그인 상태가 아닙니다", 2);
                return login = true;
            }
        }

        public bool memberLogout() // 로그아웃 메소드
        {
            int j = 0;
            display.printDisplay("로그아웃에는 주민등록번호를 다시 입력하세요");

            while (Convert.ToString(memberManagement.residentNumberList[j]) != memberData.ResidentNumber) // 로그아웃 정확히 입력시 까지 반복
            {
                display.inputDisplay("입력", 1);
                memberData.ResidentNumber = display.hideResidentNumber(); // 주민등록번호 입력할때 *** 처리

                if (Convert.ToString(memberManagement.residentNumberList[j]) == memberData.ResidentNumber) // 처음 로그인 했을때 주민등록번호와 일치하면
                {
                    display.printDisplay("로그아웃 성공");
                    memberData.ResidentNumber = "";
                    return login = true;
                }
                else
                {
                    display.printDisplay("주민등록번호가 틀렸습니다");
                    return login = false;
                }
            }
            return login;
        }

        public void bookReturn(bool login) // 도서 반납 메소드
        {
            if (login == false)
            {
                while (menu != "1" && menu != "2" && menu != "3")
                {
                    display.returnDisplay();
                    display.inputDisplay("입력", 1);
                    menu = Console.ReadLine();

                    switch (menu)
                    {
                        case "1": // 도서 반납
                            if (nameList.Count == 0) // 대여한 책이 없으면
                            {
                                display.printDisplay("대여한 책이 없습니다");
                                bookReturn(login);
                                break;
                            }          

                            else if (nameList.Count > 0) // 대여한 책이 있으면
                            {
                                display.printDisplay("반납할 도서명");
                                display.inputDisplay("입력", 1);
                                bookData.BookName = Console.ReadLine();

                                for (int i = 0; i < nameList.Count; i++)
                                {
                                    if (Convert.ToString(nameList[i]) == bookData.BookName) // 대여목록에서 책이름이 같으면
                                    {
                                        num = Convert.ToInt32(bookManagement.bookQuantityList[bookNum]);
                                        ++num;
                                        bookManagement.bookQuantityList[bookNum] = num.ToString(); // 대여할때 저장했던 인덱스 bookNum의 수량을 증가
                                        noList.RemoveAt(i);
                                        nameList.RemoveAt(i); // 대여목록 값 제거
                                        quantityList.RemoveAt(i);
                                        display.inputDisplay("반납 완료", 2);
                                    }
                                    else if (Convert.ToString(nameList[i]) != bookData.BookName && i == 0) // 대여목록에서 책이름이 같지 않으면
                                    {
                                        display.inputDisplay("그런 도서는 대여 하지 않았습니다", 2);
                                    }
                                }
                            }
                            break;
                        case "2": // 기간 연장
                            if (nameList.Count == 0) // 대여한 책이 없으면
                            {
                                display.printDisplay("대여한 책이 없습니다");
                                bookReturn(login);
                                break;
                            }
                            else if (nameList.Count > 0) // 대여한 책이 있으면
                            {
                                display.printDisplay("기간을 연장할 도서명을 입력하세요 기간은 1주일입니다");
                                display.inputDisplay("입력", 1);
                                bookData.BookName = Console.ReadLine();

                                for (int i = 0; i < nameList.Count; i++)
                                {
                                    if (Convert.ToString(nameList[i]) == bookData.BookName && count == 0)
                                    {
                                        returnTime = Convert.ToString(localDate.AddDays(14)); // 7일 더 추가
                                        display.printDisplay("대여 기간이 연장되었습니다");
                                        count++;
                                    }
                                    else if (Convert.ToString(nameList[i]) == bookData.BookName && count > 0) // 기간 연장을 한번 했으면
                                    {
                                        display.inputDisplay("기간 연장은 한번 뿐입니다", 2);
                                        break;
                                    }
                                    else if (Convert.ToString(nameList[i]) != bookData.BookName) // 대여한 책이 없다면
                                    {
                                        display.inputDisplay("그런 도서는 대여하지 않았습니다", 2);
                                    }
                                }
                            }
                            break;
                        case "3": // 뒤로 가기
                            Console.Clear();
                            selecMenu.memberUse();
                            break;
                        default:
                            display.printDisplay("제대로 입력하세요");
                            break;
                    }
                }
                menu = "";
            }
            else
            {
                display.printDisplay("로그인 상태가 아닙니다");
            }
        }
    }
}