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
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Abp.Domain.Entities;
using System.Numerics;

namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IGenericService<AppointmentsDTO, Appointment> _appointmentService;
        private readonly IGenericService<DoctorDTO, Doctor> _doctorService;
        private readonly IMapper _mapper;

        public AppointmentsController(IGenericService<AppointmentsDTO, Appointment> appointmentService,
            IGenericService<DoctorDTO, Doctor> doctorService,
            IMapper mapper)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
            _mapper = mapper;
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

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentsDTO appointmentsDTO)
        {
            if (appointmentsDTO.DoctorId == Guid.Empty)
            {
                return BadRequest("Doctor information is required.");
            }

            var doctor = await _doctorService.GetByIdAsync(appointmentsDTO.DoctorId);
            if (doctor == null)
            {
                return NotFound("Doctor not found.");
            }
            //var doctorDto = _mapper.Map<DoctorDTO>(doctor);
            //appointmentsDTO.Doctor = doctorDto;

            var response = await _appointmentService.Create(appointmentsDTO);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<AppointmentsDTO> PutAppointment(AppointmentsDTO appointmentsDTO)
        {

            var doctor = await _doctorService.GetByIdAsync(appointmentsDTO.DoctorId);
            if (doctor == null)
            {
                throw new EntityNotFoundException("Doctor not found.");
            }
            var result = await _appointmentService.Update(appointmentsDTO);

            return result;
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            var item = await _appointmentService.DeleteByIdAsync(id);
            return Ok(item);
        }

        //private bool AppointmentExists(Guid id)
        //{
        //    return (_context.Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
