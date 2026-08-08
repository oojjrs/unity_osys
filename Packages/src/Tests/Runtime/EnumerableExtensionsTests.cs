using System;
using System.Collections.Generic;
using NUnit.Framework;

public class EnumerableExtensionsTests
{
    [Test]
    public void GetIndexReturnsFirstMatchIndex()
    {
        Assert.That(new[] { 1, 2, 1 }.GetIndex(1), Is.EqualTo(0));
    }

    [Test]
    public void GetIndexReturnsIndex()
    {
        Assert.That(new[] { 1, 2, 3 }.GetIndex(1), Is.EqualTo(0));
        Assert.That(new[] { 1, 2, 3 }.GetIndex(2), Is.EqualTo(1));
        Assert.That(new[] { 1, 2, 3 }.GetIndex(3), Is.EqualTo(2));
    }

    [Test]
    public void GetIndexReturnsValueCountForMissingMatch()
    {
        Assert.That(new[] { 1, 2, 3 }.GetIndex(4), Is.EqualTo(3));
    }

    [Test]
    public void GetIndexReturnsZeroForEmptyValues()
    {
        Assert.That(Array.Empty<int>().GetIndex(0), Is.EqualTo(0));
    }

    [Test]
    public void GetNextReturnsDefaultForEmptyValues()
    {
        Assert.That(Array.Empty<int>().GetNext(0), Is.EqualTo(default(int)));
    }

    [Test]
    public void GetNextReturnsFirstValueForMissingMatch()
    {
        Assert.That(new[] { 1, 2, 3 }.GetNext(4), Is.EqualTo(1));
    }

    [Test]
    public void GetNextReturnsNextValue()
    {
        Assert.That(new[] { 1, 2, 3 }.GetNext(2), Is.EqualTo(3));
    }

    [Test]
    public void GetNextWrapsLastMatch()
    {
        Assert.That(new[] { 1, 2, 3 }.GetNext(3), Is.EqualTo(1));
    }

    [Test]
    public void GetPreviousReturnsDefaultForEmptyValues()
    {
        Assert.That(Array.Empty<int>().GetPrevious(0), Is.EqualTo(default(int)));
    }

    [Test]
    public void GetPreviousReturnsLastValueForMissingMatch()
    {
        Assert.That(new[] { 1, 2, 3 }.GetPrevious(4), Is.EqualTo(3));
    }

    [Test]
    public void GetPreviousReturnsPreviousValue()
    {
        Assert.That(new[] { 1, 2, 3 }.GetPrevious(2), Is.EqualTo(1));
    }

    [Test]
    public void GetPreviousWrapsFirstMatch()
    {
        Assert.That(new[] { 1, 2, 3 }.GetPrevious(1), Is.EqualTo(3));
    }

    [Test]
    public void GetReturnsSingleValue()
    {
        var values = new[] { 1 };

        Assert.That(values.GetNext(1), Is.EqualTo(1));
        Assert.That(values.GetPrevious(2), Is.EqualTo(1));
    }

    [Test]
    public void GetThrowsForNullValues()
    {
        IEnumerable<int> values = null;

        Assert.Throws<ArgumentNullException>(() => values.GetIndex(1));
        Assert.Throws<ArgumentNullException>(() => values.GetNext(1));
        Assert.Throws<ArgumentNullException>(() => values.GetPrevious(1));
    }
}
