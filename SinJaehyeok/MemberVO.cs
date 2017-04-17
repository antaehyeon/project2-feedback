using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensharp_study_assignment2_1v
{
    class MemberVO
    {
        //등록된 회원을 관리하기 위한 Value Object(ID, PW, 이름, 빌려간 책, 반납기한)
        private string MemberId;
        private string MemberPswd;
        private string MemberName;
        private string MemberLoan;
        private string MemberDate;

        public MemberVO(string MemberId, string MemberPswd, string MemberName, string MemberLoan, string MemberDate)
        {
            this.MemberId = MemberId;
            this.MemberPswd = MemberPswd;
            this.MemberName = MemberName;
            this.MemberLoan = MemberLoan;
            this.MemberDate = MemberDate;
        }
        public string MemberID
        {
            get { return MemberId; }
            set { MemberId = value; }
        }
        public string MemberPSWD
        {
            get { return MemberPswd; }
            set { MemberPswd = value; }
        }
        public string MemberNAME
        {
            get { return MemberName; }
            set { MemberName = value; }
        }
        public string MemberLOAN
        {
            get { return MemberLoan; }
            set { MemberLoan = value; }
        }
        public string MemberDATE
        {
            get { return MemberDate; }
            set { MemberDate = value; }
        }
    }
}
