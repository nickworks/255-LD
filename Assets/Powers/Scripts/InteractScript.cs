using UnityEngine;
using UnityEngine.Events;

public class InteractScript : MonoBehaviour
{
    [Header("Material Effect")]
    [Tooltip("The material affected.")]
    public Material affectedMaterial;
    [Tooltip("The default emission color.")]
    public Color defaultColor;
    [Tooltip("The emission color on mouse hover.")]
    public Color hoverColor;

    [Tooltip("The events to occur upon first click.")]
    public UnityEvent onClick;
    [Tooltip("Decides if there is an additional interaction after the first click.")]
    public bool interactionAfterFirstClick;
    [Tooltip("If there is an additional interaction, it would go here.")]
    public UnityEvent afterClick;
    private bool alreadyClicked; //This is used to detect if an interaction has already occurred.

    private void OnMouseOver()
    {
        //if interaction available, highlight.
        if (!interactionAfterFirstClick && !alreadyClicked || interactionAfterFirstClick && !alreadyClicked || interactionAfterFirstClick && alreadyClicked) affectedMaterial.SetColor("_EmissionColor", hoverColor);
        else affectedMaterial.SetColor("_EmissionColor", defaultColor);

        //if mouse down and an interaction available, do an interaction.
        if (Input.GetButtonDown("Fire1") && !alreadyClicked)
        {
            onClick.Invoke();
            alreadyClicked = true;
        }
        else if (Input.GetButtonDown("Fire1") && alreadyClicked && interactionAfterFirstClick) afterClick.Invoke();
    }

    private void OnMouseExit()
    {
        //change back to default color.
        affectedMaterial.SetColor("_EmissionColor", defaultColor);
    }
}
