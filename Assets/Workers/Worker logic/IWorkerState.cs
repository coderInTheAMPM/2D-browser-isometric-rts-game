using UnityEngine;

namespace PavleM.RDI.RTS
{
    public interface IWorkerState
    {
        public void OnEnter(Worker context);

        public void Update(Worker context);
    }
}
