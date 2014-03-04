using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Storage;
using System.Diagnostics;

using ChizMover.Entity;
using SQLite;

namespace ChizMover
{
    public class GameDB
    {
        private SQLiteConnection _dbConnection; 

        //singleton class
        private static GameDB _instance = null;
        public static GameDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameDB();
                }
                return _instance;
            }
        }

        private GameDB()
        {
            PrepareDataFile();

            try
            {
                _dbConnection = new SQLiteConnection(GameConfig.DBFILE);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("cannot open db: ", ex.ToString());
            }
        }


        /// <summary>
        /// this method check whether file in local folder, 
        /// if not it will copy file from installation folder (Application.GetResource...)
        /// this will be called only in Application_Launching
        /// </summary>
        public void PrepareDataFile()
        {
            try
            {
                using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (!isoStore.FileExists(GameConfig.DBFILE))
                    {
                        using (Stream input = Application.GetResourceStream(new Uri(GameConfig.DBFILE, UriKind.Relative)).Stream)
                        {
                            using (IsolatedStorageFileStream outputStream = isoStore.CreateFile(GameConfig.DBFILE))
                            {
                                byte[] buffer = new byte[4096];

                                int byteRead = -1;

                                //byteRead: The total number of bytes read into the buffer
                                //byteRead <= buffer.Length
                                while ((byteRead = input.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    outputStream.Write(buffer, 0, byteRead);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }


        public LevelDetail GetLevelDetail(int packId, int levelnum)
        {
            try
            {
                LevelDetail levelDetail = _dbConnection.Table<LevelDetail>().Where(item => (item.PackID == packId && item.LevelNum == levelnum)).FirstOrDefault();
                return levelDetail;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error get level_detail: ", ex.ToString());
            }

            return null;
        }

        public void CloseDb() 
        {
            if (_dbConnection != null)
                _dbConnection.Close();
        }
    }
}