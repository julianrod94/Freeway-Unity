using UnityEngine;

namespace Standard_Assets {
	public class PlayerCrashing : MonoBehaviour {
	
		public float TimeLeft;
		
		void Start () {
			TimeLeft = GameConstants.Crash.Time;
			transform.Rotate(0,0,90);
		}
	
		// Update is called once per frame
		void Update () {
			if (TimeLeft > 0) {
				transform.Translate(0,GameConstants.Crash.Speed,0,Space.World);
				var newY = Mathf.Clamp(transform.position.y,
					GameConstants.Controlable.LowerBound,
					GameConstants.Controlable.UpperBound);
				transform.position = new Vector3(transform.position.x, newY, transform.position.z);
				transform.Rotate(Vector3.up, GameConstants.Crash.RotationSpeed);
			} else {
				gameObject.GetComponent<PlayerController>().CanControl = true;
				transform.rotation = Quaternion.identity;
				Destroy(this);
			}
		
			TimeLeft -= Time.deltaTime;
		}

		public void AddTime() {
			TimeLeft = GameConstants.Crash.Time;
		}
	}
}
