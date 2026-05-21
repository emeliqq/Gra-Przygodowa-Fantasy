using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour, IPointerClickHandler, IDropHandler
{
    public string characterName = "Postac";

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Kliknieto: " + characterName);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag.GetComponent<Card>();
        if (card == null) return;

        switch (card.cardName)
        {
            case "Card_Map":
                Debug.Log(characterName + " patrzy na mape - odkrywa nowa lokacje!");
                break;
            default:
                Debug.Log("Ta karta nie dziala na " + characterName);
                break;
        }
    }
}