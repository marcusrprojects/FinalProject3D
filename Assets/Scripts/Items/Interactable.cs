using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Active : UnityEvent { }

public class Interactable : MonoBehaviour
{

    public float radius = 3f;

    [SerializeField] Material[] mats;

    public Active OnActive;

    private MeshRenderer render;

    //On Start
    public void Start()
    {
        render = GetComponent<MeshRenderer>();
        render.material = mats[0];
    }

    public void Highlight()
    {
        render.material = mats[1];
    }

    public void UnHighlight()
    {
        render.material = mats[0];
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
