using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            MainPage mainPage = new MainPage();                                 // MainPage 클래스의 인스턴스 생성
            Display display = new Display();                                    // Display 클래스의 인스턴스 생성
            ArrayList memberArrayList = new ArrayList();                        // ArrayList 클래스의 memberArrayList 인스턴스 생성
            ArrayList bookArrayList = new ArrayList();                          // ArrayList 클래스의 bookArrayList 인스턴스 생성
            display.PrintMainPage();                                            // 도서 관리 시스템 메인 페이지 출력
            mainPage.RunMainPage(memberArrayList, bookArrayList);               // 메인 페이지 실행
        }
    }
}
