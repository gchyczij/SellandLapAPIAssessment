using LapRecordsAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LapGenerator.Pages
{
    public class LapRecordsModel : PageModel
    {
        public bool DisplayRecords { get; set; }
        public List<string> Drivers { get; set; }
        public List<string> Cars { get; set; }
        public bool DriverSearch { get; set; }
        [BindProperty]
        public string CarNumber { get; set; }
        [BindProperty]
        public string DriverName { get; set; }
        public double AverageLapTime { get; set; }
        public void OnGet()
        {
            DisplayRecords = false;
            DriverSearch = false;
            var lapController = new Laps();
            Drivers = lapController.ListDrivers();
            Cars = lapController.ListCarNumbers();
        }
        public IActionResult OnPostSearchDriver()
        {
            if (!String.IsNullOrEmpty(DriverName))
            {
                DriverSearch = true;
                DisplayRecords = true;
                var lapController = new Laps();
                AverageLapTime = lapController.LapAverageByDriver(DriverName);
                return Page();
            }
            else
            {
                return Redirect("LapRecords");
            }
        }
        public IActionResult OnPostSearchCar()
        {
            if (!String.IsNullOrEmpty(CarNumber))
            {
                DriverSearch = false;
                DisplayRecords = true;
                var lapController = new Laps();
                AverageLapTime = lapController.LapAverageByCar(CarNumber);
                return Page();
            }
            else
            {
                return Redirect("LapRecords");
            }
        }
        public IActionResult OnPostReturn()
        {
            return Redirect("LapRecords");
        }
    }
}
