using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;


namespace Price2017.Backend
{
    class ContainerFactory : ContainerFactoryAbstract
    {
        protected const int AttributeNumber = 16;


        

        public override void GetContainer(ITransactionContainer container, string filePath)
        {
            if (!FilePaths.Contains(filePath))
                FilePaths.Add(filePath);
            else
                throw new Exception("This file has already been loaded");

            container.Clear();

            foreach (var currentPath in FilePaths)
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
