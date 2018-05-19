using System;
using System.IO;
using System.Collections.Generic;

namespace turing
{
    public partial class Turing
    {
        /// <summary>
        /// Attempts to load the turing object with a rules file. Returns true on success.
        /// Upon failure, no action is taken (i.e. previous rules are intact).
        /// </summary>
        /// <param name="path">path of file to load</param>
        public bool LoadRules(string path)
        {
            StreamReader f = null;
            string line;
            string[] args;

            // create a new rules object
            var rules = new Dictionary<Tuple<int, int>, Tuple<int, int, int>>();

            try
            {
                // open the file
                f = new StreamReader(path);

                // read all the rules
                while (true)
                {
                    // get a line
                    line = f.ReadLine();
                    // returns null on eof
                    if (line == null) break;
                    // empty lines are ok
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // split into args
                    args = line.Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    // must have exactly 5 entries
                    if (args.Length != 5) return false;

                    // add this rule
                    rules.Add(
                        new Tuple<int, int>(int.Parse(args[0]), int.Parse(args[1])),
                        new Tuple<int, int, int>(int.Parse(args[2]), int.Parse(args[3]), int.Parse(args[4])));
                }

                // replace old rules
                Rules = rules;

                // successful parse
                return true;
            }
            // any errors will be reported as a simple failure
            catch (Exception) { return false; }
            // make sure file is properly disposed
            finally { f?.Dispose(); }
        }

        /// <summary>
        /// Attempts to load the turing object with a data file and sets the initial state of 0. Returns true on success.
        /// Upon failure, no action is taken (i.e. previous data and state are intact).
        /// </summary>
        /// <param name="path">path of file to load</param>
        public bool LoadData(string path)
        {
            StreamReader f = null;
            string line;

            // get a clean iterator
            DataIterator root = new DataIterator() { Track = new Track(), Pos = 0 };
            root.Track.Clear();

            // create working iterator
            DataIterator iter = root;

            try
            {
                // open the file
                f = new StreamReader(path);

                // read all the rule data
                while (true)
                {
                    // get a line
                    line = f.ReadLine();
                    // returns null on eof
                    if (line == null) break;
                    // empty lines are ok
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    
                    // add as a data item
                    iter.Value = int.Parse(line);
                    ++iter;
                }

                // replace old data
                Pos = root;
                // set initial state
                State = 0;

                // successful parse
                return true;
            }
            // any errors will be reported as a simple failure
            catch (Exception) { return false; }
            // make sure file is properly disposed
            finally { f?.Dispose(); }
        }
    }
}
