using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PersonControll.Connection;
using PersonControll.Connection.IBMConnect;
using PersonControll.Connection.IBMConnect.Interface;
using PersonControll.Connection.Interface;
using PersonControll.Connection.ParsConfig;
using PersonControll.Connection.ParsConfig.Interface;
using PersonControll.Connection.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonControll.CastleWind
{
    public class CastleWindConf : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IGetTable>().ImplementedBy<Connect>().LifestyleTransient().Named("IGetTable"));
            container.Register(Component.For<IEditTable>().ImplementedBy<Connect>().LifestyleTransient().Named("IEditTable"));
            container.Register(Component.For<IParsConfig>().ImplementedBy<ParsConfig>().LifestyleTransient());
            container.Register(Component.For<IIfxConnectGetData>().ImplementedBy<ConnectionIBM>().LifestyleTransient().Named("IIfxConnectGetData"));
            container.Register(Component.For<IIfxConnectEditTable>().ImplementedBy<ConnectionIBM>().LifestyleTransient().Named("IIfxConnectEditTable"));
            container.Register(Component.For<ISQL>().ImplementedBy<SQL>().LifestyleTransient());
            container.Register(Component.For<IIfxCommandPar>().ImplementedBy<IfxCommandPar>().LifestyleTransient());
        }
    }
}