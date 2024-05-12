
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingClicker : MonoBehaviour
{
    /*public Tilemap buildingTilemap;
    public LayerMask buildingLayerMask;

    void Update()
    {
        if (DidLeftClick())
            HandleMouseClick();
    }

    private bool DidLeftClick()
        => Input.GetMouseButtonDown(0);

    private void HandleMouseClick()
    {
        var mouseClickPositionScreenXY = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        var mouseClickPositionWorld = Camera.main.ScreenToWorldPoint(mouseClickPositionScreenXY);
        //mouseClickPositionWorld.z = 0;

        var clickedGridPosition = buildingTilemap.WorldToCell(mouseClickPositionWorld);

        var clickedTile = buildingTilemap.GetTile(clickedGridPosition) as Tile;

        if (clickedTile == null)
            return;

        Debug.Log(clickedTile.name);*/

    /*var hit = Physics2D.OverlapPoint(mouseClickPositionWorld, buildingLayerMask);

    if (hit == null)
        return;

    Debug.Log(hit.gameObject);
}*/
}
