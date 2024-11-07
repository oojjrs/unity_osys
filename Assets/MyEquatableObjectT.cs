using System;

public abstract class MyEquatableObjectT<T> : IEquatable<T> where T : MyEquatableObjectT<T>
{
    public abstract bool Equals(T other);
    public abstract override int GetHashCode();

    public override bool Equals(object obj)
    {
        return obj is T other && Equals(other);
    }

    public static bool operator ==(MyEquatableObjectT<T> lhs, MyEquatableObjectT<T> rhs)
    {
        if (ReferenceEquals(lhs, rhs))
            return true;

        if (((object)lhs == default) || ((object)rhs == default))
            return false;

        return lhs.Equals(rhs);
    }

    public static bool operator !=(MyEquatableObjectT<T> lhs, MyEquatableObjectT<T> rhs)
    {
        return !(lhs == rhs);
    }
}
