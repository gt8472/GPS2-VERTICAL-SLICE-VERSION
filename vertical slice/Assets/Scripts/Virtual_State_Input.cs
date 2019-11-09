using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Imports the interfaces needed to interact with the EventSystem

public class Virtual_State_Input : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [Range(10f, 100f)] public float sensitivity;
    public bool resetOnRelease = true;

    private Vector3 initPos = Vector3.zero;
    private Vector3 initClickOffset = Vector3.zero;
    private Vector3 magnitude = Vector3.zero;
    public Vector3 Direction { get; private set; } = Vector3.zero; // Allow other scripts to read but not write
    public Vector3 Magnitude => magnitude;


    void Start()
    {
        initPos = this.transform.position ;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = (Vector3)eventData.position - initClickOffset;
        Direction = transform.position - initPos;

        magnitude = Direction;
        magnitude.x = Mathf.Abs(magnitude.x / (float)Screen.width * sensitivity);
        magnitude.y = Mathf.Abs(magnitude.y / (float)Screen.height * sensitivity);

        Direction = Direction.normalized; // Normalize to a range of -1 to 1
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = initPos;
        if (resetOnRelease) Direction = Vector3.zero;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initClickOffset = (Vector3)eventData.position - initPos;
    }
}
