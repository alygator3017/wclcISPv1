using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace wclc.Models
{
    //represents the member in the database. Each instance of a Member object will correspond with a row
    //within the database table. Each property of the Member class will map to a column in the table.
    public class MemberDb : DbContext
    {
        public MemberDb() : base("DefaultConnection") { }
        public DbSet<Member> Members { get; set; }
        //from here (when changing data in member controller...) change the MemberAdminController
        //and delete the migrations file and redo migrations


    }
}