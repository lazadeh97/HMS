using AutoMapper;
using HMS.Application.DTOs;
using HMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Mapping
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<AppointmentsDTO, Appointment>().ReverseMap();
            CreateMap<DoctorDTO, Doctor>().ReverseMap();
            CreateMap<HospitalDTO, Hospital>().ReverseMap();
            CreateMap<MedicineDTO, Medicine>().ReverseMap();
            CreateMap<NurseDTO, Nurse>().ReverseMap();
            CreateMap<PatientDTO_, Patient>().ReverseMap();
        }
    }
}
