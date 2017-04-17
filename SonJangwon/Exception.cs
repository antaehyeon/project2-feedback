using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Exception
    {
        Menu menu;
        string name, breaker;
        int i, orderselect;
        Register register;
        Administrator admin;
        public Exception(Menu come)
        {
            admin = new Administrator();
            menu = come;
            register = new Register();
        }
        public Exception()
        { }
        public int exceptionnum(int NumofOrder)
        {


            string exit = "False";
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out orderselect))
                {
                    for (i = 1; i <= NumofOrder; i++)
                    {
                        if (i == orderselect)
                        {
                            exit = "GoOut";
                            break;
                        }
                        if (i == NumofOrder - 1)
                        {
                            if (i != orderselect)
                            {
                                Console.WriteLine("주어진 번호 내에서 다시 입력하세요");
                            }
                        }
                    }
                    if (exit == "GoOut")
                        return i;

                }
                else
                {
                    Console.WriteLine("다시 입력하세요");
                    Console.WriteLine("숫자로 입력하세요!");

                }
            }
        }
        public string makeID()
        {
            while (true)
            {
                while (true)
                {
                    name = Console.ReadLine();
                    if (name.Length > 11)
                    {
                        Console.WriteLine("12자 미만으로 다시 입력하세요");
                    }
                    else if (name.Length < 3)
                    {
                        Console.WriteLine("3자 이상으로 다시 입력하세요");
                    }
                    else
                        break;
                }
                for (int i = 0; i < menu.getRegister().memberVolist.Count; i++)
                {
                    if (name == menu.getRegister().memberVolist[i].MemberId)
                    {
                        breaker = "GoOut";
                    }

                }
                if (breaker == "GoOut")
                {
                    Console.WriteLine("같은 아이디가 있습니다.");
                    Console.ReadKey();

                }
                else
                    return name;

            }
        }
        public string PW()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.Write("\b\0\b");
                        sb.Length--;
                    }

                    continue;
                }

                Console.Write('*');
                sb.Append(cki.KeyChar);
            }

            return sb.ToString();
        }
        public void EnrollBoook(string name, string author,int price, int quantity)
        {
            for (i = 0; i < menu.getAdmin().bookVolist.Count; i++)
            {
                if (menu.getAdmin().bookVolist[i].BookName == name)
                {
                    if (menu.getAdmin().bookVolist[i].BookAuthor == author)
                    {
                        if (menu.getAdmin().bookVolist[i].BookPrice == price)
                        {
                            if (menu.getAdmin().bookVolist[i].BookQuantity == quantity)
                            {
                                menu.getAdmin().bookVolist[i].BookNum++;
                                break;
                            }
                            else
                            {
                                menu.getAdmin().bookvo.BookName = name;
                                menu.getAdmin().bookvo.BookAuthor = author;
                                menu.getAdmin().bookvo.BookPrice = price;
                                menu.getAdmin().bookvo.BookQuantity = quantity;
                                menu.getAdmin().bookvo.BookNum = 1;
                                menu.getAdmin().bookVolist.Add(new BookVO(menu.getAdmin().bookvo, menu.getAdmin().bookvo.BookName, menu.getAdmin().bookvo.BookAuthor, menu.getAdmin().bookvo.BookPrice, menu.getAdmin().bookvo.BookQuantity, menu.getAdmin().bookvo.BookNum));
                                break;
                            }
                        }
                        else
                        {
                            menu.getAdmin().bookvo.BookName = name;
                            menu.getAdmin().bookvo.BookAuthor = author;
                            menu.getAdmin().bookvo.BookPrice = price;
                            menu.getAdmin().bookvo.BookQuantity = quantity;
                            menu.getAdmin().bookvo.BookNum = 1;
                            menu.getAdmin().bookVolist.Add(new BookVO(menu.getAdmin().bookvo, menu.getAdmin().bookvo.BookName, menu.getAdmin().bookvo.BookAuthor, menu.getAdmin().bookvo.BookPrice, menu.getAdmin().bookvo.BookQuantity, menu.getAdmin().bookvo.BookNum));
                            break;
                        }
                    }
                    else
                    {
                        menu.getAdmin().bookvo.BookName = name;
                        menu.getAdmin().bookvo.BookAuthor = author;
                        menu.getAdmin().bookvo.BookPrice = price;
                        menu.getAdmin().bookvo.BookQuantity = quantity;
                        menu.getAdmin().bookvo.BookNum = 1;
                        menu.getAdmin().bookVolist.Add(new BookVO(menu.getAdmin().bookvo, menu.getAdmin().bookvo.BookName, menu.getAdmin().bookvo.BookAuthor, menu.getAdmin().bookvo.BookPrice, menu.getAdmin().bookvo.BookQuantity, menu.getAdmin().bookvo.BookNum));
                        break;
                    }
                }
                else
                {
                    menu.getAdmin().bookvo.BookName = name;
                    menu.getAdmin().bookvo.BookAuthor = author;
                    menu.getAdmin().bookvo.BookPrice = price;
                    menu.getAdmin().bookvo.BookQuantity = quantity;
                    menu.getAdmin().bookvo.BookNum = 1;
                    menu.getAdmin().bookVolist.Add(new BookVO(menu.getAdmin().bookvo, menu.getAdmin().bookvo.BookName, menu.getAdmin().bookvo.BookAuthor, menu.getAdmin().bookvo.BookPrice, menu.getAdmin().bookvo.BookQuantity, menu.getAdmin().bookvo.BookNum));
                    break;
                }

            }

            Console.ReadKey();
        }
    
    }
    
}
