using Contacts_list.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contacts_list.Controllers
{
    public class HomeController : Controller
    {
        Contact_DBEntities db = new Contact_DBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Contacts.Select(p => new PersonViewModel()
            {
                ID = p.ID,
                Name = p.Name,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
                WebSite = p.WebSite,
                SmartPhoneName = p.SmartPhone.SmartPhoneName,
                SmartPhoneModel = p.SmartPhone.SmartPhoneModel,
            }).ToList());
        }

        //Detail Page
        public ActionResult ContactDetails(int ID)
        {
            return View(db.Contacts.Where(p => p.ID == ID).Select(p => new PersonViewModel()
            {
                ID = p.ID,
                Name = p.Name,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
                WebSite = p.WebSite,
                SmartPhoneName = p.SmartPhone.SmartPhoneName,
                SmartPhoneModel = p.SmartPhone.SmartPhoneModel,
            }).Single());
        }
        //Add contact

        [HttpGet]
        public ActionResult AddContact()
        {
            //send to "add contact" page
            return View();
        }


        [HttpPost]
        public ActionResult AddContact(PersonViewModel person)
        {
            //add contact and save chanage
            Contacts contact = new Contacts()
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                Email = person.Email,
                WebSite = person.WebSite,
            };
            db.Contacts.Add(contact);

            SmartPhone phone = new SmartPhone()
            {
                PersonID = contact.ID,
                SmartPhoneName = person.SmartPhoneName,
                SmartPhoneModel = person.SmartPhoneModel,
            };
            db.SmartPhone.Add(phone);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Edit contacts

        [HttpGet]
        public ActionResult EditContact(int ID)
        {
            //send contact to form(View)

            return View(db.Contacts.Where(p => p.ID == ID).Select(p => new PersonViewModel()
            {
                ID = p.ID,
                Name = p.Name,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
                WebSite = p.WebSite,
                SmartPhoneName = p.SmartPhone.SmartPhoneName,
                SmartPhoneModel = p.SmartPhone.SmartPhoneModel,
            }).Single());
        }


        [HttpPost]
        public ActionResult EditContact(PersonViewModel person)
        {
            //update contact

            Contacts contact = db.Contacts.Find(person.ID);

            contact.Name = person.Name;
            contact.PhoneNumber = person.PhoneNumber;
            contact.Email = person.Email;
            contact.WebSite = person.WebSite;
            db.Contacts.Add(contact);

            //update smartphone


            SmartPhone phone = db.SmartPhone.Find(person.ID);
            phone.PersonID = contact.ID;
            phone.SmartPhoneName = person.SmartPhoneName;
            phone.SmartPhoneModel = person.SmartPhoneModel;
            db.SmartPhone.Add(phone);

            //save Chanage

            db.SaveChanges();

            return RedirectToAction("Index");

        }

        //Delete contacts

        public ActionResult DeleteContact(int ID)
        {
            // find contact with id and remove it

            db.Contacts.Remove(db.Contacts.Find(ID));
            db.SmartPhone.Remove(db.SmartPhone.Find(ID));
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}