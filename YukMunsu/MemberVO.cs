using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 도서관리
{
    class MemberVO
    {
        private string memberName; // 회원명
        private string memberAge; // 회원나이
        private string memberAddress; // 회원주소
        private string memberPhone; // 핸드폰번호
        private string residentNumber; // 주민등록번호

        public MemberVO()
        {
            // 생성자
        }

        public MemberVO(string memberName, string memberAge, string memberAddress, string memberPhone, string residentNumber) // 매개변수 있는 생성자
        {
            this.memberName = memberName;
            this.memberAge = memberAge;
            this.memberAddress = memberAddress;
            this.memberPhone = memberPhone;
            this.residentNumber = residentNumber;
        }

        public string MemberName // get set 프로퍼티
        {
            get { return memberName; }
            set { memberName = value; }
        }

        public string MemberAge
        {
            get { return memberAge; }
            set { memberAge = value; }
        }

        public string MemberAddress
        {
            get { return memberAddress; }
            set { memberAddress = value; }
        }

        public string MemberPhone
        {
            get { return memberPhone; }
            set { memberPhone = value; }
        }

        public string ResidentNumber
        {
            get { return residentNumber; }
            set { residentNumber = value; }
        }
    }
}
