//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwitterRemake.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_Posts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Posts()
        {
            this.t_Comments = new HashSet<t_Comments>();
            this.t_PostVotes = new HashSet<t_PostVotes>();
        }
    
        public int PostID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Text { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Comments> t_Comments { get; set; }
        public virtual t_Users t_Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_PostVotes> t_PostVotes { get; set; }
    }
}
