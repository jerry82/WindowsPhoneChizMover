using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

using ChizMover.Entity;

namespace ChizMover
{
    public class GameLogic
    {
        /// <summary>
        /// singleton pattern
        /// </summary>
        private static GameLogic _instance = null;

        public static GameLogic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameLogic();
                return _instance;
            }
        }

        private GameLogic() { }


        public LevelDetail GetNextLevel(LevelDetail currentLevel)
        {
            LevelDetail next = null;
            int nextPackId = -1;
            int nextLevelNum = -1;

            //first start
            if (currentLevel == null)
            {
                nextPackId = 1;
                nextLevelNum = 1;
            }
            else
            {
            }

            next = GameDB.Instance.GetLevelDetail(nextPackId, nextLevelNum);

            return next;
        }

        public LevelDetail GetPreLevelv(LevelDetail currentLevel)
        {
            LevelDetail prev = null;

            return prev;
        }

        //check db file exist
        public List<string> GetLevelContent(LevelDetail levelDetail)
        {
            List<string> content = new List<string>();

            if (levelDetail != null)
            {
                if (!String.IsNullOrEmpty(levelDetail.Content))
                    content = levelDetail.Content.Split(new char[] { GameConfig.LEVEL_CONTENT_SEPARATOR }).ToList<string>();
            }

            return content;
        }
    }
}
