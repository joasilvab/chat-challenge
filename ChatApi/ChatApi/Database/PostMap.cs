using ChatApi.Domain;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ChatApi.Database
{
    public class PostMap: ClassMapping<Post>
    {
        public PostMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Message);
            Property(x => x.Timestamp);
            ManyToOne(x => x.User, m => m.Fetch(FetchKind.Join));//the join doesn't work for NHibernate Linq Query
        }
    }
}
