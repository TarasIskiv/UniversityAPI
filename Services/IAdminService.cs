using UniversityAPI.DTOS;

namespace UniversityAPI.Services
{
    public interface IAdminService
    {
        public void addNewGroup(CreateGroupDTO groupDTO);

        public void RemoveGroup(int id);

        public void ModifyGroup(ModifyGroupDTO groupDTO);

         public void addNewDirection(CreateDirectionDTO directionDTO);

        public void RemoveDiretion(int id);

        public void ModifyDirection(ModifyDirectionDTO directionDTO);

        public void RemoveStudent(int id);

        public void RemoveLecturer(int id);

    }
}