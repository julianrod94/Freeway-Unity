using System;
using UnityEngine;

namespace Standard_Assets.Scripts {

	public class TouchAxis : MonoBehaviour, AxisProvider {
		
		public TouchButton P1Up;
		public TouchButton P1Down;
		public TouchButton P2Up;
		public TouchButton P2Down;

		public float GetAxis(string axis) {
			if (axis == "P1_Vertical") {
				return (P1Up.IsPressed ? 1 : 0) + (P1Down.IsPressed ? -1 : 0);
			}
			
			if (axis == "P2_Vertical") {
				return (P2Up.IsPressed ? 1 : 0) + (P2Down.IsPressed ? -1 : 0);
			}

			throw new ArgumentException("Invalid axis");
		}
	}
}
