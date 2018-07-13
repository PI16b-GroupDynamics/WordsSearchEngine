using System.Collections.Generic;
using System.Linq;

namespace WordsSearchEngine
{
    /// <inheritdoc />
    /// <summary>
    /// Представляет стек переменного размера, не превосходящего десять элементов,
    /// которые являются уникальными.
    /// </summary>
    public class AdvancedStack : LinkedList<string>
    {
        public AdvancedStack()
        {
            
        }
        public AdvancedStack(IEnumerable<string> collection) : base(collection)
        {
            while (Remove("")) {}
        }

        /// <summary>
        /// Удаляет и возвращает объект в верхней части AdvancedStack.
        /// </summary>
        /// <returns>Объект в верхней части AdvancedStack.</returns>
        public string Pop()
        {
            LinkedList<string> j = new LinkedList<string>(this);
            var first = First.Value;
            RemoveFirst();
            return first;
        }

        /// <summary>
        /// Вставляет объект как верхний элемент стека AdvancedStack&lt;string&gt;,
        /// при этом, если указанное значение не являляется уникальным, удаляет предыдущее его вхождение.
        /// Также метод ограничивает количество элементов стека, при превышении числа элементов десяти,
        /// элемент с хвоста удаляется.
        /// </summary>
        /// <param name="item">Объект, вставляемый в AdvancedStack&lt;string&gt;.</param>
        public void PushUnique(string item)
        {
            if (Contains(item)) Remove(item);
            if (Count == 10) RemoveLast();
            AddFirst(item);
        }
    }
}
