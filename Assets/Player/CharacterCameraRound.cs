using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class CharacterCameraRound : MonoBehaviour
{
    public float sensivilty;
    public Transform target;

    private Vector3 mouseDelta = Vector3.zero;
    private Vector3 amount = Vector3.zero;

    private RaycastHit hit;
    private float hitDistance=0;

    private float tanFOV;

    private Camera cam;
    private Vector3 lookAt=Vector3.zero;
    
    Vector3 cameraPosition=Vector3.zero;
    private Vector3 cameraPositionNotOcc = Vector3.zero;
    private Quaternion cameraRotation = Quaternion.identity;

    private Vector3 centroPantalla=Vector3.zero;
    private Vector3 up = Vector3.zero;
    private Vector3 right = Vector3.zero;

    private Vector3[] esquinas = new Vector3[5];
    
    Vector3 camPos= Vector3.zero;
    public Vector3 addPoss = new Vector3(0, 1.63f, 0);

    public Vector3 dirPos = Vector3.zero;
    
    Quaternion q = Quaternion.identity;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        cam = gameObject.GetComponent<Camera>();

        float halfFOV = cam.fieldOfView * 0.5f * Mathf.Deg2Rad;
        tanFOV = Mathf.Tan(halfFOV) * cam.nearClipPlane;
    }

    private void Update()
    {
        centroPantalla= (cameraRotation * Vector3.forward) *cam.nearClipPlane;
        up= (cameraRotation * Vector3.up) *tanFOV;
        right = (cameraRotation * Vector3.right) * tanFOV * cam.aspect;

        esquinas[0]= cameraPosition + centroPantalla - up + right;
        esquinas[1]= cameraPosition + centroPantalla + up - right;
        esquinas[2]= cameraPosition + centroPantalla + up + right;
        esquinas[3]=  cameraPosition + centroPantalla - up - right;
        esquinas[4]= cameraPosition + centroPantalla;

        hitDistance = 1000000;
        for (int i = 0; i < 5; i++) {
            if (Physics.Linecast(target.transform.position+ addPoss,esquinas[i], out hit))
            {
                Debug.DrawLine(target.transform.position + addPoss, esquinas[i], Color.red);
                Debug.DrawRay(hit.point,Vector3.up * 0.5f,Color.white);
                hitDistance = Mathf.Min(hitDistance, hit.distance);
            }else{
                Debug.DrawLine(target.transform.position + addPoss, esquinas[i], Color.blue);
            }
        }

        if (hitDistance>999999)
        {
            hitDistance = 0;
        }

    }

    void LateUpdate()
    {
        mouseDelta.Set( Input.GetAxisRaw("Mouse X"),
            Input.GetAxisRaw("Mouse Y"),
            Input.GetAxisRaw("Mouse ScrollWheel")*10f
            );
        amount += -mouseDelta * sensivilty;
        amount.z = Mathf.Clamp(amount.z, 50, 100);
        amount.y = Mathf.Clamp(amount.y, 10, 89);

        cameraRotation = Quaternion.AngleAxis(-amount.x, Vector3.up) *
                         Quaternion.AngleAxis(amount.y, Vector3.right);

        lookAt = cameraRotation * Vector3.forward;

        cameraPosition = target.transform.position + addPoss - lookAt * amount.z * 0.1f;

        cameraPositionNotOcc = target.transform.position + addPoss - lookAt * hitDistance;

        if (hitDistance< cam.nearClipPlane*2.5f)
        {
            cameraPositionNotOcc -= lookAt * cam.nearClipPlane;
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation,cameraRotation, Time.deltaTime * 10.0f);

        if (hitDistance > 0)
        {
            transform.position = Vector3.Lerp(transform.position, cameraPositionNotOcc, Time.deltaTime * 10.0f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime * 10.0f);
        }
    }
}
