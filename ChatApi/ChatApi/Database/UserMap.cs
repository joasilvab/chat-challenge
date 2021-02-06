using ChatApi.Domain;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ChatApi.Database
{
    public class UserMap: ClassMapping<User>
    { 
        public UserMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Username);
        }
    }
}
