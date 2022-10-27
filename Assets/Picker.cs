using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    public GameObject picked;
    public GameObject crossHair;

    public GameObject presipit;

    public bool onSucre;

    public static Picker Instance { get; private set; }
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

    private void Start()
    {
        crossHair.transform.position = new Vector3(Screen.width / 2, Screen.height / 8, Camera.main.nearClipPlane);
    }

 
    public void Pick()
    {
        Ray screenCenter = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height/2, Camera.main.nearClipPlane));

        if (Physics.Raycast(screenCenter, out RaycastHit hitObject))
        {
            if (hitObject.transform.tag == "interactable" || hitObject.transform.tag == "endPoint" )
            {
                if (picked == null)
                {
                    picked = hitObject.transform.gameObject;
                    picked.transform.parent = Camera.main.transform;

                }
                else
                {
                    picked.transform.parent = null;
                    picked = null;
                }    

            } 
        } 
    }




}
