using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ
{
    class PriorQueue<T>
    {
        private List<T> _arrList = new List<T>();
        private List<int> _priorList = new List<int>();
        public int Count { get; private set; }

        public PriorQueue() { Count = 0; }

        public bool IsEmpty()//Проверяет очередь на пустоту
        {
            return Count == 0;
        }

        public void Enqueue(T element, int prior)//Добавляет указанный элемент с соответствующим приоритетом
        {
            _arrList.Add(element);
            _priorList.Add(prior);
            Count++;
        }

        public void Dequeue()//Удаляет минимальный элемент из PriorQueue, то есть элемент с наименьшим значением приоритета.
        {
            if (!IsEmpty())
            {
                int minPrior = _priorList[0];
                foreach (var item in _priorList)
                    if (item > minPrior) minPrior = item;

                for (int i = 0; i < Count; i++)
                    if (_priorList[i] == minPrior)
                    {
                        _arrList.Remove(_arrList[i]);
                        _priorList.Remove(_priorList[i]);
                        Count--;
                        break;
                    }
            }
        }

        public void Show()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(_arrList[i] + " " + _priorList[i]);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1. Создать массив типа ArrayList, наполните разными данными (int, decimal, float и тп.) и отсортируйте каждый тип с помощью пользовательского интерфейса IComparer
             * 2. Создайте generic класс Очередь с приоритетами. Реализуйте стандартные методы и свойства для работы очереди с приоритетами. (пример https://en.wikipedia.org/wiki/Priority_queue)
             */
            PriorQueue<string> priorQueue = new PriorQueue<string>();
            priorQueue.Enqueue("Hello", 1);
            priorQueue.Enqueue("name", 3);// Минимальный приоритет
            priorQueue.Enqueue("my", 2);

            priorQueue.Show();
            Console.WriteLine();

            priorQueue.Dequeue();

            priorQueue.Show();
            Console.WriteLine();

            priorQueue.Dequeue();

            priorQueue.Show();
            Console.WriteLine();
        }
    }
}
