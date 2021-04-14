using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Tekin.OA.IDAL;

namespace Tekin.OA.DALFactory
{
    public class DbSessionFactory
    {
        /// <summary>
        /// DbSession一次请求共用一个实例
        /// 返回的是DbSession的接口 IDbSession
        /// </summary>
        /// <returns>IDbSession</returns>
        public static IDbSession GetCurrentDbSession()
        {
            IDbSession db = CallContext.GetData("DbSession") as IDbSession;
            if (db == null)
            {
                db = new DbSession();
                CallContext.SetData("DbSession", db);
            }

            return db;
        }
    }
}
