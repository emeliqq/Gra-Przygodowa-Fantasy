
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string cardName = "Karta";

    private Vector3 startPosition;
    private CanvasGroup canvasGroup;
    private bool wasUsed = false;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (cardName == "Card_Map" && GameState.MapUsed)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (wasUsed) return;

        startPosition = transform.position;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (wasUsed) return;

        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (!wasUsed)
        {
            transform.position = startPosition;
        }
    }

    public void MarkAsUsed()
    {
        if (wasUsed) return;

        wasUsed = true;
        Destroy(gameObject);
    }
}
