using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensharp_study_assignment2_1v
{
    class BookManageProcess
    {
        const int CONFIRM_YES = 1;              // ConfirmingProcess()에서의 return값이 1이면 확인한 것이고, 2이면 취소한 것임
        const int SELECTMODE_RANGE_START = 1;   // 모드를 선택할 때, 고를 수 있는 정수의 범위 1부터 5까지 선택할 수 있음
        const int SELECTMODE_RANGE_END = 5;     // 그 이상, 이하는 입력받을 수 없음
        const int MIN_QUANTITY = 1;             // 책의 수량을 입력받을 때, 입력 가능한 정수의 범위 최소 1부터 최대 99까지 선택 가능
        const int MAX_QUANTITY = 99;            // 책의 수량을 1권부터 99권까지 입력 가능

        Exceptions Exc = new Exceptions();
        Print print = new Print();
        // MainPage()하위 클래스에서의 총 책 정보를 담아놓는 BookInfoListBot
        // 하위클래스에서 상위클래스로 올라가게되면, 변경된 정보를 유지하기위해 리스트를 그대로 반환해서 상위클래스의 리스트에 복사해서 최신화시킨다
        List<BookVO> BookInfoListBot = new List<BookVO>();
        // 정보가 변경될 때마다 Temp VO 객체에 임시로 책의 정보를 입력받아서, 그 다음에 BookInfoListBot리스트에 값을 넣어준다
        BookVO Temp = new BookVO(null, null, 0, 0);

        int SelectMode;

        // 생성자로 상위클래스에서 관리하는 종합적인 책 정보 관리 리스트를 받아와서, 하위클래스에서도 종합적인 책정보들을 최신화시킨다
        public BookManageProcess(List<BookVO> _Temp)
        {
            BookInfoListBot = _Temp;
        }
        // Book Management 모드의 기본 구조, 기본 페이지
        public void BookPage()
        {
            print.BookPage();
            SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
            while (true)
            {
                switch (SelectMode)
                {
                    case 1:
                        RegisterBookData();
                        break;
                    case 2:
                        UpdateBookData();
                        break;
                    case 3:
                        DeleteBookData();
                        break;
                    case 4:
                        SearchBookData();
                        break;
                    case 5:
                        return;
                }
                print.BookPage();
                SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
            }
        }
        // 새로운 도서 등록, 도서제목, 저자, 가격, 수량을 입력받으면 새 도서가 등록됨
        // 가격과 수량은 범위 안의 값만 할당할 수 있음
        // 가격은 $1000부터 100000까지, 수량은 1권에서 99권까지 입력 가능
        public void RegisterBookData()
        {
            BookVO NewBook = new BookVO(null, null, 0, 0);
            print.BasePage();
            Console.Write("Input new Book Name : ");
            NewBook.BookNAME = Exc.CheckNameInput();
            Console.WriteLine();
            Console.Write("Input Author : ");
            NewBook.BookAUTHOR = Exc.CheckNameInput();
            Console.WriteLine();
            Console.Write("Input Price(1000~100000) : $");
            NewBook.BookPRICE = Exc.CheckPriceInput();
            Console.WriteLine();
            Console.Write("Input Quantity(1~99) : ");
            NewBook.BookQUANTITY = Exc.CheckQuantityInput(MIN_QUANTITY, MAX_QUANTITY);
            Console.WriteLine();

            // 새로 등록한 도서를 하위클래스에서 관리하는 종합도서목록 리스트에 추가시킴
            BookInfoListBot.Add(NewBook);

            print.BasePage();
            Console.WriteLine(NewBook.BookNAME + " Registered. Thank You");
            print.EnterReturn();
        }
        // 도서 정보 업데이트, 도서명을 통해 변경할 도서 정보를 고를 수 있음
        // 도서 제목, 저자, 가격, 수량을 변경할 수 있음
        public void UpdateBookData()
        {
            print.BasePage();
            Console.WriteLine("Which Book Data to Update ?");
            Console.Write("Book Name : ");
            Temp.BookNAME = Exc.CheckNameInput();
            while (true)
            {
                foreach (BookVO i in BookInfoListBot)
                {
                    if (Temp.BookNAME == i.BookNAME)
                    {
                        print.BookUpdatePage();
                        SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
                        switch (SelectMode)
                        {
                            case 1:
                                print.BasePage();
                                Console.Write("Update Name of the Book : ");
                                Temp.BookNAME = Exc.CheckNameInput();
                                i.BookNAME = Temp.BookNAME;
                                Console.WriteLine();
                                Console.WriteLine("Updated Name of the Book");
                                print.EnterReturn();
                                return;
                            case 2:
                                print.BasePage();
                                Console.Write("Update Author of the Book : ");
                                Temp.BookAUTHOR = Exc.CheckNameInput();
                                i.BookAUTHOR = Temp.BookAUTHOR;
                                Console.WriteLine();
                                Console.WriteLine("Updated Author of the Book");
                                print.EnterReturn();
                                return;
                            case 3:
                                print.BasePage();
                                Console.Write("Update Price of the Book : $");
                                Temp.BookPRICE = Exc.CheckPriceInput();
                                i.BookPRICE = Temp.BookPRICE;
                                Console.WriteLine();
                                Console.WriteLine("Updated Price of the Book");
                                print.EnterReturn();
                                return;
                            case 4:
                                print.BasePage();
                                Console.Write("Update Quantity of the Book(1~99) : ");
                                Temp.BookQUANTITY = Exc.CheckQuantityInput(1, 99);
                                i.BookQUANTITY = Temp.BookQUANTITY;
                                Console.WriteLine();
                                Console.WriteLine("Updated Quantity of the Book");
                                print.EnterReturn();
                                return;
                            case 5:
                                return;
                        }
                    }
                }
                print.BasePage();
                Console.WriteLine("Incorrect Book Name. Try again");
                Console.Write("Book Name : ");
                Temp.BookNAME = Exc.CheckNameInput();
            }
        }
        // 등록되어 있는 도서 정보를 삭제함
        // 삭제하면 하위클래스에서 관리하는 종합도서목록 리스트에서 삭제한 도서정보를 뺀다
        public void DeleteBookData()
        {
            print.BasePage();
            Console.WriteLine("Which Book Data to Delete ?");
            Console.Write("Book Name : ");
            Temp.BookNAME = Exc.CheckNameInput();
            while (true)
            {
                foreach (BookVO i in BookInfoListBot.ToList())
                {
                    if (Temp.BookNAME == i.BookNAME)
                    {
                        if (print.ConfirmingProcess() == CONFIRM_YES)
                        {
                            BookInfoListBot.Remove(i);
                            Console.WriteLine();
                            Console.WriteLine("Book Data Deleted");
                            print.EnterReturn();
                            return;
                        }
                        else
                            return;
                    }
                }
                print.BasePage();
                Console.WriteLine("Incorrect Book Name. Try again");
                Console.Write("Book Name : ");
                Temp.BookNAME = Exc.CheckNameInput();
            }
        }
        // 등록되어 있는 도서정보를 찾음. 도서명, 저자, 가격을 통해 도서 정보를 볼 수 있고, 총 도서 정보 목록을 볼 수도 있음
        // 종합도서목록 리스트를 순회하면서 해당하는 값이 있으면 출력함
        public void SearchBookData()
        {
            int cnt = 0;
            print.BookSearchPage();
            SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
            while (true)
            {
                switch (SelectMode)
                {
                    //도서명으로 도서 정보 검색
                    case 1:
                        print.BasePage();
                        Console.Write("Book Name : ");
                        Temp.BookNAME = Exc.CheckNameInput();
                        while (true)
                        {
                            foreach (BookVO i in BookInfoListBot)
                            {
                                if (i.BookNAME == Temp.BookNAME)
                                {
                                    Console.WriteLine("\t" + i.BookNAME + "\t\t" + i.BookAUTHOR + "\t\t$" + i.BookPRICE + "\t" + i.BookQUANTITY);
                                    Console.Write("\t Member who borrowed the book : ");
                                    foreach(string j in i.BookLOAN)
                                    {
                                        Console.Write(j + ", ");
                                    }
                                    Console.WriteLine("\n");
                                    cnt++;
                                }
                            }
                            if (cnt < 1) // 찾고자하는 도서 정보가 없는 경우 다시입력받음
                            {
                                Console.WriteLine("No Data Existing. Try again");
                                Console.Write("Book Name : ");
                                Temp.BookNAME = Exc.CheckNameInput();
                                cnt = 0;
                            }
                            else
                            {
                                print.EnterReturn();
                                cnt = 0;
                                break;
                            }
                        }
                        break;
                    //저자로 도서 정보 검색
                    case 2:
                        print.BasePage();
                        Console.Write("Author : ");
                        Temp.BookAUTHOR = Exc.CheckNameInput();
                        while (true)
                        {
                            foreach (BookVO i in BookInfoListBot)
                            {
                                if (i.BookAUTHOR == Temp.BookAUTHOR)
                                {
                                    Console.WriteLine("\t" + i.BookNAME + "\t\t" + i.BookAUTHOR + "\t\t$" + i.BookPRICE + "\t" + i.BookQUANTITY);
                                    Console.Write("\t Member who borrowed the book : ");
                                    foreach (string j in i.BookLOAN)
                                    {
                                        Console.Write(j + ", ");
                                    }
                                    Console.WriteLine("\n");
                                    cnt++;
                                }
                            }
                            if (cnt < 1) // 찾고자하는 도서 정보가 없는 경우 다시입력받음
                            {
                                Console.WriteLine("No Data Existing. Try again");
                                Console.Write("Author : ");
                                Temp.BookAUTHOR = Exc.CheckNameInput();
                                cnt = 0;
                            }
                            else
                            {
                                print.EnterReturn();
                                cnt = 0;
                                break;
                            }
                        }
                        break;
                    // 가격으로 도서정보 검색
                    case 3:
                        print.BasePage();
                        Console.Write("Price : $");
                        Temp.BookPRICE = Exc.CheckPriceInput();
                        while (true)
                        {
                            foreach (BookVO i in BookInfoListBot)
                            {
                                if (i.BookPRICE == Temp.BookPRICE)
                                {
                                    Console.WriteLine("\t" + i.BookNAME + "\t\t" + i.BookAUTHOR + "\t\t$" + i.BookPRICE + "\t" + i.BookQUANTITY);
                                    Console.Write("\t Member who borrowed the book : ");
                                    foreach (string j in i.BookLOAN)
                                    {
                                        Console.Write(j + ", ");
                                    }
                                    Console.WriteLine("\n");
                                    cnt++;
                                }
                            }
                            if (cnt < 1) // 찾고자하는 도서 정보가 없는 경우 다시입력받음
                            {
                                Console.WriteLine("No Data Existing. Try again");
                                Console.Write("Price : $");
                                Temp.BookPRICE = Exc.CheckPriceInput();
                                cnt = 0;
                            }
                            else
                            {
                                print.EnterReturn();
                                cnt = 0;
                                break;
                            }
                        }
                        break;
                    // 등록되어 있는 총 도서목록을 출력
                    case 4:
                        print.BasePage();
                        foreach (BookVO i in BookInfoListBot)
                        {
                            Console.WriteLine("\t" + i.BookNAME + "\t\t" + i.BookAUTHOR + "\t\t$" + i.BookPRICE + "\t" + i.BookQUANTITY);
                            Console.Write("\t Member who borrowed the book : ");
                            foreach (string j in i.BookLOAN)
                            {
                                Console.Write(j + ", ");
                            }
                            Console.WriteLine("\n");
                            cnt++;
                        }
                        print.EnterReturn();
                        break;
                    case 5:
                        return;
                }
                print.BookSearchPage();
                SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
            }
        }
        //도서관리모드에서 변경된 종합도서목록 리스트를 반환해서 상위클래스에서 유지하는 종합도서목록 리스트를 최신화, 동기화 시킴.
        public List<BookVO> getBookInfoListBot()
        {
            return BookInfoListBot;
        }
    }
}
