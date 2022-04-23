using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.HospitalVMs
{
    public partial class HospitalListVM : BasePagedListVM<Hospital_View, HospitalSearcher>
    {

        protected override IEnumerable<IGridColumn<Hospital_View>> InitGridHeader()
        {
            return new List<GridColumn<Hospital_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Level),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Hospital_View> GetSearchQuery()
        {
            var query = DC.Set<Hospital>()
                .CheckEqual(Searcher.Level, x=>x.Level)
                .Select(x => new Hospital_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Name_view = x.Location.Name,
                    Level = x.Level,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Hospital_View : Hospital{
        [Display(Name = "User.Module1.CityName")]
        public String Name_view { get; set; }

    }
}
