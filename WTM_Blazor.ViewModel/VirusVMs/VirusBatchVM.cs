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
    public partial class VirusBatchVM : BaseBatchVM<Virus, Virus_BatchEdit>
    {
        public VirusBatchVM()
        {
            ListVM = new VirusListVM();
            LinkedVM = new Virus_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Virus_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
