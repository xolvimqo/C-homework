//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResumeManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_extra_info
    {
        public int Id { get; set; }
        public string info_title { get; set; }
        public string description { get; set; }
        public int fk_user_id { get; set; }
    
        public virtual tbl_users tbl_users { get; set; }
    }
}
