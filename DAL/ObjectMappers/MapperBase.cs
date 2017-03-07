using System;
using System.Collections.ObjectModel;
using System.Data;

namespace ObjectMappers
{
    public abstract class MapperBase<T>
    {
        /// <summary>
        /// Maps data from the DB to the domain object
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected abstract T Map(IDataReader reader);

        public Collection<T> MapAll(IDataReader reader)
        {
            var collection = new Collection<T>();

            while (reader.Read())
            {
                try
                {
                    collection.Add(Map(reader));
                }
                catch (Exception)
                {
                    // TODO consider handling the error instead of rethrowing it
                    throw;
                }
            }

            return collection;
        }
    }
}
