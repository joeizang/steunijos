using System;

namespace Steunijos.Web.ViewModels.Journal
{
    public class ShowJournalViewModel
    {
        public string JournalISSN { get; set; }

        public string JournalVolumeName { get; set; }

        public DateTimeOffset JournalYear { get; set; }

        public string ActualFileName { get; set; }
    }
}