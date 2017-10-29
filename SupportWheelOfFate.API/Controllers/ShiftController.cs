using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SupportWheelOfFate.Services;
using SupportWheelOfFate.API.Models;

namespace SupportWheelOfFate.API.Controllers
{
    [Route("api/[controller]")]
    public class ShiftController : Controller
    {
        private IScheduleService _scheduleService;

        public ShiftController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("{day}")]
        public IEnumerable<ShiftModel> Get(int day)
        {
            if (!_scheduleService.ScheduleFilled)
                _scheduleService.FillSchedule();

            return _scheduleService.GetSchedule().Shifts.Where(s => s.Day == day).Select(s => 
                new ShiftModel() {
                    Day = s.Day,
                    Shift = s.Position,
                    EngineerName = s.Engineer.Name
                }).ToList();
        }
    }
}
