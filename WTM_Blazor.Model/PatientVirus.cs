using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Attributes;

namespace WTM_Blazor.Model
{
    [MiddleTable]
    public class PatientVirus:TopBasePoco
    {
        public Patient patient { get; set; }
        public Guid patientId { get; set; }
        public Virus virus { get; set; }
        public Guid virusId { get; set; }
    }
}
