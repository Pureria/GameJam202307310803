using UnityEngine;

namespace GJ
{
    public class Timer : MonoBehaviour
    {
        private float startTime;
        private float time;
        private bool isCount;


        public float Time
        {
            get { return this.time; }
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
        }
    }
}