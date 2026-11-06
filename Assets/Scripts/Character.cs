
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour, IPointerClickHandler, IDropHandler
{
    public string characterName = "Postac";
    public GameObject mapButton;

    void Start()
    {
        if (mapButton != null)
        {
            mapButton.SetActive(GameState.MapUsed);
        }
    }

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

                if (GameState.MapUsed) return;

                Debug.Log(characterName + " uzywa mapy - odkrywa nowa lokacje!");

                GameState.UseMap();
                card.MarkAsUsed();

                if (mapButton != null)
                {
                    mapButton.SetActive(true);
                }

                break;

            default:
                Debug.Log("Ta karta nie dziala na " + characterName);
                break;
        }
    }
}
