using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 도서관리
{
    class SelectMenu
    {
        Display display;
        BookManagement bookManagement;
        MemberManagement memberManagement;
        Rental rental;
        public string input = "";
        public string inputNum = "";
        public string inputNumber = ""; // switch문 들어갈때 입력값
        public string manageNum = "";
        public string memberNum = "";
        bool login = true; // 로그인 변수

        public SelectMenu() // 생성자
        {
            display = new Display();
            bookManagement = new BookManagement(display);
            memberManagement = new MemberManagement(display);
            rental = new Rental(display, memberManagement, bookManagement, this);
        }

        public void selectMenu() // 메뉴 선택
        {
            Console.Clear();
            input = "";
            while (input != "1" && input != "2" && input != "3")
            {
                display.initDisplay(); // 초기화면 호출
                display.inputDisplay("입력", 1);
                input = Console.ReadLine();

                switch (input)
                {
                    case "1": // 관리자 전용
                        Console.Clear();
                        inputNum = "";
                        while (inputNum != "1" && inputNum != "2")
                        {
                            display.managerDisplay(); // 관리자 전용 화면
                            display.inputDisplay("입력", 1);
                            inputNum = Console.ReadLine();

                            switch (inputNum)
                            {
                                case "1": // 회원 관리
                                    Console.Clear();
                                    display.memberManagementDisplay(); // 회원관리 화면

                                    while (manageNum != "1" && manageNum != "2" && manageNum != "3" && manageNum != "4" && manageNum != "5" && manageNum != "6")
                                    {
                                        display.inputDisplay("입력", 1);
                                        manageNum = Console.ReadLine();

                                        switch (manageNum)
                                        {
                                            case "1":
                                                memberManagement.enrollmentMember(); // 회원등록 메소드
                                                display.memberManagementDisplay(); // 회원관리 화면
                                                break;
                                            case "2":
                                                memberManagement.updateMember(); // 회원수정 메소드
                                                display.memberManagementDisplay();
                                                break;
                                            case "3":
                                                memberManagement.deleteMember(); // 회원삭제 메소드
                                                display.memberManagementDisplay();
                                                break;
                                            case "4":
                                                memberManagement.searchMember(); // 회원검색 메소드
                                                display.memberManagementDisplay();
                                                break;
                                            case "5":
                                                display.memberInformation(); // 회원정보 화면
                                                memberManagement.printMember(); // 회원출력 메소드
                                                display.memberManagementDisplay();
                                                break;
                                            case "6":
                                                selectMenu(); // 뒤로 가기
                                                break;
                                            default:
                                                display.printDisplay("제대로 입력하세요");
                                                display.memberManagementDisplay();
                                                break;
                                        }
                                        manageNum = "";
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    display.bookManagementDisplay(); // 도서관리 화면

                                    while (memberNum != "1" && memberNum != "2" && memberNum != "3" && memberNum != "4" && memberNum != "5" && memberNum != "6")
                                    {
                                        display.inputDisplay("입력", 1);
                                        memberNum = Console.ReadLine();

                                        switch (memberNum)
                                        {
                                            case "1":
                                                Console.Clear();
                                                bookManagement.enrollmentBook(); // 도서 등록 메소드
                                                display.bookManagementDisplay(); // 이전 화면
                                                break;
                                            case "2":
                                                Console.Clear();
                                                bookManagement.searchBook(); // 도서 검색 메소드
                                                display.bookManagementDisplay();
                                                break;
                                            case "3":
                                                display.bookDisplay(); // 도서 정보 화면
                                                bookManagement.printBook(); // 도서 출력 메소드
                                                display.bookManagementDisplay();
                                                break;
                                            case "4":
                                                bookManagement.deleteBook(); // 도서 삭제 메소드
                                                display.bookManagementDisplay();
                                                break;
                                            case "5":
                                                bookManagement.updateBook(); // 도서 수정 메소드
                                                display.bookManagementDisplay();
                                                break;
                                            case "6": // 뒤로 가기
                                                selectMenu();
                                                break;
                                            default:
                                                display.printDisplay("제대로 입력");
                                                display.bookManagementDisplay();
                                                break;
                                        }
                                        memberNum = "";
                                    }
                                    break;
                                default:
                                    display.printDisplay("제대로 입력");
                                    break;
                            }
                        }
                        break;
                    case "2": // 회원 전용
                        Console.Clear();
                        memberUse(); // 회원 전용 메소드
                        break;
                    case "3":
                        break;
                    default:
                        display.printDisplay("제대로 입력");
                        break;
                }
            }
        }

        public void memberUse() // 회원 전용 사용가능한 기능 메소드
        {
            while (inputNumber != "1" && inputNumber != "2" && inputNumber != "3" && inputNumber != "4" && inputNumber != "5" && inputNumber != "6" && inputNumber != "7")
            {
                display.memberDisplay(); // 회원 전용 화면
                display.inputDisplay("입력", 1);
                inputNumber = Console.ReadLine();

                switch (inputNumber)
                {
                    case "1":
                        if (login) // 로그인 상태 아닐때
                        {
                            login = rental.memberLogin(); // 회원 로그인 메소드
                            memberUse(); // 이전 화면
                        }
                        else // 로그인 중복 예외처리
                        {
                            display.printDisplay("이미 로그인했습니다");
                            memberUse();
                        }
                        break;
                    case "2":
                        display.bookDisplay(); // 도서 정보 화면
                        rental.bookList(); // 도서목록 메소드
                        memberUse();
                        break;
                    case "3":
                        rental.bookRental(login); // 도서대여 메소드
                        memberUse();
                        break;
                    case "4":
                        Console.Clear();
                        rental.bookReturn(login); // 도서반납 메소드
                        memberUse();
                        break;
                    case "5":
                        if (!login)
                        {
                            display.rentalDisplay(); // 대여 정보 화면 메소드
                            login = rental.rentalList(); // 대여목록 메소드 호출
                            memberUse();
                        }
                        else
                        {
                            display.printDisplay("로그인 상태가 아닙니다");
                            memberUse(); // 비로그인 상태
                        }
                        break;
                    case "6":
                        if (!login) // 로그인 상태
                        {
                            login = rental.memberLogout(); // 로그아웃 메소드
                            memberUse();
                        }
                        else // 로그인 상태 아니면
                        {
                            display.printDisplay("로그인 상태가 아닙니다");
                            memberUse();
                        }
                        break;
                    case "7":
                        selectMenu();
                        break;
                    default:
                        display.printDisplay("제대로 입력");
                        break;
                }
            }
            inputNumber = "";
        }
    }
}
