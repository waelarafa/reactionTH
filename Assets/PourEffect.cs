using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourEffect : MonoBehaviour
{
    public int pourThreshol = 45;
    public Transform origin = null;
    public GameObject streamPrefab = null;

    private bool isPouring = false;
    private Stream currentStream = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool pourCheck = CalculatePourAngle() < pourThreshol;
        
        if(isPouring != pourCheck)
        {
            isPouring = pourCheck; 

            if(isPouring)
            {
                StartPour();
            }else
            {
                EndPour();
            }
        }
    }

    private void StartPour()
    {

        if (currentStream != null)
            return;

        currentStream = CreateStream();
        currentStream.Begin();
    }
    private void EndPour()
    {
        currentStream.End();
        currentStream = null;
    }

    private float CalculatePourAngle()
    {
        return transform.up.y * Mathf.Rad2Deg;
    }

    private Stream CreateStream ()
    {
        GameObject streamObject = Instantiate(streamPrefab,origin.position,Quaternion.identity,transform);
        return streamObject.GetComponent<Stream>();
    }
}
