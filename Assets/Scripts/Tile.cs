using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _accessColor;
    [SerializeField] private Color _colorBan;

    private List<Material> _materials;

    private void Awake()
    {
        var renderers = GetComponentsInChildren<MeshRenderer>();
        _materials = new List<Material>();
        
        foreach (var meshRenderer in renderers)
        {
            _materials.Add(meshRenderer.material);
        }
    }

    public void SetColor(bool isAvailable)
    {
        if (isAvailable)
        {
            foreach (var material in _materials)
            {
                material.color = _accessColor;
            }
        }
        else
        {
            foreach (var material in _materials)
            {
                material.color = _colorBan;
            }
        }
    }

    public void ResetColor()
    {
        foreach (var material in _materials)
        {
            material.color = Color.white;
        }
    }
}
