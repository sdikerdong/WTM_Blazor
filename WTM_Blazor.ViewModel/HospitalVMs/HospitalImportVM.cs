using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.HospitalVMs
{
    public partial class HospitalTemplateVM : BaseTemplateVM
    {
        [Display(Name = "User1.Module1.HospitalName")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Hospital>(x => x.Name);
        [Display(Name = "User.Module1.HospitalLocation")]
        public ExcelPropety Location_Excel = ExcelPropety.CreateProperty<Hospital>(x => x.LocationId);
        [Display(Name = "医院等级")]
        public ExcelPropety Level_Excel = ExcelPropety.CreateProperty<Hospital>(x => x.Level);

	    protected override void InitVM()
        {
            Location_Excel.DataType = ColumnDataType.ComboBox;
            Location_Excel.ListItems = DC.Set<City>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class HospitalImportVM : BaseImportVM<HospitalTemplateVM, Hospital>
    {

    }

}
