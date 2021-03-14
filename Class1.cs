    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Threading;

    namespace ClassLibrary1
    {
        public class Dict
        {
        public static ConcurrentDictionary<string, int> CountWords(string path)
        {
            var result = new ConcurrentDictionary<string, int>();
            var line = File.ReadAllText(path);
            var words = line.Split(new[] { ' ', '-', ':', '.', '"', '!', '?', ',', ';', ')', '(', '\\', '/', '<', '>', '*', '[', ']'}, StringSplitOptions.RemoveEmptyEntries);
            Thread thread = new Thread(Meth1);
            thread.Start();
            foreach (var word in words)
                {
                    result.TryAdd(word, 0);
                }
            return result;

            void Meth1()
            {
                foreach (var word in words)
                {
                    result.AddOrUpdate(word, 1, (_, x) => x + 1);
                }
            }
       
        }
        }
    }
