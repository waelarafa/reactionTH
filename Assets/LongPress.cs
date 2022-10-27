using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class LongPress : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{
    public float speed;
    public bool heldOn;
    public static LongPress Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

  
    //if button pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        heldOn = true;
        //Picker.Instance.picked.transform.Rotate(Vector3.forward * speed);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        heldOn = false;
    }
}
