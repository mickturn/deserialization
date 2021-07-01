# Private fields deserialization

Json objects look like this:

`
{
    "id" : 1,
    "name" : "test"
}
`

Here, the private fields are being populated in the constructor allowing complete object deserialization.

But it works only when we add accessors that are not themselves serialized... Without them you get:
> 'Each parameter in constructor 'Void .ctor(UInt16, System.String)' on type 'Experiments.Test' must bind to an object property or field on deserialization. Each parameter name must match with a property or field on the object. The match can be case-insensitive.'

Why not allowing private fields initialization in constructor without the need of these pretty useless accessors?