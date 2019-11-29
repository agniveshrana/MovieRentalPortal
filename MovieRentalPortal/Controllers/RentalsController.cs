using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRentalPortal.Controllers
{
    public class RentalsController : Controller
    {
        // GET: Rentals
        [Route("Rentals/NewRental")]
        public ActionResult NewRental()
        {
            return View();
        }
    }
}