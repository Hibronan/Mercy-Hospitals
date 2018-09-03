using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercy.Model
{
    class User
    {

        public User() {

        }
        private int userid;
        public int GetUserId()
        {
            return this.userid;
        }
        public void SetUserId(int value)
        {
            this.userid = value;
        }
        //----------------------------------------------------------- 
        private String first_name;
        public String GetFirstName()
        {
            return this.first_name;
        }

        public void SetFirstName(String first_name)
        {
            this.first_name = first_name;
        }

        //--------------------------------------------------------------
        private String last_name;
        public String GetLast_name()
        {
            return this.last_name;
        }
        public void SetLastName(String last_name)
        {
            this.last_name = last_name;
        }

        //-------------------------------------------

        private int age;
        public int GetAge()
        {
            return age;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }

        //------------------------------------------
        private String gender;
        public String GetGender()
        {
            return this.gender;
        }
        public void SetGender(String gender)
        {
            this.gender = gender;
        }
        //---------------------------------------------------------

        private long contact_number;
        public long GetContactNumber()
        {
            return this.contact_number;
        }

        public void SetContactNumber(long contact_number)
        {
            this.contact_number = contact_number;
        }

        //-------------------------------------------------------

        private String email;

        public String GetEmail()
        {
            return this.email;
        }

        public void SetEmail(String email)
        {
            this.email = email;
        }

        //-----------------------------------------------------  
        private String userType;
        public String GetUserType()
        {
            return this.userType;
        }

        public void SetUserType(String userType)
        {
            this.userType = userType;
        }

        //----------------------------------------------------------
        private String passWord;
        public String GetPassWord()
        {
            return this.passWord;
        }

        public void SetPassWord(String passWord)
        {
            this.passWord = passWord;
        }

        private String address;

        public String GetAddress() {
            return this.address;
        }
        public void SetAddress(String address)
        {
            this.address = address;
        }

    }
}
