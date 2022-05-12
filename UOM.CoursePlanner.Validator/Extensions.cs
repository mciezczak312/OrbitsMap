namespace UOM.CoursePlanner.Validator;

public static class Extensions
{
    // ref: https://stackoverflow.com/a/49191033
    public static void Deconstruct<T>(this IList<T> list, out T first, out IList<T> rest) {
        first = list.Count > 0 ? list[0] : default(T);
        rest = list.Skip(1).ToList();
    }
    
    public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out IList<T> rest) {
        first = list.Count > 0 ? list[0] : default(T); // or throw
        second = list.Count > 1 ? list[1] : default(T); // or throw
        rest = list.Skip(2).ToList();
    }
    
    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
        TKey key, Func<TValue> valueCreator)
    {
        TValue value;
        if (!dictionary.TryGetValue(key, out value))
        {
            value = valueCreator();
            dictionary.Add(key, value);
        }
        return value;
    }

    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
        TKey key) where TValue : new()
    {
        return dictionary.GetOrAdd(key, () => new TValue());
    }
}