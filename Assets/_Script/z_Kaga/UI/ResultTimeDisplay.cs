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

        [Space]
        [Header("空データの表示設定")]
        [SerializeField] private string emptyLabelText;
        [SerializeField] private string emptyTimeText;


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


        public string Label
        {
            get { return this.labelText; }
            set
            {
                this.labelText = value;
                this.label.text = value;
            }
        }


        // 空データを表示するためのメソッド.
        // まだ記録がない場合に使用する.
        public void SetEmpty()
        {
            this.Label = this.emptyLabelText;
            this.value.text = this.emptyTimeText;
        }
    }
}