using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VanStoreBE.Models;
using System.IO;

namespace VanStoreBE.Controllers
{
    public class ProDetailsController : Controller
    {
        private VanStoreEntities db = new VanStoreEntities();

        // GET: ProDetails
        public ActionResult Index()
        {
            var proDetails = db.ProDetails.Include(p => p.Color).Include(p => p.Product).Include(p => p.Supplier).Include(p => p.Size1);
            return View(proDetails.ToList());
        }

        // GET: ProDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProDetail proDetail = db.ProDetails.Find(id);
            if (proDetail == null)
            {
                return HttpNotFound();
            }
            return View(proDetail);
        }

        // GET: ProDetails/Create
        public ActionResult Create()
        {
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName");
            ViewBag.ProID = new SelectList(db.Products, "ProID", "ProName");
            ViewBag.SupID = new SelectList(db.Suppliers, "SupID", "SupName");
            ViewBag.SIZE = new SelectList(db.Sizes, "SizeID", "SizeNum");
            return View();
        }

        // POST: ProDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProDeID,ProID,SupID,ColorID,Price,RemainQuantity,SoldQuantity,ViewQuantity,DISCOUNT,SIZE,SHAPE,KEYWORD,Image1,Image2,Image3,Image4,Image5," + "UploadImg1,UploadImg2,UploadImg3,UploadImg4,UploadImg5")] ProDetail proDetail)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra RemainQuantity, SoldQuantity, và ViewQuantity không âm
                if (proDetail.RemainQuantity < 0 || proDetail.SoldQuantity < 0 || proDetail.ViewQuantity < 0)
                {
                    ModelState.AddModelError("", "Số lượng không được < 0!");
                    // Thực hiện các hành động xử lý lỗi khác nếu cần
                }
                if (proDetail.UploadImg1 == null || proDetail.UploadImg2 == null || proDetail.UploadImg3 == null || proDetail.UploadImg4 == null || proDetail.UploadImg5 == null)
                {
                    ViewBag.error = "Please select a image!!";
                }
                else
                {
                    if (proDetail.UploadImg1 != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(proDetail.UploadImg1.FileName);
                        proDetail.Image1 = path + filename;
                        proDetail.UploadImg1.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    if (proDetail.UploadImg2 != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(proDetail.UploadImg2.FileName);
                        proDetail.Image2 = path + filename;
                        proDetail.UploadImg2.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    if (proDetail.UploadImg3 != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(proDetail.UploadImg3.FileName);
                        proDetail.Image3 = path + filename;
                        proDetail.UploadImg3.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    if (proDetail.UploadImg4 != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(proDetail.UploadImg4.FileName);
                        proDetail.Image4 = path + filename;
                        proDetail.UploadImg4.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    if (proDetail.UploadImg5 != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(proDetail.UploadImg5.FileName);
                        proDetail.Image5 = path + filename;
                        proDetail.UploadImg5.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    db.ProDetails.Add(proDetail);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", proDetail.ColorID);
            ViewBag.ProID = new SelectList(db.Products, "ProID", "ProName", proDetail.ProID);
            ViewBag.SupID = new SelectList(db.Suppliers, "SupID", "SupName", proDetail.SupID);
            ViewBag.SIZE = new SelectList(db.Sizes, "SizeID", "SizeNum", proDetail.SIZE);
            return View(proDetail);
        }

        // GET: ProDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProDetail proDetail = db.ProDetails.Find(id);
            if (proDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", proDetail.ColorID);
            ViewBag.ProID = new SelectList(db.Products, "ProID", "ProName", proDetail.ProID);
            ViewBag.SupID = new SelectList(db.Suppliers, "SupID", "SupName", proDetail.SupID);
            ViewBag.SIZE = new SelectList(db.Sizes, "SizeID", "SizeNum", proDetail.SIZE);
            return View(proDetail);
        }

        // POST: ProDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProDeID,ProID,SupID,ColorID,Price,RemainQuantity,SoldQuantity,ViewQuantity,DISCOUNT,SIZE,SHAPE,KEYWORD,Image1,Image2,Image3,Image4,Image5," + "UploadImg1,UploadImg2,UploadImg3,UploadImg4,UploadImg5")] ProDetail proDetail)
        {
            if (ModelState.IsValid)
            {
                if (proDetail.UploadImg1 == null || proDetail.UploadImg2 == null || proDetail.UploadImg3 == null || proDetail.UploadImg4 == null || proDetail.UploadImg5 == null)
                {
                    ViewBag.error = "Please select a image!!";
                }
                else
                {
                    if (proDetail.UploadImg1 != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(proDetail.UploadImg1.FileName);
                        proDetail.Image1 = path + filename;
                        proDetail.UploadImg1.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    if (proDetail.UploadImg2 != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(proDetail.UploadImg2.FileName);
                        proDetail.Image2 = path + filename;
                        proDetail.UploadImg2.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    if (proDetail.UploadImg3 != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(proDetail.UploadImg3.FileName);
                        proDetail.Image3 = path + filename;
                        proDetail.UploadImg3.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    if (proDetail.UploadImg4 != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(proDetail.UploadImg4.FileName);
                        proDetail.Image4 = path + filename;
                        proDetail.UploadImg4.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    if (proDetail.UploadImg5 != null)
                    {
                        string path = "~/Content/images/";
                        string filename = Path.GetFileName(proDetail.UploadImg5.FileName);
                        proDetail.Image5 = path + filename;
                        proDetail.UploadImg5.SaveAs(Path.Combine(Server.MapPath(path), filename));
                    }
                    db.Entry(proDetail).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", proDetail.ColorID);
            ViewBag.ProID = new SelectList(db.Products, "ProID", "ProName", proDetail.ProID);
            ViewBag.SupID = new SelectList(db.Suppliers, "SupID", "SupName", proDetail.SupID);
            ViewBag.SIZE = new SelectList(db.Sizes, "SizeID", "SizeNum", proDetail.SIZE);
            return View(proDetail);
        }

        // GET: ProDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProDetail proDetail = db.ProDetails.Find(id);
            if (proDetail == null)
            {
                return HttpNotFound();
            }
            return View(proDetail);
        }

        // POST: ProDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProDetail proDetail = db.ProDetails.Find(id);
            db.ProDetails.Remove(proDetail);
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
