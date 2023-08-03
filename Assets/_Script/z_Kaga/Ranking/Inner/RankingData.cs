using System;
using System.Collections.Generic;
using UnityEngine;

namespace GJ.Ranking
{
    [Serializable]
    public class RankingData : IReadOnlyRankData
    {
        // 空のランキングデータには null を詰める.
        [SerializeField] private List<RankingRow> rankingData;
        [SerializeField] private int maxColumns;


        public IReadOnlyList<RankingRow> Rows
        {
            get { return this.rankingData; }
        }


        public RankingData(int maxColumns)
        {
            this.maxColumns = maxColumns;
            this.rankingData = new List<RankingRow>();
            for (int i = 0; i < maxColumns; i++) this.rankingData.Add(null);
        }



        // 主にランキング登録のポップアップを出すために使用する.
        public bool IsRankIn(float seconds)
        {
            foreach(var row in this.rankingData)
            {
                if (row == null) return true;
                if (seconds <= row.Seconds) return true;
            }

            return false;
        }


        public void Add(string name, float seconds)
        {
            var maxNameLength = RankingModel.MaxUserNameLength;
            var clippedName = new FixedLengthString(name, maxNameLength);
            var row = new RankingRow(clippedName, seconds);

            var newRanking = new List<RankingRow>(this.rankingData);
            newRanking.Add(row);
            newRanking.Sort((a, b) => RankingRow.ConpareTo(a, b));
            

            // null があったらランキングから追い出す
            if (newRanking[newRanking.Count - 1] == null)
            {
                newRanking.RemoveAt(newRanking.Count - 1);
            }


            this.rankingData = new List<RankingRow>();
            for (int i = 0; i < this.maxColumns; i++)
            {
                this.rankingData.Add(newRanking[i]);
            }
        }


        // JSONUtility で読み取ったデータがnullにならないっぽいのでnull化する.
        public void Cleaning()
        {
            for (int i = 0; i < this.rankingData.Count; i++)
            {
                var target = this.rankingData[i];
                if (target == null) continue;
                if (target.Seconds == 0) this.rankingData[i] = null;
            }
        }
    }
}