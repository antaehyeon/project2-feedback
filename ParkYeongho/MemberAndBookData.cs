using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class MemberAndBookData
    {
        public void InitMemberAndBookData(ArrayList memberArrayList, ArrayList bookArrayList)                               // 회원 및 도서 데이터를 초기화
        {
            memberArrayList.Add(new MemberVO("youngho", "930422", "박영호", "01028153651"));
            memberArrayList.Add(new MemberVO("jaehyuk", "iloveManU", "신재혁", "01033836782"));
            memberArrayList.Add(new MemberVO("janwon", "Komjanwon58", "손장원", "01052626832"));
            memberArrayList.Add(new MemberVO("jiyoon", "jiyoon4ever", "박지윤", "01021904360"));
            memberArrayList.Add(new MemberVO("hyowan", "TTunseom123", "박효완", "01044002779"));
            memberArrayList.Add(new MemberVO("jonwon", "coolguy33", "최종원", "01089336478"));
            memberArrayList.Add(new MemberVO("taekyoon", "ansan360", "김태균", "01089040585"));
            memberArrayList.Add(new MemberVO("moonsu", "liverpoolLove", "육문수", "01029293308"));

            bookArrayList.Add(new BookVO("1", "데이터구조", "국형준", "교보문고", "15000", "대여 가능"));
            bookArrayList.Add(new BookVO("2", "데이터베이스 개론", "김연희", "한빛아카데미", "25000", "대여 가능"));
            bookArrayList.Add(new BookVO("3", "운영체제", "조유근", "프로텍미디어", "28000", "대여 가능"));
            bookArrayList.Add(new BookVO("4", "KREYSZIG 공업수학", "ERWIN KREYSZIG", "법한서적주식회사", "30000", "대여 가능"));

        }
    }
}
