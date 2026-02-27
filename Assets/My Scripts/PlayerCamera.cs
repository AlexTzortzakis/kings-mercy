using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{

    public float sensitivityX = 100f;
    public float sensitivityY = 100f;

    public Transform Orientation;

    float xRotation;
    float yRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //mouse input
        float mouseX = Mouse.current.delta.x.ReadValue() * sensitivityX * Time.deltaTime;
        float mouseY = Mouse.current.delta.y.ReadValue() * sensitivityY * Time.deltaTime;
        
        xRotation -= mouseY;
        yRotation += mouseX;
        //οριο κινησης της καμερας πανω κατω
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //κινηση της καμερας
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
