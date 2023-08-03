using System;
using System.Collections.Generic;


namespace GJ.Ranking
{
    // internal class だと JSONUtility が読めなくなるかもしれないと思ったので
    // public にしている.
    [Serializable]
    public class RankingData
    {
        // 空のランキングデータには null を詰める.
        private List<RankingColumn> rankingData;
        private int maxColumns;


        public RankingData(int maxColumns)
        {
            this.maxColumns = maxColumns;
            this.rankingData = new List<RankingColumn>();
        }



        // 主にランキング登録のポップアップを出すために使用する.
        public bool IsRankIn(float seconds)
        {
            foreach(var column in this.rankingData)
            {
                if (seconds <= column.Seconds) return true;
            }

            return false;
        }


        public void Add(string name, float seconds)
        {
            var maxNameLength = RankingModel.MaxUserNameLength;
            var clippedName = new FixedLengthString(name, maxNameLength);
            var column = new RankingColumn(clippedName, seconds);

            var newRanking = new List<RankingColumn>(this.rankingData);
            newRanking.Add(column);
            newRanking.Sort((a, b) => a.Seconds.CompareTo(b.Seconds));

            this.rankingData = new List<RankingColumn>();
            for (int i = 0; i < this.maxColumns; i++)
            {
                this.rankingData.Add(newRanking[i]);
            }
        }
    }
}