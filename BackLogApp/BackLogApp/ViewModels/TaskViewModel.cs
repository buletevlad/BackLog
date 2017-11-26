namespace BackLogApp.ViewModels
{
    using BackLogApp.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public class TaskViewModel
    {
        public TaskViewModel() { }
        public TaskViewModel(int backLogId) { BackLogId = backLogId; }

        public TaskViewModel(Task item)
        {
            Id = item.Id;
            Label = item.Label;
            Description = item.Description;
            Status = item.Status;
            BackLogId = item.BackLogId;
            CreatedDate = item.CreatedDate;
            EditedDate = item.EditedDate;
        }
        public int Id { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public int BackLogId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EditedDate { get; set; }

    }
}
