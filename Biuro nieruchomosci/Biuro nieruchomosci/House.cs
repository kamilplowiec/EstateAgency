namespace Biuro_nieruchomosci
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("House")]
    public partial class House
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Cost_sm { get; set; }

        public decimal Area_sm { get; set; }

        public int HouseType_Id { get; set; }

        public int Level { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
