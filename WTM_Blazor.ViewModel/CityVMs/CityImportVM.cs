﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.CityVMs
{
    public partial class CityTemplateVM : BaseTemplateVM
    {
        [Display(Name = "User.Module1.CityName")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<City>(x => x.Name);
        [Display(Name = "_Admin.Parent")]
        public ExcelPropety Parent_Excel = ExcelPropety.CreateProperty<City>(x => x.ParentId);

	    protected override void InitVM()
        {
            Parent_Excel.DataType = ColumnDataType.ComboBox;
            Parent_Excel.ListItems = DC.Set<City>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class CityImportVM : BaseImportVM<CityTemplateVM, City>
    {

    }

}
