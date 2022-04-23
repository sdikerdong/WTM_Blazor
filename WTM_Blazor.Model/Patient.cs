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
    public enum SexEnum
    {
        [Display(Name ="男")]
        Male,
        [Display(Name = "女")]
        Female
    }

    public enum PatientStatuEnum
    {
        [Display(Name ="无症状")]
        NoException,
        [Display(Name = "疑似")]
        PredictVirus,
        [Display(Name = "确诊")]
        ConfirmVirus,
        [Display(Name = "治愈")]
        Recovery,
        [Display(Name = "死亡")]
        Dead
    }

    [Table("myPatients")]
    public class Patient : PersistPoco
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public new int ID { get; set; }

        [Display(Name = "User.Module1.PatientName")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(20, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Name { get; set; }

        [Display(Name ="身份证号码")]
        [Required(ErrorMessage ="Validate.{0}required")]
        [RegularExpression("^(\\d{18,18}|\\d{15,15}|\\d{17,17}x)", ErrorMessage ="格式不正确")]
        public string PersonalID { get; set; }

        [Display(Name = "性别")]
        public SexEnum PatientSex { get; set; }

        [Display(Name="生日")]
        [Required(ErrorMessage ="Validate.{0}required")]
        public DateTime? birthday { get; set; }

        [Display(Name="籍贯")]
        public City Location { get; set; }
        [Display(Name = "籍贯")]
        public Guid? LocationId { get; set; }

        [Display(Name ="医院")]
        public Hospital hospital { get; set; }

        [Display(Name = "医院")]
        [Required(ErrorMessage ="Validate.{0}required")]
        public Guid hospitalId  { get; set; }

        [Display(Name="病毒名称")]
        public List<PatientVirus> patientViruses { get; set; }

        [Display(Name ="患者状态")]
        [Required(ErrorMessage ="Validate.{0}required")]
        public PatientStatuEnum patientStatus { get; set; } 

        [Display(Name="照片")]
        public FileAttachment photo { get; set; }
        public Guid? photoId { get; set; }

        public List<Report> reports { get; set; }

        [NotMapped]
        public int Age
        {
            get {
                if (this.birthday.HasValue)
                {
                    return DateTime.Now.Year - this.birthday.Value.Year;
                }
                return 0;
            }
        }
    }
}
