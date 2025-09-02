using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    [SerializeField] private PlayingField _playingField;
    [SerializeField] private Grid _grid;
    
    private Tile _tile;
    
    
    /// <summary>
    /// Данный метод вызывается автоматически при клике на кнопки с изображениями тайлов.
    /// В качестве параметра передается префаб тайла, изображенный на кнопке.
    /// Вы можете использовать префаб tilePrefab внутри данного метода.
    /// </summary>
    public void StartPlacingTile(GameObject tilePrefab)
    {
        if (_tile)
        {
            Destroy(_tile.gameObject);
        }

        var tileObj = Instantiate(tilePrefab, _playingField.transform);
        _tile = tileObj.GetComponent<Tile>();
    }

    private void Update()
    {
        if (_tile == null)
        {
            return;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            Vector3 hitPoint = hitInfo.point;
            
            Vector3Int cell = _grid.WorldToCell(hitPoint);
            _tile.transform.position = _grid.GetCellCenterWorld(cell);

            var isAvailable = _playingField.IsCellAvailable(cell);
            _tile.SetColor(isAvailable);

            if (!isAvailable)
            {
                return;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                _playingField.SetTile(cell, _tile);
                _tile.ResetColor();
                _tile = null;
            }
        }

        
    }
}