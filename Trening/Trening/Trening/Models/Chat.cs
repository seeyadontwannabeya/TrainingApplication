//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Trening.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Chat
    {
        public int ID { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public int RegID { get; set; }
    
        public virtual UserRegistration UserRegistration { get; set; }
    }
}
