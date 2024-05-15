using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PavleM.RDI.RTS
{
    public class CameraSelection : MonoBehaviour
    {
        public static Camera playerCamera;

        // Za proveru klika VS prevlačenja
        private Vector2 startClickPosition;

        // Prevlačenje manje od ove dužine -> nije prevlačenje nego klik
        private float minimumDragDistance = 80;

        public static SelectionContainer currentSelectionContainer { get; private set; }

        private SelectionRay selectionRay;
        private SelectionBox selectionBox;

        public LayerMask selectableLayerMask; // Zbog nekog razloga mora da se u Editoru obeleže i Troop i Building layer mask, samo Selectable koji je njihov roditelj nije dovoljan.

        #region Cached selection containers
        public readonly EmptySelectionContainer emptySelectionContainer = new EmptySelectionContainer();
        public readonly TroopSelectionContainer troopSelectionContainer = new TroopSelectionContainer();
        public readonly BuildingSelectionContainer buildingSelectionContainer = new BuildingSelectionContainer();
        #endregion

        public RectTransform hotbarTransform; // To detect clicks on it

        public void SetSelectionContainer(SelectionContainer selectionContainer)
        {
            currentSelectionContainer?.OnContainerExit(this);
            currentSelectionContainer = selectionContainer;
            currentSelectionContainer.OnContainerEnter(this);
        }

        private void Start()
        {
            playerCamera = Camera.main;

            selectionRay = new SelectionRay(selectableLayerMask);
            selectionBox = new SelectionBox(boxTransform: GetComponent<RectTransform>(), 
                                            boxGFX: GetComponent<Image>(),
                                            hotbarTransform: hotbarTransform);

            SetSelectionContainer(emptySelectionContainer);
        }

        private void Update()
        {
            if (IsLeftClickUpOrDown() && IsMouseOverHotbar())
                return;

            if (IsLeftClickDown())
                startClickPosition = Input.mousePosition;

            if (IsLeftClickUp())
            {
                if (MouseClickOccurred())
                    HandleMouseClick();

                if (MouseDragOccurred())
                    HandleMouseDrag();
            }

            selectionBox.UpdateGFX(startClickPosition: startClickPosition);
        }

        /*private bool IsMouseOverUI() // Beskorisno jer uvek klikće na UI zbog selectionBox GFX
            => (EventSystem.current.IsPointerOverGameObject());*/

        private bool IsLeftClickUpOrDown()
            => IsLeftClickDown() || IsLeftClickUp();

        private bool IsMouseOverHotbar()
        {
            Vector2 mousePosition = Input.mousePosition;

            if (RectTransformUtility.RectangleContainsScreenPoint(hotbarTransform, mousePosition))
                return true;

            return false;
        }

        private bool IsLeftClickDown()
            => Input.GetMouseButtonDown(0);

        private bool IsLeftClickUp()
            => Input.GetMouseButtonUp(0);
                                                            
        private bool MouseClickOccurred()
            => (Vector3.Distance(Input.mousePosition, startClickPosition) < minimumDragDistance);

        private bool MouseDragOccurred()
            => (Vector3.Distance(Input.mousePosition, startClickPosition) >= minimumDragDistance);

        private void HandleMouseClick()
        {
            var selected = selectionRay.GetISelectableInRay();

            currentSelectionContainer.Update(selected, context: this);
        }

        private void HandleMouseDrag()
        {
            var selected = selectionBox.GetTroopsInSelectionBox(startClickPosition);

            currentSelectionContainer.Update(selected, context: this);
        }
    }
}
