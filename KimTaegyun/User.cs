using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;
namespace BookManagement
{
    class User 
    {
        UI ui = new UI();

        List<BookVO> bookList;
        List<MemberVO> memberList;
        Exception e = new Exception();

        DateTime D1 = new DateTime();
        
       
        int check_num;

        public User (List<MemberVO> member, List<BookVO> book)
        {
            this.bookList = book;
            this.memberList = member;
        }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public void User_View()
        {
            ui.Top_Space();
            ui.Left_space();
            ui.Top_Bot_star(); // 별 출력
            Console.WriteLine();
            ui.Left_space();
            Console.WriteLine("1. 회원등록");
            ui.Left_space();
            Console.WriteLine("2. 회원찾기");
            ui.Left_space();
            Console.WriteLine("3. 회원삭제");
            ui.Left_space();
            Console.WriteLine("4. 회원정보수정");
            ui.Left_space();
            Console.WriteLine("5. 도서찾기"); 
            ui.Left_space();
            Console.WriteLine("6. 도서출력");
            ui.Left_space();
            Console.WriteLine("7. 도서대여");
            ui.Left_space();
            Console.WriteLine("8. 도서반납"); // 빌리는 사람 입력 받고 있는 회원인지 찾고, 회원존재 && Rent=1이면 대여 -> Rent = 0 으로 바꾸고, 현재시간, 반납기한 출력, 
            ui.Left_space();
            Console.WriteLine("0. 이전");
            ui.Left_space();

            ui.Top_Bot_star();
            Console.WriteLine();
            ui.Left_space();
            Console.Write("입력 : ");
            Count = e.press_key(0,8);

            
            if (Count == 1)
            {
                Member_Register();
                User_View();
            }
            else if (Count == 2)
            {
                Memeber_Find();
                User_View();
            }
            else if (Count == 3)
            {
                Member_Delete();
                User_View();
            }
            else if (Count == 4)
            {
                Member_Information_Correct();
                User_View();
            }
            else if (Count == 5)
            {
                Search_Book();
                User_View();
            }
            else if (Count == 6)
            {
                Print_Book();
                User_View();
            }
            else if (Count == 7)
            {
                Book_Rent();
                User_View();
            }
            else if (Count == 8)
            {
                Book_Return();
                User_View();
            }
            else if (Count == 0)
            {
                Console.Clear();
                return;
            }
        }

        public void Member_Register()
        {
            Main_View main_view = new Main_View();
            string name, age, individual_num, cellphone;
            ArrayList Name = new ArrayList();

            ui.Top_Space();
            ui.Left_space();
            Console.WriteLine("회원등록");
            Console.Clear();

            ui.Top_Space();
            ui.Left_space();
            Console.WriteLine("이름을 입력하세요. "); // 예외처리 if(이름 ~~)
            ui.Left_space();
            name = Console.ReadLine();
            Console.Clear();

            ui.Top_Space();
            ui.Left_space();
            Console.WriteLine("나이를 입력하세요. ");
            ui.Left_space();
            age = Console.ReadLine();
            Console.Clear();

            ui.Top_Space();
            ui.Left_space();
            Console.WriteLine("주민등록번호 앞자리 ");
            ui.Left_space();
            individual_num = Console.ReadLine();
          
            Console.Clear();

            ui.Top_Space();
            ui.Left_space();
            Console.WriteLine("핸드폰번호");
            ui.Left_space();
            cellphone = Console.ReadLine();
            Console.WriteLine("{0}correctly entered", IsPhoneNumber(cellphone) ? "" : "in");
            Console.WriteLine("번호는 입력됩니다. 차후에 수정해주세요.");

            memberList.Add(new MemberVO(name, age, individual_num, cellphone));

            Console.Clear();
        } // 회원 등록

        public static bool IsPhoneNumber (string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        } // phone number Ragex 함수 

