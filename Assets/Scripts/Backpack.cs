using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Backpack : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] cardsToUnlock; 

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (GameObject card in cardsToUnlock)
        {
            card.SetActive(true);
        }
        
        gameObject.SetActive(false);
    }
}