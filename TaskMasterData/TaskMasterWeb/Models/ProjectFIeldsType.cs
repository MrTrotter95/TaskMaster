//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskMasterWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProjectFIeldsType
    {
        public int FieldTypeID { get; set; }
        public int FK_FieldID { get; set; }
        public string FieldTypeValue { get; set; }
    
        public virtual ProjectField ProjectField { get; set; }
    }
}