using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    class User : IData
    {
        int IData.Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
