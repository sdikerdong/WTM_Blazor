using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WTM_Blazor.Controllers;
using WTM_Blazor.ViewModel.HospitalVMs;
using WTM_Blazor.Model;
using WTM_Blazor.DataAccess;


namespace WTM_Blazor.Test
{
    [TestClass]
    public class HospitalApiTest
    {
        private HospitalController _controller;
        private string _seed;

        public HospitalApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<HospitalController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new HospitalSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            HospitalVM vm = _controller.Wtm.CreateVM<HospitalVM>();
            Hospital v = new Hospital();
            
            v.Name = "jQu6uLeULsz";
            v.LocationId = AddCity();
            v.Level = WTM_Blazor.Model.HospitalLevel.Class1;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Hospital>().Find(v.ID);
                
                Assert.AreEqual(data.Name, "jQu6uLeULsz");
                Assert.AreEqual(data.Level, WTM_Blazor.Model.HospitalLevel.Class1);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Hospital v = new Hospital();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Name = "jQu6uLeULsz";
                v.LocationId = AddCity();
                v.Level = WTM_Blazor.Model.HospitalLevel.Class1;
                context.Set<Hospital>().Add(v);
                context.SaveChanges();
            }

            HospitalVM vm = _controller.Wtm.CreateVM<HospitalVM>();
            var oldID = v.ID;
            v = new Hospital();
            v.ID = oldID;
       		
            v.Name = "hmEVT";
            v.Level = WTM_Blazor.Model.HospitalLevel.Class2;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.LocationId", "");
            vm.FC.Add("Entity.Level", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Hospital>().Find(v.ID);
 				
                Assert.AreEqual(data.Name, "hmEVT");
                Assert.AreEqual(data.Level, WTM_Blazor.Model.HospitalLevel.Class2);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Hospital v = new Hospital();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Name = "jQu6uLeULsz";
                v.LocationId = AddCity();
                v.Level = WTM_Blazor.Model.HospitalLevel.Class1;
                context.Set<Hospital>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Hospital v1 = new Hospital();
            Hospital v2 = new Hospital();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "jQu6uLeULsz";
                v1.LocationId = AddCity();
                v1.Level = WTM_Blazor.Model.HospitalLevel.Class1;
                v2.Name = "hmEVT";
                v2.LocationId = v1.LocationId; 
                v2.Level = WTM_Blazor.Model.HospitalLevel.Class2;
                context.Set<Hospital>().Add(v1);
                context.Set<Hospital>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Hospital>().Find(v1.ID);
                var data2 = context.Set<Hospital>().Find(v2.ID);
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

                v.Name = "MRmQ";
                context.Set<City>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
