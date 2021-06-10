using System;
using System.Collections.Generic;

namespace ImplementationOfASimplifiedGenericStack {
    class Program {
        static void Main(string[] args) {
            var stos = new Stos<char>();
            if ( stos is ImplementationOfASimplifiedGenericStack.IStos<char> )
                Console.WriteLine("Stos<T> implemented");
            else
                Console.WriteLine("Stos<T> not implemented");
        }
    }

    public interface IStos<T> {
        //w interfejsie nie deklaruje się konstruktora

        //wstawia element typu T na stos
        void Push(T value);

        //zwraca szczytowy element stosu
        T Peek { get; }

        //zdejmuje szczytowy element ze stosu i go zwraca
        T Pop();

        //zwraca liczbę elementów na stosie
        int Count { get; }

        //zwraca true, jeśli stos jest pusty, a false w przeciwnym przypadku
        bool IsEmpty { get; }

        //opróżnia stos
        void Clear();

        //kopiuje (klonuje, płytka kopia) i eksportuje stos do tablicy
        T[] ToArray();
    }

    public class StosEmptyException : Exception {
        public StosEmptyException() { }
        public StosEmptyException(string message) : base(message) { }
        public StosEmptyException(string message, Exception inner) : base(message, inner) { }
    }

    public class Stos<T> : IStos<T> {
        private List<T> list;

        public Stos() {
            list = new List<T>();
        }

        public void Push(T value) {
            list.Add(value);
        }

        public T Peek {
            get {
                if (list.Count == 0) {
                    throw new StosEmptyException();
                }

                return list[list.Count - 1];
            }
        }

        public T Pop() {
            if (list.Count == 0) {
                throw new StosEmptyException();
            }

            var valueToRemove = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return valueToRemove;
        }

        public int Count => list.Count;
        public bool IsEmpty {
            get {
                if (list.Count == 0) {
                    return true;
                }

                return false;
            }
        }

        public void Clear() {
            list.Clear();
        }

        public T[] ToArray() {
            return list.ToArray();
        }
    }
}