using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace Common.Framework
{
    public static class UnityManager
    {
        private static IUnityContainer _container;

        // Constructor  
        public static IUnityContainer Container
        {
            get
            {
                if (_container == null)
                {
                    using (IUnityContainer newInstance = new UnityContainer())
                    {                        
                        UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                        section.Configure(newInstance);                                                
                        _container = newInstance;
                    }
                }
                return _container;
            }
            set
            {
                _container = value;
            }
        }

        public static T Resolve<T>(string service)
        {
            return Container.Resolve<T>(service);
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
