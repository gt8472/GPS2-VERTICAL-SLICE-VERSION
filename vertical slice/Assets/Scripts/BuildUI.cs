
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildUI : MonoBehaviour, IPointerClickHandler
{
    public RectTransform popup;

    public GameObject popUP;

    public void OnPointerClick(PointerEventData eventData)
    {
        popUP.SetActive(true);
        
        popup.position = eventData.position;
    }
}
