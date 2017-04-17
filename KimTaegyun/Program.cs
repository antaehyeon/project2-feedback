
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    class Program
    {
        Main_View main_view = new Main_View();

        static void Main(string[] args)
        {
            UI ui = new UI();
            Main_View main_view = new Main_View();

            int number = 0;
            do
            {
                main_view.main_view();
                number = main_view.Save_num;
                ui.Left_space();
            } while (number != 3);

        }
    }
}
