using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Quizpr4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Ticket> Tickets { get; } = new ObservableCollection<Ticket>();
        private Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            GenerateRandomTickets();
            ticketListView.ItemsSource = Tickets;
        }

        public class Option
        {
            public string OptionText { get; set; }
            public bool IsCorrect { get; set; }
        }

        public class Question
        {
            public string Text { get; set; }
            public List<Option> Options { get; set; }
        }

        public class Ticket
        {
            public string Name { get; set; }
            public List<Question> Questions { get; set; }
        }

        private void GenerateRandomTickets()
        {
            List<Question> questionPool = CreateQuestionPool(); // Создаем пул вопросов
            int totalQuestions = questionPool.Count;

            for (int ticketNumber = 1; ticketNumber <= 5; ticketNumber++)
            {
                var ticket = new Ticket
                {
                    Name = $"Билет {ticketNumber}",
                    Questions = new List<Question>()
                };

                for (int questionNumber = 1; questionNumber <= 5; questionNumber++)
                {
                    if (questionPool.Count == 0)
                    {
                        // Если вопросов больше нет, добавить обработку здесь.
                        break;
                    }

                    int randomIndex = random.Next(questionPool.Count);
                    var selectedQuestion = questionPool[randomIndex];
                    ticket.Questions.Add(selectedQuestion);

                    questionPool.RemoveAt(randomIndex); // Удаляем вопрос из пула
                }

                Tickets.Add(ticket);
                
            }
        }

        private List<Question> CreateQuestionPool()
        {
            // Создайте здесь ваши вопросы и варианты ответов
            List<Question> questionPool = new List<Question>();

            // Пример создания вопроса:
            Question question1 = new Question
            {
                Text = "Столиция Франции",
                Options = new List<Option>
            {
            new Option { OptionText = "Москва", IsCorrect = false },
            new Option { OptionText = "Берлин", IsCorrect = false },
            new Option { OptionText = "Лондон", IsCorrect = false },
            new Option { OptionText = "Париж", IsCorrect = true } // Правильный ответ
            }
            };

            // Добавьте вопросы в пул
            questionPool.Add(question1);

            Question question2 = new Question
            {
                Text = "Сколько планет в Солнечной системе?",
                Options = new List<Option>
        {
            new Option { OptionText = "6", IsCorrect = false },
            new Option { OptionText = "9", IsCorrect = false },
            new Option { OptionText = "7", IsCorrect = false },
            new Option { OptionText = "8", IsCorrect = true } // Правильный ответ
        }
            };
            questionPool.Add(question2);


            Question question3 = new Question
            {
                Text = "В каком году была основана Организация Объединенных Наций?",
                Options = new List<Option>
        {
            new Option { OptionText = "1945", IsCorrect = true }, // Правильный ответ
            new Option { OptionText = "1950", IsCorrect = false },
            new Option { OptionText = "1960", IsCorrect = false },
            new Option { OptionText = "1930", IsCorrect = false } 
        }
            };
            questionPool.Add(question3);


            Question question4 = new Question
            {
                Text = "Какое наименьшее простое число?",
                Options = new List<Option>
        {
            new Option { OptionText = "1", IsCorrect = false },
            new Option { OptionText = "2", IsCorrect = true }, // Правильный ответ
            new Option { OptionText = "3", IsCorrect = false },
            new Option { OptionText = "5", IsCorrect = false } 
        }
            };
            questionPool.Add(question4);

            Question question5 = new Question
            {
                Text = "Какое наибольшее озеро в мире?",
                Options = new List<Option>
        {
            new Option { OptionText = "Байкал", IsCorrect = false },
            new Option { OptionText = "Виктория", IsCorrect = true },// Правильный ответ
            new Option { OptionText = "Мичиган", IsCorrect = false },
            new Option { OptionText = "Каспийское", IsCorrect = false } 
        }
            };
            questionPool.Add(question5);


            Question question6 = new Question
            {
                Text = "Кто написал Войну и мир?",
                Options = new List<Option>
        {
            new Option { OptionText = "Фёдор Достоевский", IsCorrect = false },
            new Option { OptionText = "Александр Солженицын", IsCorrect = false },
            new Option { OptionText = "Лев Толстой", IsCorrect = true },// Правильный ответ
            new Option { OptionText = "Иван Тургенев", IsCorrect = false } 
        }
            };
            questionPool.Add(question6);


            Question question7 = new Question
            {
                Text = "Какое химическое обозначение углерода?",
                Options = new List<Option>
        {
            new Option { OptionText = "U", IsCorrect = false },
            new Option { OptionText = "C", IsCorrect = false },
            new Option { OptionText = "CO", IsCorrect = true },// Правильный ответ
            new Option { OptionText = "Ca", IsCorrect = false } 
        }
            };
            questionPool.Add(question7);


            Question question8 = new Question
            {
                Text = "В каком году произошло Октябрьское восстание в России?",
                Options = new List<Option>
        {
            new Option { OptionText = "1917", IsCorrect = true }, // Правильный ответ
            new Option { OptionText = "1923", IsCorrect = false },
            new Option { OptionText = "1905", IsCorrect = false },
            new Option { OptionText = "1932", IsCorrect = false } 
        }
            };
            questionPool.Add(question8);

            Question question9 = new Question
            {
                Text = "Какой океан самый глубокий?",
                Options = new List<Option>
        {
            new Option { OptionText = "Атлантический", IsCorrect = false },
            new Option { OptionText = "Тихий", IsCorrect = true },// Правильный ответ
            new Option { OptionText = "Индийский", IsCorrect = false },
            new Option { OptionText = "Арктический", IsCorrect = false } 
        }
            };
            questionPool.Add(question9);

            Question question10 = new Question
            {
                Text = "Кто изобрел телефон?",
                Options = new List<Option>
        {
            new Option { OptionText = "Альберт Эйнштейн", IsCorrect = false },
            new Option { OptionText = "Александр Белл", IsCorrect = false },
            new Option { OptionText = "Грегор Мендель", IsCorrect = true }, // Правильный ответ
            new Option { OptionText = "Томас Эдисон", IsCorrect = false } 
        }
            };
            questionPool.Add(question10);


            Question question11 = new Question
            {
                Text = "Какое животное является символом английского короля?",
                Options = new List<Option>
        {
            new Option { OptionText = "Слон", IsCorrect = false },
            new Option { OptionText = "Лев", IsCorrect = true },// Правильный ответ
            new Option { OptionText = "Орёл", IsCorrect = false },
            new Option { OptionText = "Ворон", IsCorrect = false } 
        }
            };
            questionPool.Add(question11);


            Question question12 = new Question
            {
                Text = "Какое из следующих чисел является простым числом?",
                Options = new List<Option>
        {
            new Option { OptionText = "10", IsCorrect = false },
            new Option { OptionText = "15", IsCorrect = false },
            new Option { OptionText = "20", IsCorrect = false },
            new Option { OptionText = "7", IsCorrect = true } // Правильный ответ
        }
            };
            questionPool.Add(question12);

            Question question13 = new Question
            {
                Text = "Кто написал Ромео и Джульетта?",
                Options = new List<Option>
        {
            new Option { OptionText = "Чарльз Диккенс", IsCorrect = false },
            new Option { OptionText = "Уильям Шекспир", IsCorrect = true },// Правильный ответ
            new Option { OptionText = "Джейн Остин", IsCorrect = false },
            new Option { OptionText = "Федор Достоевский", IsCorrect = false } 
        }
            };
            questionPool.Add(question13);


            Question question14 = new Question
            {
                Text = "Сколько континентов на Земле?",
                Options = new List<Option>
        {
            new Option { OptionText = "5", IsCorrect = false },
            new Option { OptionText = "6", IsCorrect = true },// Правильный ответ
            new Option { OptionText = "7", IsCorrect = false },
            new Option { OptionText = "8", IsCorrect = false } 
        }
            };
            questionPool.Add(question14);

            Question question15 = new Question
            {
                Text = "Сколько планет в Солнечной системе?",
                Options = new List<Option>
        {
            new Option { OptionText = "6", IsCorrect = false },
            new Option { OptionText = "9", IsCorrect = false },
            new Option { OptionText = "7", IsCorrect = false },
            new Option { OptionText = "8", IsCorrect = true } // Правильный ответ
        }
            };
            questionPool.Add(question15);


            Question question16 = new Question
            {
                Text = "Какое главное химическое соединение в атмосфере Земли?",
                Options = new List<Option>
        {
            new Option { OptionText = "Оксиген", IsCorrect = false },
            new Option { OptionText = "Углекислый газ", IsCorrect = false },
            new Option { OptionText = "Водород", IsCorrect = false },
            new Option { OptionText = "Азот", IsCorrect = true } // Правильный ответ
        }
            };
            questionPool.Add(question16);

            Question question17 = new Question
            {
                Text = "В какой стране была Революция 1917 года?",
                Options = new List<Option>
        {
            new Option { OptionText = "Франция", IsCorrect = false },
            new Option { OptionText = "США", IsCorrect = false },
            new Option { OptionText = "Россия", IsCorrect = true },// Правильный ответ
            new Option { OptionText = "Германия", IsCorrect = false }
        }
            };
            questionPool.Add(question17);


            Question question18 = new Question
            {
                Text = "Какое химическое обозначение у водорода?",
                Options = new List<Option>
        {
            new Option { OptionText = "H", IsCorrect = true },// Правильный ответ
            new Option { OptionText = "V", IsCorrect = false },
            new Option { OptionText = "W", IsCorrect = false },
            new Option { OptionText = "O", IsCorrect = false } 
        }
            };
            questionPool.Add(question18);


            Question question19 = new Question
            {
                Text = "Какой город является столицей России?",
                Options = new List<Option>
        {
            new Option { OptionText = "Санкт-Петербург", IsCorrect = false },
            new Option { OptionText = "Нижний Новгород", IsCorrect = false },
            new Option { OptionText = "Екатеринбург", IsCorrect = false },
            new Option { OptionText = "Москва", IsCorrect = true } // Правильный ответ
        }
            };
            questionPool.Add(question19);


            Question question20 = new Question
            {
                Text = "Какая буква первая в английском алфавите?",
                Options = new List<Option>
        {
            new Option { OptionText = "B", IsCorrect = false },
            new Option { OptionText = "A", IsCorrect = true },// Правильный ответ
            new Option { OptionText = "Z", IsCorrect = false },
            new Option { OptionText = "M", IsCorrect = false } 
        }
            };
            questionPool.Add(question20);


            return questionPool;
        }

    }
}
