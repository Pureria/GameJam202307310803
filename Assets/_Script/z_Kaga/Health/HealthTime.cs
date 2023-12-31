using UnityEngine;
using UnityEngine.Events;


namespace GJ.Health
{
    public class HealthTime : MonoBehaviour
    {
        [SerializeField] private float initialHealth;

        [Header("ラウンド毎のヒール秒数")]
        [SerializeField] private float roundhealTime;
        
        [Header("攻撃が当たった時に受けるダメージの秒数")]
        [SerializeField] private float damageTime;
        [SerializeField] private UnityEvent onDeath;

        [SerializeField] private float health;
        public float Health { get { return health; } }


        public UnityEvent OnDeath { get { return this.onDeath; } }


		private void Awake()
		{
            this.Initialize();
		}


		private void Update()
		{
            this.health -= Time.deltaTime;
            if (this.health <= 0) this.onDeath.Invoke();
        }


        public void Initialize()
        {
            this.health = this.initialHealth;
        }


		public void Damage()
        {
            this.health -= this.damageTime;
            if (this.health <= 0) this.onDeath.Invoke();
        }


        public void Heal()
        {
            this.health += this.roundhealTime;
        }
    }
}