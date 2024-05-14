using UnityEngine;

namespace PavleM.RSIM.Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float movementTime = 5f;
        [SerializeField] private float movementMultiplier = 2;
        [SerializeField] private float borderThreshold = 15f; // Threshold za ivice ekrana

        [SerializeField] private float zoomAmount = 4;
        [SerializeField] private float zoomTime = 30f;
        [SerializeField] private float minZoomRadius = 5;
        [SerializeField] private float maxZoomRadius = 12;

        private UnityEngine.Camera cam;

        private void Awake()
            => cam = GetComponent<UnityEngine.Camera>();

        private void Update()
        {
            if (!Application.isEditor)
                UpdateMovement(GetMouseInput());
            UpdateMovement(GetKeyboardInput());
            
            UpdateZoom();

            /*if (Input.GetKeyDown(KeyCode.H))
                Debug.Log("Mouse position y: " + Input.mousePosition.y +
                          "Horizontal raw axis: " + Input.GetAxisRaw("Horizontal") +
                          "Vertical raw axis: " + Input.GetAxisRaw("Vertical"));*/
        }

        private Vector2 GetMouseInput()
        {
            Vector2 movementVector = new Vector2();

            if (IsOnLeftBorder())
                movementVector.x = -1;
            if (IsOnRightBorder())
                movementVector.x = 1;
            if (IsOnBottomBorder())
                movementVector.y = -1;
            if (IsOnTopBorder())
                movementVector.y = 1;

            return movementVector;
        }

        private Vector2 GetKeyboardInput()
            => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        private bool IsOnLeftBorder()
            => Input.mousePosition.x < borderThreshold;
        private bool IsOnRightBorder()
            => Input.mousePosition.x > Screen.width - borderThreshold;
        private bool IsOnBottomBorder()
            => Input.mousePosition.y < borderThreshold;
        private bool IsOnTopBorder()
            => Input.mousePosition.y > Screen.height - borderThreshold;

        private void UpdateMovement(Vector2 movementVector)
        {
            Vector2 cameraMovementVector = 
                (transform.up * movementVector.y + transform.right * movementVector.x).normalized;

            cameraMovementVector *= movementMultiplier;

            transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + cameraMovementVector.x, Time.deltaTime * movementTime),
                                             Mathf.Lerp(transform.position.y, transform.position.y + cameraMovementVector.y, Time.deltaTime * movementTime),
                                             -1);
        }
        
        private void UpdateZoom()
        {
            if (IsScrollingUp() && CanZoomIn())
                cam.orthographicSize -= zoomAmount;
            if (IsScrollingDown() && CanZoomOut())
                cam.orthographicSize += zoomAmount;
        }

        // Ako je poluprečnik² veći od najmanjeg mogućeg², znači jošuvek možemo da ga smanjimo tj. da zumiramo
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
