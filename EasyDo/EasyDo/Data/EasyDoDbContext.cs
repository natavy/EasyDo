

namespace EasyDo.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    
    public class EasyDoDbContext : IdentityDbContext<IdentityUser>
    {
        public EasyDoDbContext(DbContextOptions<EasyDoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<SendEmail> Emails { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
