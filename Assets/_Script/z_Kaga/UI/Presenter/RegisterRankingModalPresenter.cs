using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GJ.Ranking;


namespace GJ.UI.Presenter
{
    public class RegisterRankingModalPresenter : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private ResultTimeDisplay timeView;
        [SerializeField] private InputField nameField;
        [SerializeField] private Button acceptButton;

        private float clearTime;
        private string playerName;


		private void Awake()
		{
            this.timer.OnNewRecord.AddListener(
                (value) =>
                {
                    this.clearTime = value;
                    this.timeView.Time = value;
                }
            );


            this.nameField.onValueChanged.AddListener(
                (name) => this.playerName = name
            );


            this.acceptButton.onClick.AddListener(
                () => RankingModel.Instance.Add(this.playerName, this.clearTime)
            );
		}
	}
}