﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NerdDinner.Models;
using PagedList;

namespace NerdDinner.Controllers
{
    public class RSVPController : Controller
    {
        private DinnerRepository dinnerRepository = new DinnerRepository();

        [Authorize]
        [HttpPost]
        public ActionResult Register(int id)
        {
            Dinner currentDinner = dinnerRepository.GetDinner(id);

            if (!currentDinner.IsUserRegistered(User.Identity.Name))
            {
                RSVP rsvp = new RSVP() {AttendeeName = User.Identity.Name};

                //TODO
                //currentDinner.RSVPs = new List<RSVP>();
                currentDinner.RSVPs.Add(rsvp);
                dinnerRepository.Save();

            }

            return Content("Thanks - We'll see you there!");
        }
    }
}
