using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace WTM_Blazor.Model
{
    public   class Virus:BasePoco
    {
        public string Name { get; set; }    
        public List<PatientVirus> patientVirus { get; set; }

    }
}
