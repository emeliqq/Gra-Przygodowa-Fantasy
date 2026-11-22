
using UnityEngine;
using UnityEngine.EventSystems;

public class Backpack : MonoBehaviour, IPointerClickHandler
{
    [Header("Cards")]
    public GameObject[] cardsToUnlock;

    [Header("Character")]
    public Animator characterAnimator;

    private bool canBeCollected = false;
    private bool collected = false;

    void Start()
    {
        if (GameState.BackpackOpened)
        {
            collected = true;

            // Set character animation to backpack mode
            characterAnimator.SetBool("HasBackpack", true);

            // Restore unlocked cards
            UnlockCards();

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

        // Change character animation
        characterAnimator.SetBool("HasBackpack", true);

        // Hide backpack on the ground
        gameObject.SetActive(false);

        // Unlock cards
        UnlockCards();

        Debug.Log("Backpack collected. Character animation changed.");
    }

    private void UnlockCards()
    {
        foreach (GameObject cardObject in cardsToUnlock)
        {
            Card card = cardObject.GetComponent<Card>();

            if (card != null &&
                card.cardName == "Card_Map" &&
                GameState.MapUsed)
                continue;

            cardObject.SetActive(true);
        }
    }
}
