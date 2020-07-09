namespace StudentSystemCatalog.Data
{
    using System;

    public class ConsoleDataReader : IDataReader
    {
        public string Read()
        {
            //throw new System.NotImplementedException();
            return Console.ReadLine();
        }
    }
}
