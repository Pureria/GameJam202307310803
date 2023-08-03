using UnityEngine;
using GJ.UI;


namespace GJ.Ranking
{
    public class RankingView : MonoBehaviour
    {
        [SerializeField] private GameObject timeDisplayPrefab;
        [SerializeField] private Transform rankingArea;


        public void UpdateRankView(IReadOnlyRankData rankData)
        {
            var rows = rankData.Rows;
            foreach (Transform child in this.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var item in rows)
            {
                var instance = Instantiate(
                    this.timeDisplayPrefab,
                    this.rankingArea
                );

                var timeView = instance.GetComponent<ResultTimeDisplay>();

                if (item == null)
                {
                    timeView.SetEmpty();
                }
                else
                {
                    timeView.Time = item.Seconds;
                    timeView.Label = item.UserName.Value;
                }
            }
        }
    }
}