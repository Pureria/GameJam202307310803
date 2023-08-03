using UnityEngine;
using UnityEngine.Events;
using GJ.Ranking;


namespace GJ
{
    public class Timer : MonoBehaviour
    {
        private float startTime;
        private float time;
        private bool isCount;


        [SerializeField] private UnityEvent<float> onTimerStop = new UnityEvent<float>();
        [SerializeField] private UnityEvent<float> onNewRecord = new UnityEvent<float>();


        public float Time
        {
            get { return this.time; }
        }


        public UnityEvent<float> OnTimerStop
        {
            get { return this.onTimerStop; }
        }


        public UnityEvent<float> OnNewRecord
        {
            get { return this.onNewRecord; }
        }


        private void Awake()
        {
            this.time = 0f;
            this.isCount = false;
        }


        private void Update()
        {
            if (!this.isCount) return;
            var now = UnityEngine.Time.time;
            this.time = now - this.startTime;
        }


        public void StartTimer()
        {
            this.startTime = UnityEngine.Time.time;
            this.isCount = true;
        }


        public void StopTimer()
        {
            this.isCount = false;
            this.onTimerStop.Invoke(this.time);
            var newRecord = RankingModel.Instance.IsRankIn(this.time);
            if (newRecord) this.onNewRecord.Invoke(this.time);
        }


		public void ResetTimer()
		{
            this.time = 0f;
            this.isCount = false;
		}
	}
}