namespace Garage.DAO.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Repair")]
    public partial class Repair
    {
        public int id { get; set; }

        public int carId { get; set; }

        public int garageId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime date { get; set; }

        public virtual Car Car { get; set; }

        public virtual Garage Garage { get; set; }
    }
}
