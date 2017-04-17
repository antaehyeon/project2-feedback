using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensharp_study_assignment2_1v
{
    class SignInProcess
    {
        const int SELECTMODE_RANGE_START = 1;
        const int SELECTMODE_RANGE_END = 3;

        Exceptions Exc = new Exceptions();
        Print print = new Print();
        List<MemberVO> MemberInfoListBot = new List<MemberVO>();
        //로그인 여부 판단하기위해 사용
        bool SignedIn;

        string TempId;
        string TempPw;

        //상위클래스 MainFrame에서 로그인 했는지 안 했는지 판단하는 bool SignedIn을 받아옴
        public SignInProcess(List<MemberVO> _Temp, bool _SignedIn)
        {
            MemberInfoListBot = _Temp;
            SignedIn = _SignedIn;
        }
        //로그인 및 회원가입 모드의 기본페이지
        public void SignInPage()
        {
            int SelectMode;
            
            print.SignPage();
            SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
            while (true)
            {
                switch (SelectMode)
                {
                    case 1:
                        SignIn();
                        return;
                    case 2:
                        SignUp();
                        break;
                    case 3:
                        return;
                }
                print.SignPage();
                SelectMode = Exc.CheckNumberInput(SELECTMODE_RANGE_START, SELECTMODE_RANGE_END);
            }
        }
        //로그인 기능
        public void SignIn()
        {
            print.BasePage();
            Console.Write("ID : ");
            TempId = Exc.CheckIdInput();
            Console.WriteLine();
            Console.Write("PW : ");
            TempPw = Exc.CheckPasswordInput();

            while(true)
            {
                foreach (MemberVO i in MemberInfoListBot)
                {
                    if (i.MemberID == TempId && i.MemberPSWD == TempPw)
                    {
                        SignedIn = true;
                        print.BasePage();
                        Console.WriteLine("Hello " + i.MemberNAME + "\n");
                        print.EnterReturn();
                        return;
                    }
                }
                print.BasePage();
                Console.WriteLine("Incorrect username or password. Try again\n");
                Console.Write("ID : ");
                TempId = Exc.CheckIdInput();
                Console.WriteLine();
                Console.Write("PW : ");
                TempPw = Exc.CheckPasswordInput();
            }
            
        }
        //회원가입, 회원등록 기능, ID는 유일한 값만 가질 수 있음
        public void SignUp()
        {
            int cnt = 0;
            
            MemberVO Temp = new MemberVO(null, null, null, null, null);
            print.BasePage();
            Console.Write("Input new ID : ");
            Temp.MemberID = Exc.CheckIdInput();

            foreach (MemberVO i in MemberInfoListBot)
            {
                if (Temp.MemberID == i.MemberID)
                    cnt++;
            }
            while (cnt > 0)
            {
                Console.WriteLine("Sorry, that ID is already taken");
                Console.Write("Input new ID : ");
                Temp.MemberID = Exc.CheckIdInput();
                cnt = 0;
                foreach (MemberVO i in MemberInfoListBot)
                {
                    if (Temp.MemberID == i.MemberID)
                        cnt++;
                }
            }
            Console.WriteLine();
            Console.Write("Input new PW : ");
            Temp.MemberPSWD = Exc.CheckPasswordInput();
            Console.WriteLine("\n");
            Console.Write("Input new Name : ");
            Temp.MemberNAME = Exc.CheckMemberNameInput();

            MemberInfoListBot.Add(Temp);

            print.BasePage();
            Console.WriteLine("Welcome " + Temp.MemberNAME);
            print.EnterReturn();
        }
        //하위클래스의 종합회원정보 리스트를 반환해서 상위클래스에서 유지하는 종합정보 리스트를 최신화 및 동기화함
        public List<MemberVO> getMemberInfoListBot()
        {
            return MemberInfoListBot;
        }
        //로그인 성공시, 로그인 여부를 상위클래스로 반환함
        public bool getSignedIn()
        {
            return SignedIn;
        }
    }
}
