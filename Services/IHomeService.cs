using System;
using UniversityAPI.DTOS;

namespace UniversityAPI.Services
{
    public interface IHomeService
    {
        public Tuple<int, string> login(LoginUserDTO user);

        public void registerStudent(CreateStudentDTO studentDTO);

        public void registerLecturer(CreateLecturerDTO lecturerDTO);
    }
}