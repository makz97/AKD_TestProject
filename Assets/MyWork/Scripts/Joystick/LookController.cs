using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LookController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float sensitivity = 2f;

    private Vector2 rotation;
    private Vector2 lastPosition;

    private void Start()
    {
        rotation = playerTransform.localRotation.eulerAngles;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        lastPosition = eventData.position;
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var touchPosition = eventData.position;
        var direction = touchPosition - lastPosition;

        rotation += direction * sensitivity;

        playerTransform.localRotation = Quaternion.Euler(rotation.y, -rotation.x, 0);
        lastPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        lastPosition = eventData.position;
    }
}