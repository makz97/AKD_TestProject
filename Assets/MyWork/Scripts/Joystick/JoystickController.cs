using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform joystickBackground;
    [SerializeField] private RectTransform joystickHandle;
    [SerializeField] private float maxJoystickRange = 100f;

    private Vector2 inputVector;

    public float Horizontal => inputVector.x;
    public float Vertical => inputVector.y;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPosition = joystickBackground.position;
        Vector2 touchPosition = eventData.position;

        Vector2 direction = touchPosition - joystickPosition;
        float distance = Mathf.Clamp(direction.magnitude, 0, maxJoystickRange);
        Vector2 normalizedDirection = direction.normalized * distance;

        joystickHandle.position = joystickPosition + normalizedDirection;
        inputVector = normalizedDirection / maxJoystickRange;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickHandle.localPosition = Vector2.zero;
        inputVector = Vector2.zero;
    }
}