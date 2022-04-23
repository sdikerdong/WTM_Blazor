using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.PatientVMs
{
    public partial class PatientListVM : BasePagedListVM<Patient_View, PatientSearcher>
    {
        protected override IEnumerable<IGridColumn<Patient_View>> InitGridHeader()
        {
            return new List<GridColumn<Patient_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.PersonalID),
                this.MakeGridHeader(x => x.PatientSex),
                this.MakeGridHeader(x => x.birthday),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Name_view2),
                this.MakeGridHeader(x => x.Name_view3),
                this.MakeGridHeader(x => x.patientStatus),
                this.MakeGridHeader(x => x.photoId).SetFormat(photoIdFormat),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> photoIdFormat(Patient_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.photoId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.photoId,640,480),
            };
        }


        public override IOrderedQueryable<Patient_View> GetSearchQuery()
        {
            var query = DC.Set<Patient>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckContain(Searcher.PersonalID, x=>x.PersonalID)
                .CheckEqual(Searcher.PatientSex, x=>x.PatientSex)
                .CheckEqual(Searcher.LocationId, x=>x.LocationId)
                .CheckEqual(Searcher.hospitalId, x=>x.hospitalId)
                .CheckEqual(Searcher.patientStatus, x=>x.patientStatus)
                .Select(x => new Patient_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    PersonalID = x.PersonalID,
                    PatientSex = x.PatientSex,
                    birthday = x.birthday,
                    Name_view = x.Location.Name,
                    Name_view2 = x.hospital.Name,
                    Name_view3 = x.patientViruses.Select(y=>y.virus.Name).ToSepratedString(null,","), 
                    patientStatus = x.patientStatus,
                    photoId = x.photoId,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Patient_View : Patient{
        [Display(Name = "User.Module1.CityName")]
        public String Name_view { get; set; }
        [Display(Name = "User1.Module1.HospitalName")]
        public String Name_view2 { get; set; }
        public String Name_view3 { get; set; }

    }
}
