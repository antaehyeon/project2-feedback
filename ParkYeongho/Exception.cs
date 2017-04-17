using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Exception
    {
        public string EnglishOrNumberInput(ArrayList memberArrayList, ArrayList bookArrayList, string idBeforeModify, string menuInfoFirstLetter, string menuInfoSecondLetter)  // 영문자 혹은 숫자 입력 확인
        {
            ConsoleKeyInfo key;
            string content = "";
            while (true)
            {
                key = Console.ReadKey(true);                                                                            // ConsoleKey를 입력 받는다

                if ((key.KeyChar >= 48 && key.KeyChar <= 57) || (key.KeyChar >= 65 && key.KeyChar <= 90) || (key.KeyChar >= 94 && key.KeyChar <= 95) || (key.KeyChar >= 97 && key.KeyChar <= 122))  // 입력 받은 콘솔키가 영문자 혹은 숫자인지 확인
                {
                    content += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
                else if (key.Key == ConsoleKey.Backspace && content.Length > 0)                                         // Backspace키를 입력 받고 string의 길이가 0보다 크면 string을 한 자리 삭제
                {
                    content = content.Substring(0, (content.Length - 1));
                    Console.Write("\b \b");                                                                             // 출력을 한 자리 지우고 커서 위치를 한 자리 뒤로 이동
                }
                else if (key.Key == ConsoleKey.Enter)                                                                   // Enter 키를 입력 받은 경우
                {
                    Console.Write("");
                    if (content.Length >= 4 && content.Length <= 12)                                                    // string의 길이가 4이상 12이하인 경우
                    {
                        if (menuInfoFirstLetter == "등") IsIDOverlaped(memberArrayList, bookArrayList, content, " ", menuInfoFirstLetter, menuInfoSecondLetter); // 등록 메뉴에서 실행된 경우 string이 다른 아이디와 중복인지 확인
                        else if (menuInfoFirstLetter == "수") { if (content != idBeforeModify) { IsIDOverlaped(memberArrayList, bookArrayList, content, idBeforeModify, menuInfoFirstLetter, menuInfoSecondLetter); } } // 수정 메뉴에서 실행되고 입력값이 수정전 아이디와 같지 않고 다른 아이디와 중복인지 확인
                        break;
                    }
                } else if(key.Key == ConsoleKey.Backspace && content.Length == 0)                                       // Backspace를 입력 받고 string의 길이가 0인 경우
                {
                    Console.Write("");
                }
                else                                                                                                    // 입력값이 영문자 혹은 숫자가 아닌 경우
                {
                    content = "";
                    if(menuInfoFirstLetter == "등" || menuInfoFirstLetter == "수")                                      // 등록 메뉴 혹은 수정 메뉴에서 실행한 경우
                    {
                        Console.SetCursorPosition(54, 9);                                                               // 아이디를 입력하는 부분에 "잘못된 입력" 출력
                        Console.Write("잘못된 입력");
                        System.Threading.Thread.Sleep(700);
                        Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b                \b\b\b\b\b\b\b\b\b\b\b\b\b");        // "잘못된 입력" 메세지를 지우고 커서 위치를 이동
                    } else                                                                                              // 등록 메뉴 그리고 수정 메뉴에서 실행하지 않은 경우
                    {
                        Console.SetCursorPosition(68, 11);
                        Console.Write("잘못된 입력");
                        System.Threading.Thread.Sleep(700);
                        Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b                \b\b\b\b\b\b\b\b\b\b\b\b\b");
                    }
                }
            }

            return content;
        }

        public string PasswordInput(string content)                                                                     // 패스워드 입력 시 영문자 혹은 숫자인지 확인하고 '*' 표시로 출력
        {
            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(true);

                if ((key.KeyChar >= 48 && key.KeyChar <= 57) || (key.KeyChar >= 65 && key.KeyChar <= 90) || (key.KeyChar >= 94 && key.KeyChar <= 95) || (key.KeyChar >= 97 && key.KeyChar <= 122))  // 콘솔키가 영문자 혹은 숫자인지 확인
                {
                    content += key.KeyChar;
                    Console.Write("*");                                                                                 // 입력값이 영문자 혹은 숫자라면 '*'로 표시
                }
                else if (key.Key == ConsoleKey.Backspace && content.Length > 0)                                         // 콘솔키가 Backspace이고 string 길이가 0보다 큰 경우
                {
                    content = content.Substring(0, (content.Length - 1));                                               // string 한 자리 값을 삭제
                    Console.Write("\b \b");
                }
                else if (key.Key == ConsoleKey.Enter)                                                                   // Enter키를 입력 받은 경우
                {
                    Console.Write("");
                    if (content.Length >= 4 && content.Length <= 12)                                                    // string의 길이가 4이상 12이하인 경우
                    {
                        break;
                    }
                }
            }

            return content;
        }

        public string KoreanInput(string content)                                                                       // 입력이 한글인지 확인
        {
            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(true);

                if (key.KeyChar >= 12644 && key.KeyChar <= 55203)                                                       // KeyChar값이 한글 KeyChar값인 경우
                {
                    content += key.KeyChar;                                                                             // string에 콘솔키를 추가
                    Console.Write(key.KeyChar);                                                                         // 입력 받은 콘솔키를 출력
                }
                else if (key.Key == ConsoleKey.Backspace && content.Length > 0)                                         // 입력 받은 콘솔키가 Backspace이고 string의 길이가 0보다 큰 경우
                {
                    content = content.Substring(0, (content.Length - 1));                                               // string의 끝 부분 한 자리를 삭제
                    Console.Write("\b\b  \b\b");                                                                        // 커서를 한 자리 제거한 위치로 이동

                }
                else if (key.Key == ConsoleKey.Enter)                                                                   // 입력이 Enter키인 경우
                {
                    Console.Write("");
                    if (content.Length >= 2 && content.Length <= 15)                                                    // string의 길이가 2이상 15이하인 경우 break
                    {
                        break;
                    }
                }
            }

            return content;
        }

        public string PhoneNumberInput(string content)                                                                  // 연락처 입력 시 입력값이 숫자인지 확인
        {
            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(true);
                if (key.KeyChar >= 48 && key.KeyChar <= 57)                                                             // 입력값이 숫자 KeyChar 값에 포함되는 경우
                {
                    content += key.KeyChar;                                                                             // stirng에 입력값을 추가
                    Console.Write(key.KeyChar);                                                                         // 입력받은 콘솔키를 화면에 출력
                }
                else if (key.Key == ConsoleKey.Backspace && content.Length > 0)                                         // Backspace키를 입력 받고 string의 길이가 0보다 큰 경우
                {
                    content = content.Substring(0, (content.Length - 1));                                               // string의 끝 부분 한 자리를 삭제
                    Console.Write("\b \b");
                }
                else if (key.Key == ConsoleKey.Enter)                                                                   // 콘솔키가 Enter인 경우
                {
                    Console.Write("");
                    if (content.Length >= 9 && content.Length <= 12)                                                    // string의 길이가 4이상 12이하이면 break;
                    {
                        break;
                    }
                } else if(key.Key == ConsoleKey.Backspace && content.Length <= 0)                                       // Backspace를 입력 받고 string의 길이가 0인 경우
                {
                    Console.Write("");
                }
            }
            return content;
        }

        public string NumberInput(string content)                                                                       // 입력값이 숫자인지 확인
        {
            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(true);
                if (key.KeyChar >= 48 && key.KeyChar <= 57)                                                             // 입력받은 콘솔키가 숫자 KeyChar에 포함되는 경우
                {
                    content += key.KeyChar;                                                                             // string에 입력값을 추가
                    Console.Write(key.KeyChar);                                                                         // 콘솔창에 콘솔키 출력
                }
                else if (key.Key == ConsoleKey.Backspace && content.Length > 0)                                         // 입력받은 콘솔키가 Backspace이고 string의 길이가 0보다 큰 경우
                {
                    content = content.Substring(0, (content.Length - 1));                                               // string의 끝 부분 한 자리를 삭제
                    Console.Write("\b \b");
                }
                else if (key.Key == ConsoleKey.Enter)                                                                   // 입력 받은 콘솔키가 Enter인 경우
                {
                    Console.Write("");
                    if (content.Length >= 1 && content.Length <= 12)                                                    // string의 길이가 1이상 12이하인 경우 break
                    {
                        break;
                    }
                } else if(key.Key == ConsoleKey.Backspace && content.Length == 0)                                       // 입력 받은 콘솔키가 Backspace이고 string의 길이가 0인 경우
                {
                    Console.Write("");
                }
            }
            return content;
        }
        
        public string EnglishOrKoreanOrNumberInput(string content)                                                      // 입력값이 영문자 혹은 한글 숫자인지 확인
        {
            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(true);

                if ((key.KeyChar >= 33 && key.KeyChar <= 57) || (key.KeyChar >= 64 && key.KeyChar <= 126) || (key.KeyChar >= 12593 && key.KeyChar <= 55203) || key.Key == ConsoleKey.Spacebar)  // 입력값의 KeyChar가 영문자 혹은 한글 혹은 숫자 혹은 공백 KeyChar값고 일치하는지 확인
                {
                    content += key.KeyChar;                                                                             // string에 입력값 추가
                    Console.Write(key.KeyChar);                                                                         // 콘솔창에 입력값 출력
                }
                else if (key.Key == ConsoleKey.Backspace && content.Length > 0)                                         // 입력받은 콘솔키가 Backspace이고 string의 길이가 0보다 큰 경우
                {
                    if(content.Last<char>() >= 12593 && content.Last<char>() <= 55203) {                                // string의 마지막 char가 한글인 경우
                        content = content.Substring(0, (content.Length - 1));                                           // string 끝 부분 한 자리 삭제
                        Console.Write("\b\b  \b\b");                                                                    // Backspace 두 번 공백 두 번 다시 Backspace 두 번으로 한글 입력을 지우고 커서 위치를 한 자리 전으로 이동
                    }
                    else                                                                                                // string의 마지막 char가 한글이 아닌 경우
                    {
                        content = content.Substring(0, (content.Length - 1));                                           // string의 끝 부분 한 자리 삭제
                        Console.Write("\b \b");
                    }

                }
                else if (key.Key == ConsoleKey.Enter)                                                                   // 입력값이 Enter키인 경우
                {
                    Console.Write("");
                    if (content.Length >= 1 && content.Length <= 12)                                                    // string의 길이가 1이상 12이하이면 break
                    {
                        break;
                    }
                }
            }
            return content;
        }

        
        public void IsIDOverlaped(ArrayList memberArrayList, ArrayList bookArrayList, string memberID, string idBeforeModify, string menuInfoFirstLetter, string menuInfoSecondLetter) // 회원 아이디가 중복됐는지 확인
        {
            foreach(MemberVO memberList in memberArrayList)
            {
                if(memberList.MemberID == memberID)                                                                     // 넘겨 받은 memberID와 이미 등록된 회원의 아이디 중 일치하는 값이 있는 경우
                {
                    Console.Clear();
                    Display display = new Display();
                    Member member = new Member();
                    display.PrintMemberRegisterOrModify(menuInfoFirstLetter, menuInfoSecondLetter);                     // 회원 등록 또는 회원 수정 페이지 출력
                    Console.SetCursorPosition(50, 9);
                    Console.Write("이미 등록된 아이디");
                    System.Threading.Thread.Sleep(1000);
                    display.PrintMemberRegisterOrModify(menuInfoFirstLetter, menuInfoSecondLetter);                     // 회원 등록 또는 회원 수정 페이지 출력
                    if (menuInfoFirstLetter == "등") member.RegisterMember(memberArrayList, bookArrayList);             // 회원 등록 메뉴에서 넘어 온 경우 회원 등록 페이지 실행
                    else member.ModifyMemberSecondStep(memberArrayList, bookArrayList, idBeforeModify);                 // 회원 수정 메뉴에서 넘어 온 경우 회원 수정 페이지 실행
                }
            }
        }
    }
}
