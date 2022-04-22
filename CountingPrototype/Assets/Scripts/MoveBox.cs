using UnityEngine;

namespace FallingDownGame
{
    public class MoveBox : MonoBehaviour
    {

        private Vector3 GetMousePosition() =>
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);

        private void OnMouseDrag()
        {
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(GetMousePosition());
            transform.position = new Vector3(objPosition.x, transform.position.y, transform.position.z);
        }

    }
}