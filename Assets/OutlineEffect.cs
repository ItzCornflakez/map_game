using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineEffect : MonoBehaviour
{
    public Material outlineMaterial; // Assign the outline material in the Inspector

    private Material originalMaterial;
    private bool isSelected = false;

    private void Start()
    {
        // Cache the original material of the mesh renderer
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
    }

    private void Update()
    {
        // Handle selection based on input or event
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == GetComponent<MeshCollider>())
                {
                    ToggleSelection();
                }
            }
        }
    }

    private void ToggleSelection()
    {
        isSelected = !isSelected;

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (isSelected)
        {
            // Apply the outline material when selected
            meshRenderer.material = outlineMaterial;
        }
        else
        {
            // Restore the original material when deselected
            meshRenderer.material = originalMaterial;
        }
    }
}
