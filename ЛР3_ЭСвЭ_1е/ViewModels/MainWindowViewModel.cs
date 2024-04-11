using ReactiveUI;
using System.Collections.ObjectModel;
using System.Linq;

namespace ЛР3_ЭСвЭ_1е.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public class FAQ : ReactiveObject
        {
            private string _title;
            private (string Q1, string Q2, string Q3) _question;
            private (bool A1, bool A2, bool A3) _answer;

            public FAQ(string title, string q1, string q2, string q3)
            {
                _title = title;
                _question = (q1, q2, q3);
                _answer = (false, false, false);
            }

            public string Title
            {
                get => _title;
                set => this.RaiseAndSetIfChanged(ref _title, value);
            }

            public string Q1
            {
                get => _question.Q1;
                set => this.RaiseAndSetIfChanged(ref _question.Q1, value);
            }
            public string Q2
            {
                get => _question.Q2;
                set => this.RaiseAndSetIfChanged(ref _question.Q2, value);
            }
            public string Q3
            {
                get => _question.Q3;
                set => this.RaiseAndSetIfChanged(ref _question.Q3, value);
            }

            public bool A1
            {
                get => _answer.A1;
                set => this.RaiseAndSetIfChanged(ref _answer.A1, value);
            }
            public bool A2
            {
                get => _answer.A2;
                set => this.RaiseAndSetIfChanged(ref _answer.A2, value);
            }
            public bool A3
            {
                get => _answer.A3;
                set => this.RaiseAndSetIfChanged(ref _answer.A3, value);
            }
        }
        public ObservableCollection<FAQ> Faq { get; set; } = [
            new FAQ("1. По какому принципу вы бы набирали в фирму людей?", "А) По деловым качествам;", "Б) Брал бы друзей и родных;", "В) Доверился интуиции."),
            new FAQ("2. Какой цвет больше нравится?", "А) Зеленый;", "Б) Красный;", "В) Синий."),
            new FAQ("3. Какую машину вы предпочитаете?", "А) Спортивную;", "Б) Представительскую;", "В) Хэтчбек."),
            new FAQ("4. При оформлении кабинета вы предпочтете?", "А) Завесить все картинами;", "Б) Спокойные цветовые тона;", "В) Официальную обстановку."),
            new FAQ("5. Деловые люди, как правило, не видят в одежде цель жизни, а для вас она...?", "А) Для меня одежда - очень многое значит. Без фирменной одежды я мало что из себя представляю;", "Б) Я люблю красиво одеваться, так как это приятно и мне, и окружающим;", "В) Хорошая одежда нужна мне для работы. Если я буду плохо одет, люди не будут со мной иметь дела."),
            new FAQ("6. Какое из двух достоинств цените больше всего?", "А) Авторитет;", "Б) Трудоспособность;", "В) Общительность."),
            new FAQ("7. Я знаю, чего хочу и как этого можно добиться в ближайшие два-три года?", "А) Мои планы и желания часто меняются;", "Б) Мои планы и желания вряд ли кардинально изменятся;", "В) Я точно знаю, чего хочу и как этого достичь."),
            new FAQ("8. Дружба для вас:", "А) Сотрудничество;", "Б) Поддержка;", "В) Альтруизм."),
            new FAQ("9. Умеете ли вы отдыхать, отключаться от своих дел и многочисленных проблем?", "А) Могу, но не всегда. Если у меня что-то важное, я просто не могу не думать об этом. Тогда и отдых не в радость;", "Б) Когда я отдыхаю, я с радостью забываю все заботы и наслаждаюсь жизнью;", "В) Я уже не помню, когда отдыхал последний раз. Все дела и дела."),
            new FAQ("10. Мне кажется, что при оценке себя:", "А) Я чаще всего недооцениваю свои способности;", "Б) Я чаще всего переоцениваю свои способности;", "В) Я оцениваю свои способности достаточно правильно и объективно.")
        ];
        private (int R1, int R2, int R3) _result = (0,0,0);
        public int R1
        {
            get => _result.R1;
            set => this.RaiseAndSetIfChanged(ref _result.R1, value);
        }
        public int R2
        {
            get => _result.R2;
            set => this.RaiseAndSetIfChanged(ref _result.R2, value);
        }
        public int R3
        {
            get => _result.R3;
            set => this.RaiseAndSetIfChanged(ref _result.R3, value);
        }
        public void CalculateResult() // Ну типо алгоритм, который нужно нарисовать блоксхемкой
        {
            R1 = Faq.Count(x => x.A1) * 100 / 10; // Faq.Count(x => x.A1) если че цикл от 0 до конца коллекции Faq, который считает количество A1 = true
            R2 = Faq.Count(x => x.A2) * 100 / 10;
            R3 = Faq.Count(x => x.A3) * 100 / 10;
        }
        public bool ResultIsVisible => R1 != 0 && R2 != 0 && R3 != 0;
    }
}