        public void Memeber_Find()
        {
            string name, age, individual_Num, cellphone;
            int Check_Num;

            Console.Clear();
            ui.Top_Space();
            ui.Left_space();
            Console.WriteLine("회원찾기");
            ui.Left_space();
            Console.WriteLine("어떤 것으로 찾으시겠어요? ");
            ui.Left_space();
            Console.WriteLine("1. 이름 ");
            ui.Left_space();
            Console.WriteLine("2. 나이");
            ui.Left_space();
            Console.WriteLine("3. 주민번호");
            ui.Left_space();
            Console.WriteLine("4.핸드폰번호");
            ui.Left_space();
            Check_Num = e.press_key(1, 4);

            if (Check_Num == 1)  // 이름으로 찾기
            {
                Console.Clear();
                ui.Top_Space();
                ui.Left_space();
                Console.WriteLine("이름을 입력해주세요.");
                ui.Left_space();
                name = Console.ReadLine();
                for (int i = 0; i < memberList.Count; i++)
                {
                    if ((string)memberList[i].name == name)
                    {
                        Console.Write("이름 :" + " " + memberList[i].name + " " + "나이 :" + " " + memberList[i].age + " " + "주민번호 :" + " " + memberList[i].individual_num + " " + "핸드폰번호 :" + " " + memberList[i].cellphone);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("찾으시는 정보의 회원이 없습니다."); 
                    }
                }
            }
            else if (Check_Num == 2)
            {
                Console.WriteLine("나이를 입력해주세요.");
                age = Console.ReadLine();
                for (int i = 0; i < memberList.Count; i++)
                {
                    if ((string)memberList[i].age == age)
                    {
                        Console.Write("이름 :" + " " + memberList[i].name + " " + "나이 :" + " " + memberList[i].age + " " + "주민번호 :" + " " + memberList[i].individual_num + " " + "핸드폰번호 :" + " " + memberList[i].cellphone);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("찾으시는 정보의 회원이 없습니다."); 
                        User_View();
                    }
                }
            }
            else if (Check_Num == 3)
            {
                Console.WriteLine("주민번호를 입력해주세요.");
                individual_Num = Console.ReadLine();
                for (int i = 0; i < memberList.Count; i++)
                {
                    if ((string)memberList[i].individual_num == individual_Num)
                    {
                        Console.Write("이름 :" + " " + memberList[i].name + " " + "나이 :" + " " + memberList[i].age + " " + "주민번호 :" + " " + memberList[i].individual_num + " " + "핸드폰번호 :" + " " + memberList[i].cellphone);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("찾으시는 정보의 회원이 없습니다.");
                        User_View();
                    }
                }
            }
            else if (Check_Num == 4)
            {
                Console.WriteLine("핸드폰번호를 입력해주세요.");
                cellphone = Console.ReadLine();
                for (int i = 0; i < memberList.Count; i++)
                {
                    if ((string)memberList[i].cellphone == cellphone)
                    {
                        Console.Write("이름 :" + " " + memberList[i].name + " " + "나이 :" + " " + memberList[i].age + " " + "주민번호 :" + " " + memberList[i].individual_num + " " + "핸드폰번호 :" + " " + memberList[i].cellphone);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("찾으시는 정보의 회원이 없습니다.");
                        User_View();
                    }
                }
            }
        }
        
        public int Memeber_Find(string name)
        {
            ui.Top_Space();
            ui.Left_space();
            for (int i = 0; i < memberList.Count; i++)
            {
               if ((string)memberList[i].name == name)
               {
                    Console.WriteLine("회원입니다.");
                    Console.WriteLine();
                    check_num = 1;
               }
               else
               {
                    Console.WriteLine("찾으시는 정보의 회원이 없습니다.");
                    check_num = 0;
               }
            }
            return check_num;
        }
            
