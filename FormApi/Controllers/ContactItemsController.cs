using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormApi.Models;
using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using FormApi.Services;
using Microsoft.AspNetCore.Hosting;

namespace FormApi.Controllers
{
    //public class TesteEmailController : Controller
    //{
    //    private readonly IEmailSender _emailSender;
    //    public TesteEmailController(IEmailSender emailSender, IHostingEnvironment env)
    //    {
    //        _emailSender = emailSender;
    //    }
    //    public IActionResult EnviaEmail()
    //    {
    //        return View();
    //    }
    //}
    [Route("api/ContactItems")]
    [ApiController]
    public class ContactItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public ContactItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/ContactItems
        [HttpGet]
        [EnableCors("MyPolicy")]
        public async Task<ActionResult<IEnumerable<ContactItem>>> GetContactItems()
        {
            return await _context.ContactItems.ToListAsync();
        }

        // GET: api/ContactItems/5
        [HttpGet("{id}")]
        [EnableCors("MyPolicy")]
        public async Task<ActionResult<ContactItem>> GetContactItem(long id)
        {
            var contactItem = await _context.ContactItems.FindAsync(id);

            if (contactItem == null)
            {
                return NotFound();
            }

            return contactItem;
        }

        // POST: api/ContactItems
        [EnableCors("MyPolicy")]
        [HttpPost]
        public async Task<ActionResult<ContactItem>> PostContactItem(ContactItem contactItem)
        {
            _context.ContactItems.Add(contactItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContactItem), new { id = contactItem.Id }, contactItem);
        }
        
    }
}
