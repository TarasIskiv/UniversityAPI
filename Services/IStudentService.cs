using System.Collections.Generic;
using UniversityAPI.DTOS;
using UniversityAPI.Entities;

namespace UniversityAPI.Services
{
    public interface IStudentService
    {
        /*
            student:
                -get info about current student
                -modify data
            markTable:
                get marks of current Student
            group:
                -get current group info
            lecturer:
                -get all lecturers
                -get lecturer by name
        */

        public StudentDTO GetStudentInfo(int id);
        public void ModifyStudent(ModifyStudentDTO studentDTO, int id);
        public IEnumerable<MarkDTO> GetStudentMarks(int studentId);

        public GroupDTO GetStudentGroup(int studentId);

        public IEnumerable<LecturerDTO> GetAllLecturers();

        public IEnumerable<LecturerDTO> GetLecturersByName(string name);
    }
}