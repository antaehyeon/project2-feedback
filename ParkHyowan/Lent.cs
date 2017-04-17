using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBook
{
    class Lent
    {
        Play play;
        
        private bool loging; //로그인 됐는지 안 됐는지 확인한다.
        DateTime currentTime = DateTime.Now; //도서를 대출 할 때의 시간을 포착하여 저장한다.
        DateTime borrowTime; 
        DateTime returnTime = DateTime.Now.AddDays(7); //반납기간은 7일 후를 명시하기 위해서 대출 할 때의 시간에 7일을 더한다.
        public Lent(Play p) //Lent클래스도 상위 클래스에 있는 play에 있는 함수를 쓰기 위하여 연결한다.
        {
            play = p;
            loging = false; //0이면 로그인 되지 않았다.
            
        }
        public void login() {

            Console.WriteLine("대여 및 반납을 원하시면 로그인이 필요합니다.");
            Console.WriteLine("ID = 본인이름 Password = 생년월일 입니다"); //등록시 가장 기본의 정보를 써서 대출할 떄 이용한다.
            for (;;)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("ID: ");
                string username = Console.ReadLine();
                string entryUsername = (play.getMembership()).memvo.name; //입력 값이 저장된 회원이름과 일치하다면 비밀번호 칠 수 있게 넘어간다.
                if (username == entryUsername)
                {
                    Console.Write("Password: ");
                    
                    string password = Console.ReadLine();
                    string entryPassword = (play.getMembership()).memvo.birthday; //생년월일로 설정한 비밀번호 입력값하고도 맞다면 로그인 성공
                    if (password == entryPassword)
                    {
                        
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("비밀번호를 잘못입력하셨습니다.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("아이디를 잘못입력하셨습니다.");
                }
            }
            Console.WriteLine("로그인되셨습니다");
            loging = true; //bool loging은 로그인 됐다고 true로 바꿔준다.

        }

        public void lent_return()
        {
            login();

            if (loging == true) //로그인 성공 시 원하는 작업을 선택할 수 있다.
            {
                Console.WriteLine("1. 대여 2. 반납 3. 조회 4. 취소");
                int put = play.getException().input(1, 4);
                switch (put)
                {
                    case 1: // 대여
                        lent();
                        break;
                    case 2: //반납
                        bookReturn();
                        break;
                    case 3: //조회
                        show();
                        break;
                    case 4:
                        play.aPlay();
                        break;
                }
            }
            else
                Console.WriteLine("로그인이 필요합니다.");

        }

        public void show()
        {
            if (play.getMembership().memvo.hasBook != null) //따로 또 Membership클래스를 생성하지 않고 연결해놓은 play클래스를 이용해서 memvo.hasBook을 갖고온다.
            {
                Console.WriteLine("대출 목록\n");
                Console.WriteLine(play.getMembership().memvo.name + " " + play.getMembership().memvo.hasBook);
                Console.WriteLine("\n대출 기간\n");
                Console.WriteLine(borrowTime + "  ~  " + returnTime);
            }
            else
                Console.WriteLine("대출한 목록이 없습니다.");
            play.wannaBack(); //바로 메뉴 호출하는 대신 물어보고 메뉴로 가게끔 하는 메서드를 부른다.
        }

        public void lent()
        {
            (play.getBook()).ableList();
            Console.WriteLine("\n위 목록을 보고 대출하고자 하는 책 이름을 입력하세요");

            string answer = Console.ReadLine();
            if (answer == play.getBook().bookvo.bName) //빌리고자 하는 책 이름이 리스트 안에 있는 책 이름과 일치하다면
            {
                for (int i = 0; i < play.getBook().bookList.Count; i++) //인덱스를 찾는다.
                {
                    answer = play.getBook().bookList[i].bName;
                    if(play.getBook().bookList[i].bName == play.getBook().bookvo.bName){ //인덱스 주소와 찾고 있는 도서명이 같다면
                    play.getBook().bookList[i].lending = true;  //true -> 대출불가능으로 바꾼다.
                    play.getMembership().memvo.hasBook = answer; //멤버는 도서를 빌렸다고 정보를 저장한다.
                    borrowTime = currentTime; //현재시간 기록
                    Console.WriteLine("{0}님은 {1}를(을) 빌리셨습니다", play.getMembership().memvo.name, answer); //누가 뭘 빌렸는지 알려준다.
                }
                }
            }
            else
                Console.WriteLine("존재하지 않습니다.");
            
            play.wannaBack();
        }
        public void bookReturn()
        {
            Console.WriteLine("무엇을 반납하시겠습니까?");
            string answer = Console.ReadLine();
            if (answer == play.getBook().bookvo.bName)
            {
                for (int i = 0; i < play.getBook().bookList.Count; i++)
                {
                    answer = play.getBook().bookList[i].bName; //책이름과 일치하는 인덱스를 찾고
                    if (play.getBook().bookList[i].bName == play.getBook().bookvo.bName)
                    {
                        play.getBook().bookList[i].lending = false; //falst->대출가능으로 만들어준다
                        play.getMembership().memvo.hasBook = null; //그리고 회원이 도서를 빌린 정보는 비워준다.
                        Console.WriteLine("{0}님은 {1}를(을) 반납하셨습니다", play.getMembership().memvo.name, answer); //누가 무슨 책을 반납했다는 걸 알린다.
                    }
                }
            }
            else
                Console.WriteLine("존재하지 않습니다."); //이름이 검색되지 않을 경우

            play.wannaBack(); //질문을 하고 메뉴를 호출.

        }
        
        
    }
}
