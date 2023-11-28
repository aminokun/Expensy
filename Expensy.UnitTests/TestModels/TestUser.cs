using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expensy.UnitTests.TestModels
{
    internal class TestUser
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public TestUser(string username, string email, string password)
        {

        }
    }
}
