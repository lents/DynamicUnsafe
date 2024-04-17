using System.Dynamic;

public class CustomDynamicObject : DynamicObject
{
    private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

    // Getting property dynamically
    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        return _properties.TryGetValue(binder.Name, out result);
    }

    // Setting property dynamically
    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        _properties[binder.Name] = value;
        return true;
    }

    // Invoking method dynamically
    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
    {
        if (_properties.ContainsKey(binder.Name) && _properties[binder.Name] is Delegate)
        {
            result = ((Delegate)_properties[binder.Name]).DynamicInvoke(args);
            return true;
        }

        result = null;
        return false;
    }
}