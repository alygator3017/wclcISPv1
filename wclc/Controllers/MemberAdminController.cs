using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wclc.Models;

namespace wclc.Controllers
{
    public class MemberAdminController : Controller
    {
        private MemberDb db = new MemberDb();

        // GET: MemberAdmin
        [Authorize(Roles = "AppAdmin, canEdit, IT")]
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        // GET: MemberAdmin/Details/5
        [Authorize(Roles = "AppAdmin, canEdit, IT")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: MemberAdmin/Create
        [Authorize(Roles = "AppAdmin, canEdit, IT")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AppAdmin, canEdit, IT")]
        public ActionResult Create([Bind(Include = "MemberId,FirstName,LastName,StreetAddress,aptSuite,City,State,Zip,Phone,Email,inGiftOf")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: MemberAdmin/Edit/5
        [Authorize(Roles = "AppAdmin, canEdit, IT")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: MemberAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AppAdmin, canEdit, IT")]
        public ActionResult Edit([Bind(Include = "MemberId,FirstName,LastName,StreetAddress,aptSuite,City,State,Zip,Phone,Email,inGiftOf")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: MemberAdmin/Delete/5
        [Authorize(Roles = "AppAdmin, canEdit, IT")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }
        

        // POST: MemberAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AppAdmin, canEdit, IT")]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void ExportToXML()
        {
            var data = db.Members.ToList();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=wclcDonationData.xml");
            Response.ContentType = "text/xml";

            var serializer = new System.Xml.Serialization.XmlSerializer(data.GetType());
            serializer.Serialize(Response.OutputStream, data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
