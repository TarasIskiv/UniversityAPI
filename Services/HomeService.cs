using System;
using System.Linq;
using AutoMapper;
using UniversityAPI.DTOS;
using UniversityAPI.Entities;

namespace UniversityAPI.Services
{
    public class HomeService : IHomeService
    {
        private readonly UniversityDBContext _context;
        private readonly IMapper _mapper;

        public HomeService(UniversityDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Tuple<int, string> login(LoginUserDTO user)
        {
            var admin = _context.Admins
                            .ToList()
                            .FirstOrDefault(x => x.Login == user.Login && x.Password == user.Password);

            if(admin != null)
            {
                return new Tuple<int, string>(admin.Id, "admin");
            }

            var student = _context.Students
                            .ToList()
                            .FirstOrDefault(x => x.Login == user.Login && x.Password == user.Password);

            if(student != null)
            {
                return new Tuple<int, string>(student.Id, "student");
            }

            var lecturer = _context.Lecturers
                            .ToList()
                            .FirstOrDefault(x => x.Login == user.Login && x.Password == user.Password);
            
            if(lecturer != null)
            {
                return new Tuple<int, string>(lecturer.Id, "lecturer");
            }

            throw new Exception(); // user not found
        }

        public void registerLecturer(CreateLecturerDTO lecturerDTO)
        {
            var newLecturer = _mapper.Map<Lecturer>(lecturerDTO);
            _context.Lecturers.Add(newLecturer);
            _context.SaveChanges();
        }

        public void registerStudent(CreateStudentDTO studentDTO)
        {
            var newStudent = _mapper.Map<Student>(studentDTO);
            _context.Students.Add(newStudent);
            _context.SaveChanges();
        }
    }
}