using UnityEngine;
using UnityEngine.UI;
using GJ.Ranking;


namespace GJ.UI.Presenter
{
    public class TitlePopupPresenter : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button rankingButton;
        [SerializeField] private Button exitButton;
		[SerializeField] private Timer timer;
		[SerializeField] private ShowHide rankingModalShowHide;


		private void Awake()
		{
			this.ConnectTimer();
			this.ConnectRankingModal();
			this.ConnectApplicationExit();
		}


		private void ConnectTimer()
		{
			this.startButton.onClick.AddListener(
				this.timer.StartTimer
			);
		}


		private void ConnectApplicationExit()
		{
			this.exitButton.onClick.AddListener(
				Application.Quit
			);
		}


		private void ConnectRankingModal()
		{
			// ランキングモーダルを開く.
			this.rankingButton.onClick.AddListener(
				this.rankingModalShowHide.Show
			);

			// ランキングモーダルを開くたびにリロードする.
			this.rankingButton.onClick.AddListener(
				RankingModel.Instance.Reload
			);
		}
	}
}