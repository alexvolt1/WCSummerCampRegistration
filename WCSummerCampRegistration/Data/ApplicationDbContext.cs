using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WCSummerCampRegistration.Models;

namespace WCSummerCampRegistration.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Camp> Camps { get; set; }
        public DbSet<Camper> Campers { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentOption> PaymentOptions { get; set; }
        public DbSet<PaymentPlan> PaymentPlans { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<ProtectionPlan> ProtectionPlans { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        public DbSet<Week> Weeks { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
