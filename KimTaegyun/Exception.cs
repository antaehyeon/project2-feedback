using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookManagement
{
    class Exception
    {
        UI ui = new UI();
        public int press_key(int min, int max) 
        {
            int value;
            string param;

            param = Console.ReadLine();
            while ((!int.TryParse(param, out value)) || (value < min || value > max))
            {
                ui.Left_space();
                Console.WriteLine("지정된 숫자가 아닙니다.");
                param = Console.ReadLine();
            }
            return value;
        }


    }
}

