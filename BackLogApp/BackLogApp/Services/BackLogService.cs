using BackLogApp.Interfaces;
using BackLogApp.Models;
using BackLogApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackLogApp.Services
{
    public class BackLogService : IBackLogService
    {
        //Services
        DbModel Db = new DbModel();
        ITaskService taskService = new TaskService();

        public BackLogViewModel NewBackLog(BackLogViewModel item)
        {
            if (item != null)
            {
                var created = new BackLog
                {
                    Id = item.Id,
                    Label = item.Label,
                    Status = item.Status,
                    CreatedDate = DateTime.Now
                };
                Db.BackLogs.Add(created);
                Db.SaveChanges();
            }
            return item;
        }
        public BackLogViewModel GetBackLogById(int id)
        {
            var returned = new BackLogViewModel(Db.BackLogs.Find(id));
            return returned;
        }

        public ListOfBackLogViewModel GetBackLogList(string query = "")
        {
            if (query != null)
            {
                query = query.ToLower();
                var list = new ListOfBackLogViewModel(Db.BackLogs.OrderBy(x => x.CreatedDate).Where(x => x.Id.ToString().Contains(query)
                                             || x.Label.ToLower().Contains(query)
                                             || x.Status.ToLower().Contains(query)
                                             || x.CreatedDate.ToString().Contains(query))
               .Select(x => new BackLogViewModel()
               {
                   Id = x.Id,
                   Label = x.Label,
                   Status = x.Status,
                   CreatedDate = x.CreatedDate
               }).ToList());

                return list;
                //
               
            }
            else
            {
                var list = new ListOfBackLogViewModel(Db.BackLogs.OrderBy(x => x.CreatedDate).Select(x => new BackLogViewModel()
                {
                    Id = x.Id,
                    Label = x.Label,
                    Status = x.Status,
                    CreatedDate = x.CreatedDate
                }).ToList());

                return list;
            }
        }
        public bool DeleteBackLog(int id)
        {
            try
            {
                var found = Db.BackLogs.Find(id);
                if (found != null)
                {
                    taskService.DeleteTaskByBackLogId(found.Id);
                    Db.BackLogs.Remove(found);
                    Db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}