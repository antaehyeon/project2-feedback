using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 도서관리
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "도서관리 프로그램 En# 17기 육문수";
            Console.SetWindowSize(130,35);
            SelectMenu selectMenu = new SelectMenu();
            selectMenu.selectMenu(); // 메뉴 선택 메소드
        }
    }
}