
namespace TaskMasterWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class TaskMasterDataEntities : DbContext
    {
        public TaskMasterDataEntities()
            : base("name=TaskMasterDataEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientContact> ClientContacts { get; set; }
        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<AssignedProject> AssignedProjects { get; set; }
        public virtual DbSet<ProjectField> ProjectFields { get; set; }
        public virtual DbSet<ProjectFIeldsType> ProjectFIeldsTypes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectStatus> ProjectStatus { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<StaffRole> StaffRoles { get; set; }
    }
}