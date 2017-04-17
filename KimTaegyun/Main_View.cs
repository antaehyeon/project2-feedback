using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    class Main_View
    {
        UI ui = new UI();
        User member;
        Management book;
        Exception e = new Exception();

        List<MemberVO> memberList = new List<MemberVO>();
        List<BookVO> bookList = new List<BookVO>();

        public Main_View() // MemberVO와 BookVO를 Main_View에 받기위한 생성자
        {
            this.member = new User(memberList,bookList);
            this.book = new Management(bookList,memberList);
        }
     
        
        private int save_num; // Main 함수에 전달하기위한 변수.

        public int Save_num
        {
            get { return save_num; }
            set { save_num = value; }
        }
        public void main_view()
        {
            ui.background_display(); // 초기 ui 화면
            First_display(); // 초기 화면
        }

        public void First_display()
        {

            Console.WriteLine();
            ui.Left_space();
            Console.WriteLine("1. 사용자");
            ui.Left_space();
            Console.WriteLine("2. 관리자");
            ui.Left_space();
            Console.WriteLine("3. Exit");
            ui.Left_space();
            ui.Top_Bot_star();
            Console.WriteLine();
            ui.Left_space();
            Console.Write("입력 : ");
            save_num = e.press_key(1,3);


            if (Save_num == 1)
            {
                Console.Clear();
                member.User_View();
            }

            else if (Save_num == 2)
            {
                Console.Clear();
                book.Check_ID();
            }
        }
    }
}