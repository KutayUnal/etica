using E_ticaret_Uygulaması.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_ticaret_Uygulaması.Identity
{
    public class IdentityDataContext: IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("dataConntection")
        {
           
        }
    }
}