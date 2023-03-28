using Entity;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Access for users table
        /// </summary>
        public DbSet<User> Users { get;set;}

        /// <summary>
        /// Access for contacts table
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Access for Message table
        /// </summary>
       public DbSet<Message> Messages { get; set; }



        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
       : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasKey(u => new { u.contactId});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ChatDatabase;Trusted_Connection=true");
        }
    } 
}
