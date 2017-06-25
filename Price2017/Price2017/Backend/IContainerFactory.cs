namespace Price2017.Backend
{
    interface IContainerFactory
    {
        void GetContainer(ITransactionContainer container, string filePath);
    }
}