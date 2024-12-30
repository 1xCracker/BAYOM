using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Dto_s.UserDto_s
{
    public class UserSignUpDto
    {
        public int Userid { get; set; }

        public string Useremail { get; set; } = null!;

        public string Userpassword { get; set; } = null!;
        public int Userrole { get; set; }
        public int Customerid { get; set; }
        public string Customerfirstname { get; set; } = null!;

        public string Customerlastname { get; set; } = null!;

        public string Customerphonenumber { get; set; } = null!;

        public string Customeradress { get; set; } = null!;

        public string Customeremail { get; set; } = null!;
    }
}
