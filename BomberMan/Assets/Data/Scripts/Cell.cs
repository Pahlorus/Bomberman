using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool isFocus;
    public bool EditMode;
    public BoxCollider2D Collider;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (EditMode && isFocus) OnClick();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isFocus = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isFocus = false;
    }

    private void OnClick()
    {

    }
}
