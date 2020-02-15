using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.ViewModels.Paper
{
    public class PaperIndexViewModel
    {
        public string SearchString { get; set; }

        public string SortOrder { get; set; }

        public SortBy SortBy { get; set; }
    }
}
