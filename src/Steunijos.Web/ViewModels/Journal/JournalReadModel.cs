﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.ViewModels.Journal
{
    public class JournalReadModel
    {
        public string JournalId { get; set; }
        public string IssnNo { get; set; }

        public string VolumeName { get; set; }

        public string ActualFileName { get; set; }

        public DateTimeOffset CopyrightYear { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
