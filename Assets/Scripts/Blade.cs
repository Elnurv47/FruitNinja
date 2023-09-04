using UnityEngine;

public class Blade : MonoBehaviour
{
    private const float MINIMUM_MOUSE_DELTA_TO_CUT = 0.08f;
    private Vector3 lastMousePosition = Vector3.zero;

    private bool isMouseMoving;
    private bool isLeftMouseButtonHeldDown;

    private void Update()
    {
        Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(currentMousePosition.x, currentMousePosition.y, 0);
        CheckIfMouseIsMoving(currentMousePosition);
        isLeftMouseButtonHeldDown = Input.GetMouseButton(0);
    }

    private void CheckIfMouseIsMoving(Vector3 currentMousePosition)
    {
        float mouseDelta = (currentMousePosition - lastMousePosition).magnitude;
        isMouseMoving = mouseDelta > MINIMUM_MOUSE_DELTA_TO_CUT;
        lastMousePosition = currentMousePosition;
    }
    private bool CanSlice()
    {
        return isMouseMoving && isLeftMouseButtonHeldDown;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Fruit fruit))
        {
            if (CanSlice())
            {
                fruit.CreateFluidSlice();
                Destroy(fruit.gameObject);
            }
        }
    }

}
