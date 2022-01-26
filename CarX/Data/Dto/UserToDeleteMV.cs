using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarX.Data.Dto
{
    public class UserToDeleteMV
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string SignUpDate { get; set; }
        public string ImageUrl { get; set; }
    }
}
