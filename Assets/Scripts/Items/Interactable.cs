using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Active : UnityEvent { }

public class Interactable : MonoBehaviour
{

    public float radius = 3f;

    public Active OnActive;

    private MeshRenderer render;

    //On Start
    public void Start()
    {
        render = GetComponent<MeshRenderer>();
        render.material.SetColor("_Color", Color.white);
    }

    public void Highlight()
    {
        render.material.SetColor("_Color", Color.cyan);
    }

    public void UnHighlight()
    {
        render.material.SetColor("_Color", Color.white);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
