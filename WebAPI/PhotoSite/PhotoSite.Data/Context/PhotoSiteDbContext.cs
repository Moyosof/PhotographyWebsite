using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSite.Data.Context
{
    public class PhotoSiteDbContext : DbContext
    {
        public PhotoSiteDbContext(DbContextOptions<PhotoSiteDbContext> options) : base(options)
        {
            
        }



    }
}
