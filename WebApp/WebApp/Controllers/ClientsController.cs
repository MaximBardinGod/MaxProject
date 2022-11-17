using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    [Route("api/DataBase")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsContext ContextClient;

        public ClientsController(ClientsContext contextClient)
        {
            ContextClient = contextClient;
        }


        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            if (ContextClient.Clients == null)
            {
                return NotFound();
            }
            return await ContextClient.Clients.ToListAsync();

        }


        [HttpGet("GetClient/{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await ContextClient.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpGet("GetMentor/{id}")]
        public async Task<ActionResult<Mentor>> GetMentor(int id)
        {
            var mentor = await ContextClient.Mentors.FindAsync(id);

            if (mentor == null)
            {
                return NotFound();
            }

            return mentor;
        }

        [HttpPost("PostClient")] //api/client/PostClient
        public async Task<ActionResult<Client>> PostClient(Client client)
        { 
            ContextClient.Clients.Add(client);
            await ContextClient.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetClients), new { id = client.Id}, client);
        }

        [HttpPost("PostMentor")] //api/client/updateMentor
        public async Task<ActionResult<Mentor>> PostMentor(Mentor mentor)
        {
            ContextClient.Mentors.Add(mentor);
            await ContextClient.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClients), new { id = mentor.Id }, mentor);
        }

        [HttpPut("PutClient/{id}")] // /api/client?id=17  id=17
        public async Task<IActionResult> PutClient([FromQuery] int id, [FromBody] Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPut("PutMentor/{id}")] // /api/client?id=17  id=17
        public async Task<IActionResult> PutMentor([FromQuery] int id, [FromBody] Mentor mentor)
        {
            if (id != mentor.Id)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("DeleteClient/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if (ContextClient.Clients == null)
            {
                return NotFound();
            }

            var client = await ContextClient.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            ContextClient.Clients.Remove(client);
            await ContextClient.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("DeleteMentor/{id}")]
        public async Task<IActionResult> DeleteMentor(int id)
        {
            if (ContextClient.Mentors == null)
            {
                return NotFound();
            }

            var mentor = await ContextClient.Mentors.FindAsync(id);
            if (mentor == null)
            {
                return NotFound();
            }

            ContextClient.Mentors.Remove(mentor);
            await ContextClient.SaveChangesAsync();

            return NoContent();
        }
    }
}
