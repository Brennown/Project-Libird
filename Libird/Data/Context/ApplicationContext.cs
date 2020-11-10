using Libird.Models.Domain;
using Microsoft.EntityFrameworkCore;


namespace Libird.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAccount> BookAccounts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>( p => 
            {
                p.ToTable("Accounts");
                p.HasKey(p => p.AccountId);
                p.Property(p => p.AccountId).IsRequired().ValueGeneratedOnAdd();
                p.Property(p => p.UserName).HasColumnType("VARCHAR(30)").IsRequired();
                p.Property(p => p.Password).HasColumnType("VARCHAR(30)").IsRequired();
            });

            modelBuilder.Entity<Author>( p =>
            {
                p.ToTable("Authors");
                p.HasKey(p => p.AuthorId);
                p.Property(p => p.AuthorId).IsRequired().ValueGeneratedOnAdd();
                p.Property(p => p.Name).HasColumnType("VARCHAR(30)").IsRequired();
                p.Property(p => p.LastName).HasColumnType("VARCHAR(30)").IsRequired();
            });

            modelBuilder.Entity<Book>( p => 
            {
                p.ToTable("Books");
                p.HasKey(p => p.BookId);
                p.Property(p => p.BookId).IsRequired().ValueGeneratedOnAdd();
                p.Property(p => p.Title).HasColumnType("VARCHAR(30)").IsRequired();
                p.Property(p => p.SubTitle).HasColumnType("VARCHAR(25)").IsRequired();
                p.Property(p => p.NumberPage).HasColumnType("CHAR(4)").IsRequired();
                p.Property(p => p.NumberEdition).HasColumnType("CHAR(3)").IsRequired();
                p.Property(p => p.Isbn).HasColumnType("CHAR(13)").IsRequired();
                p.Property(p => p.Genre).HasColumnType("VARCHAR(20)").IsRequired();

                p.HasOne(p => p.Author)
                .WithMany(p => p.Books)
                .HasForeignKey(p => p.AuthorId)
                .HasConstraintName("FK_AuthorId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            });

            modelBuilder.Entity<User>(p => 
            {
                p.ToTable("Users");
                p.HasKey(p => p.UserId);
                p.Property(p => p.UserId).IsRequired().ValueGeneratedOnAdd();
                p.Property(p => p.Name).HasColumnType("VARCHAR(30)").IsRequired();
                p.Property(p => p.LastName).HasColumnType("VARCHAR(30)").IsRequired();
                p.Property(p => p.Email).HasColumnType("VARCHAR(30)").IsRequired();

                p.HasOne(p => p.Account)
                .WithOne(p => p.User)
                .HasForeignKey<Account>(p => p.UserId)
                .HasConstraintName("Fk_UserId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            });

            modelBuilder.Entity<BookAccount>( p => 
            {
                p.ToTable("Book_Account");
                p.HasKey(p => new { p.AccountId, p.BookId });
            });

            modelBuilder.Entity<BookAccount>( p => 
            {
                p.HasOne(p => p.Account)
                .WithMany(p => p.BookAccounts)
                .HasForeignKey(p => p.AccountId)
                .HasConstraintName("Fk_AccountId");
            });

            modelBuilder.Entity<BookAccount>( p =>
            {
                p.HasOne(p => p.Book)
                .WithMany(p => p.BookAccounts)
                .HasForeignKey(p => p.BookId)
                .HasConstraintName("Fk_BookId");
            });
        }
    }
}
