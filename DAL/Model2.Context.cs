//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Amusement_ParkEntities2 : DbContext
    {
        public Amusement_ParkEntities2()
            : base("name=Amusement_ParkEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserRide> UserRide { get; set; }
        public virtual DbSet<StandBy> StandBy { get; set; }
        public virtual DbSet<Timings> Timings { get; set; }
        public virtual DbSet<RidesVp> RidesVp { get; set; }
        public virtual DbSet<Rides> Rides { get; set; }
        public virtual DbSet<TimeRide> TimeRide { get; set; }
    }
}
