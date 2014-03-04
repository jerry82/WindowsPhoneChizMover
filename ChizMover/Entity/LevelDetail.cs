using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ChizMover.Entity
{
    /// <summary>
    /// mapping for table 'level_detail'
    /// </summary>
    [Table("level_detail")]
    public class LevelDetail
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("packId")]
        public int PackID { get; set; }

        [Column("levelnum")]
        public int LevelNum { get; set; }

        [Column("difficulty")]
        public int Difficulty { get; set; }
    }
}
