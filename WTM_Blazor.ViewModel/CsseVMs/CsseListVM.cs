using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.CsseVMs
{
    public partial class CsseListVM : BasePagedListVM<Csse_View, CsseSearcher>
    {

        protected override IEnumerable<IGridColumn<Csse_View>> InitGridHeader()
        {
            return new List<GridColumn<Csse_View>>{
                this.MakeGridHeader(x => x.Country),
                this.MakeGridHeader(x => x.Province),
                this.MakeGridHeader(x => x.JingDu),
                this.MakeGridHeader(x => x.WeiDu),
                this.MakeGridHeader(x => x.Date),
                this.MakeGridHeader(x => x.ConfirmCsse),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Csse_View> GetSearchQuery()
        {
            var query = DC.Set<Csse>()
                .CheckContain(Searcher.Country, x=>x.Country)
                .CheckContain(Searcher.Province, x=>x.Province)
                .Select(x => new Csse_View
                {
				    ID = x.ID,
                    Country = x.Country,
                    Province = x.Province,
                    JingDu = x.JingDu,
                    WeiDu = x.WeiDu,
                    Date = x.Date,
                    ConfirmCsse = x.ConfirmCsse,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Csse_View : Csse{

    }
}
