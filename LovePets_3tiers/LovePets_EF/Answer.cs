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
    
    public partial class Answer
    {
        public int ID { get; set; }
        public string Answer1 { get; set; }
        public int Dogs { get; set; }
        public int Cats { get; set; }
        public int Rodents { get; set; }
        public int Reptiles { get; set; }
        public int Birds { get; set; }
        public Nullable<int> QuestionsID { get; set; }
    
        public virtual Question Question { get; set; }
    }
}