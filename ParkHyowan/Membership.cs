using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBook
{
    class Membership
    {
        Play play;
        //Play play = new Play();
        public List<MemVO> memberList = new List<MemVO>();
        public MemVO memvo = new MemVO(null, null, null, null, null);
        public Membership(Play p)
        {
            play = p;
        }

        public void registerMem()
        {
            Console.Write("이름: "); //영어나 한글만 되게, 엔터로 안 넘기게
            memvo.name = Console.ReadLine();
            Console.Write("생년월일(6자리): "); //6자리만 받게
            memvo.birthday = Console.ReadLine();
            Console.Write("핸드폰 번호: "); //11자리만
            memvo.phonenum = Console.ReadLine();
            memberList.Add(new MemVO(memvo, memvo.name, memvo.birthday, memvo.phonenum, memvo.hasBook));
            Console.WriteLine();
            Console.WriteLine("{0}님 등록되셨습니다.", memvo.name);
            Console.WriteLine("==========================");
            play.aPlay();
        }

        public void memModify()
        {
            Console.Write("수정하려는 회원 이름을 입력해주세요: ");
            for (;;)
            {
                string n = Console.ReadLine();
                if (n == memvo.name) //내가 입력한 문자열과 회원 이름 문자열과 맞으면
                {
                    break; //멈추고 수정한다.
                }
                else
                    Console.WriteLine("등록한 이름을 정확하게 써주세요"); //틀리면 정확하게 쓰라고 언급한다.
                
            }
            Console.WriteLine("▒회원 정보 수정▒");
            registerMem();
        }

        public void memDel()
        {
            Console.Write("삭제하려는 회원 이름을 입력해주세요: ");
            for (;;)
            {

                string n = Console.ReadLine();
                if (n == memvo.name) //입력한 문자열과 이름이 맞으면
                {
                    for (int i = 0; i < memberList.Count; i++) //인덱스를 위치를 찾아야한다.
                    {
                        n = memberList[i].name;
                        if (memberList[i].name == memvo.name)
                        {
                            int a = i;
                            memberList.RemoveAt(a); //찾으면 특정인덱스 삭제
                        }
                    }
                    break;
                }
                else
                    Console.WriteLine("등록한 책 이름을 정확하게 써주세요");

            }
            Console.WriteLine("삭제되었습니다");

            play.aPlay();
        }

        public void output()
        {
            Console.WriteLine("전체 조회를 하시겠습니까?(Y/N)"); //회원들 목록을 전체로 출력하게 한다.

            for (;;)
            {
                string a = Console.ReadLine(); 
                if (a == "y" || a == "Y") //소문자도 대문자도 가능하다.
                {
                    Console.WriteLine("이름" + "   |" + "생년월일" + "  |" + "핸드폰 번호"); //줄 맞춰야함
                    foreach (MemVO memList in memberList)
                    {
                        Console.WriteLine(memList.name + "    " + memList.birthday + "     " + memList.phonenum);
                        Console.WriteLine();
                    }
                    break;

                }
                else if (a == "N" || a == "n")
                    break;
                else
                    Console.WriteLine("Only Y or N");
            }play.aPlay();
        }
    }
}
