using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 도서관리
{
    class Exception
    {
        Display display;
        bool result;
        int num;

        public Exception(Display display) // 생성자
        {
            this.display = display;
        }

        public bool intException(string str, string word) // 숫자 입력 예외
        {
            Console.Clear();
            result = int.TryParse(str, out num); // 문자열을 정수로 변환 가능하면 true 리턴
            
            if (result) // 가능하면
            {
                display.inputDisplay(word, 2); // 숫자는 입력할 수 없다
                return true;
            }
            else // 변환이 가능하지 않으면
            {
                return false;
            }
        }

        public bool stringException(string str, string word) // 문자 입력 예외
        {
            Console.Clear();
            result = int.TryParse(str, out num);

            if(!result) // 문자열을 정수로 변환 가능하지 않으면
            {
                display.inputDisplay(word, 2); // 문자는 입력할 수 없다
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool blankException(string str, string word) // 공백 입력 예외
        {
            Console.Clear();
            if(str.Contains(" ")) // 입력에 공백이 있으면
            {
                display.inputDisplay(word, 2);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int nameException(string str) // 이름 입력 예외
        {
            Console.Clear();
            if (str.Length < 2 || str.Length > 4) // 자릿수 예외
            {
                display.inputDisplay("이름은 두글자 이상 다섯글자 이하 입니다", 2);
                return 1;
            }
            else if (blankException(str, "이름에 공백은 있을 수 없습니다")) // 공백 예외
            {    
                return 1;
            }
            if (intException(str, "숫자는 이름이 아닙니다")) // 숫자 입력 예외
            {
                return 1;
            }
            else
            { 
                return 0;
            }
        }
       
        public int ageException(string str) // 나이 입력 예외
        {
            Console.Clear();
            if (stringException(str, "나이는 숫자로 입력해주세요"))
            {
                return 1;
            }
            else if (blankException(str, "나이에 공백은 있을 수 없습니다")) // 공백 예외
            {
                return 1;
            }
            else if (1 > Convert.ToInt32(str) || Convert.ToInt32(str) > 114) // 한국 최고령자 114세 할머니이다
            {
                display.inputDisplay("태어나지도 않았거나 이미 돌아가셨습니다", 2);
                return 1;
            }
            else if (1 < Convert.ToInt32(str) && Convert.ToInt32(str) < 114) // 조건 충족되면
            {
                return 0; // 예외 해방 0 리턴
            }
            else
            {
                return 0;
            }
        }

        public int addressException(string str) // 주소 입력 예외
        {
            Console.Clear();
            
            if (intException(str, "주소는 문자열 이여야합니다")) // 숫자만 입력하면
            {
                return 1;
            }
            
            else if (!blankException(str, "양식에 맞춰 입력하세요")) // 공백이 없으면
            {
                return 1;
            }
            else if (str.Length < 10) // 주소가 너무 짧으면
            {
                return 1;
            }
            else
            {
                Console.Clear();
                return 0;
            }
        }

        public int phoneException(string str, string word) // 핸드폰 번호, 주민등록번호 입력 예외
        {
            Console.Clear();
            if (blankException(str, word)) // 공백 예외
            {
                return 1;
            }
            if (str.Length == 13 || str.Length == 14) // 13자리 또는 14자리
            {
                return 0;
            }
            else if (intException(str, "양식을 지켜주세요")) // 문자 입력 예외
            {
                return 1;
            }
            return 1;
        }

        public int bookNoException(string str) // 도서번호 입력 예외
        {
            Console.Clear();
            if (!intException(str, "양식을 지켜주세요")) {
                return 1;
            }
            if (str.Length < 11 || str.Length > 11) // 임의로 도서번호는 -포함 11자리로 지정
            {
                display.inputDisplay("형식에 맞게 입력하세요", 2);
                return 1;
            }
            else
            {
                return 0;
            }            
        }

        public int priceException(string str) // 도서 가격 예외
        {
            Console.Clear();
            if (stringException(str, "숫자를 제대로 입력해주세요")) // 문자 예외
            {
                return 1;
            }
            else if (str.Contains(" "))
            {
                display.inputDisplay("공백은 있을 수 없습니다", 2); // 공백 예외
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
