using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace GJ
{
    public class BossBGManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> resetTarget;
        [SerializeField] private List<UnityEvent> bossPhaseEvents;
        private static BossBGManager instance;
        private int count;


		public static BossBGManager Instance
        {
            get { return instance; }
        }


		private void Awake()
		{
            if (instance == null) instance = this;
		}


        public void Initialize()
        {
            this.count = 0;
            foreach (Transform item in this.resetTarget)
            {
                item.gameObject.SetActive(false);
            }
        }


        public void OnBossKilled()
        {
            if (this.count < this.bossPhaseEvents.Count)
            {
                Debug.Log("Death");
                this.bossPhaseEvents[this.count].Invoke();
            }
            this.count += 1;
        }

    }
}