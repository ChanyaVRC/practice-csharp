using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Implementation.Test;

[Trait("TestOf", nameof(OverloadResolution))]
public class OverloadResolutionTest
{
    [Fact]
    public void Test_OverloadResolution()
    {
        var overloadResolution = new OverloadResolution();
        overloadResolution.CallMethod();
        Assert.Equal(typeof(long), overloadResolution.ArgumentType);
        Assert.IsType<long>(overloadResolution.Value);
        Assert.Equal(1, (int)(long)overloadResolution.Value);
    }
}