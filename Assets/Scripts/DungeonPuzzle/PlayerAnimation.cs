

using SchoolAdventure.DungeonPuzzle.Puzzle;
using SchoolAdventure.DungeonPuzzle.Towers;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace SchoolAdventure.DungeonPuzzle.Player.Animation
{
    public class PlayerAnimation :MonoBehaviour
    {
        [SerializeField] ParticleSystem _holderMainParticle;
        [SerializeField] ParticleSystem _holderRayParticle;
        [SerializeField] ParticleSystem _holderStarParticle;
        [SerializeField] Light2D _holderLight;

        [SerializeField] ParticleSystem _holderMainParticle2;
        [SerializeField] ParticleSystem _holderRayParticle2;
        [SerializeField] ParticleSystem _holderStarParticle2;
        [SerializeField] Light2D _holderLight2;
        [SerializeField] SpriteRenderer _holderSpriteRenderer;
        [SerializeField] SpriteRenderer _playerSpriteRenderer;
        [SerializeField] Animator _playerAnimator;
        MaterialPropertyBlock _materialPropertyBlock;
        void Start()
        {
            _materialPropertyBlock = new MaterialPropertyBlock();
            ChangeHolderColor();
            PlayerManager.Instance.onElementChanged += PlayerManager_OnElementChanged;
        }

        void PlayerManager_OnElementChanged(object sender, System.EventArgs e)
        {
            ChangeHolderColor();
        }

        private void OnDestroy()
        {
            PlayerManager.Instance.onElementChanged -= PlayerManager_OnElementChanged;
        }

        private void ChangeHolderColor()
        {
            Color a = PlayerManager.Instance.Element.GetCurrentElement().color;
            var tmp = _holderMainParticle.main;
            tmp.startColor = a;
            tmp =  _holderRayParticle.main;
            tmp.startColor = a;
            tmp = _holderStarParticle.main;
            tmp.startColor = a;
            _holderLight.color = a;
            //_holderSpriteRenderer.color = a;

            tmp = _holderMainParticle2.main;
            tmp.startColor = a;
            tmp = _holderRayParticle2.main;
            tmp.startColor = a;
            tmp = _holderStarParticle2.main;
            tmp.startColor = a;
            _holderLight2.color = a;
            //_holderSpriteRenderer.color = a;

            //PlayerManager.Instance.Element.GetCurrentElement().color;
            //_holderParticle.main.startColor.color = PlayerManager.Instance.Element.GetCurrentElement().color;



            /*_holderSpriteRenderer.GetPropertyBlock(_materialPropertyBlock);

            _materialPropertyBlock.SetColor("_Color", PlayerManager.Instance.Element.GetCurrentElement().color);

            _holderSpriteRenderer.SetPropertyBlock(_materialPropertyBlock);*/
        }
    }
}
