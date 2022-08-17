using UnityEngine;
using System.Collections;

public class MouseSpriteControl : MonoBehaviour
{
    public Texture2D cursorTexture;
    [SerializeField] CursorMode cursorMode = CursorMode.Auto;
    [SerializeField] Vector2 hotSpot = Vector2.zero;
    void Update()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

}