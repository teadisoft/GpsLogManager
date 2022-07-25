using System;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.SQLite.EF6;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Data.SQLite;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace GpsLogManager.Common
{
    public class DBHelper : IDisposable
    {
        private DbProviderFactory _factory = null;
        private DbProviders _provider;

        public DBHelper(DbProviders provider)
        {
            CreateDBObjects(provider);
        }

        private string _connectionstring = string.Empty;
        public string ConnectionString
        {
            get { return _connectionstring; }
            set
            {
                if (value != "")
                    _connectionstring = value;
            }
        }

        private DbConnection _connection;
        public DbConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        private DbCommand _command;
        public DbCommand Command
        {
            get { return _command; }
        }

        public string GetConnectionString()
        {
            //ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();            

            ConnectionString = string.Format(@"Data Source={0}\BikeGpx.db;Version=3;", Application.StartupPath);

            return ConnectionString;
        }

        public void CreateDBObjects(DbProviders provider)
        {
            _provider = provider;

            switch (provider)
            {
                case DbProviders.SqlServer:
                    _factory = SqlClientFactory.Instance;
                    break;
                case DbProviders.Oracle:
                    break;
                case DbProviders.OleDb:
                    _factory = OleDbFactory.Instance;
                    break;
                case DbProviders.ODBC:
                    _factory = OdbcFactory.Instance;
                    break;
                case DbProviders.SQLite:
                    _factory = SQLiteProviderFactory.Instance;
                    break;
                case DbProviders.SqlCe:
                    _factory = SqlCeProviderFactory.Instance;
                    break;
            }

            _connection = _factory.CreateConnection();
            _command = _factory.CreateCommand();
            _connection.ConnectionString = GetConnectionString();
            _command.Connection = Connection;
        }

        public int AddParameter(string name, object value)
        {
            DbParameter param = _factory.CreateParameter();
            param.ParameterName = name;
            param.Value = value;
            return Command.Parameters.Add(param);
        }

        public void ClearParameter()
        {
            if (_command != null && _command.Parameters.Count > 0)
                _command.Parameters.Clear();
        }

        public void BeginTransaction()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            Command.Transaction = Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            Command.Transaction.Commit();
            Connection.Close();
        }

        private void RollbackTransaction()
        {
            Command.Transaction.Rollback();
            Connection.Close();
        }

        public int ExecuteNonQuery(string query, CommandType commandType, List<DbParameter[]> listParameters)
        {
            int i = -1;
            Command.CommandType = commandType;
            Command.CommandText = query;

            try
            {
                if(Connection.State == ConnectionState.Closed)
                    Connection.Open();

                BeginTransaction();

                if (listParameters.Count > 0)
                {
                    for (int k = 0; k < listParameters.Count; k++)
                    {
                        foreach (DbParameter param in listParameters[k])
                        {
                            AddParameter(param.ParameterName, param.Value);
                        }

                        i = Command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw (ex);
            }
            finally
            {
                CommitTransaction();
                ClearParameter();

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                    Connection.Dispose();
                }
            }

            return i;
        }

        public List<T> ExecuteReader<T>(string query, CommandType commandType)
        {
            List<T> rtnList = new List<T>();

            Command.CommandType = commandType;
            Command.CommandText = query;

            try
            {
                Connection.Open();
                rtnList = GetListFromDataReader<T>(Command.ExecuteReader());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Command.Dispose();
                    Connection.Close();
                    Connection.Dispose();
                }
            }

            return rtnList;
        }

        public void AutoMakeParamseter<T>(string query, List<T> list)
        {
            PropertyDescriptorCollection property = GetPropetyDescriptorInfo<T>();

            List<DbParameter[]> listParameter = new List<DbParameter[]>();
            foreach (T item in list)
            {
                DbParameter[] parameters = new DbParameter[property.Count];

                for (int i = 0; i < property.Count; i++)
                {
                    PropertyDescriptor prop = property[i];
                    parameters[i] = new SqlParameter("@"+ prop.Name, prop.PropertyType);
                    parameters[i].Value = property[i].GetValue(item);
                }

                listParameter.Add(parameters);
            }

            ExecuteNonQuery(query, CommandType.Text, listParameter);
        }

        public string AddIn(List<string> list)
        {
            string rtnAddin = string.Empty;

            if (list.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (string s in list)
                    sb.AppendFormat(" '{0}', ", s);

                int lastComma = sb.ToString().LastIndexOf(',');

                if (!string.IsNullOrEmpty(sb.ToString()))
                    sb.Remove(lastComma, 1);

                rtnAddin = sb.ToString();
            }

            return rtnAddin;
        }

        public string InsertAutoQuery<T>(string tableName)
        {
            PropertyDescriptorCollection props = GetPropetyDescriptorInfo<T>();

            StringBuilder sbParameter = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];

                if (!prop.Name.Equals("OVERLAP"))
                {
                    sbParameter.AppendFormat(" {0}, ", prop.Name);
                    sbValue.AppendFormat("@{0}, ", prop.Name);
                }
            }

            sbParameter.Remove(sbParameter.ToString().LastIndexOf(','), 1);
            sbValue.Remove(sbValue.ToString().LastIndexOf(','), 1);

            string query = string.Format(@" INSERT INTO {0} ({1}) VALUES ({2}); ", tableName, sbParameter, sbValue);

            return query;
        }

        public Dictionary<string, string> DBColumn<T>(T item)
        {
            Dictionary<string, string> dbMappings = new Dictionary<string, string>();
            var type = item.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                var columnMapping = attributes.FirstOrDefault(a => a.GetType() == typeof(DbColumnAttribute));
                if (columnMapping != null)
                {
                    dbMappings.Add(property.Name, ((DbColumnAttribute)columnMapping).Name);
                }
            }
            return dbMappings;
        }

        public List<T> GetListFromDataReader<T>(IDataReader reader)
        {
            List<T> rtnList = new List<T>();
            var properties = typeof(T).GetProperties();

            var columnList = (reader.GetSchemaTable().Select()).Select(r => r.ItemArray[0].ToString());
            while (reader.Read())
            {
                var element = Activator.CreateInstance<T>();
                Dictionary<string, string> dbMappings = DBColumn(element);
                string columnName;
                foreach (var f in properties)
                {
                    if (!columnList.Contains(f.Name) && !dbMappings.ContainsKey(f.Name))
                        continue;
                    columnName = dbMappings.ContainsKey(f.Name) ? dbMappings[f.Name] : f.Name;
                    var o = (object)reader[columnName];

                    if (o.GetType() != typeof(DBNull))
                        f.SetValue(element, ChangeType(o, f.PropertyType), null);
                }

                rtnList.Add(element);
            }
            reader.Close();

            return rtnList;
        }

        public object ChangeType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }

        public PropertyDescriptorCollection GetPropetyDescriptorInfo<T>()
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            return props;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public enum DbProviders
        {
            Oracle,
            MySql,
            ORM,
            Dapper,
            NPoco,
            SqlServer,
            PostgreSQL,
            SQLite,
            NoSQL,
            MongoDB,
            RavenDB,
            Redis,
            Cassandra,
            CouchBase,
            CouchDB,
            Neo4j,
            YesSql,
            LuceneNET,
            OleDb,
            ODBC,
            NpgSql,
            SqlCe
        }
    }

    public class DbColumnAttribute : Attribute
    {
        public string Name { get; set; }

        public DbColumnAttribute(string _name)
        {
            this.Name = _name;
        }
        public DbColumnAttribute()
            : this(null) { }
    }
}
