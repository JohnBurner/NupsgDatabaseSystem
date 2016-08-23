using Microsoft.Practices.Unity;
using NupsgDatabaseSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NupsgDatabaseSystem.ViewModel
{
    public static class ContainerHelper
    {
        static ContainerHelper()
        {
            _container = new UnityContainer();
            _container.RegisterType<IMemberService, MemberService>(new ContainerControlledLifetimeManager());
        }

        private static IUnityContainer _container;
        public static IUnityContainer Container
        {
            get { return _container; }
        }
    }
}
