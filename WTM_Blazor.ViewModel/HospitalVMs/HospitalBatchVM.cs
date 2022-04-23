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
    public partial class HospitalBatchVM : BaseBatchVM<Hospital, Hospital_BatchEdit>
    {
        public HospitalBatchVM()
        {
            ListVM = new HospitalListVM();
            LinkedVM = new Hospital_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Hospital_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
