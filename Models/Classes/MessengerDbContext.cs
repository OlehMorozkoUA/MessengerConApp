using Microsoft.EntityFrameworkCore;

namespace Models.Classes
{
    public class MessengerDbContext : DbContext
    {
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=.\sqlexpress;Initial Catalog=Messenger;Integrated Security=True;");
        }
    }
}
