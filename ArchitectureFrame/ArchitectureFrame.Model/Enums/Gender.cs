using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Model.Enums
{
    public enum Gender
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }

    public static class GenderHelper
    {
        public static string GetText(this Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    return "男";
                case Gender.Female:
                    return "女";
            }
            return "未知";
        }
    }
}
