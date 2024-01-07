using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.HID;

namespace SchoolAdventure.Games.Geographie.GeoGuesser
{

    public class Highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        // R�f�rence au mat�riau brillant de l'objet
        public Material highlightMaterial;
        private Material originalMaterial;
        GameManager _manager;

        // R�f�rence au rendu du maillage (Mesh Renderer) de l'objet
        private MeshRenderer meshRenderer;

        // R�f�rence au collider 2D du type Box Collider 2D
        private BoxCollider2D boxCollider;

        private void Start()
        {
            // R�cup�rer le Mesh Renderer attach� � cet objet
            meshRenderer = GetComponent<MeshRenderer>();

            // R�cup�rer le Box Collider 2D attach� � cet objet
            boxCollider = GetComponent<BoxCollider2D>();

            // Conserver le mat�riau original de l'objet
            originalMaterial = meshRenderer.material;
            if (GameObject.FindGameObjectsWithTag(Constants.TAG_KEY)[0].TryGetComponent(out GameManager mana))
            {
                _manager = mana;
            }
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            meshRenderer.material = highlightMaterial;
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            meshRenderer.material = originalMaterial;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_manager && _manager.canClick)
            {
                _manager.SetCurrentObjName(gameObject.name);
            }
        }
    }
}