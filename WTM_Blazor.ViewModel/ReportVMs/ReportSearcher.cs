using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.ReportVMs
{
    public partial class ReportSearcher : BaseSearcher
    {
        [Display(Name = "体温")]
        public Single? temperature { get; set; }
        public Guid? patientID { get; set; }
        [Display(Name = "患者姓名")]
        public String patientName { get; set; }

        protected override void InitVM()
        {
        }

    }
}
