using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.CsseVMs
{
    public partial class CsseTemplateVM : BaseTemplateVM
    {
        [Display(Name = "国家")]
        public ExcelPropety Country_Excel = ExcelPropety.CreateProperty<Csse>(x => x.Country);
        [Display(Name = "省份")]
        public ExcelPropety Province_Excel = ExcelPropety.CreateProperty<Csse>(x => x.Province);
        [Display(Name = "经度")]
        public ExcelPropety JingDu_Excel = ExcelPropety.CreateProperty<Csse>(x => x.JingDu);
        [Display(Name = "纬度")]
        public ExcelPropety WeiDu_Excel = ExcelPropety.CreateProperty<Csse>(x => x.WeiDu);
        [Display(Name = "日期")]
        public ExcelPropety Date_Excel = ExcelPropety.CreateProperty<Csse>(x => x.Date);
        [Display(Name = "确诊")]
        public ExcelPropety ConfirmCsse_Excel = ExcelPropety.CreateProperty<Csse>(x => x.ConfirmCsse);

	    protected override void InitVM()
        {
        }

    }

    public class CsseImportVM : BaseImportVM<CsseTemplateVM, Csse>
    {

    }

}
