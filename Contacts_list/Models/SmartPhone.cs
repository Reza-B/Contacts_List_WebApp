//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Contacts_list.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SmartPhone
    {
        public int PersonID { get; set; }
        public string SmartPhoneName { get; set; }
        public string SmartPhoneModel { get; set; }
    
        public virtual Contacts Contacts { get; set; }
    }
}
