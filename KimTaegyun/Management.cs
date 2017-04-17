using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace BookManagement
{
    class Management
    {
        UI ui = new UI();

        Exception e = new Exception();
        List<BookVO> BookList;
        List<MemberVO> member;
        
        public Management (List<BookVO> book,List<MemberVO> member)
        {
            this.BookList = book;
            this.member = member;
        }

        public int Check_admin;



        public void Check_ID()
        {
            string id, pw;
            ui.Top_Space();
            ui.Left_space();
            Console.WriteLine(" 아이디를 입력하세요. ");
            ui.Left_space();
            id = Console.ReadLine();
            ui.Left_space();
            Console.WriteLine(" pw 를 입력하세요.");
            ui.Left_space();
            pw = Console.ReadLine();

            if (id == "admin") // Only Use admin
            {
                if (pw == "1111")
                {
                    Check_admin = 1;
                    Select();
                }
                else
                {
                    Console.WriteLine("비밀번호가 다릅니다!");
                    return;
                }  
            }
            else
            {
                Console.WriteLine("접근할 수 없습니다.");
                return;
            }
        }

        public void Select() // 관리자가 어떠한 일을 수행 할건지 선택하는 함수
        {
            Console.Clear();
            int num;
            ui.Top_Space();
            ui.Left_space();
            Console.WriteLine("1. 책추가");
            ui.Left_space();
            Console.WriteLine("2. 책삭제");
            ui.Left_space();
            Console.WriteLine("3. 정보변경");
            ui.Left_space();
            Console.WriteLine("4. 전체 회원 출력");
            ui.Left_space();
            num = e.press_key(1,4);

            if (num == 1)
            {
                Add_Book();
            }
            else if( num == 2)
            {
                Delete_Book();
            }
            else if(num == 3)
            {
                Correct_Book();
            }
            else if(num == 4)
            {
                Member_Output();
            }
        }

        public void Add_Book() // 책이름은 한권 씩만 존재.
        {
            string BookName, BookAuthor, BookPrice;
            int Rent;
            Console.Clear();
            ui.Top_Space();
            ui.Left_space();
            Console.WriteLine("책이름을 입력해주세요");
            ui.Left_space();
            BookName = Console.ReadLine();
            for(int i=0; i<BookList.Count; i++) // 중복 책이름 검사
            {
                if(BookList[i].bookname == BookName) // 책이름과 입력받은 이름이 같은경우.
                {
                    ui.Left_space();
                    Console.WriteLine("중복된 책입니다!");
                    return;
                }
            }
            Console.Clear();
            ui.Top_Space();
            ui.Left_space();
            Console.WriteLine("작가이름을 입력해주세요");
            ui.Left_space();
            BookAuthor = Console.ReadLine();
            Console.Clear();
            ui.Top_Space();
            ui.Left_space();
            Console.WriteLine("책가격을 입력해주세요");
            ui.Left_space();
            BookPrice = Console.ReadLine();

            Rent = 1;

            BookList.Add(new BookVO(BookName, BookAuthor, BookPrice, Rent)); // Add 할때는 new 생성자와함께 BookVO로 전달.
        }

        public void Delete_Book()
        {
            string BookName;
            Console.Clear();
            ui.Top_Space();
            ui.Left_space();
            Console.WriteLine("삭제할 책의 이름을 입력해주세요.");
            ui.Left_space();
            BookName = Console.ReadLine();

            for(int i=0; i<BookList.Count; i++) 
            {
                if(BookList[i].bookname == BookName)
                {
                    BookList.Remove(BookList[i]); 
                }
            }

        } // 책을 삭제하는 것.

        public void Correct_Book()
        {
            string correct_name,correct;
            int Select_Num;
            Console.Clear();
            ui.Top_Space();
            ui.Left_space();
            Console.WriteLine("변경할 책의 이름");
            ui.Left_space();
            correct_name = Console.ReadLine();

            for (int i = 0; i < BookList.Count; i++)
            {
                if ((string)BookList[i].bookname == correct_name) // 책 name 과 입력받은 name의 일치 여부
                {
                    Console.Write("책 이름 :" + " " + BookList[i].bookname + " " + "작가 :" + " " + BookList[i].bookauthor + " " + "가격 :" + " " + BookList[i].bookprice);
                    Console.WriteLine();
                    Console.WriteLine("어떤 정보를 변경하시겠어요?");
                    Console.WriteLine("1. 책 이름");
                    Console.WriteLine("2. 작가");
                    Console.WriteLine("3. 가격");
                    ui.Left_space();
                    Select_Num = e.press_key(1, 3);

                    switch (Select_Num)
                    {
                        case 1: 
                            {
                                Console.Clear();
                                ui.Top_Space();
                                ui.Left_space();

                                Console.WriteLine("어떤 이름으로 변경하시겠어요?");
                                ui.Left_space();
                                correct = Console.ReadLine();

                                for (int j = 0; j < BookList.Count; j++) // String 을 이용한 Replace 메소드 사용.
                                {
                                    string temp = (string)BookList[i].bookname;
                                    temp = temp.Replace((string)BookList[i].bookname, correct);
                                    BookList[i].bookname = temp;
                                }
                                break;
                            }
                        case 2: 
                            {
                                Console.Clear();
                                ui.Top_Space();
                                ui.Left_space();

                                Console.WriteLine("어떤 이름으로 변경하시겠어요?");
                                ui.Left_space();
                                correct = Console.ReadLine();

                                for (int j = 0; j < BookList.Count; j++)
                                {
                                    string temp = (string)BookList[i].bookname;
                                    temp = temp.Replace((string)BookList[i].bookname, correct);
                                    BookList[i].bookname = temp;
                                }
                                break;
                            }
                        case 3: 
                            {
                                Console.Clear();
                                ui.Top_Space();
                                ui.Left_space();

                                Console.WriteLine("어떤 가격으로 설정하시겠어요?");
                                ui.Left_space();
                                correct = Console.ReadLine();

                                for (int j = 0; j < BookList.Count; j++)
                                {
                                    string temp = (string)BookList[i].bookname;
                                    temp = temp.Replace((string)BookList[i].bookname, correct);
                                    BookList[i].bookname = temp;
                                }
                                break;
                            }
                    }
                }
                else
                {
                    Console.Clear();
                    ui.Top_Space();
                    ui.Left_space();
                    Console.WriteLine("변경할 책이름이 다릅니다.");
                    Thread.Sleep(1500);
                }
            }
        } // 책 정보의 수정

        public void Member_Output()
        {
            ui.Top_Space();
            ui.Left_space();

            Console.WriteLine("전체 회원 출력");
            for(int i =0; i<member.Count; i++)
            {
                ui.Left_space();

                Console.WriteLine(i + 1 + " 번" + " " + "이름 : " + member[i].name + " " + "나이 : " + member[i].age
                                    + " " + " 주민번호 : " + member[i].individual_num + " " + " 휴대폰번호 : " + member[i].cellphone);
            }
        } // 멤버 전체 출력
    }
 }
