using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBook
{
    class MemVO
    {
        private string memName;
        private string memNum;
        private string memBirth;
        private string has_aBook;
        private MemVO mem;
       
        public MemVO(MemVO mem, string name, string birthday, string phonenum, string hasBook) //개인적인 정보들이기 때문에 private로 선언하고 정보를 뺴온다.
        {
            this.mem = mem;
            this.memName = name;
            this.memNum = phonenum;
            this.memBirth = birthday;
            this.has_aBook = hasBook;
        }

        public string name
        {
            get { return this.memName; }
            set { memName = value; }
        }
        public string phonenum
        {
            get { return this.memNum; }
            set { this.memNum = value; }

        }

        public string birthday
        {
            get { return this.memBirth; }
            set { this.memBirth = value; }

        }
        public string hasBook
        {
            get { return this.has_aBook; }
            set { this.has_aBook = value; }
        }

    }
}
