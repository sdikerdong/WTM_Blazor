using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WTM_Blazor.Controllers;
using WTM_Blazor.ViewModel.PatientVMs;
using WTM_Blazor.Model;
using WTM_Blazor.DataAccess;


namespace WTM_Blazor.Test
{
    [TestClass]
    public class PatientApiTest
    {
        private PatientController _controller;
        private string _seed;

        public PatientApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<PatientController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new PatientSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            PatientVM vm = _controller.Wtm.CreateVM<PatientVM>();
            Patient v = new Patient();
            
            v.Name = "y05iPG0iHvKik";
            v.PersonalID = "mQsiJt62kjLn";
            v.PatientSex = WTM_Blazor.Model.SexEnum.Female;
            v.birthday = DateTime.Parse("2021-03-09 12:22:13");
            v.LocationId = AddCity();
            v.hospitalId = AddHospital();
            v.patientStatus = WTM_Blazor.Model.PatientStatuEnum.NoException;
            v.photoId = AddFileAttachment();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Patient>().Find(v.ID);
                
                Assert.AreEqual(data.Name, "y05iPG0iHvKik");
                Assert.AreEqual(data.PersonalID, "mQsiJt62kjLn");
                Assert.AreEqual(data.PatientSex, WTM_Blazor.Model.SexEnum.Female);
                Assert.AreEqual(data.birthday, DateTime.Parse("2021-03-09 12:22:13"));
                Assert.AreEqual(data.patientStatus, WTM_Blazor.Model.PatientStatuEnum.NoException);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Patient v = new Patient();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Name = "y05iPG0iHvKik";
                v.PersonalID = "mQsiJt62kjLn";
                v.PatientSex = WTM_Blazor.Model.SexEnum.Female;
                v.birthday = DateTime.Parse("2021-03-09 12:22:13");
                v.LocationId = AddCity();
                v.hospitalId = AddHospital();
                v.patientStatus = WTM_Blazor.Model.PatientStatuEnum.NoException;
                v.photoId = AddFileAttachment();
                context.Set<Patient>().Add(v);
                context.SaveChanges();
            }

            PatientVM vm = _controller.Wtm.CreateVM<PatientVM>();
            var oldID = v.ID;
            v = new Patient();
            v.ID = oldID;
       		
            v.Name = "h8oC519RXKr9I";
            v.PersonalID = "WKAMFOlsY67vybp";
            v.PatientSex = WTM_Blazor.Model.SexEnum.Male;
            v.birthday = DateTime.Parse("2022-07-03 12:22:13");
            v.patientStatus = WTM_Blazor.Model.PatientStatuEnum.NoException;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.PersonalID", "");
            vm.FC.Add("Entity.PatientSex", "");
            vm.FC.Add("Entity.birthday", "");
            vm.FC.Add("Entity.LocationId", "");
            vm.FC.Add("Entity.hospitalId", "");
            vm.FC.Add("Entity.patientStatus", "");
            vm.FC.Add("Entity.photoId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Patient>().Find(v.ID);
 				
                Assert.AreEqual(data.Name, "h8oC519RXKr9I");
                Assert.AreEqual(data.PersonalID, "WKAMFOlsY67vybp");
                Assert.AreEqual(data.PatientSex, WTM_Blazor.Model.SexEnum.Male);
                Assert.AreEqual(data.birthday, DateTime.Parse("2022-07-03 12:22:13"));
                Assert.AreEqual(data.patientStatus, WTM_Blazor.Model.PatientStatuEnum.NoException);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Patient v = new Patient();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Name = "y05iPG0iHvKik";
                v.PersonalID = "mQsiJt62kjLn";
                v.PatientSex = WTM_Blazor.Model.SexEnum.Female;
                v.birthday = DateTime.Parse("2021-03-09 12:22:13");
                v.LocationId = AddCity();
                v.hospitalId = AddHospital();
                v.patientStatus = WTM_Blazor.Model.PatientStatuEnum.NoException;
                v.photoId = AddFileAttachment();
                context.Set<Patient>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Patient v1 = new Patient();
            Patient v2 = new Patient();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "y05iPG0iHvKik";
                v1.PersonalID = "mQsiJt62kjLn";
                v1.PatientSex = WTM_Blazor.Model.SexEnum.Female;
                v1.birthday = DateTime.Parse("2021-03-09 12:22:13");
                v1.LocationId = AddCity();
                v1.hospitalId = AddHospital();
                v1.patientStatus = WTM_Blazor.Model.PatientStatuEnum.NoException;
                v1.photoId = AddFileAttachment();
                v2.Name = "h8oC519RXKr9I";
                v2.PersonalID = "WKAMFOlsY67vybp";
                v2.PatientSex = WTM_Blazor.Model.SexEnum.Male;
                v2.birthday = DateTime.Parse("2022-07-03 12:22:13");
                v2.LocationId = v1.LocationId; 
                v2.hospitalId = v1.hospitalId; 
                v2.patientStatus = WTM_Blazor.Model.PatientStatuEnum.NoException;
                v2.photoId = v1.photoId; 
                context.Set<Patient>().Add(v1);
                context.Set<Patient>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Patient>().Find(v1.ID);
                var data2 = context.Set<Patient>().Find(v2.ID);
                Assert.AreEqual(data1.IsValid, false);
            Assert.AreEqual(data2.IsValid, false);
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

                v.Name = "7LUtrwDu01saVZxT5f";
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

                v.Name = "FvXpG13wq0";
                v.LocationId = AddCity();
                v.Level = WTM_Blazor.Model.HospitalLevel.Class3;
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

                v.FileName = "XbwesU7yBbiUxstDRKw";
                v.FileExt = "U8uB";
                v.Path = "CEXGn7Bg95y";
                v.Length = 54;
                v.UploadTime = DateTime.Parse("2021-06-02 12:22:13");
                v.SaveMode = "EeZui7braQlH88bpYA";
                v.ExtraInfo = "w76Yh6gxTvF";
                v.HandlerInfo = "Xpwb";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
