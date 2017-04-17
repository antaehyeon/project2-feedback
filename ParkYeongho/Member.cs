using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Member
    {
        private MainPage mainPage;
        private Display display;
        private Exception exception;
        public Member() {
            mainPage = new MainPage();
            display = new Display();
            exception = new Exception();
        }
        public Member(MainPage aMainPage, Display aDisplay, Exception aException)
        {
            this.mainPage = aMainPage;
            this.display = aDisplay;
            this.exception = aException;
        }
        public void RunMemberPage(ArrayList memberArrayList, ArrayList bookArrayList)
        {
            string memberPageInput = Console.ReadLine();                                    // '회원 관리'에서 메뉴 선택 입력 받기
            
            switch(memberPageInput)
            {
                case "1": RegisterMember(memberArrayList, bookArrayList);break;             // 1번 입력 시 '회원 등록'으로 이동
                case "2": ModifyMemberFirstStep(memberArrayList, bookArrayList);break;      // 2번 입력 시 '회원 수정'으로 이동
                case "3": DeleteMember(memberArrayList, bookArrayList);break;               // 3번 입력 시 '회원 삭제'로 이동
                case "4": SelectMember(memberArrayList, bookArrayList);break;               // 4번 입력 시 '회원 검색'으로 이동
                case "5": PrintMemberList(memberArrayList, bookArrayList);break;            // 5번 입력 시 '회원 출력'으로 이동
                case "6": display.PrintMainPage();                                          // 6번 입력 시 메인 메뉴로 이동
                          mainPage.RunMainPage(memberArrayList, bookArrayList);
                          break;
                default:  Console.SetCursorPosition(104, 22);
                          Console.WriteLine("잘못된 입력");                                 // 지정된 번호 이외의 입력이 들어왔을 때  
                          System.Threading.Thread.Sleep(1000);
                          display.PrintMemberPage();
                          RunMemberPage(memberArrayList, bookArrayList);
                          break; 
            }
        }

        public void RegisterMember(ArrayList memberArrayList, ArrayList bookArrayList)      // '회원 등록' 기능 실행
        {
            Console.Clear();
            MemberVO memberVO = new MemberVO();
            display.PrintMemberRegisterOrModify("등", "록");                                // '회원 등록'창 출력
            Console.SetCursorPosition(54, 9);                                               // 커서 위치를 아이디 입력란으로 이동
            memberVO.MemberID = "";
            memberVO.MemberID = exception.EnglishOrNumberInput(memberArrayList, bookArrayList, memberVO.MemberID, "등", "록");    // 회원 아이디 입력이 영문자 혹은 숫자인지 확인하고 값 저장
            Console.SetCursorPosition(54, 11);                                              // 커서 위치를 비밀번호 입력란으로 이동
            memberVO.MemberPSW = "";
            memberVO.MemberPSW = exception.PasswordInput(memberVO.MemberPSW);               // 회원 비밀번호 입력이 영문자 혹은 숫자인지 확인 및 비밀번호를 *로 표기
            Console.SetCursorPosition(54, 13);
            memberVO.MemberName = "";
            memberVO.MemberName = exception.KoreanInput(memberVO.MemberName);
            Console.SetCursorPosition(54, 15);
            memberVO.MemberPhone = exception.PhoneNumberInput(memberVO.MemberPhone);        // 연락처 입력이 숫자인지 확인하고 값 저장
            memberArrayList.Add(memberVO);                                                  // 회원 정보를 ArrayList에 추가
            display.Outline();
            Console.SetCursorPosition(45, 11);
            Console.Write("회원 등록을 완료했습니다.");
            System.Threading.Thread.Sleep(2000);
            display.PrintMemberPage();                                                      // 회원 등록을 완료하고 '회원 관리' 페이지로 이동
            RunMemberPage(memberArrayList, bookArrayList);
        }

        public void ModifyMemberFirstStep(ArrayList memberArrayList, ArrayList bookArrayList)   // '회원 수정' 기능 첫 단계 실행
        {
            display.Outline();                                                                  // 기본 네모 틀 출력
            Console.SetCursorPosition(30, 11);
            Console.Write("수정할 회원의 아이디를 입력하세요. : ");
            string modifyMemberID = "";
            modifyMemberID = exception.EnglishOrNumberInput(memberArrayList, bookArrayList, modifyMemberID, " ", " ");  // 수정할 회원 정보의 아이디가 영문자 혹은 숫자인지 확인
            ModifyMemberSecondStep(memberArrayList, bookArrayList, modifyMemberID);             // '회원 수정' 두 번째 단계로 이동
        }

        public void ModifyMemberSecondStep(ArrayList memberArrayList, ArrayList bookArrayList, string modifyMemberID) { // '회원 수정' 기능 두 번째 단계 실행
            MemberVO memberVO = new MemberVO();
            foreach (MemberVO memberList in memberArrayList)                                    // 수정할 회원 정보의 아이디가 등록된 회원 아이디 중 같은 것이 있는지 확인
            {
                if (memberList.MemberID == modifyMemberID)
                {
                    string modifyMemberName = memberList.MemberName;
                    display.PrintMemberRegisterOrModify("수", "정");                            // '회원 수정' 정보를 입력하는 페이지 출력
                    Console.SetCursorPosition(54, 9);
                    memberList.MemberID = exception.EnglishOrNumberInput(memberArrayList, bookArrayList, modifyMemberID, "수", "정"); // 수정할 회원 아이디가 영문자 혹은 숫자인지 그리고 이미 등록된 다른 사람의 아이디는 아닌지 확인
                    Console.SetCursorPosition(54, 11);
                    memberList.MemberPSW = exception.PasswordInput(memberVO.MemberPSW);         // 비밀번호가 영문자 혹은 숫자인지 그리고 글자 수가 4~12자인지 확인
                    Console.SetCursorPosition(54, 13);
                    memberList.MemberName = exception.KoreanInput(memberVO.MemberName);         // 이름이 한글로 입력됐는지 확인
                    Console.SetCursorPosition(54, 15);
                    memberList.MemberPhone = exception.PhoneNumberInput(memberVO.MemberPhone);  // 연락처 입력이 번호인지 확인
                    display.Outline();                                                          // 기본 네모 틀 출력
                    Console.SetCursorPosition(45, 11);
                    Console.Write("회원 정보가 수정되었습니다.");
                    System.Threading.Thread.Sleep(2000);
                    display.PrintMemberPage();                                                  // 회원 수정을 완료하고 회원 관리 페이지로 이동
                    RunMemberPage(memberArrayList, bookArrayList);
                    break;
                }
            }
            display.Outline();                                                                  // 수정할 회원 아이디를 찾을 수 없는 경우
            Console.SetCursorPosition(45, 11);
            Console.Write(modifyMemberID + "님을 찾을 수 없습니다.");
            System.Threading.Thread.Sleep(2000);
            display.PrintMemberPage();                                                          // 회원 관리 페이지로 이동
            RunMemberPage(memberArrayList, bookArrayList);
        }

        public void DeleteMember(ArrayList memberArrayList, ArrayList bookArrayList)            // '회원 삭제' 기능 실행
        {
            display.Outline();                                                                  // 기본 네모 틀 출력
            Console.SetCursorPosition(30, 11);
            Console.Write("삭제할 회원의 아이디를 입력하세요 : ");
            string deletedMemberName = "";
            string deleteMemberID = "";
            deleteMemberID = exception.EnglishOrNumberInput(memberArrayList, bookArrayList, deleteMemberID, "삭", "제");  // 삭제할 회원 아이디 입력값이 영문자 혹은 숫자인지 확인 및 값 저장
            foreach(MemberVO memberList in memberArrayList)
            {
                if(memberList.MemberID == deleteMemberID)                                       // 삭제할 회원 아이디가 이미 등록된 회원 아이디 중 같은 것이 있는 경우 해당 회원 정보 삭제
                {
                    deletedMemberName = memberList.MemberName;
                    memberArrayList.Remove(memberList);
                    display.Outline();
                    Console.SetCursorPosition(41, 11);
                    Console.Write(deletedMemberName + "님의 회원 정보가 삭제되었습니다.");
                    System.Threading.Thread.Sleep(2000);
                    display.PrintMemberPage();
                    RunMemberPage(memberArrayList, bookArrayList);
                    return;
                }
            }
            display.Outline();                                                                  // 삭제할 회원의 아이디를 찾을 수 없는 경우
            Console.SetCursorPosition(41, 11);
            Console.Write(deleteMemberID + "님을 찾을 수 없습니다.");
            System.Threading.Thread.Sleep(2000);
            display.PrintMemberPage();                                                          // 회원 관리 페이지로 이동
            RunMemberPage(memberArrayList, bookArrayList);

        }

        public void SelectMember(ArrayList memberArrayList, ArrayList bookArrayList)            // '회원 검색' 기능 실행
        {
            display.Outline();
            Console.SetCursorPosition(30, 11);
            Console.Write("검색할 회원의 아이디를 입력하세요. : ");
            string selectMemberID = "";
            selectMemberID = exception.EnglishOrNumberInput(memberArrayList, bookArrayList, selectMemberID, "검", "색");  // 검색할 회원의 아이디 입력값이 영문자 혹은 숫자인지 확인 및 값 저장
            foreach(MemberVO memberList in memberArrayList)
            {
                if(memberList.MemberID == selectMemberID)                                       // 검색할 회원의 아이디와 이미 등록된 회원의 아이디 중 같은 것이 있는 경우
                {
                    display.MemberUpperOutline();
                    Console.SetCursorPosition(15, 5);
                    Console.Write(memberList.MemberID);
                    Console.SetCursorPosition(38, 5);
                    Console.Write(memberList.MemberPSW);
                    Console.SetCursorPosition(64, 5);
                    Console.Write(memberList.MemberName);
                    Console.SetCursorPosition(88, 5);
                    Console.Write(memberList.MemberPhone);                                                           // row 값을 1씩 증가시켜 다음 행에 커서가 위치하도록 해서 차례로 다음 행에 memberList 출력
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("뒤로 가려면 'q'를 입력하세요.");
                    ConsoleKeyInfo key;
                    while (true)
                    {
                        key = Console.ReadKey(true);                                                       // 입력값의 ConsoleKey가 'q' 혹은 'ㅂ'이면 회원 관리 페이지로 이동
                        if (key.KeyChar == 'q' || key.KeyChar == 'ㅂ')
                        {
                            display.PrintMemberPage();
                            RunMemberPage(memberArrayList, bookArrayList);
                            break;
                        }
                        else
                        {
                            Console.Write("");
                        }
                    }
                    return;
                }
            }
            display.Outline();                                                                  // 검색할 회원의 아이디가 이미 등록된 회원의 아이디 중 일치하는 값이 없는 경우
            Console.SetCursorPosition(40, 11);
            Console.WriteLine(selectMemberID + "님을 찾을 수 없습니다.");
            System.Threading.Thread.Sleep(2000);
            display.PrintMemberPage();                                                          // 회원 관리 페이지로 이동
            RunMemberPage(memberArrayList, bookArrayList);

        }

        public void PrintMemberList(ArrayList memberArrayList, ArrayList bookArrayList)         // '회원 출력' 기능 실행
        {
            display.MemberUpperOutline();
            int row = 5;                                                                        // 회원 출력하는 첫 번째  memberList 위치의 행의 값을 저장
            foreach(MemberVO memberList in memberArrayList)                                     // memberArrayList에 있는 모든 회원 정보를 출력
            {
                Console.SetCursorPosition(15, row);
                Console.Write(memberList.MemberID);
                Console.SetCursorPosition(38, row);
                Console.Write(memberList.MemberPSW);
                Console.SetCursorPosition(64, row);
                Console.Write(memberList.MemberName);
                Console.SetCursorPosition(88, row);
                Console.Write(memberList.MemberPhone);
                row = row + 2;                                                                  // row 값을 1씩 증가시켜 다음 행에 커서가 위치하도록 해서 차례로 다음 행에 memberList 출력
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("뒤로 가려면 'q'를 입력하세요."); 
            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey(true);                                                    // 입력값의 ConsoleKey가 'q' 혹은 'ㅂ'이면 회원 관리 페이지로 이동
                if (key.KeyChar == 'q' || key.KeyChar == 'ㅂ')
                {
                    display.PrintMemberPage();
                    RunMemberPage(memberArrayList, bookArrayList);
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
