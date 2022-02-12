using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOS;
using UniversityAPI.Services;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        #region Group
        [HttpPost("add/group")]
        public ActionResult CreateNewGroup([FromBody] CreateGroupDTO groupDTO)
        {
            _service.addNewGroup(groupDTO);
            return Ok();
        }

        [HttpDelete("remove/group/{groupId}")]
        public ActionResult RemoveGroup([FromRoute]int groupId)
        {
            _service.RemoveGroup(groupId);
            return Ok();
        }

        [HttpPut("modify/group")]
        public ActionResult ModifyGroupName([FromBody] ModifyGroupDTO groupDTO)
        {
            _service.ModifyGroup(groupDTO);
            return Ok();
        }
        #endregion

        #region Direction
        [HttpPost("add/direction")]
        public ActionResult CreateNewDirection([FromBody] CreateDirectionDTO directionDTO)
        {
            _service.addNewDirection(directionDTO);
            return Ok();
        }

        [HttpDelete("remove/direction/{directionId}")]
        public ActionResult RemoveDirection([FromRoute]int directionId)
        {
            _service.RemoveDiretion(directionId);
            return Ok();
        }

        [HttpPut("modify/direction")]
        public ActionResult ModifyDirectionName([FromBody] ModifyDirectionDTO directionDTO)
        {
            _service.ModifyDirection(directionDTO);
            return Ok();
        }
        #endregion

        #region Student
        [HttpDelete("remove/student/{studentId}")]
        public ActionResult RemoveStudent([FromRoute] int studentId)
        {
            _service.RemoveStudent(studentId);
            return Ok();
        }
        #endregion

        #region Lecturer
        [HttpDelete("remove/lecturer/{lecturerId}")]
        public ActionResult RemoveLecturer([FromRoute] int lecturerId)
        {
            _service.RemoveLecturer(lecturerId);
            return Ok();
        }
        #endregion
    }
}
