using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tekin.OA.EFDAL;
using Tekin.OA.IDAL;

namespace Tekin.OA.DALFactory
{
    /// <summary>
    /// 简单工厂设计模式
    /// </summary>
    public class StaticDalFactory
    {
        //返回接口类
        public static IUserInfoDal GetUserInfoDal()
        {
            // 如果实现有修改,只需要修改这里的new对象即可
            //return new UserInfoDal();

            //使用反射的方式获取对象 
            // 在UI 修改配置文件的实例程序集和接口名称
            return  Assembly.Load("Tekin.OA.EFDAL").CreateInstance("UserInfoDal") as IUserInfoDal;
        }

        public static IOrderInfoDal GetOrderInfoDal()
        {
            return new OrderInfoDal();
        }
    }
}
