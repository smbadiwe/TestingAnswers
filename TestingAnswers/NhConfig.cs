using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;

namespace TestingAnswers
{
    public class NhConfig
    {
        private static ISessionFactory _SessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_SessionFactory == null)
                {
                    var cfg = new Configuration();
                    cfg.Configure(); // read config default style


                    //cfg.Properties.Add(Environment.UseSqlComments, "true");
                    //cfg.Properties.Add(Environment.ShowSql, "true");
                    //cfg.Properties.Add(Environment.FormatSql, "true");
                    //cfg.Properties.Add(Environment.GenerateStatistics, "true");

                    //cfg.Properties.Add(Environment.ConnectionProvider, "NHibernate.Connection.DriverConnectionProvider");
                    //cfg.Properties.Add(Environment.Isolation, "ReadCommitted");
                    //cfg.Properties.Add(Environment.ProxyFactoryFactoryClass, "NHibernate.Bytecode.DefaultProxyFactoryFactory, NHibernate");
                    //cfg.Properties.Add(Environment.CurrentSessionContextClass, "web");

                    _SessionFactory = Fluently.Configure(cfg)
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Store>())
                        .BuildSessionFactory();
                }

                return _SessionFactory;
            }
        }

        public static ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
