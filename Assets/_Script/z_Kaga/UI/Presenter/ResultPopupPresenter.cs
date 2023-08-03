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


		private void Awake()
		{
			this.ConnectRankingModel();	
		}


		private void ConnectRankingModel()
		{
			RankingModel.Instance.OnRankingUpdate.AddListener(
				this.rankingView.UpdateRankView
			);
		}
	}
}