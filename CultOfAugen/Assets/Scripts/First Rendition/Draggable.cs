using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

    Transform parent_to_return_to = null;

    public void OnBeginDrag(PointerEventData eventData) {
        //Debug.Log("OnBeginDrag");

        parent_to_return_to = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

    }

    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");

        this.transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData) {
        //Debug.Log("OnEndDrag");
        this.transform.SetParent(parent_to_return_to);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Triggered");
        Debug.Log("Tag: " + other.transform.tag);
        if (other.transform.tag == "Hand") Debug.Log("damn");
    }


}
