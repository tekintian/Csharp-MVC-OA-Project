using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tekin.OA.Common;
using Tekin.OA.EFDAL;
using Tekin.OA.Model;

namespace Tekin.OA.UnitTest.Dal
{
    [TestClass]
    public class UserInfoDalUnitTest1
    {
        [TestMethod]
        public void TestGetUsers()
        {
            //单元测试  获取数据的方法
            UserInfoDal dal = new UserInfoDal();

            //单元测试必须自己处理数据,不能依赖第三方数据,如果要依赖第三方数据,必须先自己创建,然后再清除

            //先创建模拟数据
            for (int i = 0; i < 30; i++)
            {
                dal.Add(new UserInfo()
                {
                    UName = "封装"+StrUtils.GetRandStr(8)
                });
            }

            //查询数据
            IQueryable<UserInfo> tmp = dal.GetEntities(u => u.UName.Contains("aa"));
            
            //使用断言判断返回结果
            Assert.AreEqual(true,tmp.Count()>=10);
        }
    }
}
