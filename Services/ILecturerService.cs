using System.Collections.Generic;
using UniversityAPI.DTOS;

namespace UniversityAPI.Services
{
    public interface ILecturerService
    {
        public void ModifyLecturer(ModifyLecturerDTO lecturerDTO);

        public LecturerDTO GetLecturer(int id);

        public void AddNewMark();

        public IEnumerable<StudentDTO> GetAllStudents();

        public StudentDTO GetStudentByName(string name);

        public void GetGroupById(int id);
    }
}