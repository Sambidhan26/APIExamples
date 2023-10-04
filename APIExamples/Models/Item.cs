using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace APIExamples.Models
{
    public class Item
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public float Price { get; set; }
        public int OrderId { get; set; }
    }
}
