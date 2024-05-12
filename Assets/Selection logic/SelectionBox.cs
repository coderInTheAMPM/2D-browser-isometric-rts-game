using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace PavleM.SI.PrebivalisteS3
{
    public class SelectionBox
    {
        private RectTransform boxTransform;
        private Image boxGFX;
        private Rect boxCollider;

        private bool IsVisible
        {
            get => boxGFX.enabled;
            set => boxGFX.enabled = value;
        }

        public SelectionBox(RectTransform boxTransform, Image boxGFX)
        {
            this.boxTransform = boxTransform;
            this.boxGFX = boxGFX;
            boxCollider = new Rect();
        }
        
        public void UpdateGFX(Vector2 startClickPosition)
        {
            UpdateBoxVisibility();
            UpdateBoxSize(startClickPosition);
        }

        public void UpdateBoxVisibility()
        {
            if (!IsVisible && IsMouseCurrentlyBeingDragged())
                IsVisible = true;

            if (IsVisible && !IsMouseCurrentlyBeingDragged())
                IsVisible = false;
        }

        private bool IsMouseCurrentlyBeingDragged()
            => Input.GetMouseButton(0);

        public void UpdateBoxSize(Vector2 startClickPosition)
        {
            // Drag lengths
            float mouseDragDeltaX = Input.mousePosition.x - startClickPosition.x;
            float mouseDragDeltaY = Input.mousePosition.y - startClickPosition.y;

            float boxWidth = Mathf.Abs(mouseDragDeltaX);
            float boxHeight = Mathf.Abs(mouseDragDeltaY);

            Vector2 boxCenter = new Vector2(startClickPosition.x + (mouseDragDeltaX / 2f), 
                                            startClickPosition.y + (mouseDragDeltaY / 2f));
            boxTransform.anchoredPosition = boxCenter;
            boxTransform.sizeDelta = new Vector2(boxWidth, boxHeight);
        }

        public List<Selectable> GetTroopsInSelectionBox(Vector2 startClickPosition)
        {
            return GetTroopsInSelectionBoxWithCorners(startClickPosition, Input.mousePosition);
        }

        public List<Selectable> GetTroopsInSelectionBoxWithCorners(Vector2 corner1, Vector2 corner2)
        {
            boxCollider.xMin = Mathf.Min(corner1.x, corner2.x);
            boxCollider.xMax = Mathf.Max(corner1.x, corner2.x);

            boxCollider.yMin = Mathf.Min(corner1.y, corner2.y);
            boxCollider.yMax = Mathf.Max(corner1.y, corner2.y);

            var allTroops = GameObject.FindObjectsOfType<Troop>().ToList();
            var selectedTroops = new List<Selectable>();

            foreach (var troop in allTroops)
            {
                var troopPositionOnScreen = CameraSelection.playerCamera.WorldToScreenPoint(troop.transform.position);

                if ((troop.Team == 1) && boxCollider.Contains(troopPositionOnScreen))
                    selectedTroops.Add(troop);
            }
                
            return selectedTroops;
        }
    }
}
