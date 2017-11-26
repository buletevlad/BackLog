namespace BackLogApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Text")]
    public partial class TextViewModel
    {
       

        public int Id { get; set; }

        public int TaskId { get; set; }

        public string Label { get; set; }

        public string Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EditedDate { get; set; }

       
    }
}
