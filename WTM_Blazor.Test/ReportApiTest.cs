using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WTM_Blazor.Controllers;
using WTM_Blazor.ViewModel.ReportVMs;
using WTM_Blazor.Model;
using WTM_Blazor.DataAccess;


namespace WTM_Blazor.Test
{
    [TestClass]
    public class ReportApiTest
    {
        private ReportController _controller;
        private string _seed;

        public ReportApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<ReportController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new ReportSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            ReportVM vm = _controller.Wtm.CreateVM<ReportVM>();
            Report v = new Report();
            
            v.temperature = 21;
            v.Remarks = "luwPu7mc";
            v.patientID = AddPatient();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Report>().Find(v.ID);
                
                Assert.AreEqual(data.temperature, 21);
                Assert.AreEqual(data.Remarks, "luwPu7mc");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Report v = new Report();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.temperature = 21;
                v.Remarks = "luwPu7mc";
                v.patientID = AddPatient();
                context.Set<Report>().Add(v);
                context.SaveChanges();
            }

            ReportVM vm = _controller.Wtm.CreateVM<ReportVM>();
            var oldID = v.ID;
            v = new Report();
            v.ID = oldID;
       		
            v.temperature = 22;
            v.Remarks = "Vj7W2BxVR7GVoxDN";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.temperature", "");
            vm.FC.Add("Entity.Remarks", "");
            vm.FC.Add("Entity.patientID", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Report>().Find(v.ID);
 				
                Assert.AreEqual(data.temperature, 22);
                Assert.AreEqual(data.Remarks, "Vj7W2BxVR7GVoxDN");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Report v = new Report();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.temperature = 21;
                v.Remarks = "luwPu7mc";
                v.patientID = AddPatient();
                context.Set<Report>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Report v1 = new Report();
            Report v2 = new Report();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.temperature = 21;
                v1.Remarks = "luwPu7mc";
                v1.patientID = AddPatient();
                v2.temperature = 22;
                v2.Remarks = "Vj7W2BxVR7GVoxDN";
                v2.patientID = v1.patientID; 
                context.Set<Report>().Add(v1);
                context.Set<Report>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Report>().Find(v1.ID);
                var data2 = context.Set<Report>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Guid AddCity()
        {
            City v = new City();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "u3sO8cczlIfW";
                context.Set<City>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddHospital()
        {
            Hospital v = new Hospital();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "UtSgTkIE4TzzKnjHilo";
                v.LocationId = AddCity();
                v.Level = WTM_Blazor.Model.HospitalLevel.Class2;
                context.Set<Hospital>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddFileAttachment()
        {
            FileAttachment v = new FileAttachment();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.FileName = "J2cPRYrUm";
                v.FileExt = "6";
                v.Path = "PHvXVcu";
                v.Length = 80;
                v.UploadTime = DateTime.Parse("2021-12-01 17:29:37");
                v.SaveMode = "S";
                v.ExtraInfo = "xqS6Q9p6xp";
                v.HandlerInfo = "Ms37Wj";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddPatient()
        {
            Patient v = new Patient();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "RK0";
                v.PersonalID = "7f";
                v.PatientSex = WTM_Blazor.Model.SexEnum.Female;
                v.birthday = DateTime.Parse("2022-09-24 17:29:37");
                v.LocationId = AddCity();
                v.hospitalId = AddHospital();
                v.patientStatus = WTM_Blazor.Model.PatientStatuEnum.NoException;
                v.photoId = AddFileAttachment();
                context.Set<Patient>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
