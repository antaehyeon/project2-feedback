using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class BasicScreen
    {
        public void MenuScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("1. 회원가입");
            Console.WriteLine("2. 회원 로그인");
            Console.WriteLine("3. 관리자");

        }
        public void LoginScreen()
        {
            Console.Clear();
            Console.WriteLine("1. 회원정보 수정");
            Console.WriteLine("2. 전체도서 출력");
            Console.WriteLine("3. 도서 검색");
            Console.WriteLine("4. 도서 대여");
            Console.WriteLine("5. 도서 반납");
            Console.WriteLine("6. 기본화면으로 돌아가기");

        }
        public void AdminScreen()
        {
            Console.Clear();
            Console.WriteLine("1. 회원정보 출력");
            Console.WriteLine("2. 회원 삭제");
            Console.WriteLine("3. 전체 도서 출력");
            Console.WriteLine("4. 도서 등록");
            Console.WriteLine("5. 도서정보 수정");
            Console.WriteLine("6. 도서 삭제");
            Console.WriteLine("7. 기본화면으로 돌아가기");
        }
        
    }
}
