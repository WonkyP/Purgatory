using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    // A variable to store the parent which the card must return if it isn't dropped in a correct place
    private Transform parentToReturnTo;
    public Transform ParentToReturnTo { get { return this.parentToReturnTo; } set { this.parentToReturnTo = value; } }

    // A variable to unlock and lock the raycasts when dragging and object
    private CanvasGroup canvasGroup;

    // Variable to store the offset when we click an object form every point
    private Vector2 offset;


    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Called when the object starts to being dragged
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Calculations
        offset.x = this.transform.position.x - eventData.position.x;
        offset.y = this.transform.position.y - eventData.position.y;

        // We update the parent which the object must return to
        parentToReturnTo = this.transform.parent;

        // We change the parent of the object
        this.transform.SetParent(this.transform.parent.parent);

        // We set the raycast free
        canvasGroup.blocksRaycasts = false;
    }

    // Called when the object is being dragged
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position + offset;
    }

    // Called when the object finishes of being dragged
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);

        // We block the raycast
        canvasGroup.blocksRaycasts = true;
    }
}
