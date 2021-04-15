using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekin.OA.IBLL;
using Tekin.OA.Model;

namespace Tekin.OA.BLL
{
    public class OrderInfoService : BaseService<OrderInfo>,IOrderInfoService
    {
        //重写父类抽象方法
        public override void SetCurrentDal()
        {
           this.CurrentDal = this.DbSession.OrderInfoDal;
        }
    }
}
