using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.Threading.Tasks;

namespace APIExamples.Models
{
    public class Order
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }

    }
}
