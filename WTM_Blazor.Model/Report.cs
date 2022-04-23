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
    public class Report : BasePoco
    {
        [Display(Name ="体温")]
        [Required(ErrorMessage ="Validate.{0}required.")]
        [Range(20,40,ErrorMessage ="体温在20-40度之间")]
        public float? temperature { get; set; }

        [Display(Name ="备注")]
        public string Remarks { get; set; }

        public Patient patient { get; set; }
        [Display(Name = "患者")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public Guid? patientID { get; set; }

        [Display(Name ="患者姓名")]
        [NotMapped]
        public string patientName { get; set; }
    }
}
