using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBook
{
    class Search
    {
        Exception exception = new Exception();
        Play play;
        public Search(Play p)
        {
            play = p;
        }

        
        public void searching()
        {
            Console.WriteLine("검색 목록을 선택하세요");
            Console.WriteLine("1. 회원 2. 도서 3. 뒤로가기");
            int n = exception.input(1, 3);

            switch (n)
            {
                case 1:
                    (play.getMembership()).output(); //search클래스에서 play클래스를 연결하여 membership클래스에 있는 ouput 메서드를 불러온다.
                    break;
                case 2:
                    (play.getBook()).bookOutput(); //현재클래스에서 play클래스를 연결해서 book클래스에 있는 책출력 메서드를 불러온다.
                    break;
                case 3:
                    play.aPlay(); //메인 메뉴로 간다.
                    break;
            }
        }
    }
}
