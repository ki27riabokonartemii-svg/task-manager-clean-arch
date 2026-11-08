using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.UseCases;

public class CompleteTaskUseCase
{
    private readonly ITaskRepository _repository;

    public CompleteTaskUseCase(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task != null)
        {
            task.IsCompleted = true;
            await _repository.UpdateAsync(task);
        }
    }
}
