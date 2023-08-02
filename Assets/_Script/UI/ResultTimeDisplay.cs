using UnityEngine;
using UnityEngine.UI;


namespace GJ.UI
{
    public class ResultTimeDisplay : MonoBehaviour
    {
        [Header("ラベルの設定")]
        [SerializeField] private Text label;
        [SerializeField] private string labelText;

        [Space]
        [Header("タイム表示の設定")]
        [SerializeField] private Text value;
        [SerializeField] private string formatString;

        private float seconds;


        public float Time
        {
            get { return this.seconds; }
            set
            {
                this.seconds = value;
                this.value.text = this.seconds.ToString(formatString);
            }
        }


        private void Start()
        {
            this.label.text = labelText;

            // デバッグ用に初期値として適当な小数を入れてます.
            this.Time = Mathf.PI;
        }
    }
}