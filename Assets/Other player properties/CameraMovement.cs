using Unity.VisualScripting;
using UnityEngine;
 
namespace PavleM.RDI.RTS
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float movementTime = 5;
        [SerializeField] private float movementMultiplier = 2;
        [SerializeField] private float borderThreshold = 25; // Threshold za ivice ekrana

        [SerializeField] private float zoomAmount = 4;
        [SerializeField] private float minZoomRadius = 5;
        [SerializeField] private float maxZoomRadius = 12;

        private UnityEngine.Camera cam;

        private void Awake()
            => cam = GetComponent<UnityEngine.Camera>();

        private void Update()
        {
            /*if (!Application.isEditor)*/
                UpdateMovement(GetMouseInput());
            UpdateMovement(GetKeyboardInput());
            
            UpdateZoom();
        }

        private void UpdateMovement(Vector2 movementVector)
        {
            Vector2 cameraMovementVector =
                (transform.up * movementVector.y + transform.right * movementVector.x).normalized;

            cameraMovementVector *= movementMultiplier;

            transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + cameraMovementVector.x, Time.deltaTime * movementTime),
                                             Mathf.Lerp(transform.position.y, transform.position.y + cameraMovementVector.y, Time.deltaTime * movementTime),
                                             -1);
        }

        private Vector2 GetMouseInput()
        {
            Vector2 movementVector = new Vector2();

            if(IsMouseInsideGame())
            {
                if (IsOnLeftBorder())
                    movementVector.x = -1;
                if (IsOnRightBorder())
                    movementVector.x = 1;
                if (IsOnBottomBorder())
                    movementVector.y = -1;
                if (IsOnTopBorder())
                    movementVector.y = 1;
            }
            
            return movementVector;
        }

        private bool IsMouseInsideGame()
        {
            return (Input.mousePosition.x > 0 && Input.mousePosition.x < Screen.width)
                   && (Input.mousePosition.y > 0 && Input.mousePosition.y < Screen.height);
        }

        private bool IsOnLeftBorder()
            => (Input.mousePosition.x < borderThreshold);
        private bool IsOnRightBorder()
            => (Input.mousePosition.x > Screen.width - borderThreshold);
        private bool IsOnBottomBorder()
            => (Input.mousePosition.y < borderThreshold);
        private bool IsOnTopBorder()
            => (Input.mousePosition.y > Screen.height - borderThreshold);

        private Vector2 GetKeyboardInput()
            => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        private void UpdateZoom()
        {
            if (IsScrollingUp() && CanZoomIn())
                cam.orthographicSize -= zoomAmount;
            if (IsScrollingDown() && CanZoomOut())
                cam.orthographicSize += zoomAmount;
        }

        private bool CanZoomIn()
            => (cam.orthographicSize > minZoomRadius);

        private bool CanZoomOut()
            => (cam.orthographicSize < maxZoomRadius);

        private bool IsScrollingUp()
            => (Input.GetAxis("Mouse ScrollWheel") > 0f);

        private bool IsScrollingDown()
            => (Input.GetAxis("Mouse ScrollWheel") < 0f);

        public void TeleportCameraTo(Vector3 position) // Npr. klikne se hotkey da se dobaci kamera na zamak itd.
            => transform.position = position;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, minZoomRadius);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, maxZoomRadius);
        }
    }
}
