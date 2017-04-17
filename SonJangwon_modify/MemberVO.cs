using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class MemberVO
    {
        private string memberId;
        private string memberPassword;
        private string memberPhonenum;
        private string memberBirthday;
        private MemberVO mem;
       
        public MemberVO()
        { }
        public MemberVO(MemberVO mem,string memberId, string memberPassword, string memberPhonenum, string memberBirthday)
        {
            this.memberId = memberId;
            this.memberPassword = memberPassword;
            this.memberPhonenum = memberPhonenum;
            this.memberBirthday = memberBirthday;
        }
        public string MemberId
        {
            get { return memberId; }
            set { memberId = value; }
        }
        public string MemberPassword
        {
            get { return memberPassword; }
            set { memberPassword = value; }
        }
        public string MemberPhonenum
        {
            get { return memberPhonenum; }
            set { memberPhonenum = value; }
        }
        public string MemberBirthday
        {
            get { return memberBirthday; }
            set { memberBirthday = value; }
        }
        
    }
}
