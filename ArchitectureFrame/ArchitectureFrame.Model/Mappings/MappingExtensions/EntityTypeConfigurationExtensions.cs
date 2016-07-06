using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model.Mappings.MappingExtensions
{
    public static class EntityTypeConfigurationExtensions
    {
        public static void Require<T, TRequired, Tkey>(
            this EntityTypeConfiguration<T> config,
            Expression<Func<T, TRequired>> required,
            Expression<Func<TRequired, ICollection<T>>> many,
            Expression<Func<T, Tkey>> key)
            where T : ModelBase
            where TRequired : ModelBase
        {
            config.HasRequired(required).WithMany(many).HasForeignKey(key).WillCascadeOnDelete(false);
        }

        public static void Optional<T, TOptional, TKey>(this EntityTypeConfiguration<T> config,
               Expression<Func<T, TOptional>> required,
               Expression<Func<TOptional, ICollection<T>>> many,
               Expression<Func<T, TKey>> key)
            where T : ModelBase
            where TOptional : ModelBase
        {
            config.HasOptional(required).WithMany(many).HasForeignKey(key).WillCascadeOnDelete(false);
        }
    }
}
