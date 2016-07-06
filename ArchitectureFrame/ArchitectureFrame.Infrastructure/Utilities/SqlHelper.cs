using ArchitectureFrame.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureFrame.Infrastructure.Utilities
{
    public class SqlHelper
    {
        public static void BulkCopy(DataTable table, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;
                connection.Open();
                try
                {
                    transaction = connection.BeginTransaction();
                    using (var sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                    {
                        sqlBulkCopy.BatchSize = table.Rows.Count;
                        sqlBulkCopy.DestinationTableName = table.TableName;
                        sqlBulkCopy.MapColumns(table);
                        sqlBulkCopy.WriteToServer(table);
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction?.Rollback();
                    throw;
                }
            }
        }
    }
}
