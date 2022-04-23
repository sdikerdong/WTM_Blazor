using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.VirusVMs
{
    public partial class VirusVM : BaseCRUDVM<Virus>
    {
        [Display(Name = "patientVirus")]
        public List<string> SelectedpatientVirusIDs { get; set; }

        public VirusVM()
        {
            SetInclude(x => x.patientVirus);
        }

        protected override void InitVM()
        {
            SelectedpatientVirusIDs = Entity.patientVirus?.Select(x => x.patientId.ToString()).ToList();
        }

        public override void DoAdd()
        {
            Entity.patientVirus = new List<PatientVirus>();
            if (SelectedpatientVirusIDs != null)
            {
                foreach (var id in SelectedpatientVirusIDs)
                {
                     PatientVirus middle = new PatientVirus();
                    middle.SetPropertyValue("patientId", id);
                    Entity.patientVirus.Add(middle);
                }
            }
           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            Entity.patientVirus = new List<PatientVirus>();
            if(SelectedpatientVirusIDs != null )
            {
                 foreach (var item in SelectedpatientVirusIDs)
                {
                    PatientVirus middle = new PatientVirus();
                    middle.SetPropertyValue("patientId", item);
                    Entity.patientVirus.Add(middle);
                }
            }

            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
