using System.Collections.Generic;

namespace WordsSearchEngine
{
    public static class StackExtensions
    {
        /// <summary>
        /// Вставляет объект как верхний элемент стека Stack&lt;string&gt;,
        /// при этом, если указанное значение не являляется уникальным, удаляет предыдущее его вхождение.
        /// Также метод ограничивает количество элементов стека, при превышении числа элементов десяти,
        /// элемент с хвоста удаляется.
        /// </summary>
        /// <param name="stack">Стек c уникальными элементами.</param>
        /// <param name="item">Объект, вставляемый в Stack&lt;string&gt;.</param>
        public static void PushUnique(this Stack<string> stack, string item)
        {
            if(stack.Contains(item))
            {
                var temp = new Stack<string>();
                string value;
                while ((value = stack.Pop()) != item)
                    temp.Push(value);
                while (temp.Count > 0 && (value = temp.Pop()) != null)
                    stack.Push(value);
            }
            stack.Push(item);
        }

    }
}
