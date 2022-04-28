using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made using this tutorial: https://www.youtube.com/watch?v=_QajrabyTJc

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    private float xRotation = 0f;

    [SerializeField] Transform playerBody;

    private Interactable focus;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

        bool isHit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

        if (isHit)
        {
            Interactable found = hit.collider.GetComponent<Interactable>();
            if (found != null)
            {
                if(hit.distance <= found.radius)
                {
                    if (focus != null)
                    {
                        focus.UnHighlight();
                    }
                    focus = found;
                    focus.Highlight();
                }
                else
                {
                    if (focus != null)
                    {
                        focus.UnHighlight();
                    }
                    focus = null;
                }
            }
        }
        else
        {
            if (focus != null)
            {
                focus.UnHighlight();
            }
            focus = null;
        }
        
    }
}