        public void Member_Delete() // 회원 삭제
        {
            string name; 
            int Temp; 
            int Select_Num; // 중복됐을 때 User의 값을 입력받기 위한 변수
            List<int> CK = new List<int>(); // List CK 는 회원의 이름이 2명 이상 같은경우 처리하기해 List 에 위치를 찾기위해 생성.

            Console.WriteLine("회원삭제");
            Console.WriteLine("삭제하실 고객님의 이름을 입력해주세요.");
            name = Console.ReadLine();

            for (Temp = 0; Temp < memberList.Count; Temp++) // 몇번째에 위치해있는지 알기위해 생성된 List에 크기만큼 검사.
            {
                if ((string)memberList[Temp].name == name)
                {
                    CK.Add(Temp); // 위치값을 List에 입력
                }
                else 
                {
                    Console.WriteLine("삭제할 정보가 없습니다.");
                }
            }
            if (CK.Count == 1) // 이름이 1개일 때는 최초의 값을 삭제.
            {
                memberList.RemoveAt((int)CK[0]);
            }            
            else if (CK.Count >= 2) // 이름이 2개 이상일 때 중복된 이름중에서 어떤 것을 지울지 선택하기.
            {
                Console.WriteLine("중복된 이름이 있습니다.");
                for (int j = 0; j < CK.Count; j++)
                {
                    Console.Write("{0} : ", j);  // 중복된 이름을 출력하는데 List의 Name의 처음부터 출력.
                    Console.Write("이름 :" + " " + memberList[(int)CK[j]].name + " " + "나이 :" + " " + memberList[(int)CK[j]].age + " " + "주민번호 :" + " " + memberList[(int)CK[j]].individual_num + " " + "핸드폰번호 :" + " " + memberList[(int)CK[j]].cellphone);
                    Console.WriteLine();
                }
                Console.WriteLine("번호를 선택해주세요.");
                Select_Num = int.Parse(Console.ReadLine());

                memberList.RemoveAt((int)CK[Select_Num]); 
            }
        }

