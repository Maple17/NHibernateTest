using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateTest.Domain
{
    public class Animal
    {
        public virtual int AnimalID { get; set; }
        public virtual string Kind { get; set; }
        public virtual int PersonID { get; set; }
     
    }
}
