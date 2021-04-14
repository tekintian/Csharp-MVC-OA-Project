using System.Configuration;
using System.Reflection;
using Tekin.OA.EFDAL;
using Tekin.OA.IDAL;

namespace Tekin.OA.DALFactory
{
    /// <summary>
    /// 设计模式
    /// 简单工厂  需要修改new实现代码
    /// 抽象工厂  使用反射将new放入配置,不需要修改实现代码
    /// </summary>
    public class StaticDalFactory
    {
        private static string assemblyName = ConfigurationManager.AppSettings["DalAssemblyName"];
        //返回接口类
        public static IUserInfoDal GetUserInfoDal()
        {
            // 如果实现有修改,只需要修改这里的new对象即可
            //return new UserInfoDal();

            //使用反射的方式获取对象 
            // 在UI 修改配置文件的实例程序集名称

            return Assembly.Load(assemblyName).CreateInstance("UserInfoDal") as IUserInfoDal;
        }
        //抽象工厂模式实现
        public static IOrderInfoDal GetOrderInfoDal()
        {
            return Assembly.Load(assemblyName).CreateInstance("IOrderInfoDal") as IOrderInfoDal;
        }
    }
}
