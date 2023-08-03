using UnityEngine;


namespace GJ.UI
{
    public class ShowHide : MonoBehaviour
    {
        private enum State
        {
            [InspectorName("表示")] Show,
            [InspectorName("非表示")] Hide
        }


        [Header("ゲーム開始時の状態")]
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