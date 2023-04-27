using System.Text.Json;

namespace TestProject1.Utilities;

public class TestDataLoader
{
    private static TestDataLoader instance = null;
    private List<TestData> testDatas;

    private TestDataLoader()
    {
    }

    public TestData GetTestData()
    {
        return testDatas[0];
    }

    public void LoadTestData(String path)
    {
        using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();
            testDatas = JsonSerializer.Deserialize<List<TestData>>(json);
        }
    }

    public static TestDataLoader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TestDataLoader();
            }

            return instance;
        }
    }
}