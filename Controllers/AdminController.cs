using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityAPI.DTOS;
using UniversityAPI.Services;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private const string _role = "admin";
        private readonly IAdminService _service;
        private readonly ITokenService _tokenService;

        public AdminController(IAdminService service, ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }

        #region Group
        [HttpPost("add/group")]
        public ActionResult CreateNewGroup([FromHeader] string token,[FromBody] CreateGroupDTO groupDTO)
        {
            _tokenService.ValidateToken(token,_role);
            _service.addNewGroup(groupDTO);
            return Ok();
        }

        [HttpDelete("remove/group/{groupId}")]
        public ActionResult RemoveGroup([FromHeader] string token,[FromRoute]int groupId)
        {
            _tokenService.ValidateToken(token,_role);
            _service.RemoveGroup(groupId);
            return Ok();
        }

        [HttpPut("modify/group")]
        public ActionResult ModifyGroupName([FromHeader] string token,[FromBody] ModifyGroupDTO groupDTO)
        {
            _tokenService.ValidateToken(token,_role);
            _service.ModifyGroup(groupDTO);
            return Ok();
        }
        #endregion

        #region Direction
        [HttpPost("add/direction")]
        public ActionResult CreateNewDirection([FromHeader] string token,[FromBody] CreateDirectionDTO directionDTO)
        {
            _tokenService.ValidateToken(token,_role);
            _service.addNewDirection(directionDTO);
            return Ok();
        }

        [HttpDelete("remove/direction/{directionId}")]
        public ActionResult RemoveDirection([FromHeader] string token,[FromRoute]int directionId)
        {
            _tokenService.ValidateToken(token,_role);
            _service.RemoveDiretion(directionId);
            return Ok();
        }

        [HttpPut("modify/direction")]
        public ActionResult ModifyDirectionName([FromHeader] string token,[FromBody] ModifyDirectionDTO directionDTO)
        {
            _tokenService.ValidateToken(token,_role);
            _service.ModifyDirection(directionDTO);
            return Ok();
        }
        #endregion

        #region Student
        [HttpDelete("remove/student/{studentId}")]
        public ActionResult RemoveStudent([FromHeader] string token,[FromRoute] int studentId)
        {
            _tokenService.ValidateToken(token,_role);
            _service.RemoveStudent(studentId);
            return Ok();
        }
        #endregion

        #region Lecturer
        [HttpDelete("remove/lecturer/{lecturerId}")]
        public ActionResult RemoveLecturer([FromHeader] string token,[FromRoute] int lecturerId)
        {
            _tokenService.ValidateToken(token,_role);
            _service.RemoveLecturer(lecturerId);
            return Ok();
        }
        #endregion
    }
}
