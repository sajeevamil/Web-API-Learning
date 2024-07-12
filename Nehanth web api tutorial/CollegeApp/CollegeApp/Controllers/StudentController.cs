using CollegeApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("All")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(CollegeRepository.Students);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            if (id <= 0)
                return BadRequest("Id should be greater than 0");
            var student = CollegeRepository.Students.Where(student => student.Id == id)?.FirstOrDefault();
            if (student is null)
                return NotFound($"The student with {id} is not found");

            return Ok(student);
        }

        [HttpGet]
        [Route("{name:alpha}")]
        public ActionResult<Student> GetStudentByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("name cannot be null");
            var student = CollegeRepository.Students.Where(student => student.StudentName.Equals(name, StringComparison.OrdinalIgnoreCase))?.FirstOrDefault();
            if (student is null)
                return NotFound($"There no student with name {name}");
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<bool> DeleteStudent(int id)
        {
            if (id <= 0)
                return BadRequest("Id cannot be null");
            var student = CollegeRepository.Students.Where(student => student.Id == id).FirstOrDefault();
            if (student is null)
                return NotFound($"The student with {id} is not found");
            CollegeRepository.Students.Remove(student);
            return Ok(true);
        }
    }
}
