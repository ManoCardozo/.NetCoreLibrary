using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryData
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options) { }

        DbSet<Book> Books { get; set; }
        DbSet<Video> Videos { get; set; }
        DbSet<Checkout> Checkouts { get; set; }
        DbSet<CheckoutHistory> CheckoutHistories { get; set; }
        DbSet<LibraryBranch> LibraryBranches { get; set; }
        DbSet<BranchHours> BranchHours { get; set; }
        DbSet<LibraryCard> LibraryCards { get; set; }
        DbSet<Patron> Patrons { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<LibraryAsset> LibraryAssets { get; set; }
        DbSet<Hold> Holds { get; set; }
    }
}
