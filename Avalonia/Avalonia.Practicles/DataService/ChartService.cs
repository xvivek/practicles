using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using NpgsqlTypes;
using System.Data.Common;

namespace DataService
{
    public class ConnectionString
    {
        public const string CONNECTION_STRING = "server=SQLSERVER01:49193;user id=postgres;password=bprg123#4;database=deep_dive_manager";
    }

    public interface IConnectionDetails
    {
        IDbConnection CreateConnection();
    }

    public class PgConnectionDetails : IConnectionDetails
    {
        internal readonly string connectionString = ConnectionString.CONNECTION_STRING;
        public PgConnectionDetails(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                this.connectionString = connectionString;
            }
        }

        public IDbConnection CreateConnection()
        {
            IDbConnection conn = new NpgsqlConnection(connectionString);
            return conn;
        }
    }

    public class ChartService
    {
        private string connectionString;

        public IConnectionDetails Connection { get; }
        public ChartService(IConnectionDetails connection)
        {
            connectionString = ConnectionString.CONNECTION_STRING;
            Connection = connection;
        }

        public async Task<List<DataService.FinancialData>> GetPriceData(string isinNo)
        {
            List<DataService.FinancialData> chartData = new List<DataService.FinancialData>();

            using (var con = Connection.CreateConnection())
            {
                con.Open();

                try
                {
                    var result = await con.QueryAsync<dynamic>(
                     "select * from get_price_data(@isin_no);",
                     new
                     {
                         @isin_no = Utils.GetDbValue(isinNo)
                     });

                    chartData = result.Select(item => new DataService.FinancialData(item.trade_date,
                        Convert.ToDouble(item.sc_high),
                        Convert.ToDouble(item.sc_open),
                        Convert.ToDouble(item.sc_close),
                        Convert.ToDouble(item.sc_low))).ToList();
                }
                catch (NpgsqlException ex)
                {                    
                }

                return chartData;
            };
        }

    }

    public class Utils
    {
        public static object GetDbValue(object value)
        {
            if (value == null)
            { return DBNull.Value; }
            else
            { return value; }
        }

        public static string GetString(object value)
        {
            if (value == null)
            { return string.Empty; }
            else
            { return value.ToString().Trim(); }
        }
    }
}
