
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Backpack : MonoBehaviour, IPointerClickHandler
{
    [Header("Cards")]
    public GameObject[] cardsToUnlock;

    [Header("Character")]
    public Image characterImage;
    public Animator characterAnimator;
    public Sprite characterWithBackpackSprite;

    private bool canBeCollected = false;
    private bool collected = false;

    void Start()
    {
        if (GameState.BackpackOpened)
        {
            collected = true;

            // Stop animation and restore character appearance
            characterAnimator.enabled = false;
            characterImage.sprite = characterWithBackpackSprite;

            // Restore unlocked cards
            foreach (GameObject cardObject in cardsToUnlock)
            {
                Card card = cardObject.GetComponent<Card>();

                if (card != null &&
                    card.cardName == "Card_Map" &&
                    GameState.MapUsed)
                    continue;

                cardObject.SetActive(true);
            }

            // Hide backpack on the ground
            gameObject.SetActive(false);
        }
    }

    public void EnableInteraction()
    {
        canBeCollected = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!canBeCollected || collected)
            return;

        collected = true;

        // Save backpack collection
        GameState.OpenBackpack();

        // Stop character animation
        characterAnimator.enabled = false;

        // Change character sprite
        characterImage.sprite = characterWithBackpackSprite;

        // Hide backpack on the ground
        gameObject.SetActive(false);

        // Unlock cards
        foreach (GameObject cardObject in cardsToUnlock)
        {
            Card card = cardObject.GetComponent<Card>();

            if (card != null &&
                card.cardName == "Card_Map" &&
                GameState.MapUsed)
                continue;

            cardObject.SetActive(true);
        }

        Debug.Log("Backpack collected. Character updated.");
    }
}
