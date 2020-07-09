namespace StudentSystemCatalog
{
    using Commands;
    using Students;
    using Data;

    public class Engine
    {
        private commandParser commandParser;
        private StudentSystem studentSystem;

        private IDataReader dataReader;
        private IDataWriter dataWriter;
        //private Func<string> readInput;

        public Engine(
            commandParser commandParser, 
            StudentSystem studentSystem,
            //Func<string> readInput
            IDataReader dataReader,
            IDataWriter dataWriter
            )
        {
            this.commandParser = commandParser;
            this.studentSystem = studentSystem;
            //this.readInput = readInput;
            this.dataReader = dataReader;
            this.dataWriter = dataWriter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var data = this.dataReader.Read();

                    var command = commandParser.Parse(data);

                    if (command.Name == "Create")
                    {
                        var name = command.Arguments[0];
                        var age = int.Parse(command.Arguments[1]);
                        var grade = double.Parse(command.Arguments[2]);

                        studentSystem.Add(name, age, grade);
                    }
                    else if (command.Name == "Show")
                    {
                        var name = command.Arguments[0];

                        var student = studentSystem.Get(name);

                        //Console.WriteLine(student);
                        this.dataWriter.Write(student);
                    }
                    else if (command.Name == "Exit")
                    {
                        break;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
