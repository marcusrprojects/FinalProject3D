using UnityEngine;
using UnityEngine.UI;

public class PhotoCanvas : MonoBehaviour
{

    [SerializeField] Button backButton;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape))
        {
            backButton.onClick.Invoke();
        }
    }
}
