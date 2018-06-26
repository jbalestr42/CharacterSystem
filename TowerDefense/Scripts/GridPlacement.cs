using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlacement : MonoBehaviour {

    public int _width;
    public int _height;
    public float _size;

    public GameObject _placementTile;
    public TowerData _towerData;

    private float _maxWidth;
    private float _maxHeight;
    private List<TilePlacement> _prevTiles;
    private TilePlacement[,] _tiles;
    private Vector2Int _tilePos = Vector2Int.zero;
    private bool _canPlaceTower = false;
    private GameObject _towers;

    private void Start() {
        _prevTiles = new List<TilePlacement>();
        _tiles = new TilePlacement[_width, _height];

        GameObject container = new GameObject();
        container.transform.SetParent(transform);
        container.name = "Container";

        _towers = new GameObject();
        _towers.transform.SetParent(transform);
        _towers.name = "Towers";

        transform.GetChild(0).transform.localScale = new Vector3(_width * _size, _height * _size, 1f);

        _towerData.Init();

        _maxWidth = _width * _size - _size;
        _maxHeight = _height * _size - _size;
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                GameObject go = Instantiate(_placementTile);
                go.transform.SetParent(container.transform);
                go.transform.localPosition = new Vector3(x * _size - _maxWidth / 2f, 0f, y * _size - _maxHeight / 2f);
                go.transform.localScale = new Vector3(_size, _size, 1f);
                _tiles[x, y] = go.GetComponent<TilePlacement>();
            }
        }
    }

    private void OnMouseOver() {
        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            var localPoint = transform.InverseTransformPoint(hit.point);
            Vector2Int tilePos = new Vector2Int(Mathf.FloorToInt((localPoint.x / _maxWidth + 0.5f) * (_width - 1) + 0.5f), Mathf.FloorToInt((localPoint.y / _maxHeight + 0.5f) * (_height - 1) + 0.5f));

            if (tilePos != _tilePos) {
                _tilePos = tilePos;
                UnHighlightAll();

                _canPlaceTower = true;
                for (int i = 0; i < _towerData.Size.x; i++) {
                    for (int j = 0; j < _towerData.Size.y; j++) {
                        int x = tilePos.x + i - _towerData.Size.x / 2;
                        int y = tilePos.y + j - _towerData.Size.y / 2;
                        if (_towerData.Shape[i, j] != 0) {
                            if (x >= 0 && x < _tiles.GetLength(0) && y >= 0 && y < _tiles.GetLength(1) && _tiles[x, y].IsFree) {
                                _prevTiles.Add(_tiles[x, y]);
                            } else {
                                _canPlaceTower = false;
                            }
                        }
                    }
                }
                foreach (var tile in _prevTiles) {
                    if (_canPlaceTower) {
                        tile.Highlight();
                    } else {
                        tile.HighlightOccupied();
                    }
                }
            }
        }
    }

    private void OnMouseDown() {
        if (_canPlaceTower && FindObjectOfType<GameManager>().EnoughMoney(_towerData._cost)) {
            Vector3 center = Vector3.zero;
            foreach (var tile in _prevTiles) {
                tile.Select();
                center += tile.transform.localPosition;
            }
            center /= _prevTiles.Count;
            _prevTiles.Clear();
            var go = Instantiate(_towerData._gameObject);
            go.transform.SetParent(_towers.transform);
            go.transform.localPosition = center;
            go.transform.localScale = new Vector3(_size, _size, _size);
            FindObjectOfType<GameManager>().UpdateMoney(-_towerData._cost);
        }
    }

    private void OnMouseExit() {
        UnHighlightAll();
    }

    void UnHighlightAll() {
        foreach (var tile in _prevTiles) {
            tile.UnHighlight();
        }
        _prevTiles.Clear();
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.blue;

        _maxWidth = _width * _size;
        _maxHeight = _height * _size;
        for (int x = 0; x < _width + 1; x++) {
            Gizmos.DrawLine(transform.position + new Vector3(x * _size - _maxWidth / 2f, transform.position.y, transform.position.z - _maxHeight / 2f), transform.position + new Vector3(x * _size - _maxWidth / 2f, transform.position.y, transform.position.y + _height * _size / 2f));
        }
        for (int y = 0; y < _height + 1; y++) {
            Gizmos.DrawLine(transform.position + new Vector3(transform.position.x - _maxWidth / 2f, transform.position.y, y * _size - _maxHeight / 2f), transform.position + new Vector3(transform.position.x + _width * _size / 2f, transform.position.y, y * _size - _maxHeight / 2f));
        }
    }
}