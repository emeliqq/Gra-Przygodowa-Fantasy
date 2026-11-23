
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public string cardName = "Karta";

    [Header("Latarka")]
    [SerializeField] private Sprite chargedFlashlightSprite;

    private Vector3 startPosition;
    private CanvasGroup canvasGroup;
    private Image cardImage;

    private bool wasUsed = false;
    private bool isCharged = false;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        cardImage = GetComponent<Image>();

        if (cardName == "Card_Map" && GameState.MapUsed)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;

        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = true;
        }

        if (wasUsed)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = startPosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (cardName != "Card_Flashlight" || isCharged)
            return;

        Card draggedCard = eventData.pointerDrag.GetComponent<Card>();

        if (draggedCard == null)
            return;

        if (draggedCard.cardName == "Card_Battery")
        {
            ChargeFlashlight(draggedCard);
        }
    }

    private void ChargeFlashlight(Card batteryCard)
    {
        if (chargedFlashlightSprite == null)
        {
            Debug.LogWarning("Nie przypisano grafiki naładowanej latarki!");
            return;
        }

        if (cardImage == null)
        {
            Debug.LogWarning("Nie znaleziono komponentu Image na karcie latarki!");
            return;
        }

        cardImage.sprite = chargedFlashlightSprite;

        isCharged = true;
        batteryCard.MarkAsUsed();

        Debug.Log("Latarka została naładowana baterią!");
    }

    public void MarkAsUsed()
    {
        wasUsed = true;
    }
}
