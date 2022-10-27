using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 targetPosition = Vector3.zero;
    private ParticleSystem splashParticle = null;
    private Coroutine pourRoutine;

    public GameObject endObject;
    public bool OnEndPoint;

    public static Stream Instance { get; private set; }
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

        lineRenderer = GetComponent<LineRenderer>();
        splashParticle = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        MoveToPosition(0, transform.position);
        MoveToPosition(1, transform.position);
    }

    public void Begin()
    {
        StartCoroutine(UpdateParticale());
        pourRoutine = StartCoroutine(BeginPour());
    }

    private IEnumerator BeginPour()
    {
        while (gameObject.activeSelf)
        {
            targetPosition = FindEndPoint(out endObject);

            if(endObject.gameObject.tag == "endPoint")
            {
                OnEndPoint = true;
            }
            else
            {
                OnEndPoint = false;
            }

            MoveToPosition(0,transform.position);
            AnimateToPosition(1,targetPosition);

            yield return null;
        } 
     
    }

    public void End()
    {
        StopCoroutine(pourRoutine);
        pourRoutine = StartCoroutine(EndPour());
    }

    IEnumerator EndPour()
    {
        while (!HasReachedPosition(0,targetPosition))
        {
            AnimateToPosition(0,targetPosition);
            AnimateToPosition(1, targetPosition);
            yield return null;
        }

        Destroy(gameObject);
    }

    private Vector3 FindEndPoint(out GameObject endObject)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        Physics.Raycast(ray, out hit);
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(2.0f);

        endObject = hit.transform.gameObject;
        Picker.Instance.onSucre = true;
        return endPoint;
    }

    private void MoveToPosition(int index, Vector3 targetPosition)
    {
        lineRenderer.SetPosition(index, targetPosition);    
    }

    private void AnimateToPosition(int index, Vector3 targetPosition)
    {
        Vector3 currentPoint = lineRenderer.GetPosition(index);
        Vector3 newPosition = Vector3.MoveTowards(currentPoint, targetPosition, Time.deltaTime * 1.75f);

        lineRenderer.SetPosition(index, newPosition);
    }

    private bool HasReachedPosition(int index, Vector3 targetPosition)
    {
        Vector3 currentPosition = lineRenderer.GetPosition(index);
        return currentPosition == targetPosition;
    }

    private IEnumerator UpdateParticale()
    {
        while (gameObject.activeSelf)
        {
            splashParticle.gameObject.transform.position = targetPosition;

            bool isHitting = HasReachedPosition(1, targetPosition);
            splashParticle.gameObject.SetActive(isHitting); 

           yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
