using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    class UI
    {
        public void background_display()
        {
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine();
            }
            
            for (int i = 0; i <= 20; i++)
            {
                Console.Write(" ");
            }
           
            for (int i = 0; i < 10; i++)
            {
                Console.Write(" * ");
                
            }
           
        }

        public void Left_space()
        {
            for (int i = 0; i <= 20; i++)
            {
                Console.Write(" ");
            }
        }

        public void Top_Bot_star()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(" * ");
            }
        }
        
        public void Top_Space()
        {
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
