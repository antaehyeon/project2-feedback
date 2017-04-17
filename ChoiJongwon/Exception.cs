using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManamement
{
    class Exception
    {
        // Data
        private string str;          // 임시적으로 문자열을 저장하는 변수
        private int value;    // 임시적으로 정수를 저장하는 변수
        private bool judge;          // 예외처리조건을 만족하는지를 참 거짓으로 저장
        private UserMenu userMenu;   // UserMenu클래스의 데이터나 메소드에 접근하기 위해 객체 선언

        // Constructor
        public Exception() { }
        public Exception(UserMenu u)
        {
            userMenu = u;
        }

        // Other Method
        public void keyEnterInput()      // Enter키만을 입력으로 받아들이는 함수
        {
            Console.WriteLine();
            Console.Write("    돌아가시려면 Enter키를 누르세요.");

            str = Console.ReadLine();

            while ((string.Equals(str, "") == false))
            {
                Console.Write("   Wrong Input, Try Again >> ");
                str = Console.ReadLine();
            }           
        }

        public int keyIntInput(int min, int max)  // 범위 min<= x <= max의 정수만을 입력받아 리턴하는 함수
        {
            str = Console.ReadLine();
            while ((!int.TryParse(str, out value)) || (value < min || value > max))  // 입력받은 값을 parsing했을 때 정수가 아니고 지정된 범위가 넘어가면 무한반복
            {
                Console.Write("   Wrong Input, Try Again >> ");
                str = Console.ReadLine();
            }

            value = int.Parse(str);

            return value;
        }

        public string keyPWInput()  // 회원정보입력에 명시된 내용만으로 회원의 비밀번호를 받아 리턴하는 함수
        {
            do
            {
                str = Console.ReadLine();
                judge = true;

                for (int i = 0; i < str.Length; i++)
                    if (str[i] < 48 || (str[i] > 57 && str[i] < 65) || (str[i] > 90 && str[i] < 97) || str[i] > 122) { judge = false; }
                // 아스키 코드값을 참고하여 각 자리의 문자가 영대소문자, 숫자가 아닌 값은 모두 거짓

                if (str.Length < 8 || str.Length > 16 || str.Contains(" ")) //  8~16 자리가 아니거나 빈칸이 포함됐다면 거짓
                    judge = false;

                if (judge == false) { Console.Write("   Wrong Input, Try Again >> "); }

            } while (judge == false);

            return str;
        }

        public string keyNameInput(int mode)  // 회원의 이름이나 도서의 이름을 한글로만 입력받아 리턴하는 함수, 인자 mode는 입력받을 값이 도서의 이름인지 회원 이름인지 구분하여 준다.
        {
            char[] charArr;
            do
            {
                judge = true;
                str = Console.ReadLine();
                charArr = str.ToCharArray();

                if (mode == Constant.USERNAME)   // 회원의 이름을 입력받는다면 
                {
                    if (str.Length < 2 || str.Length > 5 || str.Contains(" "))  
                        judge = false;

                    foreach (char c in charArr)
                    {
                        if (char.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.OtherLetter)  //  회원정보에 명시된대로 2~5자리 한글을 제외하고 모두 거짓
                            judge = false;
                    }

                }
                else if(mode == Constant.BOOKNAME)  // 도서의 이름을 입력받는다면
                {
                    if (str.Length < 1 || str.Length > 12 || str.Contains(" "))
                        judge = false;

                    foreach (char c in charArr)
                    {
                        if (char.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.OtherLetter && c<48 && c>57) // 도서의 이름은 2~5자리 밖일 수 있고 1~12자리 한글과 숫자로 제한
                            judge = false;
                    }
                }

                if (judge == false) { Console.Write("   Wrong Input, Try Again >> "); }

            } while (judge == false);
            
            return str;
        }

        public string keyIDInput() // 회원정보입력에 명시된 내용만으로 회원아이디를 입력받아 리턴하는 함수 (로그인시 사용)
        {
            do
            {
                str = Console.ReadLine();
                judge = true;

                for (int i = 0; i < str.Length; i++)
                    if (str[i] < 48 || (str[i] > 57 && str[i] < 97) || str[i] > 122) { judge = false; }  // 


                if (str.Length < 5 || str.Length > 12 || str.Contains(" "))
                    judge = false;

                if (judge == false) { Console.Write("   Wrong Input, Try Again >> "); }

            } while (judge == false);

            return str;
        }

        public string keyIDInput(List<User> userList) // 회원정보 List를 인자로 받아 회원정보입력에 명시된 내용과 중복아이디가 있는지 확인하여 회원아이디를 입력받아 리턴하는 함수 (회원가입시 사용)
        {
            do
            {
                str = Console.ReadLine();
                judge = true;
                value = 0;

                for (int i = 0; i < userList.Count(); i++)             // 동일한 ID가 있다면 value증가
                    if (str == userList[i].UserID) { value++; }

                for (int i = 0; i < str.Length; i++)
                    if (str[i] < 48 || (str[i] > 57 && str[i] < 97) || str[i] > 122) { judge = false; }  // 아스키 코드값을 참고하여 문자열의 각 문자가 영소문, 숫자가 아니라면 거짓


                if (str.Length < 5 || str.Length > 12 || str.Contains(" ")) // 5~12자리가 아니거나 공백을 포함하고 있다면 거짓
                    judge = false;

                if (value != 0)  // 동일한 ID가 있다면 거짓
                {
                    judge = false;
                }

                if (judge == false) { Console.Write("   Wrong Input, Try Again >> "); }
                else if (judge == false && value !=0) { Console.Write("   이미 가입된 ID입니다 >> "); }

            } while (judge == false);

            return str;
        }

        public string keyAskingInput()  // y나 n의 값만을 입력으로 받아들여 리턴하는 함수 (콘솔화면 질문시 사용)
        {
            str = Console.ReadLine();
            while (string.Equals(str, "Y") == false && string.Equals(str, "y") == false && string.Equals(str, "N") == false && string.Equals(str, "n") == false)
            {
                Console.Write("   Wrong Input, Try Again >> ");
                str = Console.ReadLine();
            }

            return str;
        }

        public int keyPriceInput()  // 최소단위 10원으로 100원부터 10만원까지 도서의 가격을 입력받아 리턴하는 함수
        {
            value = keyIntInput(100, 100000);

            while ((value % 10) != 0)
                value = keyIntInput(100, 100000);

            return value;
        }

        public string keyCallInput() // 0으로 시작하는 9~11자리 숫자로만 구성된 연락처를 리턴하는 함수
        {
            do
            {
                judge = true;
                str = Console.ReadLine();

                for (int i = 0; i < str.Length; i++)
                    if (str[i] < 48 || str[i] > 57) { judge = false; }

                if(str.Length < 9 || str.Length >11 || (int.Parse(str.Substring(0,1)) != 0)) { judge = false; }

                if (judge == false) { Console.Write("   Wrong Input, Try Again >> "); }
                

            } while (judge == false);

            return str;
        }               
    }
}
