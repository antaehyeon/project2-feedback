using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Display
    {
        public void PrintMemberPage()                                                                                       // 회원 관리 페이지 출력
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  ┌────────────────────────────────────────────────────────┐");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                 회 원 관 리                                                    │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              1.  회원 등록                                                     │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              2.  회원 수정                                                     │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              3.  회원 삭제                                                     │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              4.  회원 검색                                                     │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              5.  회원 출력                                                     │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              6.  나가기                                                        │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  └────────────────────────────────────────────────────────┘");
            Console.Write("                                                                                  메뉴를 선택하세요...  ");
        }
        public void PrintMemberRegisterOrModify(string firstLetter, string secondLetter)                                    // 회원 등록 또는 회원 수정 페이지 출력
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  ┌────────────────────────────────────────────────────────┐");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                 회 원 {0} {1}                                                    │", firstLetter, secondLetter);
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                아이디    :                          (영문자 혹은 숫자 4~12자리)                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                비밀번호  :                          (영문자 혹은 숫자 4~12자리)                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                이름      :                          (한글만 입력 가능)                         │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                연락처    :                          ('-' 구분 문자 없이 번호만 입력)           │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  └────────────────────────────────────────────────────────┘");
        }


        public void PrintBookPage()                                                                                            // 도서 관리 페이지 출력
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  ┌────────────────────────────────────────────────────────┐");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                 도 서 관 리                                                    │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              1.  도서 등록                                                     │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              2.  도서 수정                                                     │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              3.  도서 삭제                                                     │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              4.  도서 검색                                                     │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              5.  도서 내역                                                     │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              6.  나가기                                                        │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  └────────────────────────────────────────────────────────┘");
            Console.Write("                                                                                  메뉴를 선택하세요...  ");
        }
        public void PrintMainPage()                                                                                             // 메인 페이지 출력
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  ┌────────────────────────────────────────────────────────┐");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                            도 서  관 리  시 스 템                                              │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              1.  회원 관리                                                     │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              2.  도서 관리                                                     │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              3.  도서 대여 및 반납                                             │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              4.  종료                                                          │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  └────────────────────────────────────────────────────────┘");
            Console.Write("                                                                                  메뉴를 선택하세요...  ");
        }
        public void PrintBookRegisterOrModify(string firstLetter, string secondLetter)                                          // 도서 등록 또는 도서 수정 페이지 출력
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  ┌────────────────────────────────────────────────────────┐");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                 도 서 {0} {1}                                                    │", firstLetter, secondLetter);
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                              제목    :                            (1~12자리 입력 가능)                         │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                              저자    :                            (1~12자리 입력 가능)                         │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                              출판사  :                            (1~12자리 입력 가능)                         │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                              가격    :                            (숫자만 입력 가능)                           │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  └────────────────────────────────────────────────────────┘");
        }
        
        public void PrintRentAndReturnBook()                                                                                    // 도서 대여 및 반납 페이지 출력
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  ┌────────────────────────────────────────────────────────┐");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                             도 서  대 여  및  반 납                                            │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              1.  도서 대여                                                     │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              2.  도서 반납                                                     │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              3.  대여 내역 조회                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                              4.  나가기                                                        │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  └────────────────────────────────────────────────────────┘");
            Console.Write("                                                                                  메뉴를 선택하세요...  ");
        }
        public void BookUpperOutline()                                                                                          // 도서 정보 카테고리 Outline 출력
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  ─────────────────────────────────────────────────────────");
            Console.WriteLine("     번호   제목                  저자               출판사               가격        대여       반납예정일         ");
            Console.WriteLine("  ─────────────────────────────────────────────────────────");
        }

        public void MemberUpperOutline()                                                                                        // 회원 정보 카테고리 Outline 출력
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  ─────────────────────────────────────────────────────────");
            Console.WriteLine("               아이디                 비밀번호                  이름                    연락처                 ");
            Console.WriteLine("  ─────────────────────────────────────────────────────────");
        }

        public void Outline()                                                                                                   // 기본 네모 Outline 출력
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  ┌────────────────────────────────────────────────────────┐");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  │                                                                                                                │");
            Console.WriteLine("  └────────────────────────────────────────────────────────┘");
        }
    }
}
