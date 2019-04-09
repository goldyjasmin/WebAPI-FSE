using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using FSE.DAL.Models;

namespace _273690_Hackathon_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblEventEnrollmentDetailsController : ControllerBase
    {
        private readonly FeedBackManagementSystemContext _context;

        public TblEventEnrollmentDetailsController(FeedBackManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/TblEventEnrollmentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblEventEnrollmentDetails>>> GetTblEventEnrollmentDetails()
        {
            return await _context.TblEventEnrollmentDetails.ToListAsync();
        }

        // GET: api/TblEventEnrollmentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblEventEnrollmentDetails>> GetTblEventEnrollmentDetails(int id)
        {
            var tblEventEnrollmentDetails = await _context.TblEventEnrollmentDetails.FindAsync(id);

            if (tblEventEnrollmentDetails == null)
            {
                return NotFound();
            }

            return tblEventEnrollmentDetails;
        }

        // PUT: api/TblEventEnrollmentDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblEventEnrollmentDetails(int id, TblEventEnrollmentDetails tblEventEnrollmentDetails)
        {
            if (id != tblEventEnrollmentDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblEventEnrollmentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEventEnrollmentDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblEventEnrollmentDetails
        [HttpPost]
        public async Task<ActionResult<TblEventEnrollmentDetails>> PostTblEventEnrollmentDetails(TblEventEnrollmentDetails tblEventEnrollmentDetails)
        {
            _context.TblEventEnrollmentDetails.Add(tblEventEnrollmentDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblEventEnrollmentDetails", new { id = tblEventEnrollmentDetails.Id }, tblEventEnrollmentDetails);
        }

        // DELETE: api/TblEventEnrollmentDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblEventEnrollmentDetails>> DeleteTblEventEnrollmentDetails(int id)
        {
            var tblEventEnrollmentDetails = await _context.TblEventEnrollmentDetails.FindAsync(id);
            if (tblEventEnrollmentDetails == null)
            {
                return NotFound();
            }

            _context.TblEventEnrollmentDetails.Remove(tblEventEnrollmentDetails);
            await _context.SaveChangesAsync();

            return tblEventEnrollmentDetails;
        }

        private bool TblEventEnrollmentDetailsExists(int id)
        {
            return _context.TblEventEnrollmentDetails.Any(e => e.Id == id);
        }
    }
}
