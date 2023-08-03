using UnityEngine;
using UnityEngine.UI;
using GJ.Ranking;


namespace GJ.UI.Presenter
{
    public class ResultPopupPresenter : MonoBehaviour
    {
        [SerializeField] private Button retryButton;
        [SerializeField] private Button gotoTitleButton;
        [SerializeField] private RankingView rankingView;
        [SerializeField] private ResultTimeDisplay resultTimeDisplay;
        [SerializeField] private Timer timer;


        private void Awake()
        {
            this.ConnectRankingModel();
            this.ConnectResultTimeDisplay();
        }


        private void ConnectRankingModel()
        {
            RankingModel.Instance.OnRankingUpdate.AddListener(
                this.rankingView.UpdateRankView
            );
        }


        private void ConnectResultTimeDisplay()
        {
            this.timer.OnTimerStop.AddListener(
                (sec) =>
                {
                    this.resultTimeDisplay.Time = sec;
                    this.resultTimeDisplay.Label = "Clear Time:";
                    RankingModel.Instance.Reload();
                }
            );
        }
    }
}