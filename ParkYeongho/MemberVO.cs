using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class MemberVO
    {
        private string memberID = "";
        private string memberPSW = "";
        private string memberName = "";
        private string memberPhone = "";
        
        public MemberVO() { }                                                                               // MemberVO의 기본 생성자 생성
        public MemberVO(string aMemberID, string aMemberPSW, string aMemberName, string aMemberPhone)       // aMemberID, aMemberPSW, aMemberName, aMemberPhone을 넘겨받아 MemberVO의 생성자 생성
        {
            this.memberID = aMemberID;
            this.memberPSW = aMemberPSW;
            this.memberName = aMemberName;
            this.memberPhone = aMemberPhone;
        }
        
        public string MemberID                                                                              // MemberID 값을 get set을 이용하여 읽고 쓰기
        {
            get { return memberID; }
            set { memberID = value; }
        }

        public string MemberPSW                                                                             // MemberPSW 값을 get set을 이용하여 읽고 쓰기
        {
            get { return memberPSW; }
            set { memberPSW = value; }
        }

        public string MemberName                                                                            // MemberName 값을 get set을 이용하여 읽고 쓰기
        {
            get { return memberName; }
            set { memberName = value; }
        }

        public string MemberPhone                                                                           // MeberPhone 값을 get set을 이용하여 읽고 쓰기
        {
            get { return memberPhone; }
            set { memberPhone = value; }
        }
    }
}
