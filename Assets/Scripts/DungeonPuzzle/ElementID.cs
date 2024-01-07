using System;

namespace SchoolAdventure.DungeonPuzzle.Elements
{
    [System.Serializable]
    public struct ElementID : IEquatable<ElementID>
    {
        public int ID;

        public bool Equals(ElementID other)
        {
            return ID == other.ID;
        }

        public override bool Equals(object obj)
        {
            return obj is ElementID other && Equals(other);
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public static bool operator ==(ElementID x, ElementID y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(ElementID x, ElementID y)
        {
            return !(x == y);
        }

        public override string ToString()
        {
            return $"ElementID({ID})";
        }
    }
}
