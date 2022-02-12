using AutoMapper;
using UniversityAPI.DTOS;
using UniversityAPI.Entities;

namespace UniversityAPI.AutoMapperData
{
    public class AutoMapperConfiguration
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<CreateStudentDTO, Student>();
                    cfg.CreateMap<CreateLecturerDTO, Lecturer>();
                    cfg.CreateMap<CreateGroupDTO, Group>();
                    cfg.CreateMap<CreateDirectionDTO, Direction>();
                }
            ).CreateMapper();
        }
    }
}