using UnityEngine;

namespace Standard_Assets.Scripts {
    public static class ScaleAdapter {
        public static void adaptToHeight(GameObject go, float height) { 
            SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();
            Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
            Vector2 scale = go.transform.localScale;
            scale /= scale.y;
            scale *= height / spriteSize.y;
            go.transform.localScale = scale;
        }
        
        public static void AdaptToWidth(GameObject go, float width) {
            SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();
            Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
            Vector2 scale = go.transform.localScale;
            scale /= scale.x;
            scale *= width / spriteSize.x;
            go.transform.localScale = scale;
        }
    }
}