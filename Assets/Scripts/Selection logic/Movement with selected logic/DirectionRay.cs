using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PavleM.RDI.RTS
{
    public class DirectionRay : MonoBehaviour
    {
        public LayerMask selectableLayerMask;

        // Razmak između trupa kad se kreću kao grupa
        [SerializeField] private float troopArrangementOffset = 0.8f; 

        private void Update()
        {
            if (HasPressedRightClick() && HasSelectedSomeTroops())
            {
                var location = GetDesiredLocation();
                if (location == null)
                    return;

                DoMovement(location);
            }
        }

        private bool HasPressedRightClick()
            => Input.GetMouseButtonDown(1);

        private bool HasSelectedSomeTroops()
            => (CameraSelection.currentSelectionContainer is TroopSelectionContainer);
        
        private Vector3? GetDesiredLocation()
        {
            /*var ray = CameraSelection.playerCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                return hit.point;*/

            var mouseClickPositionScreenXY = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            var mouseClickPositionWorld = CameraSelection.playerCamera.ScreenToWorldPoint(mouseClickPositionScreenXY);
            mouseClickPositionWorld.z = 0;

            return mouseClickPositionWorld;

            //return null;
        }

        private void DoMovement(Vector3? location)
        {
            /*if (!IsDestinationReachable(location.Value))
                Debug.Log("There is no way!");*/

            var troopsToMove = SelectionContainer.selected
                                    .Select(selectable => (Troop)selectable)
                                    .Where(troop => !troop.isFighting)
                                    .ToList();

            var positions = GetDesiredPositionsOfTroopsForDestination(location.Value, troopsToMove);

            for (int i = 0; i < troopsToMove.Count(); i++)
                troopsToMove[i].movement.MoveTo(positions[i]);
        }

        private List<Vector3> GetDesiredPositionsOfTroopsForDestination(Vector3 destination, List<Troop> troops)
        {
            //return null;
            List<Vector3> positions = new List<Vector3>();
            int nextTroopIndex = 0;

            positions.Add(destination); /// Ova skripta pretpostavlja da može da se dođe do same date pozicije
            int squareEdgeSize = 1; /// Zasad imamo 1x1 kvadrat

            while (positions.Count() < troops.Count())
            {
                /// Prvo za jedan pomeraj na gore
                destination.y += troopArrangementOffset;
                if (troops[nextTroopIndex].movement.CanAgentGetTo(destination))
                {
                    positions.Add(destination);
                    nextTroopIndex++;
                }

                /// Onda na desno do ivice
                int spotsToGoRight = squareEdgeSize / 2 + 1;
                for (int i = 0; (i < spotsToGoRight) && (positions.Count() < troops.Count()); i++)
                {
                    destination.x += troopArrangementOffset;
                    if (troops[nextTroopIndex].movement.CanAgentGetTo(destination))
                    {
                        positions.Add(destination);
                        nextTroopIndex++;
                    }
                }

                /// Onda na dole do ivice
                int spotsToGoDown = squareEdgeSize + 1;
                for (int i = 0; (i < spotsToGoDown) && (positions.Count() < troops.Count()); i++)
                {
                    destination.y -= troopArrangementOffset;
                    if (troops[nextTroopIndex].movement.CanAgentGetTo(destination))
                    {
                        positions.Add(destination);
                        nextTroopIndex++;
                    }
                }

                /// Onda na levo do ivice
                int spotsToGoLeft = squareEdgeSize + 1;
                for (int i = 0; (i < spotsToGoLeft) && (positions.Count() < troops.Count()); i++)
                {
                    destination.x -= troopArrangementOffset;
                    if (troops[nextTroopIndex].movement.CanAgentGetTo(destination))
                    {
                        positions.Add(destination);
                        nextTroopIndex++;
                    }
                }

                /// Onda na gore do ivice
                int spotsToGoUp = squareEdgeSize + 1;
                for (int i = 0; (i < spotsToGoUp) && (positions.Count() < troops.Count()); i++)
                {
                    destination.y += troopArrangementOffset;
                    if (troops[nextTroopIndex].movement.CanAgentGetTo(destination))
                    {
                        positions.Add(destination);
                        nextTroopIndex++;
                    }
                }

                /// Onda ponovo desno da upotpunimo kvadrat
                int spotsToGoRightAgain = squareEdgeSize / 2;
                for (int i = 0; (i < spotsToGoRightAgain) && (positions.Count() < troops.Count()); i++)
                {
                    destination.x += troopArrangementOffset;
                    if (troops[nextTroopIndex].movement.CanAgentGetTo(destination))
                    {
                        positions.Add(destination);
                        nextTroopIndex++;
                    }
                }

                /// Dodajem pomeraj još jednom na x da bih ga uperio na gornji centar kvadrata
                destination.x += troopArrangementOffset;

                /// Kvadrat se uvećao za 1 na svakoj strani tj. 2 po ivici
                squareEdgeSize += 2;
            }

            return positions;
        }
    }
}
