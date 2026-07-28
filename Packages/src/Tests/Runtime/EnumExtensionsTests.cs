using System;
using NUnit.Framework;

public class EnumExtensionsTests
{
    private enum AliasEnum
    {
        First = 0,
        FirstAlias = 0,
        Second = 1,
    }

    private enum EmptyEnum
    {
    }

    [Flags]
    private enum FlagEnum
    {
        None = 0,
        First = 1,
        Second = 2,
        All = First | Second,
    }

    private enum SequenceEnum
    {
        First = 10,
        Second = 20,
        Third = 30,
    }

    private enum SingleEnum
    {
        Only = 7,
    }

    [Test]
    public void GetNextIncludesNamedFlagsCombination()
    {
        Assert.That(FlagEnum.Second.GetNext(), Is.EqualTo(FlagEnum.All));
        Assert.That(FlagEnum.All.GetNext(), Is.EqualTo(FlagEnum.None));
    }

    [Test]
    public void GetNextReturnsDefaultForEmptyEnum()
    {
        Assert.That(default(EmptyEnum).GetNext(), Is.EqualTo(default(EmptyEnum)));
    }

    [Test]
    public void GetNextReturnsFirstForUndefinedValue()
    {
        Assert.That(((SequenceEnum)99).GetNext(), Is.EqualTo(SequenceEnum.First));
    }

    [Test]
    public void GetNextSkipsAliasWithTheSameValue()
    {
        Assert.That(AliasEnum.First.GetNext(), Is.EqualTo(AliasEnum.Second));
    }

    [Test]
    public void GetNextWrapsLastValue()
    {
        Assert.That(SequenceEnum.Third.GetNext(), Is.EqualTo(SequenceEnum.First));
    }

    [Test]
    public void GetPreviousReturnsLastForUndefinedValue()
    {
        Assert.That(((SequenceEnum)99).GetPrevious(), Is.EqualTo(SequenceEnum.Third));
    }

    [Test]
    public void GetPreviousReturnsPreviousDistinctValue()
    {
        Assert.That(AliasEnum.Second.GetPrevious(), Is.EqualTo(AliasEnum.First));
    }

    [Test]
    public void GetPreviousWrapsFirstValue()
    {
        Assert.That(SequenceEnum.First.GetPrevious(), Is.EqualTo(SequenceEnum.Third));
    }

    [Test]
    public void GetReturnsSingleEnumValue()
    {
        Assert.That(SingleEnum.Only.GetNext(), Is.EqualTo(SingleEnum.Only));
        Assert.That(SingleEnum.Only.GetPrevious(), Is.EqualTo(SingleEnum.Only));
    }
}
