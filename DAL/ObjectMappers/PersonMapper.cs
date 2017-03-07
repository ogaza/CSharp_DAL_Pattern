using System;
using System.Data;
using DomainEntities;

namespace ObjectMappers
{
    public class PersonMapper : MapperBase<Person>
    {
        protected override Person Map(IDataReader reader)
        {
            try
            {
                var person = new Person
                {
                    Id = DBNull.Value == reader["Id"] ? 0 : (int) reader["Id"],
                    
                    FirstName = DBNull.Value == reader["FirstName"]
                        ? string.Empty
                        : (string) reader["FirstName"]
                };


                return person;
            }
            catch (Exception)
            {
                // consider handling the error instead of rethrowing it
                throw;
            }
        }
    }
}