using System;
using System.Collections.Generic;
using System.Collections;

namespace MyLinkedList
{
    class Program
    {
        public class Item<T>
        {
            public T Data { get; set; }

            public Item<T> Next { get; set; }
            
            // конструктор
            public Item(T data) 
            {
                if (data == null)
                {
                    throw new ArgumentNullException();
                }
                Data = data;
            }
        }

        public class LinkedList<T> : IEnumerable<T>
        {
            private Item<T> _head = null;
            private Item<T> _tail = null;
            public int Count { get; private set; } = 0;

            public void Add(T data)
            {
                var item = new Item<T>(data);
                if (_head == null)
                {
                    _head = item;
                }
                else
                {
                    _tail.Next = item;
                }
                _tail = item;
                Count++;
            }

            public void AddByPosition (T data, int position)
            {
                if (position > Count + 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                var item = new Item<T>(data);
                var current = _head;
                Item<T> previous = null;
                int i = 0;
                while (i != position + 1)
                {
                    i++;
                    if (i == position)
                    {
                        // если элемент находится в середине или в конце списка
                        if (previous != null)
                        {
                            previous.Next = item;
                            item.Next = current;
                            // если это был последний элемент списка
                            if (current == null)
                            {
                                _tail = item;
                            }
                        }
                        // если элемент находится в начале списка
                        else
                        {
                            item.Next = _head;
                            _head = item;
                        }
                        Count++;
                        break;
                    }
                    previous = current;
                    current = current.Next;
                }

            }

            public void DeleteByPosition(int position)
            {
                if (position > Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                int i = 0;
                var current = _head;
                Item<T> previous = null;

                while (i != position + 1) 
                {
                    i++;
                    if (i == position)
                    {
                        // если элемент находится в середине или в конце списка
                        if (previous != null)
                        {
                            previous.Next = current.Next;
                            if (current.Next == null)
                            {
                                _tail = previous;
                            }
                        }
                        // если элемент находится в начале списка
                        else
                        {
                            _head = _head.Next;
                            // если список оказался пустым
                            if (_head == null)
                            {
                                _tail = null;
                            }
                        }
                        Count--;
                        break;
                    }
                    previous = current;
                    current = current.Next;
                }
            }
            
            public bool IfNull()
            {
                if (Count == 0)
                // возможно надо if (_head == null && _tail == null &&  _count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            public void GetByPosition(int position)
            {
                if (position > Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                int i = 1;
                foreach (var item in this)
                {
                    if (i == position)
                    {
                        Console.WriteLine(item);
                        break;
                    }
                    i++;
                }
            }
            
            public IEnumerator<T> GetEnumerator()
            {
                var current = _head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }
        }

        static void Main(string[] args)
        {
            var list = new LinkedList<string>();
            Console.WriteLine($"Is our list empty now? {list.IfNull()}");
            Console.WriteLine("");

            list.Add("first");
            list.Add("second");
            list.Add("third");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine($"Lets get value of element in position 2: ");
            list.GetByPosition(2);
            Console.WriteLine();

            Console.WriteLine($"Is our list empty now? {list.IfNull()}");
            Console.WriteLine("");

            Console.WriteLine($"Lets add element by position 4 ");
            list.AddByPosition("fourth", 4);
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine($"Lets get size of our list: {list.Count}");
            Console.WriteLine();

            Console.WriteLine($"Lets delete element by position 4 ");
            list.DeleteByPosition(4);
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine($"Lets delete element by position 2 ");
            list.DeleteByPosition(2);
            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
