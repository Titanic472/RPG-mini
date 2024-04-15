using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public bool CameraMoveEnabled = false;
    public float speed;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    public Vector2 ReturnPosition;

    void Start(){
        speed = 0.21f;
        //maxPosition = new Vector2(6.2f, 15.16f);
        //minPosition = new Vector2(-14.3f, -13.2f);
        ReturnPosition = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && CameraMoveEnabled)
        {
            float horizontal = -Input.GetAxis("Mouse X");
            float vertical = -Input.GetAxis("Mouse Y");

            transform.position -= new Vector3(horizontal, vertical, 0) * speed;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x), Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y),0);
        }
    }
    public void CameraReset(){
        CameraMoveEnabled = false;
        transform.position = ReturnPosition;
    }

    public void EnableMove(){ //WHY UNITY CAN'T CHANGE BOOL VALUE???
        CameraMoveEnabled = true;
    }
}
