using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ControlCharacter : MonoBehaviour
{
    private GameObject cam;
    CharacterController _controller;
    public float speed=5;
    public float gravedad;
    private Vector3 playerVelocity;
    public float caida;
    public float jumpForce;
    void Start()
    {
        cam= GameObject.FindGameObjectWithTag("MainCamera");
        _controller = GetComponent<CharacterController>();
    }
    
    void Update() {
        Vector3 fwd = transform.position - cam.transform.position;
        SaveUbicacion();
        fwd.y = 0;
        fwd.Normalize();
        if (Input.GetKey(KeyCode.W)) {
            _controller.Move(fwd * Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(fwd);
        }else if (Input.GetKey(KeyCode.S))
        {
            _controller.Move( (fwd*-1)* Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(fwd);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 derecha = transform.right;
            derecha.Normalize();
            _controller.Move( derecha* Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(fwd);
        }else if (Input.GetKey(KeyCode.A))
        {
            Vector3 izquierda = transform.right * -1;
            izquierda.Normalize();
            _controller.Move( izquierda* Time.deltaTime * speed);
            transform.rotation = Quaternion.LookRotation(fwd);
        }

        SetGravity();
        
        if (_controller.isGrounded) {
            if(Input.GetButtonDown("Jump")){
                caida = jumpForce;
                playerVelocity.y = caida;
                _controller.Move(playerVelocity * Time.deltaTime);
            }
        }
        _controller.Move(playerVelocity * Time.deltaTime);
    }

    public void SetGravity() {
        if (_controller.isGrounded) {
            caida = gravedad * Time.deltaTime;
            playerVelocity.y = caida;
        }else {
            caida += gravedad * Time.deltaTime;
            playerVelocity.y = caida;
        }
    }

    public void SaveUbicacion() {
        Character.Personaje saveGps = new Character.Personaje();
        Vector3 gps = transform.position;
        saveGps.setUbicacion(gps);
    }
}
