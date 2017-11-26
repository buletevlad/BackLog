using BackLogApp.Interfaces;
using BackLogApp.Services;
using BackLogApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BackLogApp.Controllers
{
    public class BackLogController : Controller
    {
        //Services
        IBackLogService backLogService = new BackLogService();
        ITaskService taskService = new TaskService();
        // GET: BackLog
        public ActionResult Index()
        {
            var model = backLogService.GetBackLogList();
            return View(model);
        }

        // GET: BackLog/Details/5
        public ActionResult Details(int id)
        {
            var backlog = backLogService.GetBackLogById(id);
            var taskList = taskService.GetTasksByBackLogId(backlog.Id);
            var model = new DetailsBackLogViewModel(backlog,taskList);
            return View(model);
        }

        // GET: BackLog/Create
        public ActionResult Create()
        {
            var model = new BackLogViewModel();
            return View(model);
        }

        // POST: BackLog/Create
        [HttpPost]
        public ActionResult Create(BackLogViewModel model)
        {
            try
            {
                backLogService.NewBackLog(model); 
                return RedirectToAction("Index","BackLog");
            }
            catch
            {
                return HttpNotFound("Edit the data and try again!");
            }
        }

        // GET: BackLog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BackLog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: BackLog/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: BackLog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                backLogService.DeleteBackLog(id);
                return RedirectToAction("Index", "BackLog");
            }
            catch
            {
                return HttpNotFound("Your Backlog could not be found!");
            }
        }
    }
}
