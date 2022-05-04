using UnityEngine;

public class FakeMatrix: MonoBehaviour
{
    private void Awake()
    {
        AudioManager.instance.Play("Main Menu");
    }

    public void TestAction()
    {
        Debug.Log("I am a fake matrix!");
    }
}
