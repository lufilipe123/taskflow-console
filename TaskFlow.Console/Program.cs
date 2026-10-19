internal static class Program
{
    private static void Main()
    {
        var manager = new TaskManager();
        var isRunning = true;

        while (isRunning)
        {
            Console.WriteLine();
            Console.WriteLine("=== Gerenciador de tarefas ===");
            Console.WriteLine("1. Adicionar tarefa");
            Console.WriteLine("2. Listar tarefas");
            Console.WriteLine("3. Concluir tarefa");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            var choice = Console.ReadLine();
            if (choice == null)
            {
                break;
            }

            switch (choice.Trim())
            {
                case "1":
                    AddTask(manager);
                    break;
                case "2":
                    ListTasks(manager);
                    break;
                case "3":
                    CompleteTask(manager);
                    break;
                case "0":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    private static void AddTask(TaskManager manager)
    {
        Console.Write("Título da tarefa: ");
        var title = Console.ReadLine();
        if (title == null)
        {
            return;
        }

        try
        {
            var task = manager.AddTask(title);
            Console.WriteLine($"Tarefa adicionada: {task.Title} (ID: {task.Id})");
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private static void ListTasks(TaskManager manager)
    {
        if (manager.Tasks.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa cadastrada.");
            return;
        }

        foreach (var task in manager.Tasks)
        {
            var status = task.IsCompleted ? "Concluída" : "Pendente";
            Console.WriteLine($"[{status}] {task.Title} (ID: {task.Id})");
        }
    }

    private static void CompleteTask(TaskManager manager)
    {
        Console.Write("ID da tarefa: ");
        var input = Console.ReadLine();
        if (input == null)
        {
            return;
        }

        if (!Guid.TryParse(input, out var id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        if (manager.CompleteTask(id))
        {
            Console.WriteLine("Tarefa concluída.");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada.");
        }
    }
}
