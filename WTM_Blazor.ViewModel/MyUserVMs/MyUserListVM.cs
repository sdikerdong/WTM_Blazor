using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.MyUserVMs
{
    public partial class MyUserListVM : BasePagedListVM<MyUser_View, MyUserSearcher>
    {

        protected override IEnumerable<IGridColumn<MyUser_View>> InitGridHeader()
        {
            return new List<GridColumn<MyUser_View>>{
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Name_view2),
                this.MakeGridHeader(x => x.Email),
                this.MakeGridHeader(x => x.Gender),
                this.MakeGridHeader(x => x.CellPhone),
                this.MakeGridHeader(x => x.HomePhone),
                this.MakeGridHeader(x => x.Address),
                this.MakeGridHeader(x => x.ZipCode),
                this.MakeGridHeader(x => x.ITCode),
                this.MakeGridHeader(x => x.Password),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.IsValid),
                this.MakeGridHeader(x => x.PhotoId).SetFormat(PhotoIdFormat),
                this.MakeGridHeader(x => x.TenantCode),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> PhotoIdFormat(MyUser_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PhotoId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PhotoId,640,480),
            };
        }


        public override IOrderedQueryable<MyUser_View> GetSearchQuery()
        {
            var query = DC.Set<MyUser>()
                .CheckEqual(Searcher.HospitalId, x=>x.HospitalId)
                .CheckContain(Searcher.Email, x=>x.Email)
                .CheckEqual(Searcher.Gender, x=>x.Gender)
                .CheckContain(Searcher.ITCode, x=>x.ITCode)
                .Select(x => new MyUser_View
                {
				    ID = x.ID,
                    Name_view = x.Hospital.Name,
                    Name_view2 = x.ControlCenter.Name,
                    Email = x.Email,
                    Gender = x.Gender,
                    CellPhone = x.CellPhone,
                    HomePhone = x.HomePhone,
                    Address = x.Address,
                    ZipCode = x.ZipCode,
                    ITCode = x.ITCode,
                    Password = x.Password,
                    Name = x.Name,
                    IsValid = x.IsValid,
                    PhotoId = x.PhotoId,
                    TenantCode = x.TenantCode,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class MyUser_View : MyUser{
        [Display(Name = "User1.Module1.HospitalName")]
        public String Name_view { get; set; }
        [Display(Name = "中心名称")]
        public String Name_view2 { get; set; }

    }
}
