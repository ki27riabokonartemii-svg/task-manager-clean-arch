using System;
using System.Threading.Tasks;
using TaskManager.Domain.Interfaces;
using TaskManager.Infrastructure.Repositories;
using TaskManager.Application.UseCases;

namespace TaskManager.Presentation.Cli;

class Program
{
    static async Task Main(string[] args)
    {
        // 1. Dependency Injection: створюємо конкретну реалізацію сховища
        ITaskRepository repository = new JsonTaskRepository();

        // 2. Впроваджуємо залежність сховища у Use Cases
        var createTaskUseCase = new CreateTaskUseCase(repository);
        var completeTaskUseCase = new CompleteTaskUseCase(repository);

        Console.WriteLine("=== Task Manager CLI ===");

        // Виконання use case створення
        var task = await createTaskUseCase.ExecuteAsync("Завершити ЛР №5", "Реалізувати Clean Architecture та Git Workflow");
        Console.WriteLine($"Створено завдання [#{task.Id}]: {task.Title}");

        // Виконання use case виконання
        await completeTaskUseCase.ExecuteAsync(task.Id);
        Console.WriteLine($"Завдання #{task.Id} позначено як виконане.");
    }
}
