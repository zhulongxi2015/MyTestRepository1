﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureFrame.Infrastructure.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString IsChecked(this HtmlHelper helper, bool isChecked)
        {
            return helper.Raw(isChecked ? "checked=\"checked\"" : string.Empty);
        }

        public static IHtmlString IsSelected(this HtmlHelper helper, bool isSelected)
        {
            return helper.Raw(isSelected ? "selected=\"selected\"" : string.Empty);
        }

        public static IHtmlString IsDisabled(this HtmlHelper helper, bool isDisabled)
        {
            return helper.Raw(isDisabled ? "disabled=\"disabled\"" : string.Empty);
        }
    }
}
