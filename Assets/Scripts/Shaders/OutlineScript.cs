using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineScript : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float outlineScaleFactor;
    [SerializeField] private Color outlineColor;
    private Renderer outlineRenderer;

    void Start()
    {
        outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);
        outlineRenderer.enabled = true;
    }
    Renderer CreateOutline(Material outlineMat, float scaleFactor, Color color)
    {
        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        Renderer rend = outlineObject.GetComponent<Renderer>();

        if(outlineObject.GetComponent<Rigidbody>() != null && outlineObject.GetComponent<ObjectPickUp>() != null && outlineObject.GetComponents<BoxCollider>() != null)
        {
            var rb = outlineObject.GetComponent<Rigidbody>();
            var pickUp = outlineObject.GetComponent<ObjectPickUp>();
            var colliders = outlineObject.GetComponents<BoxCollider>();
            Destroy(rb);
            Destroy(pickUp);
            Destroy(colliders[0]);
            Destroy(colliders[1]);
        }

        rend.material = outlineMat;
        rend.material.SetColor("_OutlineColor", color);
        rend.material.SetFloat("_Scale", scaleFactor);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        outlineObject.GetComponent<OutlineScript>().enabled = false;
        outlineObject.GetComponent<Collider>().enabled = false;

        rend.enabled = false;

        return rend;
    }
}