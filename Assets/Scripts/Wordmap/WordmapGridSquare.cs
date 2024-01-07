using SchoolAdventure.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WordmapGridSquare : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler , IPointerDownHandler
{
    public int squareIndex { get; set; }
    private WordmapAlphaData.LetterData _normalLetterData;
    private WordmapAlphaData.LetterData _selectedLetterData;
    private WordmapAlphaData.LetterData _correctLetterData;

    private SpriteRenderer _displayedImage;

    private bool _selected;
    private bool _clicked;
    private int _index = -1;
    private bool _correct;
    private bool _enter = false;
    //private AudioSource[]  _source;
    [SerializeField] AudioClip _WinClip;
    [SerializeField] AudioClip _PopClip;

    public void SetIndex(int index)
    {
        _index = index;
    }

    public int GetIndex()
    {
        return _index;
    }

    void Start()
    {
        _selected = false;
        _clicked = false;
        _correct = false;
        _displayedImage = GetComponent<SpriteRenderer>();
        //_source = GetComponents<AudioSource>();

    }

    private void OnEnable()
    {
        WordmapGameEvents.OnEnableSquareSelection += OnEnableSquareSelection;
        WordmapGameEvents.OnDisableSquareSelection += OnDisableSquareSelection;
        WordmapGameEvents.OnSelectSquare += SelectSquare;
        WordmapGameEvents.OnCorrectWord += CorrectWord;
    }

    private void OnDisable()
    {
        WordmapGameEvents.OnEnableSquareSelection -= OnEnableSquareSelection;
        WordmapGameEvents.OnDisableSquareSelection -= OnDisableSquareSelection;
        WordmapGameEvents.OnSelectSquare -= SelectSquare;
        WordmapGameEvents.OnCorrectWord -= CorrectWord;
    }

    public void OnEnableSquareSelection()
    {
        _clicked = true;
        _selected = false;
    }

    public void OnDisableSquareSelection()
    {
        _selected = false;
        _clicked = false;
        if (_correct == true) {
            _displayedImage.sprite = _correctLetterData.image;
        } else {
            _displayedImage.sprite = _normalLetterData.image;
        }
    }

    public void SelectSquare(Vector3 position)
    {
        if (this.gameObject.transform.position == position) {
            _displayedImage.sprite = _selectedLetterData.image;
        }
    }

    public void SetSprite(WordmapAlphaData.LetterData normalLetterData, WordmapAlphaData.LetterData selectedLetterData, WordmapAlphaData.LetterData correctLetterData)
    {
        _normalLetterData = normalLetterData;
        _selectedLetterData = selectedLetterData;
        _correctLetterData = correctLetterData;

        GetComponent<SpriteRenderer>().sprite = _normalLetterData.image;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_enter) {
            _enter = true;
        }
        OnEnableSquareSelection();
        WordmapGameEvents.EnableSquareSelectionMethod();
        CheckSquare();
        _displayedImage.sprite = _selectedLetterData.image;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (InputManager.GetInstance().GetLeftMouseHolded()) {
            _enter = true;
        }
        CheckSquare();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _enter = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        WordmapGameEvents.ClearSelectionMethod();
        WordmapGameEvents.DisableSquareSelectionMethod();
    }

    public void CheckSquare()
    {
        if (_selected == false && _clicked == true) {
            SoundManagerV2.Instance.PlaySound(_PopClip);
            //_source[0].Play();
            _selected = true;
            WordmapGameEvents.CheckSquareMethod(_normalLetterData.letter, gameObject.transform.position, _index);
        }
    }

    public void CorrectWord(string word, List<int> squareIndexes)
    {
        if (_selected && squareIndexes.Contains(_index)) {
            SoundManagerV2.Instance.PlaySound(_WinClip);
            //_source[1].Play();
            _correct = true;
            _displayedImage.sprite = _correctLetterData.image;
        }

        _selected = false;
        _clicked = false;
    }
}
