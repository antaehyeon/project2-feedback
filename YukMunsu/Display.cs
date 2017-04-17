using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 도서관리
{
    class Display
    {
        public Display() // 생성자
        {

        }

        public void initDisplay() // 프로그램 초기 화면
        {
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("             도서관리 프로그램");
            Console.WriteLine();
            Console.WriteLine("             1. 관리자 전용");
            Console.WriteLine("             2. 회원 전용");
            Console.WriteLine("             3. 프로그램 종료");
        }

        public void managerDisplay() // 관리자 전용 화면
        {
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("             관리자 전용");
            Console.WriteLine();
            Console.WriteLine("             1. 회원 관리");
            Console.WriteLine("             2. 도서 관리");
        }

        public void memberManagementDisplay() // 관리자 회원관리 화면
        {
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("             관리자 전용");
            Console.WriteLine();
            Console.WriteLine("             1. 회원 등록");
            Console.WriteLine("             2. 회원 수정");
            Console.WriteLine("             3. 회원 삭제");
            Console.WriteLine("             4. 회원 검색");
            Console.WriteLine("             5. 회원 출력");
            Console.WriteLine("             6. 뒤로 가기"); 
        }

        public void bookManagementDisplay() // 관리자 도서 관리 화면
        {
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("             관리자 전용");
            Console.WriteLine();
            Console.WriteLine("             1. 도서 등록");
            Console.WriteLine("             2. 도서 검색");
            Console.WriteLine("             3. 도서 출력");
            Console.WriteLine("             4. 도서 삭제");
            Console.WriteLine("             5. 도서 변경");
            Console.WriteLine("             6. 뒤로 가기");
        }

        public void memberInformation() // 회원 정보 화면
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("             ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("             |   이름   ㅣ  나이  ㅣ         주소          ㅣ    핸드폰번호   ㅣ    주민등록번호    ㅣ");
            Console.WriteLine("             ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
        }

        public void bookDisplay() // 도서 정보 화면
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("       ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("      ㅣ    번호    ㅣ             도서명            ㅣ       출판사       ㅣ     저자     ㅣ    가격    ㅣ   수량  ㅣ");
            Console.WriteLine("       ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
        }

        public void memberDisplay() // 회원 전용 화면
        {
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("             회원 전용");
            Console.WriteLine();
            Console.WriteLine("             1. 로그인");
            Console.WriteLine("             2. 도서 목록");
            Console.WriteLine("             3. 도서 대여");
            Console.WriteLine("             4. 도서 반납");
            Console.WriteLine("             5. 대여 목록");
            Console.WriteLine("             6. 로그 아웃");
            Console.WriteLine("             7. 뒤로 가기");
        }

        public void rentalDisplay() // 대여 정보 화면
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("       ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("      ㅣ    번호    ㅣ           도서명           ㅣ           대여날짜           ㅣ            반납기한            ㅣ");
            Console.WriteLine("       ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
        }

        public void bookPrint(object no, object name, object publisher, object author, object price, object quantity) // 도서 목록 화면
        {
            Console.WriteLine("\t{0}" + "\t\t{1}" + "\t\t{2}" + "\t\t{3}" + "\t\t{4}" + "\t\t{5}", no, name, publisher, author, price, quantity);
        }

        public void memberPrint(object name, object age, object address, object phone, object resident) // 회원 목록 화면
        {
            Console.Write("                {0}       {1}      {2}      {3}      {4}", name, age, address, phone, resident);
            Console.WriteLine();
        }

        public void inputDisplay(string str, int order) // 입력 화면 2가지
        {
            if (order == 1) // 개행 없이 바로 입력 받을때
            {
                Console.WriteLine();
                Console.Write("             {0} : ", str);
            }
            else if (order == 2) // 개행 있는 입력이나 알림멘트 일때
            {
                Console.WriteLine();
                Console.WriteLine("             {0}", str);
            }            
        }

        public void printDisplay(string str) // 화면 비움,개행,출력 메소드
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("             {0}", str);
        }

        public void returnDisplay() // 도서반납 화면
        {
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("             1. 도서 반납");
            Console.WriteLine("             2. 대출 연장");
            Console.WriteLine("             3. 뒤로 가기");
        }

        public string hideResidentNumber() // 주민등록번호 입력할때 *** 로 표시하는 메소드
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring(0, password.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return password;
        }
    }
}