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

        if (card != null)
        {
            Debug.Log(characterName + " otrzymal karte: " + card.cardName);
        }
    }
}