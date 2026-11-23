
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RoomLighting : MonoBehaviour, IDropHandler
{
    [SerializeField] private string roomId = "L01_S02";
    [SerializeField] private Color darkColor = new Color(0.12f, 0.04f, 0.04f, 1f);
    [SerializeField] private Color brightColor = Color.white;

    private Image roomImage;

    private void Start()
    {
        roomImage = GetComponent<Image>();
        UpdateRoomAppearance();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag.GetComponent<Card>();

        if (card == null)
            return;

        if (card.cardName != "Card_Flashlight" || !card.IsCharged)
            return;

        if (GameState.IsRoomLit(roomId))
            return;

        GameState.LightRoom(roomId);
        card.UseFlashlight();
        UpdateRoomAppearance();
    }

    private void UpdateRoomAppearance()
    {
        if (roomImage == null)
            roomImage = GetComponent<Image>();

        roomImage.color = GameState.IsRoomLit(roomId) ? brightColor : darkColor;
    }
}
