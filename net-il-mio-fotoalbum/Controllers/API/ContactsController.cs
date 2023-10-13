using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Database;
using net_il_mio_fotoalbum.Models.DatabaseModels;
using net_il_mio_fotoalbum.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace net_il_mio_fotoalbum.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IRepository<Contact, ContactFormModel> _repositoryContact;

        public ContactsController(IRepository<Contact, ContactFormModel> repositoryContact)
        {
            _repositoryContact = repositoryContact;
        }
        // GET: api/<ContactsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContactsController>
        [HttpPost]
        public IActionResult Post([FromBody] Contact newContact)
        {
            try
            {
                bool result = _repositoryContact.AddEntity(newContact);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Unable to add contact");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request." });

            }
        }

        // PUT api/<ContactsController>/5 __MOdify
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
