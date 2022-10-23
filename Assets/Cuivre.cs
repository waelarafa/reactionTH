using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuivre : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //incase something with name cuivre collide with the holograme
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "cuivre")
        {
            other.transform.parent.transform.position = transform.position;
            animator.enabled = true;
        }
    }
}
