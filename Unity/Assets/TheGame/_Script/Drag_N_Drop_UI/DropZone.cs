using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    // Variable to get access to the object dragged and change its parent
    Draggable d;

    // Called when the pointer of the mouse enters
    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    // Called when the pointer of the mouse leaves
    public void OnPointerExit(PointerEventData eventData)
    {
    }

    // Called when something is dropped
    public void OnDrop(PointerEventData eventData)
    {
        d = eventData.pointerDrag.GetComponent<Draggable>();

        if (d != null)
            d.ParentToReturnTo = this.transform;
    }
}
