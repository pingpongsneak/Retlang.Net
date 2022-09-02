namespace Retlang.Net.Core;

internal static class Lists
{
    public static void Swap(ref List<Action> a, ref List<Action> b)
    {
        (a, b) = (b, a);
    }
}