
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Candle : MonoBehaviour, IDropHandler
{
    [Header("Candle Settings")]
    [SerializeField] private Image candleImage;

    [Header("Colors")]
    [SerializeField] private Color unlitColor = Color.black;
    [SerializeField] private Color litColor = Color.white;

    private bool isLit = false;

    private void Start()
    {
        if (candleImage == null)
        {
            candleImage = GetComponent<Image>();
        }

        candleImage.color = unlitColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag.GetComponent<Card>();

        if (card == null)
            return;

        if (card.cardName != "Card_Matches")
        {
            Debug.Log("Ta karta nie może zapalić świeczki!");
            return;
        }

        if (isLit)
        {
            Debug.Log("Świeczka jest już zapalona!");
            return;
        }

        LightCandle();
        card.MarkAsUsed();

        Debug.Log("Użyto zapałek - świeczka została zapalona!");
    }

    private void LightCandle()
    {
        isLit = true;
        candleImage.color = litColor;
    }
}
