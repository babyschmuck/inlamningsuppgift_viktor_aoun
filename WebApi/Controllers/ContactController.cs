using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using WebApi.Models.DTO;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class ContactController : ControllerBase
    {
        private readonly ContactRepository _contactRepository;

        public ContactController(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(ContactModel model)
        {
            if(ModelState.IsValid)
            {
                return Created("", await _contactRepository.AddAsync(model));
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("getall")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactRepository.GetAllAsync();
            return Ok(contacts);
        }
    }
}
