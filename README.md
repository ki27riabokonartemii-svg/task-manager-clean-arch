# Task Manager (Clean Architecture & Git Workflow)

Проєкт розроблено в межах Лабораторної роботи №5 з дисципліни «Сучасні технології проєктування».

## 🏗 Архітектура застосунку (Clean Architecture)
cat << 'EOF' > README.md
# Task Manager (Clean Architecture & Git Workflow)

Проєкт розроблено в межах Лабораторної роботи №5 з дисципліни «Сучасні технології проєктування».

## 🏗 Архітектура застосунку (Clean Architecture)
```bash
cat << 'EOF' > README.md
# Task Manager (Clean Architecture & Git Workflow)

Проєкт розроблено в межах Лабораторної роботи №5 з дисципліни «Сучасні технології проєктування».

## Архітектура застосунку (Clean Architecture)


```

+-------------------------------------------------------+
|                 Presentation (CLI)                    |
|       (Program.cs - Dependency Injection Setup)       |
+--------------------------+----------------------------+
|
v
+-------------------------------------------------------+
|                     Application                       |
|        (CreateTaskUseCase, CompleteTaskUseCase)        |
+--------------------------+----------------------------+
|
v
+-------------------------------------------------------+
|                       Domain                          |
|         (TaskItem Entity, ITaskRepository)            |
+--------------------------+----------------------------+
^
|
+--------------------------+----------------------------+
|                    Infrastructure                     |
|                (JsonTaskRepository)                   |
+-------------------------------------------------------+

```

### Напрямок залежностей:
- Domain — центральний шар, не залежить від жодних інших шарів.
- Application — залежить тільки від Domain (використовує ITaskRepository через DIP).
- Infrastructure — реалізує інтерфейси з Domain.
- Presentation — збирає всі залежності в точці входу через DI.

---

## Інструкція зі збірки та запуску

### Вимоги:
- .NET SDK 8.0 або вище / GitHub Codespaces

### Запуск:
```bash
dotnet run --project src/Presentation/Cli/Program.cs

```

