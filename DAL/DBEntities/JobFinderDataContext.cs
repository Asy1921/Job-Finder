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
    public DbSet<tbl_Job_Applicants> tbl_Job_Applicants { get; set; }
    public DbSet<tbl_Companies> tbl_Companies { get; set; }
    public DbSet<tbl_User_Skills> tbl_User_Skills { get; set; }
}