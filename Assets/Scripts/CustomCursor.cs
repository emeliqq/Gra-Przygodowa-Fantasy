using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        Cursor.SetCursor(
            cursorTexture,
            Vector2.zero,
            CursorMode.Auto
        );

        Cursor.visible = true;
    }
}