using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace WTM_Blazor.Model
{
    public class ControlCenter : BasePoco
    {
        [Display(Name ="中心名称")]
        [Required(ErrorMessage="Validate.{0}required")]
        public string Name { get; set; }

        [Display(Name ="中心地点")]
        public City Location { get; set; }
        [Display(Name = "中心地点")]
        [Required(ErrorMessage ="Validate.{0}required")]
        public Guid LocationId { get; set; }
    }
}
