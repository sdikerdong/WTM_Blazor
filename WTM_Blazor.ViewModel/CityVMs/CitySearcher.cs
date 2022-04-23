using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.CityVMs
{
    public partial class CitySearcher : BaseSearcher
    {
        [Display(Name = "User.Module1.CityName")]
        public String Name { get; set; }

        protected override void InitVM()
        {
        }

    }
}
