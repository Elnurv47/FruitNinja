using UnityEngine;

public class Blade : MonoBehaviour
{
    private const float MINIMUM_MOUSE_DELTA_TO_CUT = 0.08f;
    private Vector3 lastMousePosition = Vector3.zero;

    [SerializeField] private LayerMask fruitLayerMask;
    [SerializeField] private BoxCollider boxCollider;

    private void Update()
    {
        Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float mouseDelta = (currentMousePosition - lastMousePosition).magnitude;

        boxCollider.enabled = mouseDelta > MINIMUM_MOUSE_DELTA_TO_CUT;

        lastMousePosition = currentMousePosition;
    }
}
