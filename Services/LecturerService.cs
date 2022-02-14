using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UniversityAPI.DTOS;
using UniversityAPI.Entities;

namespace UniversityAPI.Services
{
    public class LecturerService : ILecturerService
    {
        private readonly UniversityDBContext _context;
        private readonly IMapper _mapper;

        public LecturerService(UniversityDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void AddNewMark(CreateMarkDTO markDTO)
        {
            var mark = _mapper.Map<MarkTable>(markDTO);
            _context.MarkTables.Add(mark);
            _context.SaveChanges();
        }

        public IEnumerable<StudentDTO> GetAllStudents()
        {
            var students = _context.Students.ToList();
            var studentsDto = _mapper.Map<IEnumerable<StudentDTO>>(students);
            return studentsDto;
        }

        public GroupDTO GetGroupById(int id)
        {
            var group  = _context.Groups.SingleOrDefault(x => x.Id == id);
            if(group == null) throw new Exception(); // group not found

            return _mapper.Map<GroupDTO>(group);
        }

        public LecturerDTO GetLecturer(int id)
        {
            var lecturer = _context.Lecturers.SingleOrDefault(x => x.Id == id);
            if(lecturer == null) throw new Exception(); // lecturer not found

            return _mapper.Map<LecturerDTO>(lecturer);
        }

        public IEnumerable<StudentDTO> GetStudentsByName(string name)
        {
            var students = _context.Students
                            .Where(x => (x.FirstName + x.LastName).ToString().Contains(name))
                            .ToList();
            
            if(students == null) throw new Exception(); // students not found

            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public void ModifyLecturer(ModifyLecturerDTO lecturerDTO, int id)
        {
            var lecturer = _context.Lecturers.SingleOrDefault(x => x.Id == id);
            if(lecturer == null) throw new Exception(); // lecturer not found

            lecturer.FirstName = lecturerDTO.FirstName;
            lecturer.LastName = lecturerDTO.LastName;
            lecturer.Age = lecturerDTO.Age;
            lecturer.Degree = lecturerDTO.Degree;

            _context.SaveChanges();
        }
    }
}