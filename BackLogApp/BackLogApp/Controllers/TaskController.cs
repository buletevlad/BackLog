using BackLogApp.Interfaces;
using BackLogApp.Services;
using BackLogApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackLogApp.Controllers
{
    public class TaskController : Controller
    {
        //Services
        ITaskService taskService = new TaskService();
        // GET: Task
        public ActionResult Index()
        {
            var model = taskService.GetTaskList();
            return View(model);
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            var model = taskService.GetTaskById(id);
            return View(model);
        }

        // GET: Task/Create
        public ActionResult Create(int id)
        {
            var model = new TaskViewModel();
            
            return View(model);
           
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(TaskViewModel item)
        {
            try
            {
                taskService.NewTask(item);
                return RedirectToAction("Details", "BackLog", new { id = item.BackLogId});
            }
            catch
            {
                return HttpNotFound("Edit the data and try again!");
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Task/Edit/5
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

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
