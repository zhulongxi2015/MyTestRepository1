using ArchitectureFrame.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model
{
    public class User:ModelBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string ImageKey { get; set; }
        public int Age { get; set; }
        public string Signature { get; set; }
        public Gender Gender { get; set; }
        public string RegisterIp { get; set; }
        public string RegisterAddress { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public string InternalNotes { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public User()
        {
            this.Gender = Gender.Unknown;
        }
        public User(string userName, string pwd) : this()
        {
            this.UserName = userName;
            this.Password = pwd;
            if (userName.IndexOf("@") > 0)
            {
                this.NickName = userName.Substring(0, userName.IndexOf("@"));
            }
            else
            {
                this.NickName = UserName;
            }
        }
        public void UpdateByCompleteRegistration(User user)
        {
            this.NickName = user.NickName;
            this.Signature = user.Signature;
            this.Age = user.Age;
            this.Gender = user.Gender;
            this.ImageKey = user.ImageKey;
        }
    }
}
