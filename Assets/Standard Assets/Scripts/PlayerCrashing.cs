using UnityEngine;

namespace Standard_Assets.Scripts {
	public class PlayerCrashing : MonoBehaviour {
	
		private float _timeLeft;
		
		void Start () {
			var controller = GetComponent<PlayerController>();
			var difficulty = GameManager.Instance.GetDifficulty(controller.Player);
			switch (difficulty) {
				case Difficulty.Easy:
					_timeLeft = GameConstants.Crash.Time;
					transform.Rotate(0,0,90);
					controller.SetControl(false);
					break;
				case Difficulty.Hard:
					controller.ResetPosition();
					controller.SetControl(true);
					Destroy(this);
					break;
			}

		}
	
		// Update is called once per frame
		void Update () {
			if (_timeLeft > 0) {
				transform.Translate(0,Time.deltaTime * GameConstants.Crash.Speed,0,Space.World);
				var newY = Mathf.Clamp(transform.position.y,
					GameConstants.Controlable.LowerBound,
					GameConstants.Controlable.UpperBound);
				transform.position = new Vector3(transform.position.x, newY, transform.position.z);
				transform.Rotate(Vector3.up, Time.deltaTime * GameConstants.Crash.RotationSpeed);
			} else {
				gameObject.GetComponent<PlayerController>().SetControl(true);
				transform.rotation = Quaternion.identity;
				Destroy(this);
			}
		
			_timeLeft -= Time.deltaTime;
		}

		public void AddTime() {
			_timeLeft = GameConstants.Crash.Time;
		}
	}
}
