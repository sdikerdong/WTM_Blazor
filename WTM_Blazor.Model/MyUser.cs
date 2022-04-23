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
    [Table("FrameworkUsers")]
    public class MyUser : FrameworkUser
    {
        [Display(Name="所属医院")]
        public Hospital Hospital { get; set; }
        [Display(Name = "所属医院")]
        public Guid HospitalId { get; set; }

        [Display(Name = "所属疾控中心")]
        public ControlCenter ControlCenter { get; set; }
        [Display(Name = "所属疾控中心")]
        public Guid ControlCenterId { get; set; }

    }
}
