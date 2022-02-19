using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Internal;
using UniversityAPI.DTOS;
using UniversityAPI.Entities;

namespace UniversityAPI.Services
{
    public class LecturerService : ILecturerService
    {
        private readonly UniversityDBContext _context;
        private readonly IMapper _mapper;
        private readonly List<Direction> _directions;
        private readonly List<Group> _groups;
        private readonly List<MarkTable> _marks;

        public LecturerService(UniversityDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _directions = _context.Directions.ToList();
            _groups = _context.Groups.ToList();
            _marks = _context.MarkTables.ToList();
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
            var studentsDto = (_mapper.Map<IEnumerable<StudentDTO>>(students)).ToList();
            
            for(int i = 0; i < students.Count(); ++i)
            {
                studentsDto[i].DirectionName = _directions.First(x => x.Id == students[i].DirectionId).DirectionName;
                studentsDto[i].GroupName = _groups.First(x => x.Id == students[i].GroupId).Name;
                var selectedMarks = _marks.Where(x => x.StudentId == students[i].Id).ToList();
                studentsDto[i].Marks = _mapper.Map<List<SimpleMarkDTO>>(selectedMarks);
            }
            double averageMark = 0;
            foreach(var item in studentsDto)
            {
                averageMark = item.Marks.Sum(x => x.Mark) / item.Marks.Count();
                item.AverageMark = averageMark;
                averageMark = 0;
            }
            return studentsDto;
        }


        public GroupDTO GetGroupById(int id)
        {
            var group  = _context.Groups.SingleOrDefault(x => x.Id == id);
            if(group == null) throw new Exception(); // group not found
            var groupDTO = _mapper.Map<GroupDTO>(group);
            groupDTO.StudentsInGroup = _mapper.Map<List<StudentInGroupDTO>>(_context.Students.Where(x => x.GroupId == group.Id)).ToList();
            var students = groupDTO.StudentsInGroup.Count();
            groupDTO.CountStudentsInGroup = students;
            return groupDTO;
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
                            .Where(x => x.FirstName.StartsWith(name))
                            .ToList();
            
            if(students == null) throw new Exception(); // students not found
            var studentsDto = _mapper.Map<IEnumerable<StudentDTO>>(students).ToList();
            for(int i = 0; i < students.Count(); ++i)
            {
                studentsDto[i].DirectionName = _directions.First(x => x.Id == students[i].DirectionId).DirectionName;
                studentsDto[i].GroupName = _groups.First(x => x.Id == students[i].GroupId).Name;
                var selectedMarks = _marks.Where(x => x.StudentId == students[i].Id).ToList();
                studentsDto[i].Marks = _mapper.Map<List<SimpleMarkDTO>>(selectedMarks);
            }
            double averageMark = 0;
            foreach(var item in studentsDto)
            {
                averageMark = item.Marks.Sum(x => x.Mark) / item.Marks.Count();
                item.AverageMark = averageMark;
                averageMark = 0;
            }
            return studentsDto;
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