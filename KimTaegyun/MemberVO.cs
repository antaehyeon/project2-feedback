using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement
{
    class MemberVO // Member Value Objcet
    {
        private string Name;
        private string Age;
        private string Individual_Num;
        private string Cellphone;
        

        public MemberVO() { }

        public MemberVO(string Name, string Age, string Individual_Num, string Cellphone)
        {
            this.Name = Name;
            this.Age = Age;
            this.Individual_Num = Individual_Num;
            this.Cellphone = Cellphone;
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public string age
        {
            get { return Age; }
            set { Age = value; }
        }

        public string individual_num
        {
            get { return Individual_Num; }
            set { Individual_Num = value; }
        }
        public string cellphone
        {
            get { return Cellphone; }
            set { Cellphone = value; }
        }
        
    }
}
