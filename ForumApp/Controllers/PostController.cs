using ForumApp.Data;
using ForumApp.Data.Entities;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumAppDbContext context;

        public PostController(ForumAppDbContext _context)
        {
            this.context = _context;
        }

        public IActionResult Index()
        {
            var allPosts = context.Posts.Select(p => new PostViewModel()
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content
            })
                .ToList();

            return View(allPosts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]  
        public async Task<IActionResult> Add(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var post = new Post()
            {
                Id = model.Id,
                Title = model.Title,
                Content = model.Content
            };

            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = context.Posts.SingleOrDefault(p => p.Id == id);

            if (post == null)
            {
                return BadRequest();
            }

            var postDto = new PostViewModel()
            {
                Title = post.Title,
                Content = post.Content
            };
            
            return View(postDto);
        }

        [HttpPost]
        public IActionResult Edit(PostViewModel model)
        {
            var postUpdate = context.Posts.SingleOrDefault(p => p.Id == model.Id);

            if (postUpdate == null)
            {
                return BadRequest();
            }

            postUpdate.Title = model.Title;
            postUpdate.Content = model.Content;

            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            var postDel = context.Posts.SingleOrDefault(p => p.Id == Id);  
            
            if (postDel == null)
            {
                return BadRequest();
            }

            context.Posts.Remove(postDel);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
