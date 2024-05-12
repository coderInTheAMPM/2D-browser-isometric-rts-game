using UnityEngine;

namespace PavleM.SI.PrebivalisteS3
{
    public class SelectionRay
    {
        private LayerMask selectableLayerMask;

        public SelectionRay(LayerMask selectableLayerMask)
            => this.selectableLayerMask = selectableLayerMask;

        public Selectable GetISelectableInRay()
        {
            Ray ray = CameraSelection.playerCamera.ScreenPointToRay(Input.mousePosition);

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
