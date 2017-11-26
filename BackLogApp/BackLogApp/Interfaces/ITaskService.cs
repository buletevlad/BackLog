using BackLogApp.Services;
using BackLogApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackLogApp.Interfaces
{
    public interface ITaskService
    {
        TaskViewModel NewTask(TaskViewModel item);
        TaskViewModel GetTaskById(int id);
        ListOfTaskViewModel GetTaskList(int? id = null, string query = "");
        bool DeleteTask(int id);
        bool DeleteTaskByBackLogId(int id);
        List<TaskViewModel> GetTasksByBackLogId(int id);

    }
}