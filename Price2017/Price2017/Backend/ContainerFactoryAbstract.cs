using System.Collections.Generic;

namespace Price2017.Backend
{
    abstract class ContainerFactoryAbstract
    {
        public List<string> FilePaths { get; protected set; }

        public abstract void GetContainer(TransactionContainerAbstract container, string filePath);



        public ContainerFactoryAbstract()
        {
            FilePaths = new List<string>();
        }
    }
}