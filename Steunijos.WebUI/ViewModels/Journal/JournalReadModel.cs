using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.WebUI.ViewModels.Journal
{
    public class JournalReadModel
    {
        public int JournalId { get; set; }
        public string IssnNo { get; set; }

        public string VolumeName { get; set; }

        public string ActualFileName { get; set; }

        public DateTimeOffset CopyrightYear { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
