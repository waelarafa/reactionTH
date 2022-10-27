using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuivre : MonoBehaviour
{
    public GameObject blue;
    public GameObject green;

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
        if(other.tag == "fire")
        {
            transform.parent = null;
            transform.position = other.transform.position;
            animator = transform.GetComponent<Animator>();
            animator.enabled = true;
            if(other.name == "hologram")
            {
                StartCoroutine(Blue());

            }
            else if (other.name =="hologram2")
            {
                StartCoroutine(Green());
            }
        }

      
    }

    IEnumerator Blue()
    {
        yield return new WaitForSeconds(2f);
        blue.SetActive(true);
        animator.enabled = false;
    }


    IEnumerator Green()
    {
        yield return new WaitForSeconds(2f);
        green.SetActive(true);
        animator.enabled = false;
    }


}
