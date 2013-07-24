
namespace BeyondSearch.SampleCode
{
    public abstract class TemplateMethodExampleBase
    {
        public string Test1(string key)
        {
            return this.Map(key.ToLowerInvariant());
        }

        protected virtual string Map(string key)
        {
            return key;
        }
    }
}
