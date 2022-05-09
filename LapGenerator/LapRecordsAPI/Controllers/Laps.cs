using LapRecordsAPI.Models;
using LapRecordsConnection;
using System.ComponentModel.DataAnnotations;

namespace LapRecordsAPI.Controllers
{
    public class Laps
    {
        private DataConnection connection { get; set; }

        public Laps()
        {
            connection = new DataConnection();
        }
        public bool AddLap(Lap currentLap)
        {
            if (
                currentLap.CarNumber != null &&
                currentLap.CarNumber.Length <= 255 &&
                currentLap.CarNumber.Length != 0 &&
                currentLap.DriverName != null &&
                currentLap.DriverName.Length <= 255 &&
                currentLap.DriverName.Length != 0 &&
                currentLap.LapTime != 0
              )
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    "INSERT INTO Lap(DriverName, CarNumber, LapTime)" +
                    $" VALUES ('{currentLap.DriverName}', '{currentLap.CarNumber}', {currentLap.LapTime})";
                if (command.ExecuteNonQuery() == 1)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
            else return false;

        }
        public List<string> ListCarNumbers()
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT DISTINCT CarNumber FROM Lap ORDER BY CarNumber";

            List<string> carNumbers = new List<string>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    carNumbers.Add(reader.GetString(0));
                }
            }

            connection.Close();
            return carNumbers;
        }
        public List<string> ListDrivers()
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT DISTINCT DriverName FROM Lap ORDER BY DriverName";

            List<string> driverNames = new List<string>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    driverNames.Add(reader.GetString(0));
                }
            }

            connection.Close();
            return driverNames;
        }

        public double LapAverageByCar(string carNumber)
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = $"SELECT LapTime FROM Lap WHERE CarNumber = '{carNumber}'";

            int count = 0;
            int lapTime = 0;
            using(var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    lapTime += reader.GetInt32(0);
                    count++;
                }
            }
            return lapTime / count;
        }
        public double LapAverageByDriver(string driverName)
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = $"SELECT LapTime FROM Lap WHERE DriverName = '{driverName}'";

            int count = 0;
            int lapTime = 0;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    lapTime += reader.GetInt32(0);
                    count++;
                }
            }
            return lapTime / count;
        }
    }
}
