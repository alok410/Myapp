namespace MyApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){ }
        public DbSet<Cars> Car { get; set; }
        
    }
}
