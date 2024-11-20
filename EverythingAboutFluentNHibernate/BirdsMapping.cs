using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace EverythingAboutFluentNHibernate
{
    class BirdsMapping: ClassMap<Birds>
    {
        public BirdsMapping()
        {
            Id(x => x.ID).GeneratedBy.Native(); // not like (Map(x => x.ID)) because id is the primary key in my db and it generates automatically
            Map(x => x.Name);
            Map(x => x.LastName);
        }
    }
}
