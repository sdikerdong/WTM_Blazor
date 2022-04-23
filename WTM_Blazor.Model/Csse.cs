using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace WTM_Blazor.Model
{
    public class Csse : TopBasePoco
    {
        [Display(Name = "国家")]
        [Required(ErrorMessage="Validate.{0}required")]
        public string Country { get; set; }

        [Display(Name = "省份")]
        public string Province  { get; set; }

        [Display(Name = "经度")]
        public double JingDu { get; set; }

        [Display(Name ="纬度")]
        public double WeiDu { get; set; }

        [Display(Name ="日期")]
        [Column(TypeName ="DATE")]
        public DateTime? Date   { get; set; }

        [Display(Name ="确诊")]
        public int ConfirmCsse { get; set; }
    }
}
