using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.ReportVMs
{
    public partial class ReportListVM : BasePagedListVM<Report_View, ReportSearcher>
    {

        protected override IEnumerable<IGridColumn<Report_View>> InitGridHeader()
        {
            return new List<GridColumn<Report_View>>{
                this.MakeGridHeader(x => x.temperature),
                this.MakeGridHeader(x => x.Remarks),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Report_View> GetSearchQuery()
        {
            var query = DC.Set<Report>()
                .CheckEqual(Searcher.temperature, x=>x.temperature)
                .CheckEqual(Searcher.patientID, x=>x.patientID)
                .CheckContain(Searcher.patientName, x=>x.patientName)
                .Select(x => new Report_View
                {
				    ID = x.ID,
                    temperature = x.temperature,
                    Remarks = x.Remarks,
                    Name_view = x.patient.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Report_View : Report{
        [Display(Name = "User.Module1.PatientName")]
        public String Name_view { get; set; }

    }
}
