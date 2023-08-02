using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace GJ.UI
{
    public class ResultTimeDisplay : MonoBehaviour
    {
        [Header("���x���̐ݒ�")]
        [SerializeField] private Text label;
        [SerializeField] private string labelText;

        [Space]
        [Header("�^�C���\���̐ݒ�")]
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

            // �f�o�b�O�p�ɏ����l�Ƃ��ēK���ȏ��������Ă܂�.
            this.Time = Mathf.PI;
        }
    }
}