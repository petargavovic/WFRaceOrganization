using Common.Domen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace DatabaseBroker
{
    public class Broker : IDisposable
    {
        DbConnection connection;

        public Broker()
        {
            connection = new DbConnection();
        }

        public List<IEntity> GetAll(IEntity entity, string where = null)
        {
            SqlCommand command = connection.CreateCommand();
            if (where == null)
                command.CommandText = $"SELECT * FROM {entity.TableName} ORDER BY {entity.OrderByParam} ASC";
            else
            {
                string prvoSlovo = entity.TableName.Substring(0, 1).ToLower();
                command.CommandText = $"SELECT {entity.Select} FROM {entity.TableName} {prvoSlovo} {entity.Join} {where} ORDER BY {prvoSlovo}.{entity.OrderByParam} ASC";
            }
            Debug.WriteLine(command.CommandText);
            SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = new List<IEntity>();
            return entity.GetReaderList(reader, list);
        }

        public IEntity GetById(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            string prvoSlovo = entity.TableName.Substring(0, 1).ToLower();
            command.CommandText = $"SELECT {entity.Select} FROM {entity.TableName} {prvoSlovo} {entity.Join} " +
            $"WHERE ({entity.Id} = {prvoSlovo}.{entity.TableName}ID) ORDER BY {prvoSlovo}.{entity.OrderByParam} ASC";
            Debug.WriteLine(command.CommandText);
            return entity.GetReaderList(command.ExecuteReader(), new List<IEntity>()).First();
        }

        public int SaveEntity(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            return SaveOne(entity, command);
        }

        public void SaveEntities(List<IEntity> entities)
        {
            SqlCommand command = connection.CreateCommand();
            foreach (IEntity entity in entities)
            {
                Debug.WriteLine(entity.Status);
                SaveOne(entity, command);
            }
        }
        private int SaveOne(IEntity entity, SqlCommand command)
        {
            int.TryParse(entity.Id, out int savedEntityId);
            if (entity.Status == Status.Added)
            {
                command.CommandText = $"INSERT INTO {entity.TableName} OUTPUT INSERTED.{entity.TableName}ID VALUES ({entity.Values})";
                object result = command.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    throw new Exception($"{entity.TableName} nije dodat!");
                }
                savedEntityId = Convert.ToInt32(result);
            }
            else if (entity.Status == Status.Modified)
            {
                command.CommandText = $"UPDATE {entity.TableName} SET {entity.UpdateValues}";
                if (command.ExecuteNonQuery() == 0)
                {
                    throw new Exception($"{entity.TableName} nije izmenjen!");
                }
            }
            else if (entity.Status == Status.Deleted)
            {
                command.CommandText = $"DELETE FROM {entity.TableName} WHERE {entity.TableName + "ID = "}{entity.Id}";
                if (command.ExecuteNonQuery() == 0)
                {
                    throw new Exception($"{entity.TableName} nije obrisan!");
                }
            }
            Debug.WriteLine(command.CommandText);
            return savedEntityId;
        }
        public void OpenConnection()
        {
            connection.OpenConnection();
        }
        public void CloseConnection()
        {
            connection?.CloseConnection();
        }
        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void Rollback()
        {
            connection.Rollback();
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
