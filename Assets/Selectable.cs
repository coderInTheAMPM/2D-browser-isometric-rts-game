namespace PavleM.SI.PrebivalisteS3
{
    public interface Selectable
    {
        public void OnSelect();
        public void OnDeselect();

        public int Team { get; set; } // 1 - player, 2+ - opponents
    }
}
