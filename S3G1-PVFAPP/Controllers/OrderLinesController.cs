using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S3G1_PVFAPP.Models;

namespace S3G1_PVFAPP.Controllers
{
    public class OrderLinesController : Controller
    {
        private readonly Entities1 db = new Entities1();

        // GET: OrderLines
        public ActionResult Index()
        {
            var orderLine = db.OrderLine.Include(o => o.Orders).Include(o => o.Product);
            return View(orderLine.ToList());
        }

        // GET: OrderLines/Details/5
        public ActionResult Details(String description,int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Orders order = db.Orders.SingleOrDefault(o => o.OrderID ==id);
            
            //OrderLine orderLine = order.OrderLine.FirstOrDefault() ;
            List<OrderLine> orderLine = order.OrderLine.ToList();
            foreach(OrderLine item in orderLine)
            {
                if(item.Product.ProductDescription == description)
                {
                    return View(item);
                }
            }
            OrderLine item1 = null;
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            return View(item1);
        }

        // GET: OrderLines/Create
        public ActionResult Create(int? id)
        {
            ViewBag.CurrOrder = id;   
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID");
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductDescription");
            return View();
        }

        // POST: OrderLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,ProductID,OrderedQuantity")] OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                db.OrderLine.Add(orderLine);
                db.SaveChanges();
                return RedirectToAction("Edit", "Orders", new { id = orderLine.OrderID });
            }

            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderLine.OrderID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductDescription", orderLine.ProductID);
            return View(orderLine);
        }

        // GET: OrderLines/Edit/5
        public ActionResult Edit(String description, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders order = db.Orders.SingleOrDefault(o => o.OrderID == id);

            //OrderLine orderLine = order.OrderLine.FirstOrDefault() ;
            List<OrderLine> orderLines = order.OrderLine.ToList();
            OrderLine orderLine = null;
            foreach (OrderLine item in orderLines)
            {
                if (item.Product.ProductDescription == description)
                {
                    orderLine = item;
                    break;
                }
            }
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderLine.OrderID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductDescription", orderLine.ProductID);
            return View(orderLine);
        }

        // POST: OrderLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,ProductID,OrderedQuantity")] OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit","Orders",new {id= orderLine.OrderID });
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", orderLine.OrderID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductDescription", orderLine.ProductID);
            return View(orderLine);
        }

        // GET: OrderLines/Delete/5
        public ActionResult Delete(String description, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders order = db.Orders.SingleOrDefault(o => o.OrderID == id);

            //OrderLine orderLine = order.OrderLine.FirstOrDefault() ;
            List<OrderLine> orderLines = order.OrderLine.ToList();
            OrderLine orderLine = null;
            foreach (OrderLine item in orderLines)
            {
                if (item.Product.ProductDescription == description)
                {
                    orderLine = item;
                    break;
                }
            }
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            return View(orderLine);
        }

        // POST: OrderLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(String description, int? id)
        {
            Orders order = db.Orders.SingleOrDefault(o => o.OrderID == id);

            //OrderLine orderLine = order.OrderLine.FirstOrDefault() ;
            List<OrderLine> orderLines = order.OrderLine.ToList();
            OrderLine orderLine = null;
            foreach (OrderLine item in orderLines)
            {
                if (item.Product.ProductDescription == description)
                {
                    orderLine = item;
                    break;
                }
            }
            db.OrderLine.Remove(orderLine);
            db.SaveChanges();
            return RedirectToAction("Edit","Orders", new { id = orderLine.OrderID });
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
