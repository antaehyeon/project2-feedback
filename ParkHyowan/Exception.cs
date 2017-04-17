using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ManageBook
{
    class Exception
    {
        public int input(int from, int to)
        {
            int num;
            for (;;)
            {
                string a = Console.ReadLine(); 
                if (int.TryParse(a, out num) || (num >= from && num <= to))
                {
                    break;
                }
                else
                    Console.WriteLine("{0}~{1} 범위 내에 숫자를 입력해 주세요", from, to);
            }return num;
        }

        public void digit(string a)
        {
            a = Console.ReadLine();
            Regex regex = new System.Text.RegularExpressions.Regex(@"^{1,6}$");
            Boolean ismatch = regex.IsMatch(a);
        }
    }
}
