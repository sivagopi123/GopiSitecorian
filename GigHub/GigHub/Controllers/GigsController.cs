using GigHub.Models;
using GigHub.Persistence;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize]
        public ActionResult Create()
        {
            var ViewModel = new GigFormViewModel
            {
                Genres = _unitOfWork.Genres.GetGenre(),
                Heading = "Add a Gig"
            };
            return View("GigForm", ViewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genres.GetGenre();
                return View("GigForm", viewModel);
            }

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.getDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue,
            };
            _unitOfWork.Gigs.AddGig(gig);

            _unitOfWork.Complete();

            return RedirectToAction("Mine", "Gigs");
        }



        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genres.GetGenre();
                return View("GigForm", viewModel);
            }

            var gig = _unitOfWork.Gigs.GetGigWithAttendees(viewModel.Id);

            if (gig == null)
                return HttpNotFound();

            if (gig.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            gig.Update(viewModel.getDateTime(), viewModel.Venue, viewModel.Genre);

            _unitOfWork.Complete();
            return RedirectToAction("Mine", "Gigs");
        }



        [Authorize]
        public ActionResult GigList()
        {

            var currentUserId = User.Identity.GetUserId();

            var gigsViewModel = new GigsViewModel
            {
                Gigs = _unitOfWork.Gigs.GetGigsUserAttending(currentUserId),
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Gigs I'm Attending",
                Attendances = _unitOfWork.Attendances.GetFutureAttendances(currentUserId).ToLookup(a => a.GigId)
            };

            return View("Gigs", gigsViewModel);
        }

        public ActionResult ArtistList()
        {
            var currentUserId = User.Identity.GetUserId();
            var artistFollowing = _unitOfWork.Followers.GetFollowerWithUserInfo(currentUserId);
            return View(artistFollowing);
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _unitOfWork.Gigs.GetGigWithGenre(userId);

            return View(gigs);
        }

        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            Gig gig = _unitOfWork.Gigs.GetGig(id);

            if (gig == null)
                return HttpNotFound();

            if (gig.ArtistId != userId)
                return new HttpUnauthorizedResult();

            var ViewModel = new GigFormViewModel
            {
                Genres = _unitOfWork.Genres.GetGenre(),
                Date = gig.DateTime.ToString("d MMM yyyy"),
                Time = gig.DateTime.ToString("hh:mm"),
                Genre = gig.GenreId,
                Venue = gig.Venue,
                Heading = "Edit a Gig",
                Id = gig.Id
            };
            return View("GigForm", ViewModel);
        }



        public ActionResult Search(GigsViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
        }
        public ActionResult GigDetail(int? Id)
        {
            var userId = User.Identity.GetUserId();
            Gig gigSelected = _unitOfWork.Gigs.GetGigWithAttendeesAndFollowees(Id);

            var gigDetailViewModel = new GigDetailViewModel
            {
                Artist = gigSelected.Artist,
                Date = gigSelected.DateTime.ToString("dd MMM"),
                Time = gigSelected.DateTime.ToString("hh:mm"),
                Venue = gigSelected.Venue,
                IsUserAttending = gigSelected.IsUserAttending(userId),
                IsUserFollowing = gigSelected.IsUserFollowing(userId),
                IsUserLoggedIn = !string.IsNullOrEmpty(userId)
            };

            return View(gigDetailViewModel);
        }


    }
}