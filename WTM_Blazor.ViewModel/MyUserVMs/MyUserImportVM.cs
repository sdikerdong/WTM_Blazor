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
    public partial class MyUserTemplateVM : BaseTemplateVM
    {
        [Display(Name = "所属医院")]
        public ExcelPropety Hospital_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.HospitalId);
        [Display(Name = "所属疾控中心")]
        public ExcelPropety ControlCenter_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.ControlCenterId);
        [Display(Name = "_Admin.Email")]
        public ExcelPropety Email_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.Email);
        [Display(Name = "_Admin.Gender")]
        public ExcelPropety Gender_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.Gender);
        [Display(Name = "_Admin.CellPhone")]
        public ExcelPropety CellPhone_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.CellPhone);
        [Display(Name = "_Admin.HomePhone")]
        public ExcelPropety HomePhone_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.HomePhone);
        [Display(Name = "_Admin.Address")]
        public ExcelPropety Address_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.Address);
        [Display(Name = "_Admin.ZipCode")]
        public ExcelPropety ZipCode_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.ZipCode);
        [Display(Name = "_Admin.Account")]
        public ExcelPropety ITCode_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.ITCode);
        [Display(Name = "_Admin.Password")]
        public ExcelPropety Password_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.Password);
        [Display(Name = "_Admin.Name")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.Name);
        [Display(Name = "_Admin.IsValid")]
        public ExcelPropety IsValid_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.IsValid);
        [Display(Name = "_Admin.Tenant")]
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.TenantCode);

	    protected override void InitVM()
        {
            Hospital_Excel.DataType = ColumnDataType.ComboBox;
            Hospital_Excel.ListItems = DC.Set<Hospital>().GetSelectListItems(Wtm, y => y.Name);
            ControlCenter_Excel.DataType = ColumnDataType.ComboBox;
            ControlCenter_Excel.ListItems = DC.Set<ControlCenter>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class MyUserImportVM : BaseImportVM<MyUserTemplateVM, MyUser>
    {

    }

}
