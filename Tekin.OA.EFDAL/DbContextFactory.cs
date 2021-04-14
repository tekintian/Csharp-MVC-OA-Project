﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekin.OA.Model;

namespace Tekin.OA.EFDAL
{
    /// <summary>
    /// 简单工厂模式的 上下文抽象工厂
    /// </summary>
    public class DbContextFactory
    {
        // 利用静态特性 实现一次请求共用一个实例  静态工厂方法
        public static DbContext GetDbContextFactory()
        {
            return new DataModelContainer();
        }
    }
}
