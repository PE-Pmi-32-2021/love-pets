//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LovePets_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profile
    {
        public int ID { get; set; }
        public string ProfileFullname { get; set; }
        public string ProfileName { get; set; }
        public string Breed { get; set; }
        public string Coloring { get; set; }
        public bool Gender { get; set; }
        public System.DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Photolink { get; set; }
    }
}
