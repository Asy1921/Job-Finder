using Microsoft.EntityFrameworkCore;

namespace DAL;
public class JobFinderDataContext : DbContext
{
    public JobFinderDataContext()
    {
    }

    public JobFinderDataContext(DbContextOptions<JobFinderDataContext> opt) : base(opt)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

            optionsBuilder.UseNpgsql(ConnStr.Get());

        }
    }
    public DbSet<tbl_Avl_Jobs> tbl_Avl_Jobs { get; set; }
    public DbSet<tbl_Users> tbl_Users { get; set; }
}