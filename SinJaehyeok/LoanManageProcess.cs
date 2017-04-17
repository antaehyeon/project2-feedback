using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensharp_study_assignment2_1v
{
    class LoanManageProcess
    {
        //모드 선택 시, 정수 입력 가능 범위
        const int SELECTMODE_RANGE_START = 1;
        const int SELECTMODE_RANGE_END = 3;

        Exceptions Exc = new Exceptions();
        Print print = new Print();
        //책을 대여하고 반납하는 회원정보와 도서정보의 데이터 공유를 위해 하위클래스에 종합회원정보리스트와 종합도서정보리스트를 둘 다 생성함
        List<MemberVO> MemberInfoListBot = new List<MemberVO>();
        List<BookVO> BookInfoListBot = new List<BookVO>();
        MemberVO TempMember = new MemberVO(null, null, null, null, null);
        BookVO TempBook = new BookVO(null, null, 0, 0);
        //도서 반납기간 출력을 위한 DateTime클래스 생성
        DateTime DueDate = new DateTime();

        int SelectMode;

        //생성자를 통해서 상위클래스의 종합회원정보리스트와 종합도서정보리스트를 현재 클래스로 받아옴. 동기화시킴
        public LoanManageProcess(List<MemberVO> MemberInfoListTop, List<BookVO> BookInfoListTop)
        {
            MemberInfoListBot = MemberInfoListTop;
            BookInfoListBot = BookInfoListTop;
        }
        //도서 대여 및 반납 모드의 기본 페이지
        public void LoanPage()
        {
            print.LoanPage();
            SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
            while (true)
            {
                switch (SelectMode)
                {
                    case 1:
                        LoanBook();
                        break;
                    case 2:
                        ReturnBook();
                        break;
                    case 3:
                        return;
                }
                print.LoanPage();
                SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
            }
        }
        //도서 대여 시, 빌리는 사람의 ID와 빌릴 도서제목을 입력해서, 도서 대여함
        //한 사람당 한 권만 빌릴 수 있게 설정했고, 책의 수량이 없으면 대출에 제한이 된다
        //도서 대여를 하게 되면 빌리는 사람의 정보에 빌린책과 반납일자 정보가 추가되고
        //빌려간 도서의 정보에는 빌려간 사람의 ID가 추가되고, 수량이 하나 빠지게 된다
        public void LoanBook()
        {
            DueDate = DateTime.Now;
            DueDate.AddDays(14).ToShortDateString();

            print.BasePage();
            Console.Write("ID : ");
            TempMember.MemberID = Exc.CheckIdInput();
            Console.Write("Book Name : ");
            TempBook.BookNAME = Exc.CheckNameInput();
            while (true)
            {
                foreach (MemberVO i in MemberInfoListBot)
                {
                    if (i.MemberID == TempMember.MemberID)
                    {
                        foreach (BookVO j in BookInfoListBot)
                        {
                            if(j.BookNAME == TempBook.BookNAME)
                            {
                                if (i.MemberLOAN != null)
                                {
                                    print.BasePage();
                                    Console.WriteLine("Return the book first");
                                    print.EnterReturn();
                                    return;
                                }
                                else if(j.BookQUANTITY < 1)
                                {
                                    print.BasePage();
                                    Console.WriteLine("Sorry, Someone borrowed it already");
                                    print.EnterReturn();
                                    return;
                                }
                                else
                                {
                                    i.MemberLOAN = j.BookNAME;
                                    i.MemberDATE = DueDate.AddDays(14).ToShortDateString();
                                    j.BookLOAN.Add(i.MemberID);
                                    j.BookQUANTITY--;
                                    Console.WriteLine("Thanks for using us. Duedate is " + i.MemberDATE);
                                    print.EnterReturn();
                                    return;
                                }
                            }
                        }
                    }
                }
                print.BasePage();
                Console.WriteLine("Incorrect username or book title. Try again\n");
                Console.Write("ID : ");
                TempMember.MemberID = Exc.CheckIdInput();
                Console.Write("Book Name : ");
                TempBook.BookNAME = Exc.CheckNameInput();
            }
        }
        //도서 반납시에는 책 빌려간 사람의 ID만 입력하면 도서 반납이 이뤄진다
        //반납을 하게 되면 책을 반납한 사람의 정보에 빌려간 도서와 반납일자 정보가 지워지고
        //반납한 도서의 정보에는 수량이 하나 늘어나고, 빌려간 사람의 이름이 지워지게 된다
        public void ReturnBook()
        {
            DueDate = DateTime.Now;

            print.BasePage();
            Console.Write("ID : ");
            TempMember.MemberID = Exc.CheckIdInput();
            while (true)
            {
                foreach (MemberVO i in MemberInfoListBot)
                {
                    if (i.MemberID == TempMember.MemberID)
                    {
                        if (i.MemberLOAN != null)
                        {
                            foreach(BookVO j in BookInfoListBot.ToList())
                            {
                                if(j.BookNAME == i.MemberLOAN)
                                {
                                    j.BookQUANTITY++;
                                    j.BookLOAN.Remove(i.MemberID);
                                }
                            }
                            i.MemberLOAN = null;
                            i.MemberDATE = null;
                            Console.WriteLine("Thanks for using us. Book return completed in " + DueDate);
                            print.EnterReturn();
                            return;
                        }
                        else
                        {
                            print.BasePage();
                            Console.WriteLine("You haven't borrowed the book");
                            print.EnterReturn();
                            return;
                        }
                    }
                }
                print.BasePage();
                Console.WriteLine("Incorrect username. Try again\n");
                Console.Write("ID : ");
                TempMember.MemberID = Exc.CheckIdInput();
            }
        }
        //도서 대여와 대출을 통해 변경된 종합회원정보 리스트와 종합도서정보 리스트를 반환해서, 상위클래스에서 유지하는 종합정보 리스트를 최신화 및 동기화함
        public List<MemberVO> getMemberInfoListBot()
        {
            return MemberInfoListBot;
        }
        public List<BookVO> getBookInfoListBot()
        {
            return BookInfoListBot;
        }
    }
}
