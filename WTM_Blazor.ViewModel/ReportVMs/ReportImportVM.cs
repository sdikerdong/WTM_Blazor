using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.ReportVMs
{
    public partial class ReportTemplateVM : BaseTemplateVM
    {
        [Display(Name = "体温")]
        public ExcelPropety temperature_Excel = ExcelPropety.CreateProperty<Report>(x => x.temperature);
        [Display(Name = "备注")]
        public ExcelPropety Remarks_Excel = ExcelPropety.CreateProperty<Report>(x => x.Remarks);
        public ExcelPropety patient_Excel = ExcelPropety.CreateProperty<Report>(x => x.patientID);

	    protected override void InitVM()
        {
            patient_Excel.DataType = ColumnDataType.ComboBox;
            patient_Excel.ListItems = DC.Set<Patient>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class ReportImportVM : BaseImportVM<ReportTemplateVM, Report>
    {

    }

}
