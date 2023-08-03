using UnityEngine.Events;
using GJ.DataSave;


namespace GJ.Ranking
{
    public class RankingModel
    {
        private static string savePath = "ranking.json";
        private static int maxUserNameLength = 15;
        private static int maxRankingRecords = 5;
        private static RankingModel instance;
        private RankingData rankingData;


        // ランキングが更新されたときに外に通知する.
        private UnityEvent<IReadOnlyRankData>
        onRankingUpdate = new UnityEvent<IReadOnlyRankData>();


        public static int MaxUserNameLength
        {
            get { return maxUserNameLength; }
        }


        public static int MaxRankingRecords
        {
            get { return maxRankingRecords; }
        }


        public static RankingModel Instance
        {
            get
            {
                if (instance == null) instance = new RankingModel();
                return instance;
            }
        }


        public UnityEvent<IReadOnlyRankData> OnRankingUpdate
        {
            get { return this.onRankingUpdate; }
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
            this.onRankingUpdate.Invoke(this.rankingData);
        }


        // View側が任意のタイミングでランキング情報を取得するために使用する.
        public void Reload()
        {
            this.onRankingUpdate.Invoke(this.rankingData);
        }
    }
}