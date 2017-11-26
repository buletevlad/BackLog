namespace BackLogApp.ViewModels
{
    using BackLogApp.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BackLog")]
    public class BackLogViewModel
    {
        public BackLogViewModel() { }
        public BackLogViewModel(BackLog item)
        {
            Id = item.Id;
            Label = item.Label;
            Status = item.Status;
            CreatedDate = item.CreatedDate;
        }
        public int Id { get; set; }

        public string Label { get; set; }

        public string Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }

       
    }
}
