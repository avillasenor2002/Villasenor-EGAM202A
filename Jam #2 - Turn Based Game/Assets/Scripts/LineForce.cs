using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class LineForce : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float shotPower;
    [SerializeField] private float stopVelocity = .05f;
    private bool isIdle;
    private bool isAiming;
    private Rigidbody rigidbody;
    public TextMeshProUGUI ParText;
    public TextMeshProUGUI finalParText;
    public int score = 0;

    public GameObject GameEnd;
    public GameObject GameUI;
    public TextMeshProUGUI StarText;
    public int starcollect = 0;
    public ParticleSystem system;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        isAiming= false;
        lineRenderer.enabled = false;
    }

    private void Update()
    {
        if(rigidbody.velocity.magnitude < stopVelocity)
        {
            Stop();
        }

        ProcessAim();

        StarText.text = starcollect.ToString();
        if (starcollect >= 4)
        {
            GameEnd.SetActive(true);
            GameUI.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (isIdle)
        {
            isAiming = true;
        }
    }

    private void ProcessAim()
    {
        if (!isAiming || !isIdle) 
        {
            return;
        }

        Vector3? worldPoint = CastMouseClickRay();

        if (!worldPoint.HasValue)
        {
            return;
        }

        DrawLine(worldPoint.Value);

        if (Input.GetMouseButtonUp(0))
        {
            Shoot(worldPoint.Value);
        }
    }

    private void Shoot (Vector3 worldPoint) 
    {
        isAiming= false;
        lineRenderer.enabled = false;

        Vector3 horizontalWorldPoint = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);
        Vector3 direction = (horizontalWorldPoint- transform.position).normalized;
        float strength = Vector3.Distance(transform.position, horizontalWorldPoint);

        rigidbody.AddForce(direction * strength * shotPower);
        //isIdle = false;
        score++;
        ParText.text = score.ToString();
        finalParText.text = score.ToString();
    }

    private void DrawLine(Vector3 worldPoint)
    {
        Vector3[] positions = { transform.position, worldPoint};
        lineRenderer.SetPositions(positions);
        lineRenderer.enabled = true;

    }

    private void Stop()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        isIdle = true;
    }

    private Vector3? CastMouseClickRay() 
    {
        Vector3 screenMousePosFar = new Vector3
            (
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane
            );
        Vector3 screenMousePosNear = new Vector3
            (
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane
            );
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
       
        if (Physics.Raycast(worldMousePosNear,worldMousePosFar - worldMousePosNear, out hit, float.PositiveInfinity))
        {
            return hit.point;
        }
        else
        {
            return null;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            system.Play();
        }
    }
}
