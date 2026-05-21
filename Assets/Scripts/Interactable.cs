using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerClickHandler, IDropHandler
{
    public string objectName = "Obiekt";

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Kliknieto: " + objectName);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag.GetComponent<Card>();
        if (card == null) return;

        Debug.Log(objectName + " otrzymal karte: " + card.cardName);
    }
}