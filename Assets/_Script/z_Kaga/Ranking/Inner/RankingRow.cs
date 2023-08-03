using System;
using UnityEngine;


namespace GJ.Ranking
{
    [Serializable]
    public class RankingRow
    {
        [SerializeField] private FixedLengthString username;
        [SerializeField] private float seconds;


        public FixedLengthString UserName
        {
            get { return this.username; }
        }


        public float Seconds
        {
            get { return this.seconds; }
        }


        public RankingRow(FixedLengthString userName, float seconds)
        {
            this.username = userName;
            this.seconds = seconds;
        }


        public static int ConpareTo(RankingRow a, RankingRow b)
        {
            if (a == null && b == null) return 0;
            if (a == null && b != null) return 1;
            if (a != null && b == null) return -1;
            return a.seconds.CompareTo(b.seconds);
        }
    }
}