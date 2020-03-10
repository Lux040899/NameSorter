﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Name
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
             
            builder.RegisterType<Handler>().As<IHandler>();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<ReadFromDB>().As<IRead>();
            builder.RegisterType<Output>().As<IOutput>();
            builder.RegisterType<Name>().As<IName>();
            builder.RegisterType<NameParser>().As<INameParser>();
            builder.RegisterType<Sort>().As<ISort>();
            builder.RegisterType<WriteToDB>().As<IWrite>();

            return builder.Build();
        }
    }
}