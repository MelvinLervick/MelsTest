
namespace BeyondSearch.SampleCode
{
    public class TemplateMethodExample :TemplateMethodExampleBase
    {
        public string GetTest1Value(string key)
        {
            return this.Test1(key);
        }

        protected override string Map(string key)
        {
            return key.Equals("key1") ? "This is a Test String for Key1." : base.Map(key);
        }
    }
}
