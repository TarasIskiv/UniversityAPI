namespace UniversityAPI.Services
{
    public interface IAdminService
    {
        public void addNewGroup();

        public void RemoveGroup(int id);

        public void ModifyGroup();

         public void addNewDirection();

        public void RemoveDiretion(int id);

        public void ModifyDirection();

        public void RemoveStudent(int id);

        public void RemoveLecturer(int id);

    }
}