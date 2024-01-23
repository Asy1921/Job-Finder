using Microsoft.EntityFrameworkCore;

namespace DAL;
public class JobFinderDataContext : DbContext
{
    public JobFinderDataContext(DbContextOptions<JobFinderDataContext> options) : base(options)
    { }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlServer(ConnStr.Get());
        }
    }
    public DbSet<tbl_Avl_Jobs> tbl_Avl_Jobs { get; set; }
}