using GJ.DataSave;


namespace GJ.Ranking
{
    public class RankingModel
    {
        private static string savePath = "ranking.json";
        private static int maxUserNameLength = 15;
        private static int maxRankingRecords;
        private static RankingModel instance;
        private RankingData rankingData;


        public static int MaxUserNameLength
        {
            get { return maxUserNameLength; }
        }


        public static int MaxRankingRecords
        {
            get { return maxRankingRecords; }
        }


        public RankingModel Instance
        {
            get
            {
                if (instance == null) instance = new RankingModel();
                return instance;
            }
        }


        private RankingModel()
        {
            this.rankingData = DataSaveUtility.Load<RankingData>(savePath);
            if (this.rankingData == null)
            {
                this.rankingData = new RankingData(maxRankingRecords);
            }
        }


        // ランキング登録ポップアップを表示するためにランクインしたか確認する.
        public bool IsRankIn(float seconds)
        {
            return this.rankingData.IsRankIn(seconds);
        }


        // ランキングに登録する.
        public void Add(string name, float seconds)
        {
            this.rankingData.Add(name, seconds);
        }
    }
}