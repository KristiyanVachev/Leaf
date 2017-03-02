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
                new Category { Name = "Компютърни системи", Id = 0 },
                new Category { Name = "Софтуерни системи", Id = 1 },
                new Category { Name = "Операционни системи", Id = 2 },
                new Category { Name = "Мултимедия", Id = 3 },
                new Category { Name = "Компресиране на данни", Id = 4 }
                );

            context.Questions.AddOrUpdate(
                q => q.Id,
                //Category: Компютърни системи
                new Question
                {
                    Condition = "Ще работи ли една програма по-бързо на система с 4-ядрен процесор, отколкото на система с процесор с 1 ядро и с колко (честотите на ядрата са еднакви) ?",
                    CorrectAnswer = "Зависи доколко е паралелизирана програмата",
                    FirstIncorrect = "Да, 4 пъти",
                    SecondIncorrect = "Да, 2 пъти",
                    ThirdIncorrect = "Не",
                    CategoryId = 0
                },
                new Question
                {
                    Condition = "Повреда в коя компонента може да попречи на успешното завършване на POST?",
                    CorrectAnswer = "Всички",
                    FirstIncorrect = "RAM",
                    SecondIncorrect = "Видеокарта",
                    ThirdIncorrect = "LAN карта",
                    CategoryId = 0
                },
                new Question
                {
                    Condition = "Кой от следните видове информация НЕ се съдържа в MID на един DVD диск?",
                    CorrectAnswer = "Списък сектори, в които има записи",
                    FirstIncorrect = "Капацитет",
                    SecondIncorrect = "Производител",
                    ThirdIncorrect = "Възможни скорости на записване",
                    CategoryId = 0
                },
                new Question
                {
                    Condition = "На какъв тип архитектура са базирани повечето съвременни процесори за мобилни телефони",
                    CorrectAnswer = "RISC",
                    FirstIncorrect = "CISC",
                    SecondIncorrect = "OISC",
                    ThirdIncorrect = "ZISC",
                    CategoryId = 0
                },
                new Question
                {
                    Condition = "Какъв е размерът dual-layer Blu-ray дискът?",
                    CorrectAnswer = "50 GB",
                    FirstIncorrect = "25 GB",
                    SecondIncorrect = "40 GB",
                    ThirdIncorrect = "16 GB",
                    CategoryId = 0
                },

                //Category: Софтуерни системи
                new Question
                {
                    Condition = "За справяне с кой от посочените проблеми не помагат антивирусните програми?",
                    CorrectAnswer = "DDoS",
                    FirstIncorrect = "Adware",
                    SecondIncorrect = "Trojan horses",
                    ThirdIncorrect = "Spyware",
                    CategoryId = 1
                },
                new Question
                {
                    Condition = "Системен софтуер, който е  създаден  да замени BIOS:",
                    CorrectAnswer = "UEFI",
                    FirstIncorrect = "NTLDR",
                    SecondIncorrect = "RAID",
                    ThirdIncorrect = "ACPI",
                    CategoryId = 1
                },
                new Question
                {
                    Condition = "Кое от изброените не е език за програмиране",
                    CorrectAnswer = "Geany",
                    FirstIncorrect = "Brainfuck",
                    SecondIncorrect = "Lua",
                    ThirdIncorrect = "F#",
                    CategoryId = 1
                },
                new Question
                {
                    Condition = "Кой от изброените софтуерни продукти не е IDE",
                    CorrectAnswer = "jEdit",
                    FirstIncorrect = "Visual Studio",
                    SecondIncorrect = "Eclipse",
                    ThirdIncorrect = "KDevelop",
                    CategoryId = 1
                },
                new Question
                {
                    Condition = "Кое от изброените НЕ Е design pattern?",
                    CorrectAnswer = "Inception",
                    FirstIncorrect = "Bridge",
                    SecondIncorrect = "Singleton",
                    ThirdIncorrect = "Memento",
                    CategoryId = 1
                },

                //Category: Операционни системи
                new Question
                {
                    Condition = "При коя от изброените ОС най-рано се появяват Access Control Lists",
                    CorrectAnswer = "Windows 2000",
                    FirstIncorrect = "Windows XP",
                    SecondIncorrect = "Windows 98",
                    ThirdIncorrect = "Windows 3.11",
                    CategoryId = 2
                },
                new Question
                {
                    Condition = "Коя от следните файлови системи е първоначално създадена за ползване само при файлови сървъри?",
                    CorrectAnswer = "ReFS",
                    FirstIncorrect = "NTFS",
                    SecondIncorrect = "FAT",
                    ThirdIncorrect = "Files-11",
                    CategoryId = 2
                },
                new Question
                {
                    Condition = "Какво е BIOS",
                    CorrectAnswer = "Начална Входно/Изходна Система",
                    FirstIncorrect = "Международна Билогична Система",
                    SecondIncorrect = "Система за мозъчен интерфейс",
                    ThirdIncorrect = "Количвство за едно измерение",
                    CategoryId = 2
                },
                new Question
                {
                    Condition = "Коя операционна система има точно един Menu Bar видим в даден момент, независимо от броя видими на екрана прозорци?",
                    CorrectAnswer = "Mac OS",
                    FirstIncorrect = "Windows 10",
                    SecondIncorrect = "DOS",
                    ThirdIncorrect = "KDE",
                    CategoryId = 2
                },
                new Question
                {
                    Condition = "Кое от изброените не е файлова система?",
                    CorrectAnswer = "FAT4",
                    FirstIncorrect = "FAT8",
                    SecondIncorrect = "FAT12",
                    ThirdIncorrect = "FAT16",
                    CategoryId = 2
                },
                //Category: Мултимедия
                new Question
                {
                    Condition = "Кой от аудио форматите е lossless?",
                    CorrectAnswer = "FLAC",
                    FirstIncorrect = "MP3",
                    SecondIncorrect = "OGG",
                    ThirdIncorrect = "AAC",
                    CategoryId = 3
                },
                new Question
                {
                    Condition = "Какво означава известният аудио формат MP3?",
                    CorrectAnswer = "MPEG-2 Audio Layer III",
                    FirstIncorrect = "MPEG-3 Audio Layer III",
                    SecondIncorrect = "Music Presentation Level 3",
                    ThirdIncorrect = "MPEG-Encoding Version 3",
                    CategoryId = 3
                },
                new Question
                {
                    Condition = "Какво е значението на символа ‘p’ в описания на качеството на видео от порядъка на 1080p?",
                    CorrectAnswer = "progressive",
                    FirstIncorrect = "pixels",
                    SecondIncorrect = "perceived",
                    ThirdIncorrect = "points",
                    CategoryId = 3
                },
                new Question
                {
                    Condition = "Коя от следните програми може да бъде използвана за визуално записване на вашите действия на десктопа?",
                    CorrectAnswer = "Camtasia Studio",
                    FirstIncorrect = "Visual Studio 2013",
                    SecondIncorrect = "Skype",
                    ThirdIncorrect = "3D Studio Max",
                    CategoryId = 3
                },
                new Question
                {
                    Condition = "Кой от следните аудио формати не се поддържа от нито един от съвременните уеб браузъри (като част от HTML5 audio тага)?",
                    CorrectAnswer = "Flac",
                    FirstIncorrect = "AAC",
                    SecondIncorrect = "MP3",
                    ThirdIncorrect = "WAV PCM",
                    CategoryId = 3
                },
                //Category: Компресия на данни
                new Question
                {
                    Condition = "Кое от следните алгоритми НЕ се използва за компресиране на данни ?",
                    CorrectAnswer = "MPRT",
                    FirstIncorrect = "MP3",
                    SecondIncorrect = "DEFLATE",
                    ThirdIncorrect = "PAQ",
                    CategoryId = 4
                },
                new Question
                {
                    Condition = "Кое от изброените е име на кодиране, подходящо за текстови файлове",
                    CorrectAnswer = "Хъфманово",
                    FirstIncorrect = "Симетрично",
                    SecondIncorrect = "Асиметрично",
                    ThirdIncorrect = "Фрактално",
                    CategoryId = 4
                },
                new Question
                {
                    Condition = "Кой от изброените видове компресиране на данни може да доведе до загуба на данни?",
                    CorrectAnswer = "MPEG-2 видео кодек",
                    FirstIncorrect = "LZ77",
                    SecondIncorrect = "CTW",
                    ThirdIncorrect = "LZW.JPEG",
                    CategoryId = 4
                },
                new Question
                {
                    Condition = "Кой от изброените по – долу не е файлов стандарт за компресиране/декомпресиране на изображения?",
                    CorrectAnswer = "TXT",
                    FirstIncorrect = "JPEG",
                    SecondIncorrect = "TIFF",
                    ThirdIncorrect = "PNG",
                    CategoryId = 4
                },
                new Question
                {
                    Condition = "Кой от следните алгоритми за компресиране НЕ е алгоритъм за речниково кодиране?",
                    CorrectAnswer = "Хъфманово",
                    FirstIncorrect = "LZSS",
                    SecondIncorrect = "LZ-77",
                    ThirdIncorrect = "FAT16",
                    CategoryId = 4
                }

                );
        }
    }
}
