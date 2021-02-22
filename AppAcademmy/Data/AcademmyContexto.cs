using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppAcademmy
{
    public class AppAcademmyContext : DbContext
    {
         public AppAcademmyContext(DbContextOptions<AppAcademmyContext> options)
            : base(options)
        {
        }
    
    }

}