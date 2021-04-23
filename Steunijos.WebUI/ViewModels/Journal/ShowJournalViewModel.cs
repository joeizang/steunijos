using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.WebUI.ViewModels.Journal
{
    public class ShowJournalViewModel
    {
        public string JournalISSN { get; set; }

        public string JournalVolumeName { get; set; }

        public DateTimeOffset JournalYear { get; set; }

        public string ActualFileName { get; set; }
    }
}
