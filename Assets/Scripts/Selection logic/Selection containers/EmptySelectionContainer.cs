namespace PavleM.RDI.RTS // Zaniti ove kontejnere sa samo nekim Enumom? Da li sve treba biti u baznoj klasi ili zapravo obrnuto?
{
    public class EmptySelectionContainer : SelectionContainer
    {
        public override void OnContainerEnter(CameraSelection context)
        {
            UIManager.instance?.SetHotbarGUI(DefaultGUI.instance?.gameObject);
        }
    }
}
