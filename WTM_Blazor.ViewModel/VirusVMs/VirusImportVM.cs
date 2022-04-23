using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.VirusVMs
{
    public partial class VirusTemplateVM : BaseTemplateVM
    {
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Virus>(x => x.Name);

	    protected override void InitVM()
        {
        }

    }

    public class VirusImportVM : BaseImportVM<VirusTemplateVM, Virus>
    {

    }

}
