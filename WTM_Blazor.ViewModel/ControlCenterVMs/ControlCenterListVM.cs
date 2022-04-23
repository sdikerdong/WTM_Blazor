using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.ControlCenterVMs
{
    public partial class ControlCenterListVM : BasePagedListVM<ControlCenter_View, ControlCenterSearcher>
    {

        protected override IEnumerable<IGridColumn<ControlCenter_View>> InitGridHeader()
        {
            return new List<GridColumn<ControlCenter_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ControlCenter_View> GetSearchQuery()
        {
            var query = DC.Set<ControlCenter>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckEqual(Searcher.LocationId, x=>x.LocationId)
                .Select(x => new ControlCenter_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Name_view = x.Location.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ControlCenter_View : ControlCenter{
        [Display(Name = "User.Module1.CityName")]
        public String Name_view { get; set; }

    }
}
