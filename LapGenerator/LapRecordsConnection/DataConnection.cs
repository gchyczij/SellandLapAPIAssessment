using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace LapRecordsConnection
{
        /// <summary>
        /// Data Connection Class for Lap Records Database
        /// </summary>
        /// <remarks>
        /// CREATED BY: Gregory Chyczij 05/08/2022
        /// </remarks>
        public class DataConnection : SqliteConnection
        {
            public DataConnection()
            {
                ConnectionString = "Data Source=..\\..\\LapRecords.db";
            }
        }
    }
