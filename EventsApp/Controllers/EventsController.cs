using EventsApp.Data;
using EventsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EventsApp.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {

        private readonly ApplicationDbContext db;
        public EventsController(ApplicationDbContext context)
        {
            db = context;
        }

        // Here is the homepage, everytime we are on the homepage the index is called.
        public IActionResult Index()
        {
            var events = db.Events
              .Include(e => e.Tag)
              .OrderByDescending(e => e.StartDate)
              .ToList();

            ViewBag.Events = events.Take(5);

            if (TempData.ContainsKey("message"))
            {
                ViewBag.Message = TempData["message"];
            }

            return View();
        }
        // this is the action taken by ajax when we press the search button
        public IActionResult Results(string search)
        {
            var events = db.Events.Include(e => e.Tag).Take(5).ToList();
            if (!String.IsNullOrEmpty(search))
            {

                events = db.Events
                  .Include(e => e.Tag)
                  .OrderByDescending(e => e.StartDate)
                  .Where(e => e.Title.Contains(search) || e.Content.Contains(search))
                  .ToList();

            }
            ViewBag.SearchString = search;

            return PartialView("_EventList", events.Take(5));
        }
        // this is the ajax function for the load more method
        public IActionResult LoadMore(int page, string search)
        {
            var pageSize = 5; // number of pages we want to take 
            var events = db.Events.Include(e => e.Tag).OrderByDescending(e => e.StartDate).Where(e => e.Title.Contains(search) || e.Content.Contains(search)).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            // that query filters our db firstly by ordering is descendingly by their startdate, and only those that cointain the search string
            if (events.Count() == 0)
            {
                return NotFound();
                // if we get no results
            }
            // now we go into the partial view called event list, this view is inside our Events folder.
            return PartialView("_EventList", events);
        }
        // new CRUD operation
        public IActionResult New()
        {
            Event ev = new Event();

            ev.AllTags = GetAllTags();

            return View(ev);
        }

        [HttpPost]
        // httppost because we want to update the database
        public IActionResult New(Event ev)
        {

            if (ModelState.IsValid)
            {
                db.Events.Add(ev); // we add the element
                db.SaveChanges(); // we save the element into our db
                TempData["message"] = "Event was added"; // message that appears on the screen when we come back to index
                return RedirectToAction("Index"); // we go back to our index method
            }
            else
            { // if we failed the new, we get again all the tags and we try again.
                ev.AllTags = GetAllTags();
                return View(ev);
            }
        }

        [NonAction]
        // non action because we do not have a corresponding view to it, we just use it to get all the tags in our db
        public IEnumerable<SelectListItem> GetAllTags()
        {
            var selectList = new List<SelectListItem>();

            var tags = from tag in db.Tags
                       select tag;

            foreach (var tag in tags)
            {

                selectList.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.TagName.ToString()
                });
            }

            return selectList;
        }
        // show CRUD method , we just filter them by the id on the one we clicked
        public IActionResult Show(int id)
        {
            Event ev = db.Events.Include("Tag")
              .Where(ev => ev.Id == id)
              .First();

            return View(ev);
        }

        // here we go into the edit method, where we firstly get the event we want to edit, and after that we go into our form page
        public IActionResult Edit(int id)
        {

            Event ev = db.Events.Include("Tag")
              .Where(ev => ev.Id == id)
              .First();

            ev.AllTags = GetAllTags(); // method to get all tags
            return View(ev);

        }

        [HttpPost]
        // post because we want to update the database
        public IActionResult Edit(int id, Event requestEvent)
        {
            Event ev = db.Events.Find(id);

            if (ModelState.IsValid) // if it passed all the requiredments, like title length and stuff like that
            {
                // here our form using the html helper returns an requestEvent, which is the event we just created inside the form
                // now when we comeback into our httppost method, we need to find the initial event we where editing,
                // and change the values

                ev.Title = requestEvent.Title;
                ev.Content = requestEvent.Content;
                ev.TagId = requestEvent.TagId;
                ev.TagId = requestEvent.TagId;
                ev.StartDate = requestEvent.StartDate;
                ev.EndDate = requestEvent.EndDate;
                ev.Link = requestEvent.Link;

                TempData["message"] = "The event was modified.";
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                requestEvent.AllTags = GetAllTags();
                return View(requestEvent);
            }
        }

        [HttpPost]
        // Delete CRUD method, it's post because we update the database.
        public ActionResult Delete(int id)
        {
            Event ev = db.Events.Include("Tag")
              .Where(ev => ev.Id == id)
              .First();
            db.Events.Remove(ev);
            db.SaveChanges();
            TempData["message"] = "The Event was deleted";
            return RedirectToAction("Index");

        }

    }

}