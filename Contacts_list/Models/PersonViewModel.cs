using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts_list.Models
{
    public class PersonViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string SmartPhoneName { get; set; }
        public string SmartPhoneModel { get; set; }
    }
}