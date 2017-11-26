namespace BackLogApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Line")]
    public class LineViewModel
    {
        public int Id { get; set; }

        public int TextId { get; set; }

        public string Text { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EditedDate { get; set; }

        public string Status { get; set; }

    }
}
