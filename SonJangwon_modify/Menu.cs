using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Menu
    {
        BasicScreen basic_screen;               //기본화면
        Register register;                      //회원 등록 클래스
        LogIn login;                            //회원 로그인& 그 이후
        Administrator admin;                    //관리자
        Exception exception;                    //예외처리클래스
        public Menu()
        {                                           ////생성자에서 다른클래스들을 호출하고 VO를 사용하기 위해 그 안에 Menu클래스 자신도 매개변수로 보내줬습니다.

            exception = new Exception(this);
            basic_screen = new BasicScreen();
            register = new Register(this);
            login = new LogIn(this);
            admin = new Administrator(this);


        }
        public Register getRegister()           //List<VO>가 존재하는 두개의 클래스를 MAIN함수에서 호출했습니다.
        {
            return register;
        }
        public Administrator getAdmin()
        {
            return admin;
        }
        public void menus()
        {
            int ChosenNum;
            basic_screen.MenuScreen();
            Console.WriteLine();
            ChosenNum=exception.exceptionnum(3);            //숫자3개 입력받을 떄 예외처리입니다.
            switch(ChosenNum)
            {
                case 1:
                    register.registers();
                    break;
                case 2:
                    login.Logins();
                    login.User();
                    break;
                case 3:
                    admin.Administrators();
                    break;
            }
            

        }
    }

}
