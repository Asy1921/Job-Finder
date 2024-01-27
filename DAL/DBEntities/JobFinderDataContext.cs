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

            optionsBuilder.UseSqlServer(ConnStr.Get());

        }
    }
    public DbSet<tbl_Avl_Jobs> tbl_Avl_Jobs { get; set; }
}