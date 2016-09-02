using UnityEngine;

namespace Aytona.UI
{
    public class CursorAnim : Global.Singleton<CursorAnim>
    {
        public Texture2D cursorImg;
        private CursorMode cursorMode = CursorMode.Auto;
        private Vector2 downPressAnim = Vector2.down * 5f;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.SetCursor(cursorImg, downPressAnim, cursorMode);
            }

            else if (Input.GetMouseButtonUp(0))
            {
                Cursor.SetCursor(cursorImg, Vector2.zero, cursorMode);
            }
        }
    }
}