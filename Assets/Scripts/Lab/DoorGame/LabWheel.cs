using System;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Lab.Door
{
    public class LabWheel : LabRunes
    {
        [SerializeField] private Sprite[] _shapesSpriteArray;

        private (Sprite, Rune)[] _shapesSpriteTuple;
        [SerializeField] private Vector3[] _shapesPos;
        [SerializeField] private Quaternion[] _shapesRot;
        [SerializeField] private GameObject _arrow;
        private int _randomizedValue;
        private int _enumLenght;
        private Transform _thisTransform;
        public List<Rune> _holding;
        //

        private void Awake()
        {
            _thisTransform = transform;
            _enumLenght = Enum.GetNames(typeof(Rune)).Length;

            _shapesSpriteTuple = new (Sprite, Rune)[] {
            (_shapesSpriteArray[0], Rune.Rune1),
            (_shapesSpriteArray[1], Rune.Rune2),
            (_shapesSpriteArray[2], Rune.Rune3),
            (_shapesSpriteArray[3], Rune.Rune4),
            (_shapesSpriteArray[4], Rune.Rune5),
            (_shapesSpriteArray[5], Rune.Rune6),
            (_shapesSpriteArray[6], Rune.Rune7),
            (_shapesSpriteArray[7], Rune.Rune8),
            (_shapesSpriteArray[8], Rune.Rune9),
            (_shapesSpriteArray[9], Rune.Rune10),
            (_shapesSpriteArray[10], Rune.Rune11),
            (_shapesSpriteArray[11], Rune.Rune12),
            (_shapesSpriteArray[12], Rune.Rune13),
            (_shapesSpriteArray[13], Rune.Rune14),
            (_shapesSpriteArray[14], Rune.Rune15),
            (_shapesSpriteArray[15], Rune.Rune16),
        };
        }

        public Rune TakeRune()
        {
            return _holding[UnityEngine.Random.Range(0, _holding.Count)];

        }
        public bool HasShape(Rune rune)
        {
            return _holding.Contains(rune);
        }

        public bool removeShape(Rune rune)
        {
            _holding.Remove(rune);
            return _holding.Count == 0 ? true : false;
        }

        private void Initialiaze()
        {

        }
        private void OnEnable()
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject tmp = Instantiate(_arrow, _thisTransform.position + _shapesPos[i], _shapesRot[i]);
                _randomizedValue = UnityEngine.Random.Range(0, _enumLenght);
                tmp.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = _shapesSpriteTuple[_randomizedValue].Item1;
                tmp.GetComponent<LabAreaGen>().rune = _shapesSpriteTuple[_randomizedValue].Item2;
                tmp.transform.parent = _thisTransform;
                _holding.Add(_shapesSpriteTuple[_randomizedValue].Item2);
            }
        }

        private void OnDisable()
        {
            _holding.Clear();
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

        }
    }
}
