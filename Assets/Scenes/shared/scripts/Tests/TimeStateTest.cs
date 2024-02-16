using NUnit.Framework;
using Lib;
namespace SharedTests
{

    public class TimeStateTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void CalculatesPercentage()
    {
        ExperimentTimeState st = new ExperimentTimeState(1, 10);
        Assert.AreEqual(st.percentage, 0.1f);
        Assert.False(st.over);
    }
    [Test]
    public void ZeroPercentage()
    {
        ExperimentTimeState st = new ExperimentTimeState(0, 2);
        Assert.AreEqual(st.percentage, 0f);
        Assert.False(st.over);
    }
    [Test]
    public void NegativeTime()
    {
        try{
        ExperimentTimeState st = new ExperimentTimeState(-1, 2);
        }
        catch(System.ArgumentOutOfRangeException){
            return;
        }
        Assert.Fail("The method should fail at negative time");
    }
    [Test]
    public void NegativeMax()
    {
        try{
        ExperimentTimeState st = new ExperimentTimeState(1, -2);
        }
        catch(System.ArgumentOutOfRangeException){
            return;
        }
        Assert.Fail("The method should fail at negative time");
    }
    [Test]
    public void OverTime(){
        ExperimentTimeState st = new(2, 1);
        Assert.Greater(st.percentage, 1);
        Assert.True(st.over);
    }
    
}
}