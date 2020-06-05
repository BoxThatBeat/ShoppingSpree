using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, ISubmitHandler, IMoveHandler, IPointerClickHandler, IPointerEnterHandler
{
    //UI Events
    public void OnSubmit(BaseEventData eventData)
    {
        EventSystemGame.current.PlaySound("Click");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        EventSystemGame.current.PlaySound("Click");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EventSystemGame.current.PlaySound("Swap");
    }

    public void OnMove(AxisEventData eventData)
    {
        EventSystemGame.current.PlaySound("Swap");
        /*
        if (eventData.moveVector.y < 0)
            EventSystemGame.current.PlaySound("SwapDown");
        else
        {
            EventSystemGame.current.PlaySound("SwapUp");
        }
        */
    }
}
