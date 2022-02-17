using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UniversityAPI.DTOS;
using UniversityAPI.Entities;

namespace UniversityAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly UniversityDBContext _context;
        private readonly IMapper _mapper;

        public StudentService(UniversityDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<LecturerDTO> GetAllLecturers()
        {
            var lecturers = _context.Lecturers.ToList();
            if(lecturers == null) throw new Exception(); // lecturers not found

            var lecturersDTO = _mapper.Map<IEnumerable<LecturerDTO>>(lecturers);
            return lecturersDTO;
        }

        public IEnumerable<LecturerDTO> GetLecturersByName(string name)
        {
            var lecturers = _context.Lecturers
                            .Where(x => x.FirstName.StartsWith(name))
                            .ToList();
            if(lecturers == null) throw new Exception(); // lecturers not found

            var lecturersDTO = _mapper.Map<IEnumerable<LecturerDTO>>(lecturers);
            return lecturersDTO;
        }

        public GroupDTO GetStudentGroup(int studentId)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == studentId);
            if(student == null) throw new Exception(); // student not found
            int id = student.GroupId;
            var group = _context.Groups.SingleOrDefault(x => x.Id == id);
            if(group == null) throw new Exception(); // group not found
                

            var groupDTO = _mapper.Map<GroupDTO>(group);
            groupDTO.StudentsInGroup = _mapper.Map<IEnumerable<StudentDTO>>(_context.Students.Where(x => x.GroupId == id).ToList()).ToList();

            return groupDTO;
        }


        public StudentDTO GetStudentInfo(int id)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == id);

            return _mapper.Map<StudentDTO>(student);
        }

        public IEnumerable<MarkDTO> GetStudentMarks(int studentId)
        {
            var marks = _context.MarkTables.Where(x => x.StudentId == studentId).ToList();
            if(marks == null || marks.Count() == 0) throw new Exception(); // marks not found
            
            return _mapper.Map<IEnumerable<MarkDTO>>(marks);
        }

        public void ModifyStudent(ModifyStudentDTO studentDTO, int id)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == id);
            if(student == null) throw new Exception(); //student not found

            student.Age = studentDTO.Age;
            student.FirstName = studentDTO.FirstName;
            student.LastName = studentDTO.LastName;
            student.CourseYear = studentDTO.CourseYear;

            _context.SaveChanges();
        }
    }
}