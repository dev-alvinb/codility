using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Codility2.Data;
using Codility2.Models;

namespace Codility2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyController : ControllerBase
    {
        private readonly ManagerContext _context;

        public ApplyController(ManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicantJob>>> GetApplicantJob()
        {
            if (_context.Applicants == null)
            {
                return NotFound();
            }
            return await _context.ApplicantJobs.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ApplicantJob>> PostApplication(ApplicantJob application)
        {
            if (application == null)
            {
                return Problem("Entity set 'ManagerContext.Applicants'  is null.");
            }

            //
            ApplicantJob? checkIfApplied = await _context.ApplicantJobs
                    .Where(a => a.ApplicantId == application.ApplicantId && a.JobId == application.JobId)
                    .FirstOrDefaultAsync();

            if (checkIfApplied == null)
            {
                _context.ApplicantJobs.Add(application);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetApplicantJob", new { id = application.ApplicantId }, application);
            } else
            {
                return BadRequest("You are already applied for this job");
            }

        }



    }
}
