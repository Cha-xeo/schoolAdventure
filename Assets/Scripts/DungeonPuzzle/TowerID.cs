using System;

namespace SchoolAdventure.DungeonPuzzle.Towers
{
    [System.Serializable]
    public struct TowerID : IEquatable<TowerID>
    {
        public int ID;

        public bool Equals(TowerID other)
        {
            return ID == other.ID;
        }

        public override bool Equals(object obj)
        {
            return obj is TowerID other && Equals(other);
        }

        public override int GetHashCode()
        {
            return ID;
        }

        public static bool operator ==(TowerID x, TowerID y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(TowerID x, TowerID y)
        {
            return !(x == y);
        }

        public override string ToString()
        {
            return $"TowerID({ID})";
        }
    }
}
