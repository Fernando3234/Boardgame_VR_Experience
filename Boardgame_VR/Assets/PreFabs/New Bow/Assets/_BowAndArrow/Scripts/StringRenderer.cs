using UnityEngine;

[ExecuteInEditMode]
public class StringRenderer : MonoBehaviour
{
    [Header("Render Positions")]
    [SerializeField] private Transform start;
    [SerializeField] private Transform middle;
    [SerializeField] private Transform end;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        // Get the LineRenderer component
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        // While in editor, make sure the line renderer follows the bow
        if (Application.isEditor && !Application.isPlaying)
            UpdatePositions();
    }

    private void OnEnable()
    {
        // Subscribe to the before render event to update line renderer positions
        Application.onBeforeRender += UpdatePositions;
    }

    private void OnDisable()
    {
        // Unsubscribe from the before render event
        Application.onBeforeRender -= UpdatePositions;
    }

    private void UpdatePositions()
    {
        // Set the positions of the line renderer using the start, middle, and end transforms
        // The middle position is the notch attach transform
        lineRenderer.SetPositions(new Vector3[] { start.position, middle.position, end.position });
    }
}
