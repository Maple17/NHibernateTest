using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*引用以下的命名空間*/
using NHibernate;
using NHibernate.Cfg;

using NHibernateTest.Domain;

namespace NHibernateTest
{
    public class MyHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    Configuration configuration = new Configuration();
                    configuration.Configure();//預設抓目錄下的hibernate.cfg.xml
                    //或者給絕對路徑↓
                    //configuration.Configure(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)+@"\hibernate.cfg.xml");
                    configuration.AddFile("Persons.hbm.xml");
                    configuration.AddFile("Mappings\\acm_penalty_combine_main.hbm.xml");
                    configuration.AddFile("Mappings\\csswaterno_tmp.hbm.xml");
                    configuration.AddFile("Mappings\\Animal.hbm.xml");
                    //configuration.AddAssembly(typeof(Persons).Assembly);
                    
                    _sessionFactory = configuration.BuildSessionFactory();

                }
                return _sessionFactory;
            }

        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }


    }
}
