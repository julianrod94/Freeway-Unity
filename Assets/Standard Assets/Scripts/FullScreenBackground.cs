using System.Collections;
using System.Collections.Generic;
using Standard_Assets;
using UnityEngine;

namespace Standard_Assets {

	public class FullScreenBackground : MonoBehaviour {

		void Start() {
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
			Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
			Vector2 scale = transform.localScale;
			Vector2 newScale = new Vector2(
				GameConstants.World.Width / spriteSize.x,
				GameConstants.World.Height / spriteSize.y
			);
			transform.localScale = newScale;
			transform.position = Vector2.zero;

			LevelManager.SetLevel(2);
		}
	}
}
