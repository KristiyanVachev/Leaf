using System.Linq;
using Leaf.Models;

namespace Leaf.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Leaf.Data.LeafDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Leaf.Data.LeafDbContext";
        }

        protected override void Seed(LeafDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            context.Categories.AddOrUpdate(
                c => c.Id,
                new Category { Name = "Компютърни системи", Id = 0 }
            );

            context.Questions.AddOrUpdate(
                q => q.Id,
                //Category: Компютърни системи
                new Question
                {
                    Id = 0,
                    Condition = "Повреда в коя компонента може да попречи на успешното завършване на POST?",
                    Answers =
                    {
                        new Answer {Id = 0, Content = "Всички", IsCorrect = true, QuestionId = 0},
                        new Answer {Id = 1, Content = "RAM", IsCorrect = false, QuestionId = 0},
                        new Answer {Id = 2, Content = "Видеокарта", IsCorrect = false, QuestionId = 0 },
                        new Answer {Id = 3, Content = "LAN карта", IsCorrect = false, QuestionId = 0},
                    },
                    CategoryId = 0
                },
                new Question
                {
                    Id = 1,
                    Condition = "Ще работи ли една програма по-бързо на система с 4-ядрен процесор, отколкото на система с процесор с 1 ядро и с колко (честотите на ядрата са еднакви) ?",
                    Answers =
                    {
                        new Answer {Id = 4, Content = "Зависи доколко е паралелизирана програмата", IsCorrect = true, QuestionId = 1},
                        new Answer {Id = 5, Content = "Да, 4 пъти", IsCorrect = false, QuestionId = 1},
                        new Answer {Id = 6, Content = "Да, 2 пъти", IsCorrect = false, QuestionId = 1 },
                        new Answer {Id = 7, Content = "Не", IsCorrect = false, QuestionId = 1},
                    },
                    CategoryId = 0
                },
                new Question
                {
                    Id = 2,
                    Condition = "Кой от следните видове информация НЕ се съдържа в MID на един DVD диск?",
                    Answers =
                    {
                        new Answer {Id = 8, Content = "писък сектори, в които има записи", IsCorrect = true, QuestionId = 2},
                        new Answer {Id = 9, Content = "Капацитет", IsCorrect = false, QuestionId = 2},
                        new Answer {Id = 10, Content = "Производител", IsCorrect = false, QuestionId = 2 },
                        new Answer {Id = 11, Content = "Възможни скорости на записване", IsCorrect = false, QuestionId = 2},
                    },
                    CategoryId = 0
                }
            );

            //context.Tests.AddOrUpdate(
            //        t => t.Id,
            //        new Test
            //        {
            //            AnsweredQuestions =
            //            {
            //                new AnsweredQuestion
            //                {
            //                    QuestionId = 0,
            //                    AnswerId = 1
            //                },
            //                new AnsweredQuestion
            //                {
            //                    QuestionId = 2,
            //                    AnswerId = 11
            //                }
            //            },
            //            IsFinished = false
            //        }
            //    );

            context.SaveChanges();
        }
    }
}
