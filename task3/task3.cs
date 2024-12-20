using Newtonsoft.Json;
using System.Net.Http;
using System.Xml.Linq;


class values0
{
    public values[] values { get; set; }
}
class tests0
{
    public tests[] tests { get; set; }
}
class values
{
    public int id { get; set; }
    public string value { get; set; }
}

class tests
{
    public int id { get; set; }
    public string value { get; set; }
    public string title { get; set; }
    public tests[] values { get; set; }

}
class A
{

    static void Main()
    {
        var v = JsonConvert.DeserializeObject<values0>(File.ReadAllText("values.json"));
        var t = JsonConvert.DeserializeObject<tests0>(File.ReadAllText("tests.json"));
        A a = new A();
        tests[] tm = t.tests;
        a.FillingTests(ref tm, v);
        t.tests = tm;
        File.WriteAllText("report.json",JsonConvert.SerializeObject(t));

    }
    void FillingTests(ref tests[] tm, values0 v)
    {
        for(int i = 0; i < tm.Length; i++)
        {
            if (tm[i].values != null) { var ntest = tm[i].values; FillingTests(ref ntest, v); tm[i].values = ntest; }
            if (tm[i].value != null) { string valueStr = SearchValue(v, tm[i].id ); tm[i].value = valueStr; }
        }
    }

    string SearchValue(values0 v, int id)
    {
        string valueStr = "";
        foreach (var val in v.values)
        {
            if (val.id == id) { valueStr=val.value; break; }
        }
        return valueStr;
    }
}