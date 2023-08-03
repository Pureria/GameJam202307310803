using System;
using UnityEngine;


namespace GJ.Ranking
{
    [Serializable]
    internal class RankingColumn
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


        public RankingColumn(FixedLengthString userName, float seconds)
        {
            this.username = userName;
            this.seconds = seconds;
        }
    }
}