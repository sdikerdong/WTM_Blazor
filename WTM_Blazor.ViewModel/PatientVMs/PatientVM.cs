using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTM_Blazor.Model;


namespace WTM_Blazor.ViewModel.PatientVMs
{
    public partial class PatientVM : BaseCRUDVM<Patient>
    {
        [Display(Name = "病毒名称")]
        public List<string> SelectedpatientVirusesIDs { get; set; }

        public PatientVM()
        {
            SetInclude(x => x.Location);
            SetInclude(x => x.hospital);
            SetInclude(x => x.patientViruses);
        }

        protected override void InitVM()
        {
            SelectedpatientVirusesIDs = Entity.patientViruses?.Select(x => x.virusId.ToString()).ToList();
        }

        public override void DoAdd()
        {
            Entity.patientViruses = new List<PatientVirus>();
            if (SelectedpatientVirusesIDs != null)
            {
                foreach (var id in SelectedpatientVirusesIDs)
                {
                     PatientVirus middle = new PatientVirus();
                    middle.SetPropertyValue("virusId", id);
                    Entity.patientViruses.Add(middle);
                }
            }
           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            Entity.patientViruses = new List<PatientVirus>();
            if(SelectedpatientVirusesIDs != null )
            {
                 foreach (var item in SelectedpatientVirusesIDs)
                {
                    PatientVirus middle = new PatientVirus();
                    middle.SetPropertyValue("virusId", item);
                    Entity.patientViruses.Add(middle);
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
