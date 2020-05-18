using MissionTracking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MissionTracking.Controllers
{
    public class ISMController : Controller
    {
        // ACTION METHODS FOR ISM 

        public ActionResult Index()
        {
            TDBContext db = new TDBContext();

            return View(db.ISM.ToList());
        }

        [HttpPost]
        public ActionResult Create(ISM iSM)
        {
            TDBContext db = new TDBContext();

            string message = "Saved Successfully";
            bool status = true;
            db.ISM.Add(iSM);
            db.SaveChanges();
            return Json(new { status = status, message = message, id = db.ISM.Max(x => x.MissionID) }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            TDBContext db = new TDBContext();

            var mission = db.ISM.Where(x => x.MissionID == id).FirstOrDefault();
            db.ISM.Remove(mission);
            db.SaveChanges();
            string message = "Record has been deleted successfully";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetMissions(int ID)
        {
            TDBContext db = new TDBContext();
            ISM data = new ISM();

            var getMission = db.ISM.Where(x => x.MissionID == ID).FirstOrDefault();

            data.MissionID = getMission.MissionID;
            data.MStartDate = getMission.MStartDate;
            data.MEndDate = getMission.MEndDate;
            data.Program = getMission.Program;
            data.Type = getMission.Type;
            data.Rating = getMission.Rating;

            return Json(new { success = true, data = data }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult UpdateMission(ISM model)
        {
            TDBContext db = new TDBContext();

            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            string message = "Recored has been updated successfully.";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);    


        }



        // ACTION METHODS FOR ACTIONPOINTS

        public ActionResult ActionPointsList(int id)
        {
            TDBContext db = new TDBContext();

            TempData["ID"] = id;

            var GetList = (from p in db.ActionPoint
                           join v in db.Progress on p.APID equals v.APID into ps
                           from v in ps.DefaultIfEmpty()
                              where p.MissionID == id
                              select new ActionProgressVM
                              {
                                APID = p.APID,
                                ActionPoint = p.ActionPoint,
                                Catagory = p.Catagory,
                                DueDate = p.DueDate,
                                Status = v.Status,
                                Responsible = p.Responsible,
                                Priority = p.Priority,
                                Remarks = p.Remarks,
                                Percentage = v.Percentage

                              }).ToList();




            //var data = db.Database.SqlQuery<ActionProgressVM>("EXEC uspgetactionprog {0}", id).ToList();
            return View(GetList);

        }

        [HttpPost]
        public ActionResult ACreate(ActionPoints actionPoints)
        {
            TDBContext db = new TDBContext();

            string message = "Saved Successfully";
            bool status = true;

            int MID = Convert.ToInt32(TempData["ID"]);


            ActionPoints ac = new ActionPoints
            {
                Catagory = actionPoints.Catagory,
                Priority = actionPoints.Priority,
                ActionPoint = actionPoints.ActionPoint,
                DueDate = actionPoints.DueDate,
                Responsible = actionPoints.Responsible,
                Remarks = actionPoints.Remarks,
                MissionID = MID
           
            };
            db.ActionPoint.Add(ac);
            db.SaveChanges();
            return Json(new { status = status, message = message, id = db.ActionPoint.Max(x => x.APID) }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult ADelete(int id)
        {
            TDBContext db = new TDBContext();

            var mission = db.ActionPoint.Where(x => x.APID == id).FirstOrDefault();
            db.ActionPoint.Remove(mission);
            db.SaveChanges();
            string message = "Record has been deleted successfully";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetActions(int ID)
        {
            TDBContext db = new TDBContext();

            ActionPoints data = new ActionPoints();

            var getMission = db.ActionPoint.Where(x => x.APID == ID).FirstOrDefault();

            data.APID = getMission.APID;
            data.Catagory = getMission.Catagory;
            data.Priority = getMission.Priority;
            data.ActionPoint = getMission.ActionPoint;
            data.DueDate = getMission.DueDate;
            data.Responsible = getMission.Responsible;
            data.Remarks = getMission.Remarks;

            return Json(new { success = true, data = data }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult UpdateAction(ActionPoints model)
        {
            TDBContext db = new TDBContext();

            int MID = Convert.ToInt32(TempData["ID"]);

            ActionPoints ac = new ActionPoints
            {
                APID = model.APID,
                Catagory = model.Catagory,
                Priority = model.Priority,
                ActionPoint = model.ActionPoint,
                DueDate = model.DueDate,
                Responsible = model.Responsible,
                Remarks = model.Remarks,
                MissionID = MID

            };
            db.Entry(ac).State = EntityState.Modified;
            db.SaveChanges();

            string message = "Recored has been updated successfully.";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);


        }



        // ACTION METHODS FOR PROGRESS

        public ActionResult ProgressList(int id)
        {
            TDBContext db = new TDBContext();

            TempData["PID"] = id;

            var ProgressList = db.Progress.Where(x => x.APID == id).ToList();

            return View(ProgressList);
        }

        [HttpPost]
        public ActionResult PCreate(Progress progress)
        {
            TDBContext db = new TDBContext();

            string message = "Saved Successfully";
            bool status = true;

            int MID = Convert.ToInt32(TempData["PID"]);


            Progress ac = new Progress
            {
                ReportingDate = progress.ReportingDate,
                Percentage = progress.Percentage,
                Status = progress.Status,
                APID = MID
            };
            db.Progress.Add(ac);
            db.SaveChanges();


            return Json(new { status = status, message = message, id = db.ActionPoint.Max(x => x.APID) }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult PDelete(int id)
        {
            TDBContext db = new TDBContext();

            var mission = db.Progress.Where(x => x.ProgID == id).FirstOrDefault();
            db.Progress.Remove(mission);
            db.SaveChanges();
            string message = "Record has been deleted successfully";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetProgress(int ID)
        {
            TDBContext db = new TDBContext();

            Progress data = new Progress();

            var getMission = db.Progress.Where(x => x.ProgID == ID).FirstOrDefault();

            data.ProgID = getMission.ProgID;
            data.ReportingDate = getMission.ReportingDate;
            data.Percentage = getMission.Percentage;
            data.Status = getMission.Status;


            return Json(new { success = true, data = data }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult UpdateProgress(Progress model)
        {
            TDBContext db = new TDBContext();

            int MID = Convert.ToInt32(TempData["PID"]);

            Progress ac = new Progress
            {
                ProgID = model.ProgID,
                Status = model.Status,
                ReportingDate = model.ReportingDate,
                Percentage = model.Percentage,
                APID = MID

            };
            db.Entry(ac).State = EntityState.Modified;
            db.SaveChanges();

            string message = "Recored has been updated successfully.";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);


        }




        //METHODS FOR UPLOADING FILES

        public ActionResult DList(int id)
        {

            TempData["UID"] = id;
            TempData.Keep();

            return View();
        }

        [HttpPost]
        public ActionResult GetFile(HttpPostedFileBase file, Files files)
        {
            TDBContext db = new TDBContext();

            int MID = Convert.ToInt32(TempData["UID"]);
            int id = Convert.ToInt32(TempData["UID"]);
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string fil = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("/App_Data/Uploads/"), fil);
                    file.SaveAs(path);
                    files.URL = "/App_Data/Uploads/" + file.FileName;
                }

                Files fc = new Files
                {
                    Title = files.Title,
                    Description = files.Description,
                    URL = files.URL,
                    MissionID = MID
                };
                db.Files.Add(fc);
                db.SaveChanges();

                return RedirectToAction("DList", new { id = MID});
            }
            return View(files);
        }

        public PartialViewResult DownloadFiles()
        {
            TDBContext db = new TDBContext();

            ViewBag.message = "file does not exist";

            int MID = Convert.ToInt32(TempData["UID"]);

            var all = db.Files.Where(x => x.MissionID == MID).ToList();

            //var data = db.Files.Find(all);
            //var filename = Path.GetFileName(FilePath.FileName);
            //var path = Request.MapPath("~/App_Data/Uploads/" + all.URL);

            if (all != null)
            {
               // var dir = new DirectoryInfo(Server.MapPath("/App_Data/Uploads/"));

                //FileInfo[] fileNames = dir.GetFiles(path);
                
                //List<string> items = new List<string>();

                List<Files> files = new List<Files>();

                foreach (var file in all)
                {
                    file.URL.ToString();
                    file.FID.ToString();
                    //files.Add(file.URL);
                    //files.Add(Convert.ToString(file.FID));

                }
                return PartialView("_DownloadFiles", all);
            }
            return ViewBag.message;


        }

        public FileResult Download(string filename)
        {
            //byte[] fileBytes = System.IO.File.ReadAllBytes(@"~/App_Data/Uploads");            
            return File(filename, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(filename)); 
        }

        public ActionResult FDelete(int ID)
        {
            using (var db = new TDBContext())
            {

                int MID = Convert.ToInt32(TempData["UID"]);
                int id = Convert.ToInt32(TempData["UID"]);


                var data = db.Files.Find(ID);
                //var filename = Path.GetFileName(FilePath.FileName);
                var path = Request.MapPath(data.URL);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    ViewBag.deleteSuccess = "true";
                }
                db.Files.Remove(data);
                db.SaveChanges();
                return RedirectToAction("DList", new { id = MID });

            }

        }



    }
}