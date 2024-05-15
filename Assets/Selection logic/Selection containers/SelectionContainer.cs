using System.Collections.Generic;
using System.Linq;

namespace PavleM.RDI.RTS
{
    public abstract class SelectionContainer
    {
        public static List<Selectable> selected { get; private set; } = new List<Selectable>();

        public virtual void OnContainerEnter(CameraSelection context)
            => SelectEverything();

        private void SelectEverything()
        {
            foreach (var selectable in selected)
                selectable.OnSelect();
        }

        public void OnContainerExit(CameraSelection context)
            => DeselectEverything();

        private void DeselectEverything()
        {
            foreach (var selectable in selected)
                selectable.OnDeselect();
        }

        // Klik dozvoljava selekciju i trupe i zgrade
        public void Update(Selectable selectable, CameraSelection context)
        {
            if (DidntSelectAnything(selectable))
            {
                DeselectEverything();
                selected.Clear();

                context.SetSelectionContainer(context.emptySelectionContainer);
            }
            else if (selectable is Troop)
            {
                DeselectEverything();
                var selectedTroop = (Troop) selectable;
                selected = new List<Selectable>() { selectedTroop };

                context.SetSelectionContainer(context.troopSelectionContainer);
            }
            else if (selectable is Building)
            {
                DeselectEverything();
                var selectedBuilding = (Building)selectable;
                selected = new List<Selectable>() { selectedBuilding };

                context.SetSelectionContainer(context.buildingSelectionContainer);
            }
        }

        private bool DidntSelectAnything(Selectable selectable)
            => (selectable == null);

        // Prevlačenje dozvoljava samo selekciju trupa
        public void Update(List<Selectable> selectables, CameraSelection context)
        {
            if (DidntSelectAnything(selectables))
            {
                DeselectEverything();
                selected.Clear();

                context.SetSelectionContainer(context.emptySelectionContainer);
            }
            else
            {
                var selectedTroops = selectables.Where(selectable => selectable is Troop)
                                                .ToList();

                if (selectedTroops == null || selectedTroops.Count() == 0)
                {
                    DeselectEverything();
                    selected.Clear();

                    context.SetSelectionContainer(context.emptySelectionContainer);
                }
                else
                {
                    DeselectEverything();
                    selected = selectedTroops;
                    context.SetSelectionContainer(context.troopSelectionContainer);
                } 
            }
        }

        private bool DidntSelectAnything(List<Selectable> selectables)
            => (selectables == null || selectables.Count() == 0);
    }
}
