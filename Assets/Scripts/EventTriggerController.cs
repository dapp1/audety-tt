using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class EventTriggerController : MonoBehaviour
{
    public bool pointerDown;

    public void SetScale(float scale)
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector2(scale, -scale);
    }

    public void SetBool(bool isDown)
    {
        pointerDown = isDown;
    }
}
