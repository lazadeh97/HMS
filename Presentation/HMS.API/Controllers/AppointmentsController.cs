using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMS.Domain.Entities;
using HMS.Persistence.Contexts;
using HMS.Application.Services.Interfaces;
using HMS.Application.DTOs;
using HMS.Application.Services;
using NuGet.Protocol;

namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IGenericService<AppointmentsDTO, Appointment> _appointmentService;
        private readonly IGenericService<DoctorDTO, Doctor> _doctorService;

        public AppointmentsController(IGenericService<AppointmentsDTO, Appointment> appointmentService,
            IGenericService<DoctorDTO, Doctor> doctorService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<IEnumerable<AppointmentsDTO>> GetAppointments()
        {
            var response = await _appointmentService.GetAllAsync();
            return response;
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<AppointmentsDTO>> GetAppointmentById(Guid id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);
            if (appointment == null)
            {
                return Enumerable.Empty<AppointmentsDTO>();
            }
            return new List<AppointmentsDTO> { appointment };
        }

        //// PUT: api/Appointments/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAppointment(Guid id, Appointment appointment)
        //{
        //    if (id != appointment.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(appointment).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AppointmentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Appointments
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        //{
        //  if (_context.Appointments == null)
        //  {
        //      return Problem("Entity set 'HMSDbContext.Appointments'  is null.");
        //  }
        //    _context.Appointments.Add(appointment);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
        //}

        //// DELETE: api/Appointments/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAppointment(Guid id)
        //{
        //    if (_context.Appointments == null)
        //    {
        //        return NotFound();
        //    }
        //    var appointment = await _context.Appointments.FindAsync(id);
        //    if (appointment == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Appointments.Remove(appointment);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AppointmentExists(Guid id)
        //{
        //    return (_context.Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
