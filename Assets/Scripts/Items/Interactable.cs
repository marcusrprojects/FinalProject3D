using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Active : UnityEvent { }

public class Interactable : MonoBehaviour
{

    public float radius = 3f;
    public float clickRadius = 3f;

    public Active OnActive;

    private MeshRenderer render;

    private Color baseColor = Color.white;

    private bool lastHit = false;

    //On Start
    private void Start()
    {
        render = GetComponent<MeshRenderer>();
        render.material.SetColor("_Color", baseColor);
    }

    private void Update()
    {
        Vector3 playerPos = MouseLook.instance.transform.position;
        float distance = Vector3.Distance(playerPos, transform.position);
        bool isHit = distance <= radius;
        if (!lastHit && isHit)
        {
            baseColor = Color.red;
            render.material.SetColor("_Color", baseColor);
            lastHit = true;
        }
        else if (lastHit && !isHit)
        {
            baseColor = Color.white;
            render.material.SetColor("_Color", baseColor);
            lastHit = false;
        }
    }

    public void Highlight()
    {
        render.material.SetColor("_Color", Color.cyan);
    }

    public void UnHighlight()
    {
        render.material.SetColor("_Color", baseColor);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, clickRadius);
    }

}