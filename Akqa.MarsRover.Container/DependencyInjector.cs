using System;
using System.Collections.Generic;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Akqa.MarsRover.Container
{
    public sealed class DependencyInjector
    {
        private static readonly DependencyInjector m_instance = new DependencyInjector();

        public static DependencyInjector Instance
        {
            get { return m_instance; }
        }

        public T GetDefaultInstance<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }

        public T GetNamedInstance<T>(string name)
        {
            return ObjectFactory.GetNamedInstance<T>(name);
        }

        public IEnumerable<T> GetAllInstances<T>()
        {
            return ObjectFactory.GetAllInstances<T>();
        }

        public IContainer Container
        {
            get { return GetDefaultInstance<IContainer>(); }
        }

        public static void Initialise()
        {
            ObjectFactory.Initialize(x => x.AddRegistry<DefaultRegistry>());
        }

        public class DefaultRegistry : Registry
        {
            /// <summary>
            /// Initializes a new instance of the DependencyRegistry class.
            /// </summary>
            public DefaultRegistry()
            {
                Scan(x =>
                {
                    x.AssembliesFromApplicationBaseDirectory(assembly =>
                        assembly.GetName().Name
                            .StartsWith("Akqa", StringComparison.CurrentCultureIgnoreCase));
                    x.WithDefaultConventions();
                });
            }
        }

        public static string WhatDoIHave()
        {
            return ObjectFactory.WhatDoIHave();
        }
    }
}
