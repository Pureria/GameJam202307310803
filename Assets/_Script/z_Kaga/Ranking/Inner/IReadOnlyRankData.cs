using System.Collections.Generic;

namespace GJ.Ranking
{
    public interface IReadOnlyRankData
    {
        public IReadOnlyList<RankingRow> Rows { get; }
    }
}