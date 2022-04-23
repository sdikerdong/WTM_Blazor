using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WTM_Blazor.Controllers;
using WTM_Blazor.ViewModel.MyUserVMs;
using WTM_Blazor.Model;
using WTM_Blazor.DataAccess;


namespace WTM_Blazor.Test
{
    [TestClass]
    public class MyUserApiTest
    {
        private MyUserController _controller;
        private string _seed;

        public MyUserApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<MyUserController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new MyUserSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            MyUserVM vm = _controller.Wtm.CreateVM<MyUserVM>();
            MyUser v = new MyUser();
            
            v.HospitalId = AddHospital();
            v.ControlCenterId = AddControlCenter();
            v.Email = "hbux9cTBJ4vrS";
            v.Gender = WalkingTec.Mvvm.Core.GenderEnum.Male;
            v.CellPhone = "AnLLn";
            v.HomePhone = "EW8j0n";
            v.Address = "tVVIanEst2HrFsRMsRDQyff0RrQGxGIqxCRdoIjMhXsINvgemGv4mOH3o8n7mzbnteyxaeQZP77XfIGcP7AA8okk2zZCQBgUHlUhuwZJFOe3StkWLoAbKwhaPOL7ifvwHJ3wWHMEfLi6hRUIWqUMQqYAEuGVVJ";
            v.ZipCode = "R";
            v.ITCode = "JDCIB1W5dYGNZss3DtDIQTiQIX7k41quniJiCbeUbhePd2";
            v.Password = "GHbLFRKh0C";
            v.Name = "YCP6BTrY59o";
            v.IsValid = false;
            v.PhotoId = AddFileAttachment();
            v.TenantCode = "5YlBCMtWRvVVakap1u1";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<MyUser>().Find(v.ID);
                
                Assert.AreEqual(data.Email, "hbux9cTBJ4vrS");
                Assert.AreEqual(data.Gender, WalkingTec.Mvvm.Core.GenderEnum.Male);
                Assert.AreEqual(data.CellPhone, "AnLLn");
                Assert.AreEqual(data.HomePhone, "EW8j0n");
                Assert.AreEqual(data.Address, "tVVIanEst2HrFsRMsRDQyff0RrQGxGIqxCRdoIjMhXsINvgemGv4mOH3o8n7mzbnteyxaeQZP77XfIGcP7AA8okk2zZCQBgUHlUhuwZJFOe3StkWLoAbKwhaPOL7ifvwHJ3wWHMEfLi6hRUIWqUMQqYAEuGVVJ");
                Assert.AreEqual(data.ZipCode, "R");
                Assert.AreEqual(data.ITCode, "JDCIB1W5dYGNZss3DtDIQTiQIX7k41quniJiCbeUbhePd2");
                Assert.AreEqual(data.Password, "GHbLFRKh0C");
                Assert.AreEqual(data.Name, "YCP6BTrY59o");
                Assert.AreEqual(data.IsValid, false);
                Assert.AreEqual(data.TenantCode, "5YlBCMtWRvVVakap1u1");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            MyUser v = new MyUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.HospitalId = AddHospital();
                v.ControlCenterId = AddControlCenter();
                v.Email = "hbux9cTBJ4vrS";
                v.Gender = WalkingTec.Mvvm.Core.GenderEnum.Male;
                v.CellPhone = "AnLLn";
                v.HomePhone = "EW8j0n";
                v.Address = "tVVIanEst2HrFsRMsRDQyff0RrQGxGIqxCRdoIjMhXsINvgemGv4mOH3o8n7mzbnteyxaeQZP77XfIGcP7AA8okk2zZCQBgUHlUhuwZJFOe3StkWLoAbKwhaPOL7ifvwHJ3wWHMEfLi6hRUIWqUMQqYAEuGVVJ";
                v.ZipCode = "R";
                v.ITCode = "JDCIB1W5dYGNZss3DtDIQTiQIX7k41quniJiCbeUbhePd2";
                v.Password = "GHbLFRKh0C";
                v.Name = "YCP6BTrY59o";
                v.IsValid = false;
                v.PhotoId = AddFileAttachment();
                v.TenantCode = "5YlBCMtWRvVVakap1u1";
                context.Set<MyUser>().Add(v);
                context.SaveChanges();
            }

