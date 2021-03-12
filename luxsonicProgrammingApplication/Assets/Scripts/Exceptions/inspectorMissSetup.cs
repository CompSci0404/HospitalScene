using System;


/// <summary>
/// <c>InspectorMissSetup</c>
/// 
/// pre: a script using inspector data.
/// 
/// post: Throws a exception stating that a variable configured on the inspector is incorrect.
/// 
/// <author>Matt Radke</author>
/// </summary>
public class InspectorMissSetup : Exception
{
    public InspectorMissSetup() :
        base() 
    { 
    }

    public InspectorMissSetup(string message) 
        : base(message) 
    {
    }

    public InspectorMissSetup(string message, Exception inner) 
        : base(message, inner) 
    { 
    }

}
