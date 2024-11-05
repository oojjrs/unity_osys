using System;

namespace Assets.Editor
{
    public abstract class MyEquatableObjectT<T> : IEquatable<T> where T : MyEquatableObjectT<T>
    {
        public abstract bool Equals(T other);

        public override bool Equals(object obj)
        {
            return obj is T other && Equals(other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(MyEquatableObjectT<T> lhs, MyEquatableObjectT<T> rhs)
        {
            if (ReferenceEquals(lhs, rhs))
                return true;

            if ((lhs == default) || (rhs == default))
                return false;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(MyEquatableObjectT<T> lhs, MyEquatableObjectT<T> rhs)
        {
            return !(lhs == rhs);
        }
    }
}
