using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model
{
   public class ModelBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public bool DeleteFlag { get; set; }
        //public bool IsNew => this.Id == Guid.Empty;

        //public void NewId()
        //{
        //    this.Id = Guid.NewGuid();
        //}
        protected ModelBase()
        {
            CreatedTime = DateTime.Now;
            DeleteFlag = false;
        }
    }
}
