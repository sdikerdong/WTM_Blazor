using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace WTM_Blazor.Model
{
    public enum HospitalLevel
    {
        [Display(Name = "三级")]
        Class3,
        [Display(Name = "二级")]
        Class2,
        [Display(Name = "一级")]
        Class1

    }
    public class Hospital : BasePoco
    {
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "医院名称必填")]
        [Display(Name = "User1.Module1.HospitalName")]

        public string Name { get; set; }

        [Display(Name = "User.Module1.HospitalLocation")]
        public City Location { get; set; }
        [Required(ErrorMessage = "Validate.{0}required")]
        public Guid LocationId { get; set; }

        [Display(Name = "医院等级")]
        public HospitalLevel Level { set; get; }
    }
}
