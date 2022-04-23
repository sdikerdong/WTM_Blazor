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
    public partial class ControlCenterBatchVM : BaseBatchVM<ControlCenter, ControlCenter_BatchEdit>
    {
        public ControlCenterBatchVM()
        {
            ListVM = new ControlCenterListVM();
            LinkedVM = new ControlCenter_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ControlCenter_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
