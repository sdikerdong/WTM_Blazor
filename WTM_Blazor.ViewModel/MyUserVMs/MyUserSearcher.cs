using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.MyUserVMs
{
    public partial class MyUserSearcher : BaseSearcher
    {
        [Display(Name = "所属医院")]
        public Guid? HospitalId { get; set; }
        [Display(Name = "_Admin.Email")]
        public String Email { get; set; }
        [Display(Name = "_Admin.Gender")]
        public GenderEnum? Gender { get; set; }
        [Display(Name = "_Admin.Account")]
        public String ITCode { get; set; }

        protected override void InitVM()
        {
        }

    }
}
