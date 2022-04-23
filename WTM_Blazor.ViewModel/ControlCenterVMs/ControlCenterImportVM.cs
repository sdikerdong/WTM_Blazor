using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.ControlCenterVMs
{
    public partial class ControlCenterTemplateVM : BaseTemplateVM
    {
        [Display(Name = "中心名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<ControlCenter>(x => x.Name);
        [Display(Name = "中心地点")]
        public ExcelPropety Location_Excel = ExcelPropety.CreateProperty<ControlCenter>(x => x.LocationId);

	    protected override void InitVM()
        {
            Location_Excel.DataType = ColumnDataType.ComboBox;
            Location_Excel.ListItems = DC.Set<City>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class ControlCenterImportVM : BaseImportVM<ControlCenterTemplateVM, ControlCenter>
    {

    }

}
