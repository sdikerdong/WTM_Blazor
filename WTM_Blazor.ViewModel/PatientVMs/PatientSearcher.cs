using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.PatientVMs
{
    public partial class PatientSearcher : BaseSearcher
    {
        [Display(Name = "User.Module1.PatientName")]
        public String Name { get; set; }
        [Display(Name = "身份证号码")]
        public String PersonalID { get; set; }
        [Display(Name = "性别")]
        public SexEnum? PatientSex { get; set; }
        [Display(Name = "籍贯")]
        public Guid? LocationId { get; set; }
        [Display(Name = "医院")]
        public Guid? hospitalId { get; set; }
        [Display(Name = "患者状态")]
        public PatientStatuEnum? patientStatus { get; set; }

        protected override void InitVM()
        {
        }

    }
}
