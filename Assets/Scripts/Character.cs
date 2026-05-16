using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour, IPointerClickHandler
{
    public string characterName = "Postac";

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Kliknieto: " + characterName);
    }
}