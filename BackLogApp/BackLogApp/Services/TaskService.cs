using BackLogApp.Interfaces;
using BackLogApp.Models;
using BackLogApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackLogApp.Services
{
    public class TaskService : ITaskService
    {
        DbModel Db = new DbModel();

        public TaskViewModel NewTask(TaskViewModel item)
        {
            if (item != null)
            {
                var created = new Task
                {
                    Id = item.Id,
                    Description = item.Description,
                    Label = item.Label,
                    Status = item.Status,
                    CreatedDate = DateTime.Now,
                    EditedDate = DateTime.Now
                };
                Db.Tasks.Add(created);
                Db.SaveChanges();
            }
            return item;
        }
        public TaskViewModel GetTaskById(int id)
        {
            var returned = new TaskViewModel(Db.Tasks.Find(id));
            return returned;
        }
        public ListOfTaskViewModel GetTaskList(int? id = null, string query = "")
        {
           
            if (id != null)
            {
                var list = new ListOfTaskViewModel(Db.Tasks.Where(x=>x.BackLogId == id).Select(x => new TaskViewModel()
                {
                    Id = x.Id,
                    BackLogId = x.BackLogId,
                    Label = x.Label,
                    Description = x.Description,
                    Status = x.Status,
                    CreatedDate = x.CreatedDate,
                    EditedDate = x.EditedDate
                }).ToList());

                return list;
            }
           
            else if (query != null)
            {
                var list = new ListOfTaskViewModel(Db.Tasks.Where(x => x.Id.ToString().Contains(query)
                                              || x.BackLogId.ToString().Contains(query)
                                              || x.Label.ToLower().Contains(query)
                                              || x.Description.ToLower().Contains(query)
                                              || x.Status.ToLower().Contains(query)
                                              || x.CreatedDate.ToString().Contains(query)
                                              || x.EditedDate.ToString().Contains(query))

                .Select(x => new TaskViewModel()
                {
                    Id = x.Id,
                    BackLogId = x.BackLogId,
                    Label = x.Label,
                    Description = x.Description,
                    Status = x.Status,
                    CreatedDate = x.CreatedDate,
                    EditedDate = x.EditedDate
                }).ToList());

                return list;
                //
                
            }
            else
            {
                var list = new ListOfTaskViewModel(Db.Tasks.Select(x => new TaskViewModel()
                {
                    Id = x.Id,
                    BackLogId = x.BackLogId,
                    Label = x.Label,
                    Description = x.Description,
                    Status = x.Status,
                    CreatedDate = x.CreatedDate,
                    EditedDate = x.EditedDate
                }).ToList());

                return list;
            }
        }
        public List<TaskViewModel> GetTasksByBackLogId(int id)
        {
            var list = new List<TaskViewModel>(Db.Tasks.Where(x => x.BackLogId == id).Select(x => new TaskViewModel()
            {
                Id = x.Id,
                BackLogId = x.BackLogId,
                Label = x.Label,
                Description = x.Description,
                Status = x.Status,
                CreatedDate = x.CreatedDate,
                EditedDate = x.EditedDate
            }).ToList());

            return list;
        }
        public bool DeleteTask(int id)
        {
            var found = Db.Tasks.Find(id);
            if (found != null)
            {
                Db.Tasks.Remove(found);
                Db.SaveChanges();
                return true;
            }
            else return false;
        }
        public bool DeleteTaskByBackLogId(int id)
        {
            var foundList = Db.Tasks.Where(x => x.BackLogId == id).Select(x => new Task()).ToList();
            if (foundList != null)
            {
                Db.Tasks.RemoveRange(foundList);
                Db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}