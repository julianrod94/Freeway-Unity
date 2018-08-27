using System.Collections;
using System.Collections.Generic;
using Standard_Assets.Scripts;
using UnityEngine;

namespace Standard_Assets.Scripts {

    public class NormalAxis : AxisProvider {
        public float GetAxis(string axis) {
            return Input.GetAxis(axis);
        }
    }
}
