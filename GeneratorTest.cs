using Xunit;

namespace ScribanSourceGeneratorDemo;

public class GeneratorTest
{
    [Fact]
    public void ScribanGen1_ParseTest()
    {
        const int expected = 123;
        string s = "123";

        Assert.True(ScribanGenDemo1.TryParse(s, out byte b8));
        Assert.Equal<byte>(expected, b8);

        Assert.True(ScribanGenDemo1.TryParse(s, out ushort u16));
        Assert.Equal<ushort>(expected, u16);

        Assert.True(ScribanGenDemo1.TryParse(s, out int i32));
        Assert.Equal<int>(expected, i32);

        Assert.True(ScribanGenDemo1.TryParse(s, out ulong u64));
        Assert.Equal<ulong>(expected, u64);
    }

    [Fact]
    public void ScribanText_ParseTest()
    {
        const int expected = 123;
        string s = "123";

        Assert.True(ScribanDemo.TryParse(s, out byte b8));
        Assert.Equal<byte>(expected, b8);

        Assert.True(ScribanDemo.TryParse(s, out ushort u16));
        Assert.Equal<ushort>(expected, u16);

        Assert.True(ScribanDemo.TryParse(s, out int i32));
        Assert.Equal<int>(expected, i32);

        Assert.True(ScribanDemo.TryParse(s, out ulong u64));
        Assert.Equal<ulong>(expected, u64);
    }

    [Fact]
    public void T4_ParseTest()
    {
        const int expected = 123;
        string s = "123";

        T4Demo1.Parse(s, out byte b8);
        Assert.Equal<byte>(expected, b8);

        T4Demo1.Parse(s, out ushort u16);
        Assert.Equal<ushort>(expected, u16);

        T4Demo1.Parse(s, out int i32);
        Assert.Equal<int>(expected, i32);

        T4Demo1.Parse(s, out ulong u64);
        Assert.Equal<ulong>(expected, u64);
    }

    [Fact]
    public async void ScribanGen2_TaskTest()
    {
        var expected = (11, "22", true, DateTime.MinValue);

        var task1 = Task.FromResult(expected.Item1);
        var task2 = GetValueAsync(expected.Item2);
        var task3 = Task.Run(() => { Thread.Sleep(300); return expected.Item3; });
        var task4 = Task.Run(() => expected.Item4);

        var result = await ScribanGenDemo2.WhenAll(task1, task2, task3, task4);
        Assert.Equal(expected, result);

        static async Task<T> GetValueAsync<T>(T value)
        {
            await Task.Delay(600);
            return value;
        }
    }
}