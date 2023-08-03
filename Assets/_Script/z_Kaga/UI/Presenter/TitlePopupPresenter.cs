using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using GJ.Ranking;


namespace GJ.UI.Presenter
{
    public class TitlePopupPresenter : MonoBehaviour
    {
		[SerializeField] private GameManager gameMamager;
        [SerializeField] private Button startButton;
        [SerializeField] private Button rankingButton;
        [SerializeField] private Button exitButton;
		[SerializeField] private Slider soundSlider;
		[SerializeField] private Timer timer;
		[SerializeField] private ShowHide rankingModalShowHide;

		[Space]
		[SerializeField] private AudioMixer audioMixer;
		[SerializeField] private AudioSource buttonPushSound;


		private void Awake()
		{
			this.ConnectGameManager();
			this.ConnectTimer();
			this.ConnectRankingModal();
			this.ConnectApplicationExit();
			this.ConnectAudioSource();
			this.ConnectAudioMixer();
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


		private void ConnectAudioSource()
		{
			this.startButton.onClick.AddListener(
				this.buttonPushSound.Play
			);


			this.rankingButton.onClick.AddListener(
				this.buttonPushSound.Play
			);


			this.exitButton.onClick.AddListener(
				this.buttonPushSound.Play
			);
		}


		private void ConnectAudioMixer()
		{
			this.soundSlider.onValueChanged.AddListener(
				(value)=> { this.audioMixer.SetFloat("SE", value); }
			);
		}


		private void ConnectGameManager()
		{
			this.startButton.onClick.AddListener(
				this.gameMamager.GameStart
			);
		}
	}
}