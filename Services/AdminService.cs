using System;
using System.Linq;
using AutoMapper;
using UniversityAPI.DTOS;
using UniversityAPI.Entities;

namespace UniversityAPI.Services
{
    public class AdminService : IAdminService
    {
        private readonly UniversityDBContext _context;
        private readonly IMapper _mapper;

        public AdminService(UniversityDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void addNewGroup(CreateGroupDTO groupDTO)
        {
            var newGroup = _mapper.Map<Group>(groupDTO);
            _context.Groups.Add(newGroup);
            _context.SaveChanges();
        }
        public void RemoveGroup(int id)
        {
            var selectedGroup = _context.Groups.SingleOrDefault(x => x.Id == id);
            if(selectedGroup == null) throw new Exception(); // group not found

            _context.Groups.Remove(selectedGroup);
            _context.SaveChanges();
        }
        
        public void ModifyGroup(ModifyGroupDTO dto)
        {
            var selectedGroup = _context.Groups.SingleOrDefault(x => x.Id == dto.Id);
            if(selectedGroup == null) throw new Exception(); // group not found

            selectedGroup.Name = dto.Name;
            _context.SaveChanges();
        }

        public void addNewDirection(CreateDirectionDTO directionDTO)
        {
            var newDirection = _mapper.Map<Direction>(directionDTO);
            _context.Directions.Add(newDirection);
            _context.SaveChanges();
        }

        public void RemoveDiretion(int id)
        {
            var selectedDirection = _context.Directions.SingleOrDefault(x => x.Id == id);
            if(selectedDirection == null) throw new Exception(); // direction not found

            _context.Directions.Remove(selectedDirection);
            _context.SaveChanges();
        }
        public void ModifyDirection(ModifyDirectionDTO directionDTO)
        {
            var selectedDirection = _context.Directions.SingleOrDefault(x => x.Id == directionDTO.Id);
            if(selectedDirection == null) throw new Exception(); // direction not found

            selectedDirection.DirectionName = directionDTO.Name;
            _context.SaveChanges();
        }
        public void RemoveStudent(int id)
        {
            var selectedStudent = _context.Students.SingleOrDefault(x => x.Id == id);
            if(selectedStudent == null) throw new Exception(); // student not found;

            _context.Students.Remove(selectedStudent);
            _context.SaveChanges();
        }
        public void RemoveLecturer(int id)
        {
            var selectedLecturer = _context.Lecturers.SingleOrDefault(x => x.Id == id);
            if(selectedLecturer == null) throw new Exception(); // lecturer not found;

            _context.Lecturers.Remove(selectedLecturer);
            _context.SaveChanges();
        }
        
    }
}