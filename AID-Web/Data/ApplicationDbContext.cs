using AID.Entites;
using Microsoft.EntityFrameworkCore;

namespace AID.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<DataSet> Datasets { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Video> Videos { get; set; }    
        public DbSet<WithdrawRequest> WithdrawRequests { get; set; }

    }
}