using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Material))]
[RequireComponent(typeof(MeshRenderer))]
public class SelectionHighlight : MonoBehaviour
{
	private Material materialToHighlight;
	private MeshRenderer renderer;
	private MaterialPropertyBlock materialPropertyBlockHighlighted;
	private MaterialPropertyBlock materialPropertyBlockNotHighlighted;

	public void SetHighlight(bool isActive)
	{
		if (isActive)
		{
			renderer.SetPropertyBlock(materialPropertyBlockHighlighted);
		}
		else
		{
			renderer.SetPropertyBlock(materialPropertyBlockNotHighlighted);
		}
	}

	private void Start()
    {
		materialToHighlight = gameObject.GetComponent<Material>();
		renderer = gameObject.GetComponent<MeshRenderer>();
		materialPropertyBlockHighlighted = new MaterialPropertyBlock();
		materialPropertyBlockNotHighlighted = new MaterialPropertyBlock();
		materialPropertyBlockHighlighted.SetFloat("_isToggled", 1);
		materialPropertyBlockNotHighlighted.SetFloat("_isToggled", 0);
	}

    private void Update()
    {
        
	}
}
