﻿//------------------------------------------------------------------------------
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
    
    public partial class ComputerizedVotingEntities1 : DbContext
    {
        public ComputerizedVotingEntities1()
            : base("name=ComputerizedVotingEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BallotBox> BallotBox { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Factions> Factions { get; set; }
        public virtual DbSet<FinalResults> FinalResults { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<ManagersStatus> ManagersStatus { get; set; }
        public virtual DbSet<National> National { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Voting> Voting { get; set; }
    }
}
