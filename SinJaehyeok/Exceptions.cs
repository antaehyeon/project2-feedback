using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensharp_study_assignment2_1v
{
    class Exceptions
    {
        //입력받은 문자열이 정수로 변환 가능한지 판단. 입력받은 문자열이 정수인지 아닌지 판단
        public bool IsNumeric(string NumberString)
        {
            foreach (char i in NumberString)
                if (Char.IsNumber(i) == false)
                    return false;
            return true;
        }
        //start에서 end까지의 범위 내의 정수 값만 입력받을 수 있게 설정
        //정수값 범위를 벗어나거나 01,02와 같은 값들도 다시 입력받게 설정
        //스페이스바 및 아무 값 입력하지 않은 상태에서의 엔터입력도 다시 입력받음
        public int CheckNumberInput(int start, int end)
        {
            string InputNumber;

            while (true)
            {
                int cnt = 0;

                InputNumber = Console.ReadLine();
                foreach (char i in InputNumber)
                    cnt++;
                while (InputNumber == "" || InputNumber[0] == ' ' || IsNumeric(InputNumber) == false || cnt > 1)
                {
                    Console.Write("Input again : ");
                    InputNumber = Console.ReadLine();
                    cnt = 0;
                    foreach (char i in InputNumber)
                        cnt++;
                }
                if (Convert.ToInt32(InputNumber) >= start && Convert.ToInt32(InputNumber) <= end)
                {
                    return Convert.ToInt32(InputNumber);
                }
                Console.Write("Input again : ");
            }
        }
        //책의 수량을 받을 수 있는 범위 설정 1권부터 99권까지 책의 수량을 설정할 수 있음
        public int CheckQuantityInput(int start, int end)
        {
            string InputNumber;

            while (true)
            {
                int cnt = 0;

                InputNumber = Console.ReadLine();
                foreach (char i in InputNumber)
                    cnt++;
                while (InputNumber == "" || InputNumber[0] == ' ' || IsNumeric(InputNumber) == false || cnt > 3)
                {
                    Console.Write("Input again : ");
                    InputNumber = Console.ReadLine();
                    cnt = 0;
                    foreach (char i in InputNumber)
                        cnt++;
                }
                if (Convert.ToInt32(InputNumber) >= start && Convert.ToInt32(InputNumber) <= end)
                {
                    return Convert.ToInt32(InputNumber);
                }
                Console.Write("Input again : ");
            }
        }
        //가격을 입력받는 범위 설정. $1000부터 $100000까지 입력 가능
        public int CheckPriceInput()
        {
            string InputNumber;

            while (true)
            {
                int cnt = 0;

                InputNumber = Console.ReadLine();
                foreach (char i in InputNumber)
                    cnt++;
                while (InputNumber == "" || InputNumber[0] == ' ' || IsNumeric(InputNumber) == false || cnt > 6)
                {
                    Console.Write("Input again : ");
                    InputNumber = Console.ReadLine();
                    cnt = 0;
                    foreach (char i in InputNumber)
                        cnt++;
                }
                if (Convert.ToInt32(InputNumber) >= 1000 && Convert.ToInt32(InputNumber) <= 100000)
                {
                    return Convert.ToInt32(InputNumber);
                }
                Console.Write("Input again : ");
            }
        }
        //도서정보(도서명과 저자)를 입력받음. 스페이스바 및 아무 것도 입력하지 않은 상태의 엔터는 다시 입력받음
        public string CheckNameInput()
        {
            string InputName;

            InputName = Console.ReadLine();

            while (InputName == "" || InputName[0] == ' ')
            {
                Console.WriteLine("Input again : ");
                InputName = Console.ReadLine();
            }
            return InputName;
        }
        //회원 이름 입력을 받음. 이름 내 특수문자나 숫자가 포함되면 다시 입력받음
        public string CheckMemberNameInput()
        {
            string InputName;
            int CntNumber = 0;
            int CntSpecialLetter = 0;

            InputName = Console.ReadLine();
            foreach (char i in InputName)
            {
                if (Char.IsNumber(i))
                    CntNumber++;
            }
            foreach (char i in InputName)
            {
                if (!Char.IsLetter(i))
                    CntSpecialLetter++;
            }
            while (InputName == "" || InputName[0] == ' ' || CntNumber > 0 || CntSpecialLetter > 0)
            {
                Console.WriteLine("Input again : ");
                InputName = Console.ReadLine();
                CntNumber = 0;
                CntSpecialLetter = 0;
                foreach (char i in InputName)
                {
                    if (Char.IsNumber(i))
                        CntNumber++;
                }
                foreach (char i in InputName)
                {
                    if (!Char.IsLetter(i))
                        CntSpecialLetter++;
                }
            }
            return InputName;
        }
        //ID를 입력받음. 아이디 설정 시 20자리 이하로 생성해야함
        public string CheckIdInput()
        {
            string InputId;
            int cnt = 0;

            InputId = Console.ReadLine();
            foreach (char i in InputId)
                cnt++;
            while (InputId == "" || InputId[0] == ' ' || cnt > 20)
            {
                Console.WriteLine("Input again : ");
                InputId = Console.ReadLine();
                cnt = 0;
                foreach (char i in InputId)
                    cnt++;
            }
            return InputId;
        }
        //비밀번호를 입력받음. 비밀번호 설정 시 20자리 이하로 생성해야함
        public string CheckPasswordInput()
        {
            string Password = "";
            ConsoleKeyInfo InputKey;
            do
            {
                InputKey = Console.ReadKey(true);
                if (InputKey.Key == ConsoleKey.Enter && Password.Length < 1)
                {
                    Console.WriteLine("Input Again : ");
                }
                else if (InputKey.Key != ConsoleKey.Backspace && InputKey.Key != ConsoleKey.Enter)
                {
                    if (Password.Length < 20)
                    {
                        Password += InputKey.KeyChar;
                        Console.Write("*");
                    }
                }
                else
                {
                    if (InputKey.Key == ConsoleKey.Backspace && Password.Length > 0)
                    {
                        Password = Password.Substring(0, (Password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            } while (InputKey.Key != ConsoleKey.Enter || (InputKey.Key == ConsoleKey.Enter && Password.Length < 1));

            return Password;
        }
    }
}
