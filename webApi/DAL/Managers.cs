//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Managers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Managers()
        {
            this.BallotBox = new HashSet<BallotBox>();
        }
    
        public string MIdentity { get; set; }
        public string MFullName { get; set; }
        public string MUserName { get; set; }
        public string MPassword { get; set; }
        public string NumStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BallotBox> BallotBox { get; set; }
        public virtual ManagersStatus ManagersStatus { get; set; }
    }
}
