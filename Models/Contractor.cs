using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ais.Models
{
    class Contractor
    {
        public Contractor(string codeContractor, string nameContractor, string city, string street, string building, int porch, int office, string account, string email)
        {
            CodeContractor = codeContractor;
            NameContractor = nameContractor;
            City = city;
            Street = street;
            Building = building;
            Porch = porch;
            Office = office;
            Account = account;
            Email = email;
        }

        public string CodeContractor { get; set; }
        public string NameContractor { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public int Porch { get; set; }
        public int Office { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }

    }
}
