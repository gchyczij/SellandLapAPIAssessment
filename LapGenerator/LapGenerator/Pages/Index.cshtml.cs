using LapRecordsAPI.Controllers;
using LapRecordsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LapGenerator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string? DriverName { get; set; }

        [BindProperty]
        public string? CarNumber { get; set; }

        [BindProperty]
        public int LapTime { get; set; }

        [BindProperty]
        public int LapSubmitTime { get; set; }

        [TempData]
        public string MessageComplete { get; set; }

        public bool LapAutomatic { get; set; }

        private static Timer _timer;
        private static Lap loopingLap;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            MessageComplete = "";
        }

        public void OnGet()
        {
            LapAutomatic = false;
        }

        public IActionResult OnPost() 
        {
            if (LapSubmitTime <= 0)
            {
                if (MessageComplete != null)
                {
                    TempData.Remove(MessageComplete);
                }
                var newLap = new Lap(DriverName, CarNumber, LapTime);
                var lapController = new Laps();
                if (lapController.AddLap(newLap) == true)
                {

                    MessageComplete = "Lap Successfully Added";
                    return Redirect("Index");
                }
                else
                {
                    MessageComplete = "Invalid Data";
                    return Page();
                }
            }
            else
            {
                var newLap = new Lap(DriverName, CarNumber, LapTime);
                var lapController = new Laps();
                if (lapController.AddLap(newLap) == true)
                {
                    LapAutomatic = true;
                    loopingLap = newLap;
                    SetTimer(LapSubmitTime * 1000);
                    return Page();
                }
                else
                {
                    MessageComplete = "Invalid Data";
                    return Page();
                }
            }
        }

        public IActionResult OnPostModify()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            _timer.Dispose();
            LapAutomatic = false;
            if (LapSubmitTime <= 0)
            {
                if (MessageComplete != null)
                {
                    TempData.Remove(MessageComplete);
                }
                var newLap = new Lap(DriverName, CarNumber, LapTime);
                var lapController = new Laps();
                if (lapController.AddLap(newLap) == true)
                {

                    MessageComplete = "Lap Successfully Added";
                    return Redirect("Index");
                }
                else
                {
                    MessageComplete = "Invalid Data";
                    return Page();
                }
            }
            else
            {
                var newLap = new Lap(DriverName, CarNumber, LapTime);
                var lapController = new Laps();
                if (lapController.AddLap(newLap) == true)
                {
                    LapAutomatic = true;
                    loopingLap = newLap;
                    SetTimer(LapSubmitTime * 1000);
                    return Page();
                }
                else
                {
                    MessageComplete = "Invalid Data";
                    return Page();
                }
            }
        }

        public IActionResult OnPostStop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            _timer.Dispose();
            LapAutomatic = false;
            MessageComplete = "Loop Stopped";
            return Redirect("Index");
        }

        static void SetTimer(int interval)
        {
            _timer = new Timer(new TimerCallback(LoopingLapSubmit), null, interval, interval);

        }

        static void LoopingLapSubmit(object state)
        {
            var lapController = new Laps();
            lapController.AddLap(loopingLap);
        }
    }
}