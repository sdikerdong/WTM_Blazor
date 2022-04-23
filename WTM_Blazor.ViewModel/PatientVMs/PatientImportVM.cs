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
    public partial class PatientTemplateVM : BaseTemplateVM
    {
        [Display(Name = "User.Module1.PatientName")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Patient>(x => x.Name);
        [Display(Name = "身份证号码")]
        public ExcelPropety PersonalID_Excel = ExcelPropety.CreateProperty<Patient>(x => x.PersonalID);
        [Display(Name = "性别")]
        public ExcelPropety PatientSex_Excel = ExcelPropety.CreateProperty<Patient>(x => x.PatientSex);
        [Display(Name = "生日")]
        public ExcelPropety birthday_Excel = ExcelPropety.CreateProperty<Patient>(x => x.birthday);
        [Display(Name = "籍贯")]
        public ExcelPropety Location_Excel = ExcelPropety.CreateProperty<Patient>(x => x.LocationId);
        [Display(Name = "医院")]
        public ExcelPropety hospital_Excel = ExcelPropety.CreateProperty<Patient>(x => x.hospitalId);
        [Display(Name = "患者状态")]
        public ExcelPropety patientStatus_Excel = ExcelPropety.CreateProperty<Patient>(x => x.patientStatus);

	    protected override void InitVM()
        {
            Location_Excel.DataType = ColumnDataType.ComboBox;
            Location_Excel.ListItems = DC.Set<City>().GetSelectListItems(Wtm, y => y.Name);
            hospital_Excel.DataType = ColumnDataType.ComboBox;
            hospital_Excel.ListItems = DC.Set<Hospital>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class PatientImportVM : BaseImportVM<PatientTemplateVM, Patient>
    {

    }

}
