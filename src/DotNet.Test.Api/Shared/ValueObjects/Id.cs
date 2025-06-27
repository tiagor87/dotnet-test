using TheNoobs.ValueObjects.Abstractions;

namespace DotNet.Test.Api.Shared.ValueObjects;

public class Id : ValueObject<string>
{
    public Id() : base(Guid.CreateVersion7().ToString())
    {
    }
    
    public Id(string value) : base(value)
    {
    }
    
    public static implicit operator string(Id id) => id.Value;
    
    public static implicit operator Id(string id) => new(id);
}