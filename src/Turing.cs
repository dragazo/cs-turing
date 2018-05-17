using System;
using System.Collections.Generic;

namespace turing
{
    public partial class Turing
    {
        /// <summary>
        /// Value filled in for newly-created memory
        /// </summary>
        private const int ZeroValue = 0;

        /// <summary>
        /// Represents a block of memory in a turing machine
        /// </summary>
        internal class Track
        {
            public Track Prev = null, Next = null;
            public int[] Data = new int[64];

            /// <summary>
            /// Zeroes out the data
            /// </summary>
            internal void Clear()
            {
                for (int i = 0; i < Data.Length; ++i) Data[i] = ZeroValue;
            }
        }

        /// <summary>
        /// An iterator to a value in a turing machine's memory
        /// </summary>
        public class DataIterator
        {
            internal Track Track = null;
            internal int Pos = 0;

            internal DataIterator() { }

            /// <summary>
            /// Gets/sets the value pointed to by this iterator
            /// </summary>
            public int Value
            {
                get
                {
                    // get value if in range, otherwise get an imaginary zero value
                    return Pos >= 0 && Pos < Track.Data.Length ? Track.Data[Pos] : ZeroValue;
                }
                set
                {
                    // while we're out of bounds to the left
                    while (Pos < 0)
                    {
                        // link in a new track on the left
                        Track t = new Track() { Prev = null, Next = Track };
                        t.Clear();

                        // go into new track
                        Track = Track.Prev = t;
                        Pos += t.Data.Length;
                    }
                    // while we're out of bounds to the right
                    while (Pos >= Track.Data.Length)
                    {
                        // link in a new track on the right
                        Track t = new Track() { Prev = Track, Next = null };
                        t.Clear();

                        // go into new track
                        Pos -= Track.Data.Length;
                        Track = Track.Next = t;
                    }

                    // now we have a valid iterator: set the value
                    Track.Data[Pos] = value;
                }
            }

            public static DataIterator operator +(DataIterator iter, int offset)
            {
                // create new iterator
                DataIterator res = new DataIterator() { Track = iter.Track, Pos = iter.Pos + offset };

                // do any collapsing we can
                while (res.Pos < 0 && res.Track.Prev != null)
                {
                    res.Track = res.Track.Prev;
                    res.Pos += res.Track.Data.Length;
                }
                while (res.Pos >= res.Track.Data.Length && res.Track.Next != null)
                {
                    res.Pos -= res.Track.Data.Length;
                    res.Track = res.Track.Next;
                }

                // return new iterator
                return res;
            }
            public static DataIterator operator +(int offset, DataIterator iter) => iter + offset;
            public static DataIterator operator -(DataIterator iter, int offset) => iter - (-offset);
        }

        // -----------------------------------

        /// <summary>
        /// Gets/sets the iterator to the execution position
        /// </summary>
        public DataIterator Pos { get; set; } = new DataIterator();

        /// <summary>
        /// Gets the current state of the 
        /// </summary>
        public int State { get; set; } = 0;

        /// <summary>
        /// Holds the rules used by this turing machine. (state, in) -> (state, out, off)
        /// </summary>
        private Dictionary<Tuple<int, int>, Tuple<int, int, int>> Rules = new Dictionary<Tuple<int, int>, Tuple<int, int, int>>();

        // -----------------------------------

        public Turing()
        {
            ClearData();
        }

        /// <summary>
        /// Removes all the data from the machine
        /// </summary>
        public void ClearData()
        {
            // get a new track root
            Pos.Track = new Track();
            Pos.Pos = 0;

            // zero it
            Pos.Track.Clear();
        }

        /// <summary>
        /// Adds a new rule to the machine. Returns true on success (fails if there's a conflicting rule).
        /// </summary>
        /// <param name="currentState">the current state that is required to exeute the rule</param>
        /// <param name="input">the current input that is required to execute the rule</param>
        /// <param name="nextState">the state to go to after executing the rule</param>
        /// <param name="output">the value to write when executing the rule</param>
        /// <param name="offset">the amount to offset the read cursor by after executing the rule</param>
        public bool AddRule(int currentState, int input, int nextState, int output, int offset)
        {
            // create the key
            var key = new Tuple<int, int>(currentState, input);

            // make sure we don't redefine a rule
            if (Rules.ContainsKey(key)) return false;

            // add the rule
            Rules.Add(key, new Tuple<int, int, int>(nextState, output, offset));
            return true;
        }
        /// <summary>
        /// Removes all the rules from the machine
        /// </summary>
        public void ClearRules() => Rules.Clear();

        /// <summary>
        /// Applies a single rule to the machine. Returns true if a rule was successfully executed (failure implies end of execution)
        /// </summary>
        public bool Tick()
        {
            // get the rule to execute
            if (!Rules.TryGetValue(new Tuple<int, int>(State, Pos.Value), out var rule)) return false;

            // apply the rule
            State = rule.Item1;
            Pos.Value = rule.Item2;
            Pos += rule.Item3;

            return true;
        }
    }
}
