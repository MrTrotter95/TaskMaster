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
    
    public partial class ProjectField
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectField()
        {
            this.ProjectFIeldsTypes = new HashSet<ProjectFIeldsType>();
        }
    
        public int FieldID { get; set; }
        public int FK_ProjectID { get; set; }
        public string FieldValue { get; set; }
    
        public virtual Project Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectFIeldsType> ProjectFIeldsTypes { get; set; }
    }
}
