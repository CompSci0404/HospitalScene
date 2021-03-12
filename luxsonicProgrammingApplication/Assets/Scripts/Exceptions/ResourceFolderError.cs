using System;

/// <summary>
/// <c>ResourceFolderError</c>
/// pre: any script that is accessing resource folder.
/// 
/// post: exception if no resources are found.  
/// <author>By Matt Radke</author>
/// </summary>

public class ResourceFolderError : Exception
{
    public ResourceFolderError()
         : base()
    {
    }

    public ResourceFolderError(string message)
        : base(message)
    {
    }

    public ResourceFolderError(string message, Exception inner)
        : base(message, inner)
    {
    }


}
