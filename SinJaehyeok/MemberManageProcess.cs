using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensharp_study_assignment2_1v
{
    class MemberManageProcess
    {
        const int CONFIRM_YES = 1;
        const int SELECTMODE_RANGE_START = 1;
        const int SELECTMODE_RANGE_END = 4;

        Exceptions Exc = new Exceptions();
        Print print = new Print();
        // MainPage()하위 클래스에서의 총 회원 정보를 담아놓는 BookInfoListBot
        // 하위클래스에서 상위클래스로 올라가게되면, 변경된 정보를 유지하기위해 리스트를 그대로 반환해서 상위클래스의 리스트에 복사해서 최신화시킨다
        List<MemberVO> MemberInfoListBot = new List<MemberVO>();
        MemberVO Temp = new MemberVO(null, null, null, null, null);

        int SelectMode;

        //생성자를 통해서 상위클래스의 종합회원정보리스트와 종합도서정보리스트를 현재 클래스로 받아옴. 동기화시킴
        public MemberManageProcess(List<MemberVO> _Temp)
        {
            MemberInfoListBot = _Temp;
        }
        //회원관리모드의 기본 페이지
        public void MemberPage()
        {
            print.MemberPage();
            SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
            while (true)
            {
                switch (SelectMode)
                {
                    case 1:
                        UpdateMemberData();
                        break;
                    case 2:
                        DeleteMemberData();
                        break;
                    case 3:
                        SearchMemberData();
                        break;
                    case 4:
                        return;
                }
                print.MemberPage();
                SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
            }
        }
        //회원정보 업데이트할 때, 사용자 ID를 통해서 접근해서 변경할 회원정보를 선택함
        //ID는 수정 시, 다른 것들과 고유하게 중복될 수 없게 설정
        public void UpdateMemberData()
        {
            int cnt = 0;

            print.BasePage();
            Console.WriteLine("Whose Data to Update ?");
            Console.Write("ID : ");
            Temp.MemberID = Exc.CheckIdInput();
            while(true)
            {
                foreach(MemberVO i in MemberInfoListBot)
                {
                    if(Temp.MemberID == i.MemberID) 
                    {
                        print.MemberUpdatePage();
                        SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
                        switch (SelectMode)
                        {
                            case 1:
                                print.BasePage();
                                Console.Write("Input new ID : ");
                                Temp.MemberID = Exc.CheckIdInput();

                                foreach (MemberVO j in MemberInfoListBot)
                                {
                                    if (Temp.MemberID == j.MemberID)
                                        cnt++;
                                }
                                while (cnt > 0)
                                {
                                    Console.WriteLine("Sorry, that ID is already taken");
                                    Console.Write("Input new ID : ");
                                    Temp.MemberID = Exc.CheckIdInput();
                                    cnt = 0;
                                    foreach (MemberVO j in MemberInfoListBot)
                                    {
                                        if (Temp.MemberID == j.MemberID)
                                            cnt++;
                                    }
                                }
                                i.MemberID = Temp.MemberID;
                                Console.WriteLine();
                                Console.WriteLine("New ID updated");
                                print.EnterReturn();
                                return;
                            case 2:
                                print.BasePage();
                                Console.Write("Input new PW : ");
                                Temp.MemberPSWD = Exc.CheckPasswordInput();
                                i.MemberPSWD = Temp.MemberPSWD;
                                Console.WriteLine();
                                Console.WriteLine("New PW updated");
                                print.EnterReturn();
                                return;
                            case 3:
                                print.BasePage();
                                Console.Write("Input new Name : ");
                                Temp.MemberNAME = Exc.CheckMemberNameInput();
                                i.MemberNAME = Temp.MemberNAME;
                                Console.WriteLine();
                                Console.WriteLine("New Name updated");
                                print.EnterReturn();
                                return;
                            case 4:
                                return;
                        }
                    }
                }
                print.BasePage();
                Console.WriteLine("Incorrect Member ID. Try again");
                Console.Write("ID : ");
                Temp.MemberID = Exc.CheckIdInput();
            }
        }
        //회원 정보 삭제
        public void DeleteMemberData()
        {
            print.BasePage();
            Console.WriteLine("Whose Data to Delete ?");
            Console.Write("ID : ");
            Temp.MemberID = Exc.CheckIdInput();
            while(true)
            {
                foreach(MemberVO i in MemberInfoListBot.ToList())
                {
                    if(Temp.MemberID == i.MemberID)
                    {
                        if (print.ConfirmingProcess() == CONFIRM_YES)
                        {
                            MemberInfoListBot.Remove(i);
                            Console.WriteLine();
                            Console.WriteLine("Member Data Deleted");
                            print.EnterReturn();
                            return;
                        }
                        else
                            return;
                    }
                }
                print.BasePage();
                Console.WriteLine("Incorrect Member ID. Try again");
                Console.Write("ID : ");
                Temp.MemberID = Exc.CheckIdInput();
            }
        }
        //회원 정보 찾기 및 전체 출력
        public void SearchMemberData()
        {
            int cnt = 0;
            print.MemberSearchPage();
            SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
            while (true)
            {
                switch(SelectMode)
                {
                    case 1://ID를 통해서 검색
                        print.BasePage();
                        Console.Write("ID : ");
                        Temp.MemberID = Exc.CheckIdInput();
                        while(true)
                        {
                            foreach (MemberVO i in MemberInfoListBot)
                            {
                                if (i.MemberID == Temp.MemberID)
                                {
                                    Console.WriteLine("\t" + i.MemberID + "\t\t" + i.MemberNAME + "\t\t" + i.MemberLOAN + "\t\t" + i.MemberDATE);
                                    cnt++;
                                }                                
                            }
                            if (cnt < 1)
                            {
                                Console.WriteLine("No Data Existing. Try again");
                                Console.Write("ID : ");
                                Temp.MemberID = Exc.CheckIdInput();
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
                    case 2://이름을 통해서 검색
                        print.BasePage();
                        Console.Write("Name : ");
                        Temp.MemberNAME = Exc.CheckMemberNameInput();
                        while (true)
                        {
                            foreach (MemberVO i in MemberInfoListBot)
                            {
                                if (i.MemberNAME == Temp.MemberNAME)
                                {
                                    Console.WriteLine("\t" + i.MemberID + "\t\t" + i.MemberNAME + "\t\t" + i.MemberLOAN + "\t\t" + i.MemberDATE);
                                    cnt++;
                                }
                            }
                            if (cnt < 1)
                            {
                                Console.WriteLine("No Data Existing. Try again");
                                Console.Write("Name : ");
                                Temp.MemberID = Exc.CheckMemberNameInput();
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
                    case 3://등록된 모든 회원 정보 출력
                        print.BasePage();
                        foreach (MemberVO i in MemberInfoListBot)
                        {
                            Console.WriteLine("\t" + i.MemberID + "\t\t" + i.MemberNAME + "\t\t" + i.MemberLOAN + "\t\t" + i.MemberDATE);
                        }
                        print.EnterReturn();
                        break;
                    case 4:
                        return;
                }
                print.MemberSearchPage();
                SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
            }
        }
        //하위클래스의 종합회원정보 리스트를 반환해서 상위클래스에서 유지하는 종합정보 리스트를 최신화 및 동기화함
        public List<MemberVO> getMemberInfoListBot()
        {
            return MemberInfoListBot;
        }
    }
}
