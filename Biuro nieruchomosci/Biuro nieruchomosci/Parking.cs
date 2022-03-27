namespace Biuro_nieruchomosci
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Parking")]
    public partial class Parking
    {
        public int Id { get; set; }

        public int House_Id { get; set; }

        public string Address { get; set; }

        public string Number { get; set; }
    }
}
