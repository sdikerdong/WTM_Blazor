using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.VirusVMs
{
    public partial class VirusListVM : BasePagedListVM<Virus_View, VirusSearcher>
    {

        protected override IEnumerable<IGridColumn<Virus_View>> InitGridHeader()
        {
            return new List<GridColumn<Virus_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Virus_View> GetSearchQuery()
        {
            var query = DC.Set<Virus>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckWhere(Searcher.SelectedpatientVirusIDs,x=>DC.Set<PatientVirus>().Where(y=>Searcher.SelectedpatientVirusIDs.Contains(y.patientId)).Select(z=>z.virusId).Contains(x.ID))
                .Select(x => new Virus_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Name_view = x.patientVirus.Select(y=>y.patient.Name).ToSepratedString(null,","), 
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Virus_View : Virus{
        public String Name_view { get; set; }

    }
}
