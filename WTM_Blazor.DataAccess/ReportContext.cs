using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WTM_Blazor.Model;

namespace WTM_Blazor.DataAccess
{
    public class ReportContext : EmptyContext
    {
        public DbSet<Csse> csses { get; set; }

        public ReportContext(CS cs) : base(cs)
        {

        }
        public ReportContext(string cs, DBTypeEnum dbtype) : base(cs, dbtype)
        {

        }
    }
}
