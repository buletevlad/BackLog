using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackLogApp.ViewModels
{
    public class ListOfTaskViewModel
    {
        public ListOfTaskViewModel() { }
        public ListOfTaskViewModel(List<TaskViewModel> items)
        {
            TaskList = items.Select(x => new TaskViewModel()
            {
                Id = x.Id,
                BackLogId = x.BackLogId,
                Label = x.Label,
                Description = x.Description,
                Status = x.Status,
                CreatedDate = x.CreatedDate,
                EditedDate = x.EditedDate
            }).ToList();
        }
        List<TaskViewModel> TaskList { get; set; }
    }
}