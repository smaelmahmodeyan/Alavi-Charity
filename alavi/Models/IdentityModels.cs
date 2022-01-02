using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace alavi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class alaviDbContext : IdentityDbContext<ApplicationUser>
    {
        public alaviDbContext()
            : base("alaviConnection")
        {
        }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Child> Childes { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Link> Links { get; set; }

        public virtual DbSet<Sandogh> Sandoghs { get; set; }

        public virtual DbSet<Sponsor> Sponsors { get; set; }

        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<AdminUser> adminUsers { get; set; }





    }
}