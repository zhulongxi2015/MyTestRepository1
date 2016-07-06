using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using ArchitectureFrame.Infrastructure.Extensions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model
{
    public partial class ArchitectureFrameEntities : DbContext
    {
        public ArchitectureFrameEntities() : base("ArchitectureFrameEntities")
        {
            this.Configuration.ProxyCreationEnabled = true;
            Database.SetInitializer<ArchitectureFrame.Model.ArchitectureFrameEntities>
                (new DropCreateDatabaseIfModelChanges<ArchitectureFrame.Model.ArchitectureFrameEntities>());//没提供数据库初始化数据时使用该形式  
        }
        public ArchitectureFrameEntities(string connectionStringOrName):base(!string.IsNullOrEmpty(connectionStringOrName)?connectionStringOrName: "ArchitectureFrameEntities")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            //如果数据库不存在，则创建数据库和空表（在第一次调用DbContext对象访问数据库的时候才创建）
            Database.SetInitializer<ArchitectureFrame.Model.ArchitectureFrameEntities>
               (new DropCreateDatabaseIfModelChanges<ArchitectureFrame.Model.ArchitectureFrameEntities>());//没提供数据库初始化数据时使用该形式  
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var mappings = GetType().Assembly.GetInheritedTypes(typeof(EntityTypeConfiguration<>));
            foreach (var mapping in mappings)
            {
                dynamic instance = Activator.CreateInstance(mapping);
                modelBuilder.Configurations.Add(instance);
            }
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
