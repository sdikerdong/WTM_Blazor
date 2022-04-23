using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.VirusVMs
{
    public partial class VirusSearcher : BaseSearcher
    {
        public String Name { get; set; }
        public List<Guid> SelectedpatientVirusIDs { get; set; }

        protected override void InitVM()
        {
        }

    }
}