            MyUserVM vm = _controller.Wtm.CreateVM<MyUserVM>();
            var oldID = v.ID;
            v = new MyUser();
            v.ID = oldID;
       		
            v.Email = "tLgiyGn8koeKZ7o83zFL";
            v.Gender = WalkingTec.Mvvm.Core.GenderEnum.Female;
            v.CellPhone = "bwxmDZE1Y1e";
            v.HomePhone = "32M";
            v.Address = "LSX4x6WtD7tNnmjYzVcqLVtG8g8NltILnz35uRJnfaMgnkr50759hLA6ezrEoTiskIsL5wjTcj6nqNh6QtR4VTAOKr73UFc59pt9fJKy6SfAN5d13xIra9G4OLQ9pANTvFsduW29cbDYgHO";
            v.ZipCode = "i";
            v.ITCode = "Xv0VY4V8sF9y40ID89Ve3eridDCgdl";
            v.Password = "zC4FXeQkIAVIM";
            v.Name = "HzQALCWfw97aSXDJvuqyTa7ydoEznOYt4PKcu2D4";
            v.IsValid = true;
            v.TenantCode = "Hw59XOoNew5f9A";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.HospitalId", "");
            vm.FC.Add("Entity.ControlCenterId", "");
            vm.FC.Add("Entity.Email", "");
            vm.FC.Add("Entity.Gender", "");
            vm.FC.Add("Entity.CellPhone", "");
            vm.FC.Add("Entity.HomePhone", "");
            vm.FC.Add("Entity.Address", "");
            vm.FC.Add("Entity.ZipCode", "");
            vm.FC.Add("Entity.ITCode", "");
            vm.FC.Add("Entity.Password", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.IsValid", "");
            vm.FC.Add("Entity.PhotoId", "");
            vm.FC.Add("Entity.TenantCode", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<MyUser>().Find(v.ID);
 				
                Assert.AreEqual(data.Email, "tLgiyGn8koeKZ7o83zFL");
                Assert.AreEqual(data.Gender, WalkingTec.Mvvm.Core.GenderEnum.Female);
                Assert.AreEqual(data.CellPhone, "bwxmDZE1Y1e");
                Assert.AreEqual(data.HomePhone, "32M");
                Assert.AreEqual(data.Address, "LSX4x6WtD7tNnmjYzVcqLVtG8g8NltILnz35uRJnfaMgnkr50759hLA6ezrEoTiskIsL5wjTcj6nqNh6QtR4VTAOKr73UFc59pt9fJKy6SfAN5d13xIra9G4OLQ9pANTvFsduW29cbDYgHO");
                Assert.AreEqual(data.ZipCode, "i");
                Assert.AreEqual(data.ITCode, "Xv0VY4V8sF9y40ID89Ve3eridDCgdl");
                Assert.AreEqual(data.Password, "zC4FXeQkIAVIM");
                Assert.AreEqual(data.Name, "HzQALCWfw97aSXDJvuqyTa7ydoEznOYt4PKcu2D4");
                Assert.AreEqual(data.IsValid, true);
                Assert.AreEqual(data.TenantCode, "Hw59XOoNew5f9A");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            MyUser v = new MyUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.HospitalId = AddHospital();
                v.ControlCenterId = AddControlCenter();
                v.Email = "hbux9cTBJ4vrS";
                v.Gender = WalkingTec.Mvvm.Core.GenderEnum.Male;
                v.CellPhone = "AnLLn";
                v.HomePhone = "EW8j0n";
                v.Address = "tVVIanEst2HrFsRMsRDQyff0RrQGxGIqxCRdoIjMhXsINvgemGv4mOH3o8n7mzbnteyxaeQZP77XfIGcP7AA8okk2zZCQBgUHlUhuwZJFOe3StkWLoAbKwhaPOL7ifvwHJ3wWHMEfLi6hRUIWqUMQqYAEuGVVJ";
                v.ZipCode = "R";
                v.ITCode = "JDCIB1W5dYGNZss3DtDIQTiQIX7k41quniJiCbeUbhePd2";
                v.Password = "GHbLFRKh0C";
                v.Name = "YCP6BTrY59o";
                v.IsValid = false;
                v.PhotoId = AddFileAttachment();
                v.TenantCode = "5YlBCMtWRvVVakap1u1";
                context.Set<MyUser>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            MyUser v1 = new MyUser();
            MyUser v2 = new MyUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.HospitalId = AddHospital();
                v1.ControlCenterId = AddControlCenter();
                v1.Email = "hbux9cTBJ4vrS";
                v1.Gender = WalkingTec.Mvvm.Core.GenderEnum.Male;
                v1.CellPhone = "AnLLn";
                v1.HomePhone = "EW8j0n";
                v1.Address = "tVVIanEst2HrFsRMsRDQyff0RrQGxGIqxCRdoIjMhXsINvgemGv4mOH3o8n7mzbnteyxaeQZP77XfIGcP7AA8okk2zZCQBgUHlUhuwZJFOe3StkWLoAbKwhaPOL7ifvwHJ3wWHMEfLi6hRUIWqUMQqYAEuGVVJ";
                v1.ZipCode = "R";
                v1.ITCode = "JDCIB1W5dYGNZss3DtDIQTiQIX7k41quniJiCbeUbhePd2";
                v1.Password = "GHbLFRKh0C";
                v1.Name = "YCP6BTrY59o";
                v1.IsValid = false;
                v1.PhotoId = AddFileAttachment();
                v1.TenantCode = "5YlBCMtWRvVVakap1u1";
                v2.HospitalId = v1.HospitalId; 
                v2.ControlCenterId = v1.ControlCenterId; 
                v2.Email = "tLgiyGn8koeKZ7o83zFL";
                v2.Gender = WalkingTec.Mvvm.Core.GenderEnum.Female;
                v2.CellPhone = "bwxmDZE1Y1e";
                v2.HomePhone = "32M";
                v2.Address = "LSX4x6WtD7tNnmjYzVcqLVtG8g8NltILnz35uRJnfaMgnkr50759hLA6ezrEoTiskIsL5wjTcj6nqNh6QtR4VTAOKr73UFc59pt9fJKy6SfAN5d13xIra9G4OLQ9pANTvFsduW29cbDYgHO";
                v2.ZipCode = "i";
                v2.ITCode = "Xv0VY4V8sF9y40ID89Ve3eridDCgdl";
                v2.Password = "zC4FXeQkIAVIM";
                v2.Name = "HzQALCWfw97aSXDJvuqyTa7ydoEznOYt4PKcu2D4";
                v2.IsValid = true;
                v2.PhotoId = v1.PhotoId; 
                v2.TenantCode = "Hw59XOoNew5f9A";
                context.Set<MyUser>().Add(v1);
                context.Set<MyUser>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<MyUser>().Find(v1.ID);
                var data2 = context.Set<MyUser>().Find(v2.ID);
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

                v.Name = "X3VYW";
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

                v.Name = "RSAH2YIp6plfehv34jv";
                v.LocationId = AddCity();
                v.Level = WTM_Blazor.Model.HospitalLevel.Class3;
                context.Set<Hospital>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddControlCenter()
        {
            ControlCenter v = new ControlCenter();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.Name = "M466kzCf5V2cfVCT";
                v.LocationId = AddCity();
                context.Set<ControlCenter>().Add(v);
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

                v.FileName = "vIinRPRughIbaojFg";
                v.FileExt = "z";
                v.Path = "Rths";
                v.Length = 6;
                v.UploadTime = DateTime.Parse("2023-05-28 10:41:02");
                v.SaveMode = "scm0NrEZFm1uPxvK";
                v.ExtraInfo = "054ZhVCOfGEPko8";
                v.HandlerInfo = "XF4Va";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
