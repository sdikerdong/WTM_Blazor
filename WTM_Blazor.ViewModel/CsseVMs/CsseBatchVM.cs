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
    public partial class CsseBatchVM : BaseBatchVM<Csse, Csse_BatchEdit>
    {
        public CsseBatchVM()
        {
            ListVM = new CsseListVM();
            LinkedVM = new Csse_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Csse_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
