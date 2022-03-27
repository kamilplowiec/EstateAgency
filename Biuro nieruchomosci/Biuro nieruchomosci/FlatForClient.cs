namespace Biuro_nieruchomosci
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FlatForClient")]
    public partial class FlatForClient
    {
        public int Id { get; set; }

        public int Client_Id { get; set; }

        public int UseType_Id { get; set; }

        public DateTime? DateTo { get; set; }

        public bool Accepted { get; set; }

        public int House_Id { get; set; }
    }
}
