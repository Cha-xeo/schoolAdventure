using UnityEngine;
using SchoolAdventure.DungeonPuzzle.Scriptable.Towers;

namespace SchoolAdventure.DungeonPuzzle.Towers
{

    public class Tower : MonoBehaviour
    {
        [SerializeField] TowerScriptable _tower;
        GameObject _towerInstance;
        MaterialPropertyBlock _materialPropertyBlock;
        [SerializeField] SpriteRenderer _renderer;
        [SerializeField] PolygonCollider2D _collider;
        public TowerManager manager;
        int currentElement = 0;

        void Start()
        {
            _towerInstance = Instantiate(_tower.statuePrefab, transform);
            _renderer = _towerInstance.GetComponent<SpriteRenderer>();
            ChangeTowerColor();
            _materialPropertyBlock = new MaterialPropertyBlock();
        }

        void Activate()
         {
            ChangeTowerColor();
            manager.TowerActivated();
         }
        
        private void ChangeTowerColor()
        {
            _renderer.color = _tower.element[currentElement].color;
            /*_renderer.GetPropertyBlock(_materialPropertyBlock);
            _materialPropertyBlock.SetColor("_Color", _tower.element[currentElement].color);
            _renderer.SetPropertyBlock(_materialPropertyBlock);*/
        }

        void OnTriggerEnter2D(Collider2D collision)
         {
            if (collision.CompareTag(Constants.TAG_PLAYER))
            {
                if (Player.PlayerManager.Instance.Element.GetCurrentElement().ID.ID == _tower.element[currentElement].ID.ID)
                {
                    Activate();
                    currentElement++;
                    ChangeTowerColor();
                    if (currentElement >= _tower.element.Length-1) 
                    {
                        _collider.enabled = false;
                        _tower.state = TowerState.Activated;
                    }
                }
            }
         }
    }
}
