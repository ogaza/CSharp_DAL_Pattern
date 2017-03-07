using System;
using System.Collections.ObjectModel;
using System.Data;
using ObjectMappers;

namespace DataReaders
{
    public abstract class ObjectReaderBase<T>
    {
        protected abstract IDbConnection GetConnection();

        protected abstract MapperBase<T> GetMapper();

        protected abstract Collection<IDataParameter> GetParameters(IDbCommand command);

        protected abstract string CommandText { get; }

        protected abstract CommandType CommandType { get; }

        public Collection<T> Execute()
        {
            using (IDbConnection connection = GetConnection())
            {
                IDbCommand command = connection.CreateCommand();

                command.Connection = connection;

                command.CommandText = CommandText;

                command.CommandType = CommandType;

                foreach (IDataParameter parameter in GetParameters(command))
                {
                    command.Parameters.Add(parameter);
                }

                try
                {
                    connection.Open();

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            MapperBase<T> mapper = GetMapper();

                            Collection<T> collection = mapper.MapAll(reader);

                            return collection;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            
        }
    }
}
