using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Configuration;
using GoTournamental.BLL.Planner;

namespace GoTournamental.ORM.Planner 
{

    public class ToolTipDbContext : DbContext 
    {
        public DbSet<ToolTip> ToolTips { get; set; }
        public ToolTipDbContext() : base(ConfigurationManager.ConnectionStrings["GoTournamentalConnection"].ConnectionString)
        {
                Database.SetInitializer<ToolTipDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Configurations.Add(new ToolTipConfiguration());
            base.OnModelCreating(modelBuilder);
        }
  
	}
    public class ToolTipConfiguration : EntityTypeConfiguration<ToolTip>
    {
        public ToolTipConfiguration() : base() 
        {
            HasKey(i => i.ID);
			Property(i => i.WebPage).HasColumnName("WebPage");
			Property(i => i.ControlID).HasColumnName("ControlID");
			Property(i => i.ToolTipText).HasColumnName("ToolTipText");
			Property(i => i.UserID).HasColumnName("UserID");
			Property(i => i.DateModified).HasColumnName("DateModified");
			ToTable("Administration.ToolTips");
        }
    }

}
