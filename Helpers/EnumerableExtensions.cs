using System.Runtime.CompilerServices;




namespace TecDocStorageFlattener.Helpers;

public static class EnumerableExtensions
    {
        public static async IAsyncEnumerable<T[]> Chunk<T>(this IAsyncEnumerable<T> source, int size, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            List<T> chunk = new(size);
            await foreach (var item in source)
            {
                chunk.Add(item);
                if (chunk.Count >= size)
                {
                    var chunkArray = chunk.ToArray();
                    chunk.Clear();
                    yield return chunkArray;
                }
            }
            if (chunk.Count > 0)
                yield return chunk.ToArray();
        }
    }



