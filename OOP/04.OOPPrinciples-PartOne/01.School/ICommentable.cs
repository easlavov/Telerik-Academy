// Students, classes, teachers and disciplines could have optional comments (free text block).

using System;

public interface ICommentable
{
    void SetComment(string comment);
    string GetComment();
}