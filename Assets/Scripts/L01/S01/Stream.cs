
using UnityEngine;
using UnityEngine.EventSystems;

public class Stream : MonoBehaviour, IDropHandler
{
    [Header("Character")]
    public Animator characterAnimator;

    public void OnDrop(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag.GetComponent<Card>();

        if (card == null)
            return;

        switch (card.cardName)
        {
            case "Card_Filter":
                if (GameState.FilterUsed)
                    return;

                GameState.UseFilter();
                characterAnimator.SetTrigger("UseFilter");
                card.MarkAsUsed();

                Debug.Log("Uzywasz filtra - woda jest bezpieczna!");
                break;

                case "Card_Bottle":
                    if (GameState.BottleChosen)
                        return;

                    GameState.ChooseBottle();
                    characterAnimator.SetTrigger("CollectWater");
                    card.MarkAsUsed();

                    Debug.Log("Wypelniasz butelke - przydatna pozniej!");
                    break;

            default:
                Debug.Log("Ta karta nie dziala na strumien.");
                break;
        }
    }
}
