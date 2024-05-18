using UnityEngine;

namespace PavleM.RDI.RTS
{
    public class SelectionRay
    {
        private LayerMask selectableLayerMask;

        public SelectionRay(LayerMask selectableLayerMask)
            => this.selectableLayerMask = selectableLayerMask;

        public Selectable GetISelectableInRay()
        {
            var mouseClickPositionScreenXY = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            var ray = CameraSelection.playerCamera.ScreenPointToRay(mouseClickPositionScreenXY);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, selectableLayerMask))
            {
                if (hit.collider.TryGetComponent(out Troop troop))
                    return troop;

                if (hit.collider.TryGetComponent(out Building building))
                    return building;
            }

            return null;
        }
    }
}
