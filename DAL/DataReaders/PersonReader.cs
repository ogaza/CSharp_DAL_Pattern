using System.Collections.ObjectModel;
using System.Data;
using DomainEntities;
using ObjectMappers;

namespace DataReaders
{
    public class PersonReader : ObjectReaderWithConnection<Person>
    {
        protected override string CommandText
        {
            get { return "SELECT * FROM Person;"; }
        }

        protected override CommandType CommandType
        {
            get { return CommandType.Text;}
        }

        protected override Collection<IDataParameter> GetParameters(IDbCommand command)
        {
            var collection = new Collection<IDataParameter>();

            // if needed add some params ...

            return collection;
        }

        protected override MapperBase<Person> GetMapper()
        {
            return new PersonMapper();
        }
    }
}