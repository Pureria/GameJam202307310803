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