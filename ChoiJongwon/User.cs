using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManamement
{
    class User
    {
        // Data
        private string userID;                //  회원아이디
        private string userPW;                //  비밀번호
        private string userCall;              //  연락처
        private string userName;              //  회원성명
        private Book userBook;                //  대여한 도서의 정보를 담고 있는 Book(V/O)클래스의 객체
        private Book initBook = new Book();   //  리스트간의 삭제가 원활하지 못하여 추가적으로 넣은 default userBook => 발표 때 Feedback 필요 !

        // Constructor
        public User()
        {
            userBook = new Book();
        }
        public User(string userID, string userPW, string userCall, string userName, Book userBook)
        {
            this.userID = userID;
            this.userPW = userPW;
            this.userCall = userCall;
            this.userName = userName;
            this.userBook = userBook;
        }

        public User(User user)
        {
            userID = user.UserID;
            userPW = user.UserPW;
            userCall = user.UserCall;
            userName = user.UserName;
            userBook = user.UserBook;
        }

        // Get/Set
        public Book UserBook
        {
            get { return userBook; }
            set { userBook = value; }
        }

        public Book InitBook
        {
            get { return initBook; }
            set { initBook = value; }
        }

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string UserPW
        {
            get { return userPW; }
            set { userPW = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string UserCall
        {
            get { return userCall; }
            set { userCall = value; }
        }
    }
}
