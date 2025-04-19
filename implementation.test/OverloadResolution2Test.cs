using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Implementation.Test;

[Trait("TestOf", nameof(OverloadResolution2))]
public class OverloadResolution2Test
{
    private readonly OverloadResolution2 _overloadResolution;
    public OverloadResolution2Test()
    {
        _overloadResolution = new OverloadResolution2();
    }

    [Fact]
    public void Test_OverloadResolution2()
    {
        Assert.Equal(0, _overloadResolution.CallCount);
        Assert.False(_overloadResolution.HasSpecialCall);

        _overloadResolution.Method("Neko");

        Assert.Equal(1, _overloadResolution.CallCount);
        Assert.False(_overloadResolution.HasSpecialCall);

        _overloadResolution.Method(1);

        Assert.Equal(2, _overloadResolution.CallCount);
        Assert.True(_overloadResolution.HasSpecialCall);
    }
}