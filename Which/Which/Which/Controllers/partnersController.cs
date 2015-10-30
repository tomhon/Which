using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Which.Models;

namespace Which.Controllers
{
    public class partnersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: partners
        public ActionResult Index()
        {
            return View(db.partners.ToList());
        }

        // GET: partners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            partner partner = db.partners.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }


        // Summary:
        //     Creates a raw SQL query that will return entities in this set. By default, the
        //     entities returned are tracked by the context; this can be changed by calling
        //     AsNoTracking on the System.Data.Entity.Infrastructure.DbSqlQuery`1 returned.
        //     Note that the entities returned are always of the type for this set and never
        //     of a derived type. If the table or tables queried may contain data for other
        //     entity types, then the SQL query must be written appropriately to ensure that
        //     only entities of the correct type are returned. As with any API that accepts
        //     SQL it is important to parameterize any user input to protect against a SQL injection
        //     attack. You can include parameter place holders in the SQL query string and then
        //     supply parameter values as additional arguments. Any parameter values you supply
        //     will automatically be converted to a DbParameter. context.Blogs.SqlQuery("SELECT
        //     * FROM dbo.Posts WHERE Author = @p0", userSuppliedAuthor); Alternatively, you
        //     can also construct a DbParameter and supply it to SqlQuery. This allows you to
        //     use named parameters in the SQL query string. context.Blogs.SqlQuery("SELECT
        //     * FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        //
        // Parameters:
        //   sql:
        //     The SQL query string.
        //
        //   parameters:
        //     The parameters to apply to the SQL query string. If output parameters are used,
        //     their values will not be available until the results have been read completely.
        //     This is due to the underlying behavior of DbDataReader, see http://go.microsoft.com/fwlink/?LinkID=398589
        //     for more details.
        //
        // Returns:
        //     A System.Data.Entity.Infrastructure.DbSqlQuery`1 object that will execute the
        //     query when it is enumerated.


        //public virtual DbSqlQuery<TEntity> SqlQuery(string sql, params object[] parameters);

        // GET: partners/Query - pass Partner name to get TE & BE back
        public ActionResult Query(string id)
        {
            //id = "Netflix";
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var testResult = db.partners.SqlQuery("SELECT * from dbo.partners WHERE PartnerName =  ('Amazon')").ToArray();
            var testResult = db.partners.SqlQuery("SELECT * from dbo.partners WHERE PartnerName = @partnerName", new SqlParameter("@partnerName", id)).ToArray();
            //var queryDetails = db.partners.SqlQuery("SELECT * from dbo.partners WHERE PartnerName = @partnerName", new SqlParameter("@partnerName", partnerName)).ToList();
            //db.partners.Find(id);
            //var partnerResult = new partner;
            //partnerResult.PartnerName = testResult[1];
            if (testResult == null || testResult.Count() == 0) 
            {
                return HttpNotFound();
            }
             return View(testResult[0]);
        }

        // GET: partners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: partners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartnerId,PartnerName,TEName,BEName,GTMName")] partner partner)
        {
            if (ModelState.IsValid)
            {
                db.partners.Add(partner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partner);
        }

        // GET: partners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            partner partner = db.partners.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        // POST: partners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartnerId,PartnerName,TEName,BEName,GTMName")] partner partner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partner);
        }

        // GET: partners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            partner partner = db.partners.Find(id);
            if (partner == null)
            {
                return HttpNotFound();
            }
            return View(partner);
        }

        // POST: partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            partner partner = db.partners.Find(id);
            db.partners.Remove(partner);
            db.SaveChanges();
            return RedirectToAction("Index");
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
