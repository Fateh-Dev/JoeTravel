using Joe.Travel.Models;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Joe.Travel.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class TravelDbContext :
    AbpDbContext<TravelDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }
    
    // Joe.Travel 
     public DbSet<Trip> Trips { get; set; }
     public DbSet<Activity> Activities { get; set; }
     public DbSet<Guide> Guides { get; set; }
     public DbSet<Risk> Risks { get; set; }
     public DbSet<NotAllowedStuff> NotAllowedStuffs { get; set; }
     public DbSet<NotSuitableFor> NotSuitableFors { get; set; }
     public DbSet<Loging> logings { get; set; }
     public DbSet<IncludedStuff> IncludedStuffs { get; set; }
     public DbSet<RequiredStuff> RequiredStuffs { get; set; }

    #endregion

    public TravelDbContext(DbContextOptions<TravelDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(TravelConsts.DbTablePrefix + "YourEntities", TravelConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
            
         builder.Entity<Trip>(b =>
            {
                b.ToTable(AppConsts.DbTablePrefix + "Trips");
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Title).IsRequired().HasMaxLength(TripConst.MaxTitleLength);
                b.HasMany(x=>x.Activities).WithOne().HasForeignKey(x=>x.ActivityId).IsRequired();
                b.HasMany(x=>x.Risks).WithOne().HasForeignKey(x=>x.RiskId).IsRequired();

                b.HasMany(x=>x.NotAllowedStuffs).WithOne().HasForeignKey(x=>x.NotAllowedStuffId).IsRequired();
                b.HasMany(x=>x.NotSuitableFors).WithOne().HasForeignKey(x=>x.NotSuitableForId).IsRequired();
                b.HasMany(x=>x.Logings).WithOne().HasForeignKey(x=>x.LogingId).IsRequired();
                b.HasMany(x=>x.IncludedStuffs).WithOne().HasForeignKey(x=>x.IncludedStuffId).IsRequired();
                b.HasMany(x=>x.RequiredStuffs).WithOne().HasForeignKey(x=>x.RequiredStuffId).IsRequired();
               
                b.HasMany(x=>x.Pictures).WithOne().HasForeignKey(x=>x.TripId).IsRequired();

                b.HasOne<Guide>().WithMany(x=>x.Trips).HasForeignKey(x=>x.GuideId).IsRequired();
            });

        

         builder.Entity<Image>(b =>
            {
                b.ToTable(AppConsts.DbTablePrefix + "Images");
                b.ConfigureByConvention(); //auto configure for the base class props
               b.HasOne<Trip>().WithMany(x=>x.Pictures).HasForeignKey(x=>x.TripId).IsRequired();
           });
 

         builder.Entity<Guide>(b =>
            {
                b.ToTable(AppConsts.DbTablePrefix + "Guides");
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Firstname).IsRequired().HasMaxLength(GuideConst.NameMaxLenght);
                b.Property(x => x.Lastname).IsRequired().HasMaxLength(GuideConst.NameMaxLenght); 
                b.HasMany(x=>x.Trips).WithOne().HasForeignKey(x=>x.GuideId).IsRequired();
            });
 

         builder.Entity<Activity>(b =>
            {
                b.ToTable(AppConsts.DbTablePrefix + "Activities");
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.DescriptionFr).IsRequired().HasMaxLength(ActivityConst.MaxDescriptionLength);
                b.Property(x => x.DescriptionAr).IsRequired().HasMaxLength(ActivityConst.MaxDescriptionLength);
            });

         builder.Entity<NotAllowedStuff>(b =>
            {
                b.ToTable(AppConsts.DbTablePrefix + "NotAllowedStuff");
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.DescriptionFr).IsRequired().HasMaxLength(ActivityConst.MaxDescriptionLength);
                b.Property(x => x.DescriptionAr).IsRequired().HasMaxLength(ActivityConst.MaxDescriptionLength);
            });

         builder.Entity<Loging>(b =>
            {
                b.ToTable(AppConsts.DbTablePrefix + "Logings");
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.DescriptionFr).IsRequired().HasMaxLength(ActivityConst.MaxDescriptionLength);
                b.Property(x => x.DescriptionAr).IsRequired().HasMaxLength(ActivityConst.MaxDescriptionLength);
            });

         builder.Entity<IncludedStuff>(b =>
            {
                b.ToTable(AppConsts.DbTablePrefix + "IncludedStuff");
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.DescriptionFr).IsRequired().HasMaxLength(ActivityConst.MaxDescriptionLength);
                b.Property(x => x.DescriptionAr).IsRequired().HasMaxLength(ActivityConst.MaxDescriptionLength);
            });

         builder.Entity<NotSuitableFor>(b =>
            {
                b.ToTable(AppConsts.DbTablePrefix + "NotSuitableFor");
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.DescriptionFr).IsRequired().HasMaxLength(ActivityConst.MaxDescriptionLength);
                b.Property(x => x.DescriptionAr).IsRequired().HasMaxLength(ActivityConst.MaxDescriptionLength);
            });

         builder.Entity<RequiredStuff>(b =>
            {
                b.ToTable(AppConsts.DbTablePrefix + "RequiredStuff");
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.DescriptionFr).IsRequired().HasMaxLength(ActivityConst.MaxDescriptionLength);
                b.Property(x => x.DescriptionAr).IsRequired().HasMaxLength(ActivityConst.MaxDescriptionLength);
            });

         builder.Entity<Risk>(b =>
            {
                b.ToTable(AppConsts.DbTablePrefix + "Risks");
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.DescriptionFr).IsRequired().HasMaxLength(ActivityConst.MaxDescriptionLength);
                b.Property(x => x.DescriptionAr).IsRequired().HasMaxLength(ActivityConst.MaxDescriptionLength);
            });

        builder.Entity<TripActivity>(b=>
            {
                b.ToTable(AppConsts.DbTablePrefix + "Trip_Activities");
                b.ConfigureByConvention();//define composite key
                b.HasKey(x=>new{x.TripId,x.ActivityId});//many-to-many configuration
                b.HasOne<Trip>().WithMany(x=>x.Activities).HasForeignKey(x=>x.TripId).IsRequired();
                b.HasOne<Activity>().WithMany().HasForeignKey(x=>x.ActivityId).IsRequired();
                b.HasIndex(x=>new{x.TripId,x.ActivityId});
            });

        builder.Entity<TripNotAllowedStuff>(b=>
            {
                b.ToTable(AppConsts.DbTablePrefix + "Trip_NotAllowedStuff");
                b.ConfigureByConvention();//define composite key
                b.HasKey(x=>new{x.TripId,x.NotAllowedStuffId});//many-to-many configuration
                b.HasOne<Trip>().WithMany(x=>x.NotAllowedStuffs).HasForeignKey(x=>x.TripId).IsRequired();
                b.HasOne<NotAllowedStuff>().WithMany().HasForeignKey(x=>x.NotAllowedStuffId).IsRequired();
                b.HasIndex(x=>new{x.TripId,x.NotAllowedStuffId});
            });

        builder.Entity<TripNotSuitableFor>(b=>
            {
                b.ToTable(AppConsts.DbTablePrefix + "Trip_NotSuitableFor");
                b.ConfigureByConvention();//define composite key
                b.HasKey(x=>new{x.TripId,x.NotSuitableForId});//many-to-many configuration
                b.HasOne<Trip>().WithMany(x=>x.NotSuitableFors).HasForeignKey(x=>x.TripId).IsRequired();
                b.HasOne<NotSuitableFor>().WithMany().HasForeignKey(x=>x.NotSuitableForId).IsRequired();
                b.HasIndex(x=>new{x.TripId,x.NotSuitableForId});
            });

        builder.Entity<TripLoging>(b=>
            {
                b.ToTable(AppConsts.DbTablePrefix + "Trip_Loging");
                b.ConfigureByConvention();//define composite key
                b.HasKey(x=>new{x.TripId,x.LogingId});//many-to-many configuration
                b.HasOne<Trip>().WithMany(x=>x.Logings).HasForeignKey(x=>x.TripId).IsRequired();
                b.HasOne<Loging>().WithMany().HasForeignKey(x=>x.LogingId).IsRequired();
                b.HasIndex(x=>new{x.TripId,x.LogingId});
            });

        builder.Entity<TripIncludedStuff>(b=>
            {
                b.ToTable(AppConsts.DbTablePrefix + "Trip_IncludedStuff");
                b.ConfigureByConvention();//define composite key
                b.HasKey(x=>new{x.TripId,x.IncludedStuffId});//many-to-many configuration
                b.HasOne<Trip>().WithMany(x=>x.IncludedStuffs).HasForeignKey(x=>x.TripId).IsRequired();
                b.HasOne<IncludedStuff>().WithMany().HasForeignKey(x=>x.IncludedStuffId).IsRequired();
                b.HasIndex(x=>new{x.TripId,x.IncludedStuffId});
            });

        builder.Entity<TripRequiredStuff>(b=>
            {
                b.ToTable(AppConsts.DbTablePrefix + "Trip_RequiredStuff");
                b.ConfigureByConvention();//define composite key
                b.HasKey(x=>new{x.TripId,x.RequiredStuffId});//many-to-many configuration
                b.HasOne<Trip>().WithMany(x=>x.RequiredStuffs).HasForeignKey(x=>x.TripId).IsRequired();
                b.HasOne<RequiredStuff>().WithMany().HasForeignKey(x=>x.RequiredStuffId).IsRequired();
                b.HasIndex(x=>new{x.TripId,x.RequiredStuffId});
            });

        builder.Entity<TripRisk>(b=>
            {
                b.ToTable(AppConsts.DbTablePrefix + "Trip_Risks");
                b.ConfigureByConvention();//define composite key
                b.HasKey(x=>new{x.TripId,x.RiskId});//many-to-many configuration
                b.HasOne<Trip>().WithMany(x=>x.Risks).HasForeignKey(x=>x.TripId).IsRequired();
                b.HasOne<Risk>().WithMany().HasForeignKey(x=>x.RiskId).IsRequired();
                b.HasIndex(x=>new{x.TripId,x.RiskId});
            });
    }
}
