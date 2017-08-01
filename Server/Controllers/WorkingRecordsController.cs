using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sfBase.Server;
using sfBase.Server.Entities;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace sfBase.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/WorkingRecords")]
    public class WorkingRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkingRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkingRecords
        [HttpGet]
        public IEnumerable<WorkingRecord> GetWorkingRecord()
        {

            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(new { text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),icon_emoji= ":ghost:", username = "test" });

                var contentPost = new StringContent(json, Encoding.UTF8, "application/json");
                var res =  client.PostAsync("https://hooks.slack.com/services/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",contentPost).Result;
            }
            


            return _context.WorkingRecord;
        }

        // GET: api/WorkingRecords/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkingRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workingRecord = await _context.WorkingRecord.SingleOrDefaultAsync(m => m.Id == id);

            if (workingRecord == null)
            {
                return NotFound();
            }

            return Ok(workingRecord);
        }

        // PUT: api/WorkingRecords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkingRecord([FromRoute] int id, [FromBody] WorkingRecord workingRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workingRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(workingRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkingRecordExists(id))
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

        // POST: api/WorkingRecords
        [HttpPost]
        public async Task<IActionResult> PostWorkingRecord([FromBody] WorkingRecord workingRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.WorkingRecord.Add(workingRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkingRecord", new { id = workingRecord.Id }, workingRecord);
        }

        // DELETE: api/WorkingRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkingRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workingRecord = await _context.WorkingRecord.SingleOrDefaultAsync(m => m.Id == id);
            if (workingRecord == null)
            {
                return NotFound();
            }

            _context.WorkingRecord.Remove(workingRecord);
            await _context.SaveChangesAsync();

            return Ok(workingRecord);
        }

        // PUT: api/WorkingRecords/ClockIn
        [HttpPut]
        [HttpPost]
        [Route("ClockIn")]
        public async Task<IActionResult> ClockIn()
        {
            var workingRecords = new List<WorkingRecord>()
            {
                new WorkingRecord()
                {
                    Id =2,
                    UserId=1,
                    RecordeDate= DateTime.Now.Date,
                    ClockIn=DateTime.Now
                },
                new WorkingRecord()
                {
                    Id =1,
                    UserId=1,
                    RecordeDate=DateTime.Parse("2017-07-07"),
                    ClockIn=new DateTime(2017,7,7,8,50,23),
                    ClockOut=new DateTime(2017,7,7,17,45,43),
                },
            };
            if (workingRecords == null)
            {
                return NotFound();
            }

            return Ok(workingRecords);
        }

        [HttpPut]
        [HttpPost]
        [Route("ClockOut")]
        public async Task<IActionResult> ClockOut()
        {
            var workingRecords = new List<WorkingRecord>()
            {
                new WorkingRecord()
                {
                    Id =2,
                    UserId=1,
                    RecordeDate=DateTime.Now.Date,
                    ClockIn=new DateTime(2017,7,8,8,27,13),
                    ClockOut=DateTime.Now
                },
                new WorkingRecord()
                {
                    Id =1,
                    UserId=1,
                    RecordeDate=DateTime.Parse("2017-07-07"),
                    ClockIn=new DateTime(2017,7,7,8,50,23),
                    ClockOut=new DateTime(2017,7,7,17,45,43),
                },
            };
            if (workingRecords == null)
            {
                return NotFound();
            }

            return Ok(workingRecords);
        }
        private bool WorkingRecordExists(int id)
        {
            return _context.WorkingRecord.Any(e => e.Id == id);
        }
    }
}