using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GJ.Ranking;


namespace GJ.UI.Presenter
{
    public class RankingModalPresenter : MonoBehaviour
    {
        [SerializeField] private RankingView rankingView;


        private void Awake()
        {
            this.ConnectRankingView();

        }


        private void ConnectRankingView()
        {
            var rankingModel = RankingModel.Instance;
            rankingModel.OnRankingUpdate.AddListener(
                this.rankingView.UpdateRankView
            );
        }
    }
}