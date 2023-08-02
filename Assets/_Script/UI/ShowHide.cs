using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GJ.UI
{
    public class ShowHide : MonoBehaviour
    {
        private enum State
        {
            [InspectorName("�\��")] Show,
            [InspectorName("��\��")] Hide
        }


        [Header("�Q�[���J�n���̏��")]
        [SerializeField] private State initialState;


		private void Start()
		{
            switch (this.initialState)
            {
                case State.Show:
                    this.gameObject.SetActive(true);
                    break;

                case State.Hide:
                    this.gameObject.SetActive(false);
                    break;
            }
		}


        public void Show()
        {
            this.gameObject.SetActive(true);
        }


        public void Hide()
        {
            this.gameObject.SetActive(false);
        }
	}
}