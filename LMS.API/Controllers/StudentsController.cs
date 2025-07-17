using LMS.Application.Students.Commands.CreateOrUpdateGuardian;
using LMS.Application.Students.Commands.CreateOrUpdateParent;
using LMS.Application.Students.Commands.CreateStudentBasicInfo;
using LMS.Application.Students.Commands.CreateStudentWithParentAndGuardian;
using LMS.Application.Students.Commands.DeleteStudent;
using LMS.Application.Students.Commands.FinalizeStudentRegistration;
using LMS.Application.Students.Commands.UpdateStudentWithRelations;
using LMS.Application.Students.DTOs;
using LMS.Application.Students.Queries.GetAllStudents;
using LMS.Application.Students.Queries.GetParentAndGuardianByStudentId;
using LMS.Application.Students.Queries.GetStudentByEmail;
using LMS.Application.Students.Queries.GetStudentDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("basic-info")]
        public async Task<IActionResult> CreateBasicInfo(CreateStudentBasicInfoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("add-parent")]
        public async Task<IActionResult> AddParent(AddOrUpdateParentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("add-guardian")]
        public async Task<IActionResult> AddGuardian(AddOrUpdateGuardianCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("finalize")]
        public async Task<IActionResult> Finalize(FinalizeStudentRegistrationCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentWithParentAndGuardianCommand command)
        {
            var studentId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = studentId }, new { id = studentId });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateStudentWithRelationsCommand command)
        {
            if (id != command.Id) return BadRequest("Invalid ID");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteStudentCommand(id));
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var student = await _mediator.Send(new GetStudentDetailsQuery(id));
            return student is not null ? Ok(student) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Filter filter)
        {
            var students = await _mediator.Send(new GetAllStudentsQuery(filter));
            return Ok(students);
        }

        [HttpGet("by-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            var student = await _mediator.Send(new GetStudentByEmailQuery(email));
            return student is not null ? Ok(student) : NotFound();
        }

        [HttpGet("{id}/relations")]
        public async Task<IActionResult> GetRelations(Guid id)
        {
            var result = await _mediator.Send(new GetParentAndGuardianByStudentIdQuery(id));
            return result.Item1 is not null && result.Item2 is not null ? Ok(result) : NotFound();
        }
    }

}