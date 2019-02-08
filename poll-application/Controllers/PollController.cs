using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using poll_application.ViewModels;
using poll_application.Models;
using System.Diagnostics;

namespace poll_application.Controllers
{
    public class PollController : Controller
    {
        PollDbContext db = new PollDbContext();

        public ActionResult Form(PollFormViewModel viewModel)
        {
            if (viewModel == null)
            {
                viewModel = new PollFormViewModel();
                viewModel.Options = new List<PollOption>();
                viewModel.Options.Add(new PollOption());
                viewModel.Options.Add(new PollOption());
            }

            return View(viewModel);
        }

        public ActionResult Browse()
        {
            var latestPolls = db.Polls.OrderByDescending(p => p.Date).Where(p => p.Private == false).Take(5).ToList();
            var popularPolls = db.Polls.OrderByDescending(p => p.Votes).Where(p => p.Private == false).Take(5).ToList();

            var viewModel = new PollBrowseViewModel()
            {
                LatestPolls = latestPolls,
                PopularPolls = popularPolls
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PollFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Form", viewModel);

            var poll = new Poll()
            {
                Name = viewModel.Poll.Name,
                Date = DateTime.Now,
                MultiVote = viewModel.Poll.MultiVote,
                Private = viewModel.Poll.Private             
            };

            db.Polls.Add(poll);

            foreach(var option in viewModel.Options)
            {
                db.PollOptions.Add(option);
            }

            db.SaveChanges();

            return RedirectToAction("Vote", "Poll", new { @id = poll.Id });
        }

        public ActionResult Vote(int id)
        {
            var poll = db.Polls.SingleOrDefault(p => p.Id == id);
            if (poll == null)
                return HttpNotFound();

            var pollOptions = db.PollOptions.Where(o => o.PollId == id);

            var viewModel = new PollVoteViewModel()
            {
                Poll = poll,
                PollOptions = pollOptions
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VoteAction(int id)
        {
            var option = db.PollOptions.SingleOrDefault(o => o.Id == id);
            var poll = db.Polls.SingleOrDefault(p => p.Id == option.PollId);

            var vote = new Vote()
            {
                IpAdress = System.Web.HttpContext.Current.Request.UserHostAddress,
                PollId = option.PollId
            };

            if (option == null || poll == null)
                return HttpNotFound();

            if (!poll.MultiVote)
            {
                var voteCheck = db.Votes.FirstOrDefault(v => (v.PollId == option.PollId && v.IpAdress == vote.IpAdress));
                if (voteCheck != null)
                    return Json(new { result = "Redirect", url = Url.Action("Vote", "Poll", new { @id = poll.Id }) });
            }

            option.Votes += 1;
            poll.Votes += 1;

            db.Votes.Add(vote);
            db.SaveChanges();

            return Json(new { result = "Redirect", url = Url.Action("Result", "Poll", new { @id = poll.Id }) });
        }

        public ActionResult Result(int id)
        {
            var poll = db.Polls.SingleOrDefault(p => p.Id == id);
            if (poll == null)
                return HttpNotFound();

            var pollOptions = db.PollOptions.Where(o => o.PollId == id);

            var viewModel = new PollVoteViewModel()
            {
                Poll = poll,
                PollOptions = pollOptions
            };

            return View(viewModel);
        }

        public ActionResult Search(string phrase)
        {
            var results = db.Polls.Where(p => p.Name.Contains(phrase)).ToList();

            var model = new PollSearchViewModel()
            {
                Phrase = phrase,
                Polls = results
            };

            return View(model);
        }
    }
}