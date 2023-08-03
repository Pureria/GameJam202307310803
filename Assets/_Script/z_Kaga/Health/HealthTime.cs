using UnityEngine;
using UnityEngine.Events;


namespace GJ.Health
{
    public class HealthTime : MonoBehaviour
    {
        [SerializeField] private float initialHealth;

        [Header("���E���h���̃q�[���b��")]
        [SerializeField] private float roundhealTime;
        
        [Header("�U���������������Ɏ󂯂�_���[�W�̕b��")]
        [SerializeField] private float damageTime;
        [SerializeField] private UnityEvent onDeath;

        [SerializeField] private float health;


        public UnityEvent OnDeath { get { return this.onDeath; } }


		private void Awake()
		{
            this.health = this.initialHealth;
		}


		private void Update()
		{
            this.health -= Time.deltaTime;
            if (this.health <= 0) this.onDeath.Invoke();
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