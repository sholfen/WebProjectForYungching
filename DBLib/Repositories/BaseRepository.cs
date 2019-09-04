using Dapper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlBuilder;

namespace DBLib.Repositories
{
    public class BaseRepository<T>
    {
        protected SQLiteConnection _sqlConnection { get; set; }
        private static ConcurrentDictionary<string, string> SqlCmdDict = new ConcurrentDictionary<string, string>();

        public BaseRepository(string connectionString)
        {
            _sqlConnection = new SQLiteConnection(connectionString);
        }

        private void AddSqlCmd(string key, string sql)
        {
            SqlCmdDict.TryAdd(key, sql);
        }

        private string GetSqlCmd(string key)
        {
            if (SqlCmdDict.ContainsKey(key))
            {
                return SqlCmdDict[key];
            }
            return string.Empty;
        }

        public int Insert(T parameter)
        {
            string[] parameterArray = typeof(T).GetProperties().Select(p => p.Name).ToArray();
            string parameterString = string.Join(",", parameterArray);
            string query =
                $"INSERT INTO {typeof(T).Name} ({parameterString}) VALUES ({string.Join(",", parameterArray.Select(n => "@" + n).ToArray())})";
            return _sqlConnection.Execute(query, parameter);
        }

        public List<T> Query()
        {
            string query = $"SELECT * FROM {typeof(T).Name}";
            return _sqlConnection.Query<T>(query).AsList();
        }

        public List<T> QueryBy(Dictionary<string, object> parameters)
        {
            SqlBuilder builder = new SqlBuilder();
            string query = $"SELECT * FROM {typeof(T).Name} /**where**/ ";
            Template template = builder.AddTemplate(query);

            DynamicParameters dynamicParams = new DynamicParameters();
            foreach (var parameter in parameters)
            {
                builder.Where($"{parameter.Key} = @{parameter.Key}");
                dynamicParams.Add(parameter.Key, parameter.Value);
            }
            string rawSql = template.RawSql;

            return _sqlConnection.Query<T>(rawSql, dynamicParams).AsList();
        }
    }
}
