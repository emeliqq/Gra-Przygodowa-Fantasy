using UnityEngine;
using UnityEngine.EventSystems;

public class Stream : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag.GetComponent<Card>();
        if (card == null) return;

        switch (card.cardName)
        {
            case "Card_Filter":
                Debug.Log("Uzywasz filtra - woda jest bezpieczna!");
                break;
            case "Card_Bottle":
                Debug.Log("Wypelniasz butelke - przydatna pozniej!");
                break;
            default:
                Debug.Log("Ta karta nie dziala na strumien.");
                break;
        }
    }
}