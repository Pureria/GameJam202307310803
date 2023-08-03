using System.Collections;
using System.Collections.Generic;
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
		[SerializeField] private ShowHide rankingModalShowHide;


		private void Awake()
		{
			this.ConnectRankingModal();
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