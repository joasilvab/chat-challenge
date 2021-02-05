using ChatApi.Domain;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ChatApi.Database
{
    public class PostMap: ClassMapping<Post>
    { 
        public PostMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.GuidComb));
            Property(x => x.Message);
        }
    }
}
