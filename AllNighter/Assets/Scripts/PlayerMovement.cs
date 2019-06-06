using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 40;

    public Rigidbody rb;
    public Camera camera;

    public bool isBehindPc = false;


    public float lookSpeed = 3;
    private Vector2 rotation = Vector2.zero;

    public Transform pcSnapPosition;
    public Transform camPlayerPos;
    public Transform camPCPos;

    public Canvas myCanvas;
    public Image cursor;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(!isBehindPc)
        {
            Move();
            Debug.Log("Move Active");
        }            
        else
        {
            PcMove();
            Debug.Log("PCMove Active");
        }
    }

    public void Look() // Look rotation (UP down is Camera) (Left right is Transform rotation)
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -15f, 15f);
        transform.eulerAngles = new Vector2(0, rotation.y) * lookSpeed;
        camera.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);
    }

    public void Move()
    {
        Look();
        camera.transform.position = camPlayerPos.position;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddRelativeForce(movement * speed);
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
    }

    public void PcMove()
    {
        camera.transform.position = camPCPos.position;
        camera.transform.rotation = camPCPos.rotation;

        this.transform.position = pcSnapPosition.position;

        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        cursor.transform.position = myCanvas.transform.TransformPoint(pos);
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        rb.useGravity = false;
    }
}
