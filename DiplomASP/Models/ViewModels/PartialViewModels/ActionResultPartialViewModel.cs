using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomASP.Models.ViewModels.PartialViewModels
{
    public enum BootstrapAlertClass { primary, success, danger, warning }
    public class ActionResultPartialViewModel
    {
        public BootstrapAlertClass status;
        public string message;

        public ActionResultPartialViewModel(string message, BootstrapAlertClass status = BootstrapAlertClass.primary)
        {
            this.status = status;
            this.message = message;
        }
    }
}
