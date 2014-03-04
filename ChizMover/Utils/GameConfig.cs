using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;

namespace ChizMover
{
    public class GameConfig
    {
        //public static readonly string DBPATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "sodokuDB.sqlite"));

        public static readonly string DBFILE = "sodokuDB.sqlite";

        public static readonly char LEVEL_CONTENT_SEPARATOR = '0';

        //resources: image + sound
        public static string GetBackground()
        {
            return "screen";
        }

        public static string GetBot()
        {
            return "bot40";
        }

        //
    }
}
