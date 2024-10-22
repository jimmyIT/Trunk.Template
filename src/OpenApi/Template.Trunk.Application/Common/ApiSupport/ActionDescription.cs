namespace Template.Trunk.Server.Application.Common.ApiSupport
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class ActionDescription : Attribute
    {
        public string RequestType { get; }

        public ActionDescription(string requestType)
        {
            RequestType = requestType;
        }
    }
}
