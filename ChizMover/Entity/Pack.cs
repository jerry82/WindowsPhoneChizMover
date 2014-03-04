using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace ChizMover.Entity
{
    /// <summary>
    /// mapping for table 'pack'
    /// </summary>
    [Table("pack")]
    public class Pack
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("current_level")]
        public int CurrentLevel { get; set; }

        [Column("lock")]
        public int IsLocked { get; set; }
    }
}
