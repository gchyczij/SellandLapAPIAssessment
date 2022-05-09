using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapRecordsAPI.Models
{
    /// <summary>
    /// ViewModel for the Lap table
    /// </summary>
    /// <remarks>
    /// CREATED BY: Gregory Chyczij 05/08/2022
    /// </remarks>
    public class Lap
    {
        public int LapNumber { get; }
        [Required(ErrorMessage = "Driver Name is Required")]
        [MinLength(1, ErrorMessage = "Driver Name is Required")]
        [MaxLength(255, ErrorMessage = "Driver Name is Too Long")]
        public string? DriverName { get; set; }
        [Required(ErrorMessage = "Car Number is Required")]
        [MinLength(1, ErrorMessage = "Car Number is Required")]
        [MaxLength(255, ErrorMessage = "Car Number must be less then 10 characters")]
        public string? CarNumber { get; set; }
        public int LapTime { get; set; }

        public Lap(string? driverName, string? carNumber, int lapTime)
        {
            DriverName = driverName;
            CarNumber = carNumber;
            LapTime = lapTime;
        }
        public Lap(int lapNumber, string driverName, string carNumber, int lapTime)
        {
            LapNumber = lapNumber;
            DriverName = driverName;
            CarNumber = carNumber;
            LapTime = lapTime;
        }

    }
}
