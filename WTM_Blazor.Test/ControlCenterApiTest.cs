using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WTM_Blazor.Controllers;
using WTM_Blazor.ViewModel.ControlCenterVMs;
using WTM_Blazor.Model;
using WTM_Blazor.DataAccess;


namespace WTM_Blazor.Test
{
    [TestClass]
    public class ControlCenterApiTest
    {
        private ControlCenterController _controller;
        private string _seed;

        public ControlCenterApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<ControlCenterController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new ControlCenterSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            ControlCenterVM vm = _controller.Wtm.CreateVM<ControlCenterVM>();
            ControlCenter v = new ControlCenter();
            
            v.Name = "Uu4j1";
            v.LocationId = AddCity();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ControlCenter>().Find(v.ID);
                
                Assert.AreEqual(data.Name, "Uu4j1");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            ControlCenter v = new ControlCenter();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Name = "Uu4j1";
                v.LocationId = AddCity();
                context.Set<ControlCenter>().Add(v);
                context.SaveChanges();
            }

            ControlCenterVM vm = _controller.Wtm.CreateVM<ControlCenterVM>();
            var oldID = v.ID;
            v = new ControlCenter();
            v.ID = oldID;
       		
            v.Name = "bO1Oo3wV0Oi7aBUq7JR";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.LocationId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ControlCenter>().Find(v.ID);
 				
                Assert.AreEqual(data.Name, "bO1Oo3wV0Oi7aBUq7JR");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            ControlCenter v = new ControlCenter();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Name = "Uu4j1";
                v.LocationId = AddCity();
                context.Set<ControlCenter>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ControlCenter v1 = new ControlCenter();
            ControlCenter v2 = new ControlCenter();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Name = "Uu4j1";
                v1.LocationId = AddCity();
                v2.Name = "bO1Oo3wV0Oi7aBUq7JR";
                v2.LocationId = v1.LocationId; 
                context.Set<ControlCenter>().Add(v1);
                context.Set<ControlCenter>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<ControlCenter>().Find(v1.ID);
                var data2 = context.Set<ControlCenter>().Find(v2.ID);
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

                v.Name = "7bPItFzsUzL6l";
                context.Set<City>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