        public void Member_Information_Correct() // 회원 정보 수정
        {

            string correct_name;//초기 유저의 이름을 입력받는 변수
            string correct; // 이후 변경하게될 변수
            int Select_Num;

            Console.WriteLine("회원 정보 수정");
            Console.WriteLine("수정할 이름은? ");
            correct_name = Console.ReadLine();

            for (int i = 0; i < memberList.Count; i++)
            {
                if ((string)memberList[i].name == correct_name)
                {
                    Console.Write("이름 :" + " " + memberList[i].name + " " + "나이 :" + " " + memberList[i].age + " " + "주민번호 :" + " " + memberList[i].individual_num + " " + "핸드폰번호 :" + " " + memberList[i].cellphone);
                    Console.WriteLine();
                    Console.WriteLine("어떤 정보를 변경하시겠어요?");
                    Console.WriteLine("1. 이름");
                    Console.WriteLine("2. 나이");
                    Console.WriteLine("3. 주민번호");
                    Console.WriteLine("4. 핸드폰번호");
                    Select_Num = e.press_key(1, 4);

                    switch (Select_Num) // 선택한 Num로 체크.
                    {
                        case 1: 
                            {
                                Console.WriteLine("어떤 이름으로 변경하시겠어요?");
                                correct = Console.ReadLine();
                                for (int j = 0; j < memberList.Count; j++)
                                {
                                    string temp = (string)memberList[i].name; // Replace 메소드를 쓰기위해 string으로 형변환.
                                    temp = temp.Replace((string)memberList[i].name, correct);
                                    memberList[i].name = temp;
                                }
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("어떤 나이로 변경하시겠어요?");
                                correct = Console.ReadLine();
                                for (int j = 0; j < memberList.Count; j++)
                                {
                                    string temp = (string)memberList[i].age;
                                    temp = temp.Replace((string)memberList[i].age, correct);
                                    memberList[i].age = temp;
                                }
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("주민등록번호를 변경하시겠어요?");
                                correct= Console.ReadLine();
                                for (int j = 0; j < memberList.Count; j++)
                                {
                                    string temp = (string)memberList[i].individual_num;
                                    temp = temp.Replace((string)memberList[i].individual_num, correct);
                                    memberList[i].individual_num = temp;
                                }
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("변경하실 핸드폰번호를 입력해주세요.");
                                correct = Console.ReadLine();
                                for (int j = 0; j < memberList.Count; j++)
                                {
                                    string temp = (string)memberList[i].cellphone;
                                    temp = temp.Replace((string)memberList[i].cellphone, correct);
                                    memberList[i].cellphone = temp;
                                }
                                break;
                            }
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("찾으시는 정보의 회원이 없습니다."); 
                }

            }
        }

        public void Search_Book() 
        {
            string name;

            ui.Top_Space();
            ui.Left_space();

            Console.WriteLine("책 찾기");
            ui.Left_space();
            Console.WriteLine("찾을 책의 이름을 입력해주세요.");
            ui.Left_space();
            name = Console.ReadLine();

            for(int i=0; i<bookList.Count; i++)
            {
                if (bookList[i].rent==0)
                {
                    ui.Left_space();
                    Console.WriteLine("대여중입니다.");
                }
                if (name == bookList[i].bookname && bookList[i].rent ==1)
                {
                    ui.Left_space();
                    Console.WriteLine("책이름 : " + bookList[i].bookname + "작가 : " + " " + bookList[i].bookauthor + " " + "가격 : " + bookList[i].bookprice);
                }
            }

        }

        public void Print_Book()
        {
            ui.Top_Space();
            ui.Left_space();

            Console.WriteLine("보관중이며, 대여가능한 책을 모두 출력합니다. ");
            for(int i=0; i<bookList.Count; i++)
            {
                if(bookList[i].rent ==1)
                {
                    ui.Left_space();
                    Console.WriteLine(i + 1 + " 번" + " 책이름 " + bookList[i].bookname + " 작가 " + bookList[i].bookauthor + " 가격 : " + bookList[i].bookprice);
                }
                else if(bookList[i].rent == 0)
                {
                    ui.Left_space();
                    Console.WriteLine(i + 1 + " 번 현재 대여중입니다.");
                }
               
            }
        } // 도서 전부 출력

        public void Book_Rent() // 책대여
        {
            string name;
            int number;

            Console.WriteLine("빌리시는분 성함을 입력해주세요.");
            name = Console.ReadLine();
            D1 = DateTime.Now;

            Memeber_Find(name);
            if (check_num == 1) // Member_Find 에서 전달받은 int 형 check_num(회원정보가 존재하면 1)으로 대여가능여부 확인.
            {
                if (bookList.Count == 0) // Book이 등록되지 않았으면 책 없음 출력.
                {
                    Console.WriteLine("빌릴 책이 없습니다.");
                    Thread.Sleep(1500);
                    Console.Clear();
                    return;
                }
                if (bookList.Count > 0)
                {
                    Print_Book();
                    Console.WriteLine("빌리실 책의 번호를 입력해주세요.");
                    number = int.Parse(Console.ReadLine());
                    

                    if (number > bookList.Count) // 출력된 번호의 미만은 제한.
                    {
                        Console.Clear();
                        Console.WriteLine("빌릴 수 없는 책입니다.");
                    }
                    else if (1 <= number && number <= bookList.Count) // 1 번부터 출력되는 Print_Book 에서의 범위를맞추기 위해 조건 설정.
                    {
                        Console.Clear();
                        Console.WriteLine("대여되었습니다. 반납기간은 "+ D1.AddDays(7)+ "까지입니다.");
                        bookList[number - 1].rent = 0; // bookList 가 0부터 시작하기때문에 선택한값의 -1.
                    }
                }
            }
            else if(check_num == 0)
            {
                Console.WriteLine("회원이 아닙니다.");
            }
        }

        public void Book_Return()
        {
            string name, book_name;
            ui.Top_Space();
            ui.Left_space();

            Console.WriteLine("반납");
            ui.Left_space();
            Console.WriteLine("이름을 입력해주세요.");
            ui.Left_space();
            name = Console.ReadLine();

            Memeber_Find(name); // 회원인지 찾기.
            if(check_num ==1)
            {
                Console.Clear();
                ui.Top_Space();
                ui.Left_space();
                Console.WriteLine("책이름을 입력해주세요. ");
                book_name = Console.ReadLine();
                for(int i=0; i<bookList.Count; i++)
                {
                    if(bookList[i].bookname == book_name && bookList[i].rent == 0)
                    {
                        ui.Top_Space();
                        ui.Left_space();
                        bookList[i].rent = 1;
                        Console.WriteLine("책이 반납되었습니다. 이용해주셔서 감사합니다."); // 정상적인 반납
                        return;
                    }
                    else if(bookList[i].bookname == book_name && bookList[i].rent == 1) // 책이 이미 반납되어있는상태.
                    {
                        ui.Top_Space();
                        ui.Left_space();
                        Console.WriteLine("이미 책이 반납되었습니다.");
                        return;
                    }
                    else if(bookList[i].bookname != book_name && bookList[i].rent == 0) // 반납은 되지않았으나 책이름 오류
                    {
                        ui.Top_Space();
                        ui.Left_space();
                        Console.WriteLine("책이름이 다릅니다!");
                        return;
                    }
                }
            }
            else if(check_num == 0)
            {
                ui.Top_Space();
                ui.Left_space();
                Console.WriteLine("회원이 아닙니다.");
                return;
            }
        }
    }
}
