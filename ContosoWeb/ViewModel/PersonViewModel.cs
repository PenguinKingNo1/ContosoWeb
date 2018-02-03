using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContosoWeb.Models;

namespace ContosoWeb.ViewModel
{
    public class PersonViewModel
    {
        public PersonViewModel(People people)
        {
            LastName = people.LastName;
            FirstName = people.FirstName;
            MiddleName = people.MiddleName;
            Birthday = people.Birthday;
            Email = people.Email;
            Phone = people.Phone;
            AddressLine1 = people.AddressLine1;
            AddressLine2 = people.AddressLine2;
            UnitNumber = people.UnitNumber;
            City = people.City;
            State = people.State;
            ZipCode = people.ZipCode;
        }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string UnitNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Password { get; set; }
        public string RetypePassword { get; set; }
    }
}