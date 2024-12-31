using UnityEngine;
using UnityEngine.EventSystems;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask mask;

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, mask)) 
        {
            transform.position = raycastHit.point;
        }
    }
}
