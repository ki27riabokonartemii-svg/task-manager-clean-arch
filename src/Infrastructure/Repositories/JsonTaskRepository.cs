using System.Text.Json;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Infrastructure.Repositories;

public class JsonTaskRepository : ITaskRepository
{
    private readonly string _filePath;

    public JsonTaskRepository(string filePath = "tasks.json")
    {
        _filePath = filePath;
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }
    }

    private async Task<List<TaskItem>> LoadTasksAsync()
    {
        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }

    private async Task SaveTasksAsync(List<TaskItem> tasks)
    {
        var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(_filePath, json);
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        var tasks = await LoadTasksAsync();
        return tasks.FirstOrDefault(t => t.Id == id);
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await LoadTasksAsync();
    }

    public async Task AddAsync(TaskItem task)
    {
        var tasks = await LoadTasksAsync();
        int newId = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
        task.Id = newId;
        tasks.Add(task);
        await SaveTasksAsync(tasks);
    }

    public async Task UpdateAsync(TaskItem task)
    {
        var tasks = await LoadTasksAsync();
        var index = tasks.FindIndex(t => t.Id == task.Id);
        if (index != -1)
        {
            tasks[index] = task;
            await SaveTasksAsync(tasks);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var tasks = await LoadTasksAsync();
        tasks.RemoveAll(t => t.Id == id);
        await SaveTasksAsync(tasks);
    }
}