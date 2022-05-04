using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made using this tutorial: https://www.youtube.com/watch?v=_QajrabyTJc

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public static MouseLook instance;

    private float xRotation = 0f;

    [SerializeField] Transform playerBody;
    [SerializeField] GameObject flashlight;

    [SerializeField] GameObject crosshair;
    [SerializeField] GameObject pauseMenu;

    private Interactable focus;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(Time.timeScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.E) && focus != null)
            {
                focus.OnActive.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                flashlight.SetActive(!flashlight.activeSelf);
                AudioManager.instance.Play("Flashlight");
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
                pauseMenu.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
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
            else
            {
                if (focus != null)
                {
                    focus.UnHighlight();
                }
                focus = null;
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

    public void Pause()
    {
        Time.timeScale = 0;
        crosshair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        crosshair.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

}
