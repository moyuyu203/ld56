using System.Collections.Generic;

public class SimplePriorityQueue<T> {
    private List<(T Item, float Priority)> _elements = new List<(T, float)>();

    public int Count => _elements.Count;

    public void Enqueue(T item, float priority) {
        _elements.Add((item, priority));
    }

    public T Dequeue() {
        var bestIndex = 0;
        for (var i = 1; i < _elements.Count; i++) {
            if (_elements[i].Priority < _elements[bestIndex].Priority) {
                bestIndex = i;
            }
        }

        var bestItem = _elements[bestIndex].Item;
        _elements.RemoveAt(bestIndex);
        return bestItem;
    }
}
