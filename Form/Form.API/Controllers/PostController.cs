using Form.API.Data;
using Form.API.Models.DTO;
using Form.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Form.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly FormDbContext dbContext;

        public PostController(FormDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllPosts()
        {
           var posts = await dbContext.Posts.ToListAsync();
            return Ok(posts);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetPostById")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            var post = await dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (post != null)
            {
                return Ok(post);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(AddPostRequest addPostRequest)
        {
            var post = new Post()
        {
             FirstName = addPostRequest.FirstName,
             LastName = addPostRequest.LastName,
             Email = addPostRequest.Email,
             Phone = addPostRequest.Phone,
             BirthDay = addPostRequest.BirthDay
        };
            post.Id = Guid.NewGuid();
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetPostById), new {id = post.Id}, post);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePost([FromRoute] Guid id, UpdatePostRequest updatePostRequest)
        {
       
           var existingPost = await dbContext.Posts.FindAsync(id);
            if (existingPost != null)
            {
                existingPost.FirstName = updatePostRequest.FirstName;
                existingPost.LastName = updatePostRequest.LastName;
                existingPost.Email = updatePostRequest.Email;
                existingPost.Phone = updatePostRequest.Phone;
                existingPost.BirthDay = updatePostRequest.BirthDay;

               await dbContext.SaveChangesAsync();
                return Ok(existingPost);    
            }
            return NotFound();


        }
    


    }
}
