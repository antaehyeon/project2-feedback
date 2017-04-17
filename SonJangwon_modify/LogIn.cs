using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class LogIn
    {
        
        Menu menu;                                  
        BasicScreen basicScreen;                                        //기본화면
        Exception exception;                                             //예외처리
        int ChooseNum, i;
        string breaker;                                                  //2중반복문 탈출하기위한 변수
        
        DateTime saveNow;
        public string datePatt = @"yyyy/M/d tt hh:mm:ss ";              //날짜의 형식을 지정해 주었습니다.
        public List<string> RentBook = new List<string>();              //대여한 책을 받아줍니다.
        public List<string> RentTime = new List<string>();              //대여한 시간을 받아줍니다.
        public LogIn(Menu come)                                         //생성자에서 Menu클래스를 호출해와서 이 클래스에서 선언한 변수에 대입했습니다. 
        {
            
            exception = new Exception();
            menu = come;
            basicScreen = new BasicScreen();
            saveNow = DateTime.Now;
        }
    
        
        public void DisplayNow(string title, DateTime inputDt)          //책 대여 시간을 호출해줍니다.
        {
            string dtString = inputDt.ToString(datePatt);
            Console.WriteLine("{0} ", dtString);

        }
        public void Logins()                                                 //로그인하는 화면입니다.
        {
            while (true)
            {
                if (menu.getRegister().memberVolist.Count == 0)                 //아직 회원이 0명인 경우
                {
                    Console.WriteLine();
                    Console.WriteLine("가입된 회원이 없습니다.");
                    Console.WriteLine("회원가입 먼저 하세요");
                    Console.ReadKey();
                    menu.menus();
                }
                Console.WriteLine("아이디를 입력하세요");
                string id = Console.ReadLine();
                Console.WriteLine("패스워드를 입력하세요");
                string password = exception.PW();
                

                for (i = 0; i < menu.getRegister().memberVolist.Count; i++)
                {

                    if (id == menu.getRegister().memberVolist[i].MemberId)                         
                    {
                        if (password == menu.getRegister().memberVolist[i].MemberPassword)          //아이디와 비밀번호를 제대로 입력한 경우입니다.
                        {
                            breaker = "GoOut";
                            
                            break;
                        }
                    }
                    if (i == menu.getRegister().memberVolist.Count - 1)
                    {
                        if (id != menu.getRegister().memberVolist[i].MemberId)              //한바퀴 다 돌았는데 저장되어 있는 아이디와 일치하지 않는 경우를 찾습니다.
                        {
                            Console.WriteLine("제대로 된 아이디를 입력해주세요");
                            Console.WriteLine("이 전 메뉴로 돌아가기: (q)");
                            Console.WriteLine("아니면 : Any Key");

                            string q = Console.ReadLine();
                            if (q == "q")
                            {
                                menu.menus();
                            }
                        }
                        else if (password != menu.getRegister().memberVolist[i].MemberPassword)     //기존의 비밀번호 정보와 일치하지 않는 경우를 찾습니다.
                        {
                            Console.WriteLine("제대로 된 비밀번호를 입력해주세요");
                            Console.WriteLine("이 전 메뉴로 돌아가기: (q)");
                            Console.WriteLine("아니면 : Any Key");

                            string q = Console.ReadLine();
                            if (q == "q")
                            {
                                menu.menus();
                            }
                        }

                    }
                   
                }
                if (breaker == "GoOut")
                    break;

            }
        }
        public void User()
        {
            breaker = "";
            basicScreen.LoginScreen();
            ChooseNum = exception.exceptionnum(6);                  //예외처리입니다.
            switch (ChooseNum)
            {
                case 1:
                    ModifyInformation();
                    break;
                case 2:
                    PrintAll();
                    break;
                case 3:
                    Search();
                    break;
                case 4:
                    Rent();
                    break;
                case 5:
                    Return();
                    break;
                case 6:
                    menu.menus();
                    break;
            }
        }
        public void ModifyInformation()                         //회원정보수정입니다.
        {

            Console.WriteLine("");
            Console.WriteLine(menu.getRegister().memberVolist[i].MemberId + "   " + menu.getRegister().memberVolist[i].MemberPhonenum + "   " + menu.getRegister().memberVolist[i].MemberBirthday);

            string name, password, phonenum, birthday;
            

            Console.WriteLine("회원수정");
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("수정할 아이디 입력");
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
                    if (name == menu.getRegister().memberVolist[i].MemberId)                //수정할 아이디가 기존에 있는 아이디와 일치하는 경우입니다. 다시 반복문을 돌 것입니다.
                    {
                        breaker = "GoOut";
                    }
                }
                if (breaker == "GoOut")
                {
                    Console.WriteLine("같은 아이디가 있습니다.");
                    Console.ReadKey();
                }
                else                                                     //같은 아이디가 없는 경우 반복문을 탈출합니다.
                    break;
            }
            Console.WriteLine("수정할 비밀번호 입력");
            while (true)
            {
                password = Console.ReadLine();
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
            Console.WriteLine("수정할 전화번호 입력(- 제외)");
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
            Console.WriteLine("수정할 생년월일 입력(주민번호 앞 6자리)");
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
            menu.getRegister().memberVolist[i].MemberId = name;
            menu.getRegister().memberVolist[i].MemberPassword = password;
            menu.getRegister().memberVolist[i].MemberPhonenum = phonenum;
            menu.getRegister().memberVolist[i].MemberBirthday = birthday;
            Console.ReadKey();
            this.User();
        }
        public void PrintAll()                                          //전체 도서를 출력합니다.
        {
            Console.WriteLine("출력");
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" 도서 이름       도서 저자       도서 가격       페이지 수       도서 수량  ");
            for (i = 0; i < menu.getAdmin().bookVolist.Count; i++)
            {
                Console.Write((menu.getAdmin().bookVolist[i].BookName + "                 ").Substring(0, 13));
                Console.Write((menu.getAdmin().bookVolist[i].BookAuthor + "              ").Substring(0, 13));
                Console.Write((menu.getAdmin().bookVolist[i].BookPrice + "              ").Substring(0, 13));
                Console.Write((menu.getAdmin().bookVolist[i].BookQuantity + "            ").Substring(0, 13));
                Console.WriteLine((menu.getAdmin().bookVolist[i].BookNum + "             ").Substring(0, 13));

            }
            Console.ReadKey();
            this.User();
        }
        public void Search()
        {
            Console.WriteLine("검색");

            Console.WriteLine("어떤 기준으로 찾으시겠습니까?");
            Console.WriteLine("1. 도서명으로 찾기 2.저자로 찾기 3. 가격으로 찾기");
            ChooseNum = exception.exceptionnum(3);
            switch (ChooseNum)
            {
                case 1:
                    while (true)
                    {
                        Console.WriteLine("도서명을 입력해주세요");
                        string selectName = Console.ReadLine();
                        for (i = 0; i < menu.getAdmin().bookVolist.Count; i++)
                        {
                            if (menu.getAdmin().bookVolist[i].BookName == selectName)
                            {
                                breaker = "GoOut";
                                break;
                            }
                            if (i == menu.getAdmin().bookVolist.Count - 1)                 //맨마지막 책까지 돌아도 입력한 책이 없는 경우
                            {
                                if (selectName != menu.getAdmin().bookVolist[i].BookName)
                                {
                                    Console.WriteLine("제대로 된 도서명을 입력해주세요");
                                }
                            }
                        }
                        if (breaker == "GoOut")
                            break;
                    }break;
                    
                case 2:
                    while (true)
                    {
                        Console.WriteLine("저자를 입력해주세요");
                        string selectAuthor = Console.ReadLine();
                        for (i = 0; i < menu.getAdmin().bookVolist.Count; i++)
                        {
                            if (selectAuthor == menu.getAdmin().bookVolist[i].BookAuthor)
                            {
                                break;
                            }

                            if (i == menu.getAdmin().bookVolist.Count - 1)                 //맨마지막 책까지 돌아도 입력한 책이 없는 경우
                            {
                                if (selectAuthor != menu.getAdmin().bookVolist[i].BookAuthor)
                                {
                                    Console.WriteLine("제대로 된 저자를 입력해주세요");
                                }
                            }
                        }
                        if (breaker == "GoOut")
                            break;
                    }
                    break;
                case 3:
                    while (true)
                    {
                        Console.WriteLine("가격을 입력해주세요");
                        int selectPrice = int.Parse(Console.ReadLine());
                        for (i = 0; i < menu.getAdmin().bookVolist.Count; i++)
                        {
                            if (selectPrice == menu.getAdmin().bookVolist[i].BookPrice)
                            {
                                break;
                            }
                            if (i == menu.getAdmin().bookVolist.Count - 1)                      
                            {
                                if (selectPrice != menu.getAdmin().bookVolist[i].BookPrice)     //맨마지막 책까지 돌아도 입력한 책이 없는 경우
                                {
                                    Console.WriteLine("제대로 된 가격을 입력해주세요");
                                }
                            }
                        }
                        if (breaker == "GoOut")             //책을 찾으면 반복문을 탈출하기
                            break;
                    }
                    break;

            }
            Console.Write((menu.getAdmin().bookVolist[i].BookName + "                 ").Substring(0, 13));         //검색한 도서정보 출력하기
            Console.Write((menu.getAdmin().bookVolist[i].BookAuthor + "              ").Substring(0, 13));
            Console.Write((menu.getAdmin().bookVolist[i].BookPrice + "              ").Substring(0, 13));
            Console.Write((menu.getAdmin().bookVolist[i].BookQuantity + "            ").Substring(0, 13));
            Console.WriteLine((menu.getAdmin().bookVolist[i].BookNum + "             ").Substring(0, 13));
            Console.ReadKey();
            this.User();
            
        }
        public void Rent()
        {
            Console.WriteLine("어떤 책을 빌리시겠습니까?");
            Console.WriteLine("1. 책 이름으로 선택하기 2.저자 이름으로 선택하기 3. 이전 메뉴로 돌아가기");
            ChooseNum = exception.exceptionnum(3);                                  //예외처리입니다.
            switch (ChooseNum)
            {
                case 1:
                    while (true)
                    {
                        Console.WriteLine("도서명을 입력해주세요");
                        string selectName = Console.ReadLine();
                        for (i = 0; i < menu.getAdmin().bookVolist.Count; i++)
                        {
                            if (selectName == menu.getAdmin().bookVolist[i].BookName)           //원하는 책을 도서내역에서 찾은 경우입니다.
                            {
                                breaker = "GoOut";
                                break;
                            }
                            
                        }
                        if (breaker == "GoOut")
                            break;
                        else if (breaker != "GoOut")                                   //마지막까지 다 돌았는데 원하는 책이 없는 경우입니다. 
                        {
                            Console.WriteLine("제대로 된 도서명을 입력해주세요");
                            Console.WriteLine("이 전 메뉴로 돌아가기: (q)");
                            Console.WriteLine("아니면 : Any Key");

                            string q = Console.ReadLine();
                            if (q == "q")
                            {
                                this.User();
                            }
                        }
                    }
                    Console.Write((menu.getAdmin().bookVolist[i].BookName + "                 ").Substring(0, 13));     //검색한 도서정보 출력하기
                    Console.Write((menu.getAdmin().bookVolist[i].BookAuthor + "              ").Substring(0, 13));
                    Console.Write((menu.getAdmin().bookVolist[i].BookPrice + "              ").Substring(0, 13));
                    Console.Write((menu.getAdmin().bookVolist[i].BookQuantity + "            ").Substring(0, 13));
                    Console.WriteLine((menu.getAdmin().bookVolist[i].BookNum + "             ").Substring(0, 13));
                    Console.ReadKey();

                    if (menu.getAdmin().bookVolist[i].BookNum == 0)                                     //원하는 책을 찾았지만 수량이 없는 경우입니다.
                    {
                        Console.WriteLine("해당 도서의 수량이 없습니다.");
                        Console.WriteLine("다음에 이용해 주세요");
                        Console.ReadKey();
                        this.User();

                    }
                    Console.WriteLine("해당 도서를 대여 하시겠습니까?");
                    Console.WriteLine("대여하실거면 '1'    그렇지 않으면 '2'를 입력해주세요"); ;
                    int select = exception.exceptionnum(2);
                    switch (select)
                    {
                        case 1:
                            menu.getAdmin().bookVolist[i].BookNum--;                                //책을 빌리고 서점의 수량을 1권 줄입니다.

                            string dtString = saveNow.ToString(datePatt);                            //대여시간을 출력합니다.
                            Console.WriteLine("{0}가 대여되었습니다.", menu.getAdmin().bookVolist[i].BookName);  //{1}, RentTime[RentTime.Count - 1]
                            RentBook.Add(menu.getAdmin().bookVolist[i].BookName);                       //대여책을 리스트에 넣습니다.
                            //RentTime.Add(RentTime[RentTime.Count - 1]);                                 //대여시간을 리스트에 넣습니다.

                            Console.ReadKey();
                            this.User();
                            break;
                        case 2:
                            this.User();
                            break;
                    }
                    break;
                case 2:
                    while (true)
                    {
                        Console.WriteLine("저자를 입력해주세요");
                        string selectName = Console.ReadLine();
                        for (i = 0; i < menu.getAdmin().bookVolist.Count; i++)
                        {
                            if (selectName == menu.getAdmin().bookVolist[i].BookAuthor)      //원하는 책을 도서내역에서 찾은 경우입니다.
                            {
                                breaker = "GoOut";
                                break;
                            }
                            
                        }
                        if (breaker == "GoOut")
                            break;
                        else if (breaker != "GoOut")                         //마지막까지 다 돌았는데 원하는 책이 없는 경우입니다. 
                        {
                            Console.WriteLine("제대로 된 도서명을 입력해주세요");
                            Console.WriteLine("이 전 메뉴로 돌아가기: (q)");
                            Console.WriteLine("아니면 : Any Key");

                            string q = Console.ReadLine();
                            if (q == "q")
                            {
                                this.User();
                            }
                        }
                    }
                    Console.Write((menu.getAdmin().bookVolist[i].BookName + "                 ").Substring(0, 13));     //검색한 도서정보 출력하기
                    Console.Write((menu.getAdmin().bookVolist[i].BookAuthor + "              ").Substring(0, 13));
                    Console.Write((menu.getAdmin().bookVolist[i].BookPrice + "              ").Substring(0, 13));
                    Console.Write((menu.getAdmin().bookVolist[i].BookQuantity + "            ").Substring(0, 13));
                    Console.WriteLine((menu.getAdmin().bookVolist[i].BookNum + "             ").Substring(0, 13));
                    Console.ReadKey();

                    if (menu.getAdmin().bookVolist[i].BookNum == 0)                                     //원하는 책을 찾았지만 수량이 없는 경우입니다.
                    {
                        Console.WriteLine("해당 도서의 수량이 없습니다.");
                        Console.WriteLine("다음에 이용해 주세요");
                        Console.ReadKey();
                        this.User();

                    }
                    Console.WriteLine("해당 도서를 대여 하시겠습니까?");
                    Console.WriteLine("대여하실거면 '1'    그렇지 않으면 '2'를 입력해주세요"); ;
                    select = exception.exceptionnum(2);
                    switch (select)
                    {
                        case 1:
                            menu.getAdmin().bookVolist[i].BookNum--;                                //책을 빌리고 서점의 수량을 1권 줄입니다.

                            string dtString = saveNow.ToString(datePatt);                            //대여시간을 출력합니다.
                            Console.WriteLine("{0}가 대여되었습니다.", menu.getAdmin().bookVolist[i].BookName);  //{1}, RentTime[RentTime.Count - 1]
                            RentBook.Add(menu.getAdmin().bookVolist[i].BookName);                       //대여책을 리스트에 넣습니다.
                            //RentTime.Add(RentTime[RentTime.Count - 1]);                                 //대여시간을 리스트에 넣습니다.

                            Console.ReadKey();
                            this.User();
                            break;
                        case 2:
                            this.User();
                            break;
                    }
                    break;
                case 3:
                    this.User();
                    break;
            }
            
        }
        public void Return()
        {
            Console.WriteLine("회원님의 대여 도서 목록입니다.");
            for(i=0; i<RentBook.Count;i++)
            {
                Console.WriteLine(RentBook[i]);                                         //대여한 도서 명을 보여줍니다.
            }
            Console.ReadKey();
            Console.WriteLine("어떤 책을 반납하시겠습니까?");
            Console.WriteLine("1. 책 이름으로 선택하기 2.저자 이름으로 선택하기 3. 이전 메뉴로 돌아가기");
            ChooseNum = exception.exceptionnum(3);
            switch (ChooseNum)
            {
                case 1:
                    while (true)
                    {
                        Console.WriteLine("도서명을 입력해주세요");
                        string selectName = Console.ReadLine();
                        for (i = 0; i < menu.getAdmin().bookVolist.Count; i++)
                        {
                            if (selectName == menu.getAdmin().bookVolist[i].BookName)
                            {
                                breaker = "GoOut";
                                break;
                            }
                            if (i == menu.getAdmin().bookVolist.Count - 1)                 //맨마지막 책까지 돌아도 입력한 책이 없는 경우
                            {
                                if (selectName != menu.getAdmin().bookVolist[i].BookName)
                                {
                                    Console.WriteLine("제대로 된 도서명을 입력해주세요");
                                }
                            }
                        }
                        if (breaker == "GoOut")
                            break;
                        else if (breaker != "GoOut")
                        {
                            Console.WriteLine("제대로 된 도서명을 입력해주세요");
                            Console.WriteLine("이 전 메뉴로 돌아가기: (q)");
                            Console.WriteLine("아니면 : Any Key");

                            string q = Console.ReadLine();
                            if (q == "q")
                            {
                                this.User();
                            }
                        }
                    }
                    Console.Write((menu.getAdmin().bookVolist[i].BookName + "                 ").Substring(0, 13));
                    Console.Write((menu.getAdmin().bookVolist[i].BookAuthor + "              ").Substring(0, 13));
                    Console.Write((menu.getAdmin().bookVolist[i].BookPrice + "              ").Substring(0, 13));
                    Console.Write((menu.getAdmin().bookVolist[i].BookQuantity + "            ").Substring(0, 13));
                    Console.WriteLine((menu.getAdmin().bookVolist[i].BookNum + "             ").Substring(0, 13));
                    Console.ReadKey();

                    Console.WriteLine("해당 도서를 반납 하시겠습니까?");
                    Console.WriteLine("반납하실거면 '1'    그렇지 않으면 '2'를 입력해주세요"); ;
                    int select = exception.exceptionnum(2);
                    switch (select)
                    {
                        case 1:
                            menu.getAdmin().bookVolist[i].BookNum++;                            //반납하고 도서관의 책 수량1을 1개증가.

                            string dtString = saveNow.ToString(datePatt);
                            RentTime.Add(dtString);
                            Console.WriteLine("{0} 가 {1}에 반납되었습니다.", menu.getAdmin().bookVolist[i].BookName, RentTime[RentTime.Count - 1]);
                            Console.ReadKey();
                            this.User();
                            break;
                        case 2:
                            this.User();
                            break;
                    }
                    break;
                case 2:
                    while (true)
                    {
                        Console.WriteLine("저자를 입력해주세요");
                        string selectName = Console.ReadLine();
                        for (i = 0; i < menu.getAdmin().bookVolist.Count; i++)
                        {
                            if (selectName == menu.getAdmin().bookVolist[i].BookAuthor)
                            {
                                breaker = "GoOut";
                                break;
                            }
                            if (i == menu.getAdmin().bookVolist.Count - 1)                 //맨마지막 책까지 돌아도 입력한 책이 없는 경우
                            {
                                if (selectName != menu.getAdmin().bookVolist[i].BookAuthor)
                                {
                                    Console.WriteLine("제대로 된 도서명을 입력해주세요");
                                }
                            }
                        }
                        if (breaker == "GoOut")
                            break;
                        else if (breaker != "GoOut")
                        {
                            Console.WriteLine("제대로 된 도서명을 입력해주세요");
                            Console.WriteLine("이 전 메뉴로 돌아가기: (q)");
                            Console.WriteLine("아니면 : Any Key");

                            string q = Console.ReadLine();
                            if (q == "q")
                            {
                                this.User();
                            }
                        }
                    }
                    Console.Write((menu.getAdmin().bookVolist[i].BookName + "                 ").Substring(0, 13));
                    Console.Write((menu.getAdmin().bookVolist[i].BookAuthor + "              ").Substring(0, 13));
                    Console.Write((menu.getAdmin().bookVolist[i].BookPrice + "              ").Substring(0, 13));
                    Console.Write((menu.getAdmin().bookVolist[i].BookQuantity + "            ").Substring(0, 13));
                    Console.WriteLine((menu.getAdmin().bookVolist[i].BookNum + "             ").Substring(0, 13));
                    Console.ReadKey();

                    Console.WriteLine("해당 도서를 반납 하시겠습니까?");
                    Console.WriteLine("반납하실거면 '1'    그렇지 않으면 '2'를 입력해주세요"); ;
                    select = exception.exceptionnum(2);
                    switch (select)
                    {
                        case 1:
                            menu.getAdmin().bookVolist[i].BookNum++;

                            string dtString = saveNow.ToString(datePatt);
                            RentTime.Add(dtString);
                            Console.WriteLine("{0} 가 {1}에 반납되었습니다.", menu.getAdmin().bookVolist[i].BookName, RentTime[RentTime.Count - 1]);
                            Console.ReadKey();
                            this.User();
                            break;
                        case 2:
                            this.User();
                            break;
                    }
                    break;
                case 3:
                    this.User();
                    break;
            }
            
        }

    }
    
}
