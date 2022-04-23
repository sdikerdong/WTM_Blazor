using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WTM_Blazor.Controllers;
using WTM_Blazor.ViewModel.CsseVMs;
using WTM_Blazor.Model;
using WTM_Blazor.DataAccess;


namespace WTM_Blazor.Test
{
    [TestClass]
    public class CsseApiTest
    {
        private CsseController _controller;
        private string _seed;

        public CsseApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<CsseController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new CsseSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            CsseVM vm = _controller.Wtm.CreateVM<CsseVM>();
            Csse v = new Csse();
            
            v.Country = "OWpK9mHIXf";
            v.Province = "iQBppzhr6MEUhy8Zds";
            v.JingDu = 25;
            v.WeiDu = 59;
            v.Date = DateTime.Parse("2022-01-28 17:29:01");
            v.ConfirmCsse = 74;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Csse>().Find(v.ID);
                
                Assert.AreEqual(data.Country, "OWpK9mHIXf");
                Assert.AreEqual(data.Province, "iQBppzhr6MEUhy8Zds");
                Assert.AreEqual(data.JingDu, 25);
                Assert.AreEqual(data.WeiDu, 59);
                Assert.AreEqual(data.Date, DateTime.Parse("2022-01-28 17:29:01"));
                Assert.AreEqual(data.ConfirmCsse, 74);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Csse v = new Csse();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Country = "OWpK9mHIXf";
                v.Province = "iQBppzhr6MEUhy8Zds";
                v.JingDu = 25;
                v.WeiDu = 59;
                v.Date = DateTime.Parse("2022-01-28 17:29:01");
                v.ConfirmCsse = 74;
                context.Set<Csse>().Add(v);
                context.SaveChanges();
            }

            CsseVM vm = _controller.Wtm.CreateVM<CsseVM>();
            var oldID = v.ID;
            v = new Csse();
            v.ID = oldID;
       		
            v.Country = "RPYVhoQbvNqVc";
            v.Province = "ppoCG51jhves8Yyf";
            v.JingDu = 99;
            v.WeiDu = 55;
            v.Date = DateTime.Parse("2022-02-11 17:29:01");
            v.ConfirmCsse = 19;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Country", "");
            vm.FC.Add("Entity.Province", "");
            vm.FC.Add("Entity.JingDu", "");
            vm.FC.Add("Entity.WeiDu", "");
            vm.FC.Add("Entity.Date", "");
            vm.FC.Add("Entity.ConfirmCsse", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Csse>().Find(v.ID);
 				
                Assert.AreEqual(data.Country, "RPYVhoQbvNqVc");
                Assert.AreEqual(data.Province, "ppoCG51jhves8Yyf");
                Assert.AreEqual(data.JingDu, 99);
                Assert.AreEqual(data.WeiDu, 55);
                Assert.AreEqual(data.Date, DateTime.Parse("2022-02-11 17:29:01"));
                Assert.AreEqual(data.ConfirmCsse, 19);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Csse v = new Csse();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Country = "OWpK9mHIXf";
                v.Province = "iQBppzhr6MEUhy8Zds";
                v.JingDu = 25;
                v.WeiDu = 59;
                v.Date = DateTime.Parse("2022-01-28 17:29:01");
                v.ConfirmCsse = 74;
                context.Set<Csse>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Csse v1 = new Csse();
            Csse v2 = new Csse();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Country = "OWpK9mHIXf";
                v1.Province = "iQBppzhr6MEUhy8Zds";
                v1.JingDu = 25;
                v1.WeiDu = 59;
                v1.Date = DateTime.Parse("2022-01-28 17:29:01");
                v1.ConfirmCsse = 74;
                v2.Country = "RPYVhoQbvNqVc";
                v2.Province = "ppoCG51jhves8Yyf";
                v2.JingDu = 99;
                v2.WeiDu = 55;
                v2.Date = DateTime.Parse("2022-02-11 17:29:01");
                v2.ConfirmCsse = 19;
                context.Set<Csse>().Add(v1);
                context.Set<Csse>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Csse>().Find(v1.ID);
                var data2 = context.Set<Csse>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
