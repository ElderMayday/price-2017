using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;


namespace Price2017.Backend
{
    class ContainerFactory : IContainerFactory
    {
        public const int AttributeNumber = 16;

        public HashSet<string> filePaths;

        public ContainerFactory()
        {
            filePaths = new HashSet<string>();
        }

        public void GetContainer(ITransactionContainer container, string filePath)
        {
            filePaths.Add(filePath);

            foreach (var currentPath in filePaths)
            {
                var lines = File.ReadLines(currentPath);

                foreach (string s in lines)
                {
                    string[] split = s.Split(',');

                    if (split.Length != AttributeNumber)
                        throw new Exception("Column number mismatch");

                    container.AddTransaction(long.Parse(split[0]),
                        DateTime.ParseExact(split[1], "HH:mm:ss", CultureInfo.InvariantCulture),
                        split[4],
                        double.Parse(split[5]),
                        double.Parse(split[7]),
                        split[15] == "B" ? true : false);
                }
            }
        }
    }
}
