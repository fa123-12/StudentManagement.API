using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.NativeInterop;
using StudentManagement.API.Data;
using StudentManagement.API.Models;

namespace StudentManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TeachersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Teachers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
    {
        return await _context.Teachers.Include(c => c.Courses).ToListAsync();
    }

    // GET: Teachers/1
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Teacher>> GetTeacher(int id)
    {
        var teacher = await _context.Teachers
           .Where(t => t.Id == id)
            .Select(t => new Teacher
            {
                Id = t.Id,
                FirstName = t.FirstName,
                LastName = t.LastName,
                Email = t.Email,
                Speciality = t.Speciality,
                TeacherCode = t.TeacherCode,

                Courses = t.Courses.Select(c => new Course
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    Credits = c.Credits,
                    TeacherId = c.TeacherId
                }).ToList()
            })
            .FirstOrDefaultAsync(t => t.Id == id);

        if (teacher == null)
            return NotFound();

        return teacher;
    }

    [HttpGet("by-code/{code}")]
    public async Task<ActionResult<Teacher>> GetTeacherByCode(string code)
    {
        var teacher = await _context.Teachers
            .Where(t => t.TeacherCode == code)
            .Select(t => new Teacher
            {
                Id = t.Id,
                FirstName = t.FirstName,
                LastName = t.LastName,
                Email = t.Email,
                Speciality = t.Speciality,
                TeacherCode = t.TeacherCode,

                Courses = t.Courses.Select(c => new Course
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    Credits = c.Credits,
                    TeacherId = c.TeacherId
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (teacher == null)
            return NotFound();

        return Ok(teacher);
    }
    // POST: api/Teachers
    [HttpPost]
    public async Task<ActionResult<Teacher>> CreateTeacher(Teacher teacher)
    {
        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetTeacher),
            new { id = teacher.Id },
            teacher
        );
    }

    // PUT: api/Teachers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeacher(
        int id,
        Teacher teacher)
    {
        if (id != teacher.Id)
            return BadRequest();

        _context.Entry(teacher).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Teachers/5
   
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);

        if (teacher == null)
            return NotFound();

        var hasCourses = await _context.Courses
            .AnyAsync(c => c.TeacherId == id);

        if (hasCourses)
            return Conflict("This teacher cannot be deleted because they have courses assigned.");

        _context.Teachers.Remove(teacher);

        await _context.SaveChangesAsync();

        return NoContent();
    }

}
