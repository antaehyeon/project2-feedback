using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Register
    {
        Menu menu;
        BasicScreen basicScreen;                //기본화면
        Exception exception;                    //예외처리
        string breaker;                         //2중반복문 탈출하기위한 변수
        public MemberVO memVo;                  //멤버VO
        public List<MemberVO> memberVolist;         //lIST<멤버vo>
        int ChooseNum, i;       
        
        public Register(Menu come)                          //생성자에서 Menu클래스를 호출해와서 이 클래스에서 선언한 변수에 대입했습니다. 
        {
            exception = new Exception();
            menu = come;
            basicScreen = new BasicScreen();
            memVo = new MemberVO();
            memberVolist = new List<MemberVO>();
        }
        public Register()
        { }
        
        public void registers()
        {

            string name, password, phonenum, birthday;
            
            Console.WriteLine("1. 회원등록하기 2.이전 메뉴로 돌아가기");
            ChooseNum = exception.exceptionnum(2);                              //예외처리
            switch (ChooseNum)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("회원등록");
                    Console.WriteLine("아이디 입력[3자 이상 12자 미만]");
                    //name = exception.makeID();
                    
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
                    for (int i = 0; i < memberVolist.Count; i++)                
                    {
                        if (name == memberVolist[i].MemberId)               //아이디 중복방지입니다.
                        {
                            breaker = "GoOut";
                        }
                    }
                    if (breaker == "GoOut")
                    {
                        Console.WriteLine("같은 아이디가 있습니다.");
                        Console.ReadKey();
                        break;
                    }

                    Console.WriteLine("비밀번호 입력[3자 이상 9자 미만]"); 
                    while (true)
                    {
                        password = exception.PW();                                  //비밀번호 콘솔창에서 * 표시로 나오게 하는 것입니다.
                        if (password.Length > 8)
                        {
                            Console.WriteLine("9자 미만으로 다시 입력하세요");
                        }
                        else if (password.Length < 3)
                        {
                            Console.WriteLine("3자 이상으로 다시 입력하세요");
                        }
                        else
                            break;
                    }
                    
                    Console.WriteLine("전화번호 입력(- 제외해서 11자리) (예: 01052626832)");
                    while (true)
                    {
                        phonenum = Console.ReadLine();
                        if (phonenum.Length != 11)
                        {
                            Console.WriteLine("전화번호 입력(- 제외해서 11자리) (예: 01052626832)");
                            Console.WriteLine("11자로 다시 입력하세요");
                        }
                        else
                            break;
                    }
                    Console.WriteLine("생년월일 입력(주민번호 앞 6자리) (예: 921031 )");
                    while (true)
                    {
                        birthday = Console.ReadLine();
                        if (birthday.Length != 6)
                        {
                            Console.WriteLine("주민번호 앞 6자리 입력 (예: 921031)");
                            Console.WriteLine("6자로 다시 입력하세요");
                        }
                        else
                            break;
                    }
                    memVo.MemberId = name;
                    memVo.MemberPassword = password;
                    memVo.MemberPhonenum = phonenum;
                    memVo.MemberBirthday = birthday;

                    memberVolist.Add(new MemberVO(memVo, memVo.MemberId, memVo.MemberPassword, memVo.MemberPhonenum, memVo.MemberBirthday));

                    Console.WriteLine();
                    Console.WriteLine("{0}님의 정보가 처리되었습니다. ", memVo.MemberId);
                    Console.ReadKey();
                    menu.menus();
                    break;
                case 2:
                    menu.menus();
                    break;
            }



        }
        
    }
}
