namespace BackLogApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Line")]
    public partial class Line
    {
        public int Id { get; set; }

        public int TextId { get; set; }

        public string Text { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EditedDate { get; set; }

        public string Status { get; set; }

        public virtual Text Text1 { get; set; }
    }
}
