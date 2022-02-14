using System.Collections.Generic;
using UniversityAPI.DTOS;

namespace UniversityAPI.Services
{
    public interface ILecturerService
    {
        public void ModifyLecturer(ModifyLecturerDTO lecturerDTO, int id);

        public LecturerDTO GetLecturer(int id);

        public void AddNewMark(CreateMarkDTO markDTO);

        public IEnumerable<StudentDTO> GetAllStudents();

        public IEnumerable<StudentDTO> GetStudentsByName(string name);

        public GroupDTO GetGroupById(int id);
    }
}