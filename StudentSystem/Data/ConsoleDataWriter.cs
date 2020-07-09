namespace StudentSystemCatalog.Data
{
    using System;

    class ConsoleDataWriter : IDataWriter
    {
        public void Write(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
