using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BackLogApp.ViewModels
{
    public class DetailsBackLogViewModel
    {
        public DetailsBackLogViewModel() { }
        public DetailsBackLogViewModel(BackLogViewModel backlog, List<TaskViewModel> taskList)
        {
            Id = backlog.Id;
            Label = backlog.Label;
            Status = backlog.Status;
            CreatedDate = backlog.CreatedDate;
            TaskList = taskList.Select(x=> new TaskViewModel
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
        public int Id { get; set; }

        public string Label { get; set; }

        public string Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }

        public List<TaskViewModel> TaskList { get; set; }

    }
}