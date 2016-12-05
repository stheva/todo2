namespace TodoList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TodoList.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TodoList.Models.TodoListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TodoList.Models.TodoListContext context)
        {
            context.Assignments.AddOrUpdate(x => x.Id,
                new Assignment()
                {
                    Id = 1,
                    Description = "Ringe Jean Claude",
                    Completed = false
                },
                new Assignment()
                {
                    Id = 2,
                    Description = "Lage middag",
                    Completed = false
                },
                new Assignment()
                {
                    Id = 3,
                    Description = "Fikse bilen",
                    Completed = false
                },
                new Assignment()
                {
                    Id = 4,
                    Description = "Bestille ferietur",
                    Completed = false
                },
                new Assignment()
                {
                    Id = 5,
                    Description = "Ro budsjettet i land",
                    Completed = false
                },
                new Assignment()
                {
                    Id = 6,
                    Description = "Bestille ferietur",
                    Completed = false
                }
            );
        }
    }
}
