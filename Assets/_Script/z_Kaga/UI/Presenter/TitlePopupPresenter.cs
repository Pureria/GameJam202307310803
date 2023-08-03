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
			// �����L���O���[�_�����J��.
			this.rankingButton.onClick.AddListener(
				this.rankingModalShowHide.Show
			);

			// �����L���O���[�_�����J�����тɃ����[�h����.
			this.rankingButton.onClick.AddListener(
				RankingModel.Instance.Reload
			);
		}
	}
}