
using UnityEngine;
using UnityEngine.EventSystems;

public class Backpack : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] cardsToUnlock;

    void Start()
    {
        if (GameState.BackpackOpened)
        {
            foreach (GameObject cardObject in cardsToUnlock)
            {
                Card card = cardObject.GetComponent<Card>();

                if (card != null && card.cardName == "Card_Map" && GameState.MapUsed)
                    continue;

                cardObject.SetActive(true);
            }

            gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameState.OpenBackpack();

        foreach (GameObject card in cardsToUnlock)
        {
            Card cardComponent = card.GetComponent<Card>();

            if (cardComponent != null && cardComponent.cardName == "Card_Map" && GameState.MapUsed)
                continue;

            card.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
