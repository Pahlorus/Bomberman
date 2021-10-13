using System;
using System.Collections.Generic;

public enum Tag : int
{
    UNKNOWN = -1,
    UNDEFINED = 0,
    OTHER = 1,
    WALL = 2,
    OBSTACLE = 3,
    HERO = 4,
    ENEMY = 5,
    ENEMYSHIELD = 6,
    ENEMYBULLET = 7,
    CHARACTERBULLET = 8
}

public static class CustomTag  
{
    private static readonly Dictionary<string, Tag> _dictionary;

    static CustomTag()
    {
        _dictionary = new Dictionary<string, Tag>();
        var type = typeof(Tag);
        foreach (Tag tag in Enum.GetValues(type))
        {
            _dictionary.Add(Enum.GetName(type, tag), tag);
        }
    }

    public static Tag GetTag(this string tagString)
    {
        if (!_dictionary.TryGetValue(tagString, out var tag))
            tag = Tag.UNKNOWN;
        return tag;
    }
}
