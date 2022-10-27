using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //incase something with name cuivre collide with the holograme
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "endPoint")
        {
            if(Picker.Instance.onSucre)
            {
                Picker.Instance.presipit.SetActive(true);
            }
        }
    }
}

