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
    
    public partial class t_PostVotes
    {
        public int VoteID { get; set; }
        public int UserID { get; set; }
        public int PostID { get; set; }
        public bool IsUpvote { get; set; }
    
        public virtual t_Posts t_Posts { get; set; }
        public virtual t_Users t_Users { get; set; }
    }
}
