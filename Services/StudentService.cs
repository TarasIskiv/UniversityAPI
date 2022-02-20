using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UniversityAPI.DTOS;
using UniversityAPI.Entities;
using UniversityAPI.Exceptions;

namespace UniversityAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly UniversityDBContext _context;
        private readonly IMapper _mapper;
        private readonly List<Direction> _directions;
        private readonly List<Group> _groups;
        private readonly List<MarkTable> _marks;

        public StudentService(UniversityDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _directions = _context.Directions.ToList();
            _groups = _context.Groups.ToList();
            _marks = _context.MarkTables.ToList();
        }
        public IEnumerable<LecturerDTO> GetAllLecturers()
        {
            var lecturers = _context.Lecturers.ToList();
            if(lecturers == null) throw new Exception(ExceptionType.LecturerNotFound); // lecturers not found

            var lecturersDTO = _mapper.Map<IEnumerable<LecturerDTO>>(lecturers);
            return lecturersDTO;
        }

        public IEnumerable<LecturerDTO> GetLecturersByName(string name)
        {
            var lecturers = _context.Lecturers
                            .Where(x => x.FirstName.StartsWith(name))
                            .ToList();
            if(lecturers == null) throw new Exception(ExceptionType.LecturerNotFound); // lecturers not found

            var lecturersDTO = _mapper.Map<IEnumerable<LecturerDTO>>(lecturers);
            return lecturersDTO;
        }

        public GroupDTO GetStudentGroup(int studentId)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == studentId);
            if(student == null) throw new Exception(ExceptionType.StudentNotFound); // student not found
            int id = student.GroupId;
            var group = _context.Groups.SingleOrDefault(x => x.Id == id);
            if(group == null) throw new Exception(ExceptionType.GroupNotFound); // group not found
                

            var groupDTO = _mapper.Map<GroupDTO>(group);
            groupDTO.StudentsInGroup = _mapper.Map<IEnumerable<StudentInGroupDTO>>(_context.Students.Where(x => x.GroupId == id).ToList()).ToList();

            groupDTO.CountStudentsInGroup = groupDTO.StudentsInGroup.Count(); 
            return groupDTO;
        }


        public StudentDTO GetStudentInfo(int id)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == id);
            var studentDTO = _mapper.Map<StudentDTO>(student);
            studentDTO.DirectionName = _directions.First(x => x.Id == student.DirectionId).DirectionName;
            studentDTO.GroupName = _groups.First(x => x.Id == student.GroupId).Name;
            var selectedMarks = _marks.Where(x => x.StudentId == student.Id).ToList();
            studentDTO.Marks = _mapper.Map<List<SimpleMarkDTO>>(selectedMarks);
            double averageMark = 0;

            averageMark = studentDTO.Marks.Sum(x => x.Mark) / studentDTO.Marks.Count();
            studentDTO.AverageMark = averageMark;
            
            return studentDTO;
        }

        public IEnumerable<MarkDTO> GetStudentMarks(int studentId)
        {
            var marks = _context.MarkTables.Where(x => x.StudentId == studentId).ToList();
            if(marks == null || marks.Count() == 0) throw new Exception(ExceptionType.MarksNotFound); // marks not found
            
            return _mapper.Map<IEnumerable<MarkDTO>>(marks);
        }

        public void ModifyStudent(ModifyStudentDTO studentDTO, int id)
        {
            var student = _context.Students.SingleOrDefault(x => x.Id == id);
            if(student == null) throw new Exception(ExceptionType.StudentNotFound); //student not found

            student.Age = studentDTO.Age;
            student.FirstName = studentDTO.FirstName;
            student.LastName = studentDTO.LastName;
            student.CourseYear = studentDTO.CourseYear;

            _context.SaveChanges();
        }
    }
}