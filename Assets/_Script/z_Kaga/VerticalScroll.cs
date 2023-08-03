using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GJ
{
    public class VerticalScroll : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float spriteHeight;


		private void FixedUpdate()
		{
			var pos = this.transform.position + new Vector3(0, this.speed, 0);
			this.transform.position = pos;

			if (this.spriteHeight <= this.transform.position.y)
			{
				var z = this.transform.position.z;
				var y = -this.spriteHeight;
				this.transform.position = new Vector3(0, y, z);
			}
		}
	}
}