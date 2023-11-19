using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using chatBotToasts;

namespace chatBotToasts
{
    internal class Bot
    {
        const string linkToGitHub = "https://github.com/MikalaiRakhman";
        const string linkToTheLinkedIn = "https://www.linkedin.com/in/mikalai-rakhman-7b572190/";
        const string linkToTheMail = "rakhmanmikalai@gmail.com";
        const string telefonNumber = "48 572068230";
        const string TO_MAIN_MENU_BUTTON = "/start";
        const string ABOUT_BOT = "Подробнее о телеграм боте";
        const string ABOUT_ME = "Подробнее о разработчике";
        const string START_BUTTON = "СТАРТ";
        const string SHORT_TOSTS_BUTTON = "Короткие";
        const string FUNNY_TOSTS_BUTTON = "Смешные и прикольные";
        const string HAPPY_BIRTHDAY_BUTTON = "На День Рождения";
        const string ANNIVERSARY_BUTTON = "На юбилей";
        const string WEDDING_BUTTON = "Свадебные поздравления и тосты";
        const string PARENTS_BUTTON = "За родителей";
        const string GIRLS_AND_WOMEN_BUTTON = "За женщин и девушек";
        const string LOVE_BUTTON = "Про любовь";
        const string CAUCASIAN_AND_GEORGIAN_BUTTON = "Кавказкие и грузинские";
        const string PARABLE_BUTTON = "Притчи (поучительные и поздравительные)";
        const string NEW_YEAR_BUTTON = "Новогодние тосты и поздравления";
        const string CRYSTMAS_BUTTON = "Рождевственские поздравления";
        const string VALENTINAS_BUTTON = "На 14 февраля (Св. Валентина)";
        const string FEBRIARY23_BUTTON = "На 23 февраля (День защитника Отечества)";
        const string MARCH8_BUTTON = "На 8 марта (Международный женский день)";
        const string EASTER_BUTTON = "На Пасху";
        const string MAY9_BUTTON = "На 9 мая (День Победы)";
        const string NEXT_BUTTON1 = "Еще>>>";
        const string BACK_BUTTON1 = "<Назад";
        const string NEXT_BUTTON2 = "Еще>>";
        const string BACK_BUTTON2 = "<<Назад";
        const string NEXT_BUTTON3 = "Еще>";
        const string BACK_BUTTON3 = "<<<Назад";
        const string HAPPY_BIRTHDAY_TO_MEN = "Мужчине";
        const string HAPPY_BIRTHDAY_TO_WOMEN = "Женщине";
        const string HAPPY_BIRTHDAY_TO_HUSBENT = "Мужу";
        const string HAPPY_BIRTHDAY_TO_WIFE = "Жене";
        const string HAPPY_BIRTHDAY_TO_SISTER = "Сестре";
        const string HAPPY_BIRTHDAY_TO_MALE_FRIEND = "Другу";
        const string HAPPY_BIRTHDAY_TO_FEMALE_FRIEND = "Подруге";
        const string ANNIVERSARY_TO_MEN = "Mужчине"; //first 'M' is on English
        const string ANNIVERSARY_TO_WOMEN = "Жeщине"; //first 'e' is on English
        const string ANNIVERSARY_TO_MEN_50 = "Mужчине 50";
        const string ANNIVERSARY_TO_WOMEN_50 = "Женщине 50";
        const string ANNIVERSARY_TO_MEN_55 = "Mужчине 55";
        const string ANNIVERSARY_TO_WOMEN_55 = "Женщине 55";
        const string ANNIVERSARY_TO_MEN_60 = "Mужчине 60";
        const string ANNIVERSARY_TO_WOMEN_60 = "Женщине 60";
        const string PARENTS_EACH = "Тосты для обеих родителей";
        const string PARENTS_FATHER = "Тосты за папу";
        const string PARENTS_MOTHER = "Тосты за маму";
        const string TEXT1 = "Нажмите на кнопку из предолженных ниже";
        Toasts toasts = new Toasts();
        public void RunBot()
        {
            const string token = "6711785532:AAFg8-RrIydDMq88LNLnr0nJqkk9-szq5E4";
            var botClient = new TelegramBotClient(token);
            // Create a cancellation token source
            var cts = new CancellationTokenSource();
            botClient.StartReceiving(updateHandler: HandleUpdateAsync,
                                     pollingErrorHandler: HandlePollingErrorAsync,
                                    cancellationToken: cts.Token);



            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                var messege = update.Message;

                if (messege != null)
                {
                    if (messege.Text == "/start")
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, WelcomeMessege(messege.Chat.Username, CountOfAllToasts()), replyMarkup: GetFirstMenuButtons());
                    }
                    if (messege.Text == ABOUT_BOT)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, AboutBotText(messege.Chat.Username), replyMarkup: GetFirstMenuButtons());
                    }
                    if (messege.Text == ABOUT_ME)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, AboutMeText(), replyMarkup: GetFirstMenuButtons());
                    }
                    if (messege.Text == START_BUTTON || messege.Text == BACK_BUTTON1)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, TEXT1, replyMarkup: GetButtonsAfterStart());
                    }
                    if (messege.Text == NEXT_BUTTON1 || messege.Text == BACK_BUTTON2)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, TEXT1, replyMarkup: GetButtonsAfterNext1Back2Button());
                    }
                    if (messege.Text == NEXT_BUTTON2 || messege.Text == BACK_BUTTON3)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, TEXT1, replyMarkup: GetButtonsAfterNext2Back3Button());
                    }
                    if (messege.Text == NEXT_BUTTON3)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, TEXT1, replyMarkup: GetButtonsAfterNext3Button());
                    }
                    if (messege.Text == HAPPY_BIRTHDAY_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, TEXT1, replyMarkup: GetButtonsHappyBirthday());
                    }
                    if (messege.Text == ANNIVERSARY_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, TEXT1, replyMarkup: GetButtonsAnniversary());
                    }
                    if (messege.Text == PARENTS_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, TEXT1, replyMarkup: GetButtonsParents());
                    }
                    if (messege.Text == SHORT_TOSTS_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetShortToasts()));
                    }
                    if (messege.Text == FUNNY_TOSTS_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetFunnyToasts()));
                    }
                    if (messege.Text == HAPPY_BIRTHDAY_TO_MEN)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToHappyBirthdayTheMen()));
                    }
                    if (messege.Text == HAPPY_BIRTHDAY_TO_WOMEN)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToHappyBirthdayTheWomen()));
                    }
                    if (messege.Text == HAPPY_BIRTHDAY_TO_HUSBENT)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToHappyBirthdayTheHusband()));
                    }
                    if (messege.Text == HAPPY_BIRTHDAY_TO_WIFE)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToHappyBirthdayTheWife()));
                    }
                    if (messege.Text == HAPPY_BIRTHDAY_TO_MALE_FRIEND)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToHappyBirthdayTheMaleFriend()));
                    }
                    if (messege.Text == HAPPY_BIRTHDAY_TO_FEMALE_FRIEND)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToHappyBirthdayTheFemaleFriend()));
                    }
                    if (messege.Text == HAPPY_BIRTHDAY_TO_SISTER)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToHappyBirthdayTheSister()));
                    }
                    if (messege.Text == ANNIVERSARY_TO_MEN)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToAnniversaryMan()));
                    }
                    if (messege.Text == ANNIVERSARY_TO_WOMEN)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToAnniversaryFemale()));
                    }
                    if (messege.Text == ANNIVERSARY_TO_MEN_50)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToAnniversaryMan50()));
                    }
                    if (messege.Text == ANNIVERSARY_TO_WOMEN_50)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToAnniversaryFemale50()));
                    }
                    if (messege.Text == ANNIVERSARY_TO_MEN_55)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToAnniversaryMan55()));
                    }
                    if (messege.Text == ANNIVERSARY_TO_WOMEN_55)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToAnniversaryFemale55()));
                    }
                    if (messege.Text == ANNIVERSARY_TO_MEN_60)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToAnniversaryMan60()));
                    }
                    if (messege.Text == ANNIVERSARY_TO_WOMEN_60)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToAnniversaryFemale60()));
                    }
                    if (messege.Text == WEDDING_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetWeddingToasts()));
                    }
                    if (messege.Text == PARENTS_EACH)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToEachParent()));
                    }
                    if (messege.Text == PARENTS_FATHER)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToTheFather()));
                    }
                    if (messege.Text == PARENTS_MOTHER)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToTheMother()));
                    }
                    if (messege.Text == GIRLS_AND_WOMEN_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetToTheGirlsAndWomenToasts()));
                    }
                    if (messege.Text == LOVE_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetForTheLoveToasts()));
                    }
                    if (messege.Text == CAUCASIAN_AND_GEORGIAN_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetCaucasianAndGeorgianToasts()));
                    }
                    if (messege.Text == PARABLE_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetParableToasts()));
                    }
                    if (messege.Text == NEW_YEAR_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetNewYearToasts()));
                    }
                    if (messege.Text == CRYSTMAS_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetCristmasToasts()));
                    }
                    if (messege.Text == VALENTINAS_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetValentinesDay()));
                    }
                    if (messege.Text == FEBRIARY23_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetFebruary23Toasts()));
                    }
                    if (messege.Text == MARCH8_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.Get8MarchToasts()));
                    }
                    if (messege.Text == EASTER_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.GetEasterToasts()));
                    }
                    if (messege.Text == MAY9_BUTTON)
                    {
                        botClient.SendTextMessageAsync(messege.Chat.Id, GetRandomToastFrom(toasts.Get9MayToasts()));
                    }

                }
            }
            Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
            {
                var ErrorMessage = exception switch
                {
                    ApiRequestException apiRequestException
                        => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                    _ => exception.ToString()
                };

                Console.WriteLine(ErrorMessage);
                return Task.CompletedTask;
            }

            Console.ReadLine();
        }
        static float CountOfAllToasts()
        {
            Toasts toasts = new Toasts();
            return toasts.CountsOfAllToasts();
        }
        IReplyMarkup GetFirstMenuButtons()
        {
            List<KeyboardButton> button1 = new List<KeyboardButton>() { new KeyboardButton(START_BUTTON) };
            List<KeyboardButton> button2 = new List<KeyboardButton>() { new KeyboardButton(ABOUT_BOT) };
            List<KeyboardButton> button3 = new List<KeyboardButton>() { new KeyboardButton(ABOUT_ME) };
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>> { button1, button2, button3 };
            IReplyMarkup replyMarkup = new ReplyKeyboardMarkup(keyboardButtons);
            return replyMarkup;
        }
        string AboutBotText(string name)
        {
            return $"В телеграм боте вы, {name}, сможете найти много тостов, поздравлений и притч.\nЧасто так случается, что нужные слова в моменты застолья не находятся, а хочется поздравить близкого человека не только подарком, но и красивым тостом. В этом телеграм-боте находятся лучшие высказывания в стихах и прозе, как короткие, так и длинные. Для удобства поздравления разбиты по категориям. При нажатии кнопки определенной категории, вы получите один тост по теме в произвольном порядке. \n Хочется, чтобы этот бот занял достойное место в вашем списке чатов!";
        }

        string AboutMeText()
        {
            return $"Всем привет! Меня зовут Рахман Николай. Осенью 2022 года я переехал из Беларуси в Польшу. Я сейчас проживаю в городе Варшава и работаю в такси. В последнее время активно начал изучать программирование, т.к. хочу поменять работу. Этот чат-бот, тоже, своего рода, часть самостоятельного обучения. Написал я его на C# в VisualStudio.\n\n Буду очень рад, если среди вас найдется человек, который поможет мне с трудоустройством или обучением в компании в качестве интерна. Чуть ниже оставляю контакты:\n\n  Тел. +{telefonNumber}\n  email: {linkToTheMail}\n  linkedIn: {linkToTheLinkedIn}\n  GitHub: {linkToGitHub}";
        }

        IReplyMarkup GetButton(string buttonName)
        {
            KeyboardButton keyboardButton = new KeyboardButton(buttonName);
            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButton);
            return replyKeyboardMarkup;
        }
        string WelcomeMessege(string name, float coutOfAllToasts)
        {
            string messege = $"Приветствуем Вас, {name}! В этом телеграм боте мы поможем подобрать тост к Вашему застолью!\n\n На данный момент в базе бота находится {coutOfAllToasts} тост(ов). \n\n";
            return messege;
        }
        IReplyMarkup GetButtonsAfterStart()
        {
            KeyboardButton b1 = new KeyboardButton(SHORT_TOSTS_BUTTON);
            KeyboardButton b2 = new KeyboardButton(FUNNY_TOSTS_BUTTON);
            List<KeyboardButton> row1 = new List<KeyboardButton>() { b1, b2 };
            KeyboardButton b3 = new KeyboardButton(HAPPY_BIRTHDAY_BUTTON);
            KeyboardButton b4 = new KeyboardButton(ANNIVERSARY_BUTTON);
            List<KeyboardButton> row2 = new List<KeyboardButton>() { b3, b4 };
            List<KeyboardButton> row3 = new List<KeyboardButton> { new KeyboardButton(TO_MAIN_MENU_BUTTON), new KeyboardButton(NEXT_BUTTON1) };
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>> { row1, row2, row3 };
            IReplyMarkup replyMarkup = new ReplyKeyboardMarkup(keyboardButtons);
            return replyMarkup;
        }
        IReplyMarkup GetButtonsAfterNext1Back2Button()
        {
            List<KeyboardButton> row1 = new List<KeyboardButton>() { new KeyboardButton(WEDDING_BUTTON), new KeyboardButton(PARENTS_BUTTON) };
            List<KeyboardButton> row2 = new List<KeyboardButton>() { new KeyboardButton(GIRLS_AND_WOMEN_BUTTON), new KeyboardButton(LOVE_BUTTON) };
            List<KeyboardButton> row3 = new List<KeyboardButton>() { new KeyboardButton(BACK_BUTTON1), new KeyboardButton(NEXT_BUTTON2) };
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>() { row1, row2, row3 };
            IReplyMarkup replyMarkup = new ReplyKeyboardMarkup(keyboardButtons);
            return replyMarkup;
        }
        IReplyMarkup GetButtonsAfterNext2Back3Button()
        {
            List<KeyboardButton> row1 = new List<KeyboardButton>() { new KeyboardButton(CAUCASIAN_AND_GEORGIAN_BUTTON), new KeyboardButton(PARABLE_BUTTON) };
            List<KeyboardButton> row2 = new List<KeyboardButton>() { new KeyboardButton(NEW_YEAR_BUTTON), new KeyboardButton(CRYSTMAS_BUTTON) };
            List<KeyboardButton> row3 = new List<KeyboardButton>() { new KeyboardButton(BACK_BUTTON2), new KeyboardButton(NEXT_BUTTON3) };
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>() { row1, row2, row3 };
            IReplyMarkup replyMarkup = new ReplyKeyboardMarkup(keyboardButtons);
            return replyMarkup;
        }
        IReplyMarkup GetButtonsAfterNext3Button()
        {
            List<KeyboardButton> row1 = new List<KeyboardButton>() { new KeyboardButton(VALENTINAS_BUTTON), new KeyboardButton(FEBRIARY23_BUTTON) };
            List<KeyboardButton> row2 = new List<KeyboardButton>() { new KeyboardButton(MARCH8_BUTTON), new KeyboardButton(EASTER_BUTTON) };
            List<KeyboardButton> row3 = new List<KeyboardButton>() { new KeyboardButton(BACK_BUTTON3), new KeyboardButton(MAY9_BUTTON) };
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>() { row1, row2, row3 };
            IReplyMarkup replyMarkup = new ReplyKeyboardMarkup(keyboardButtons);
            return replyMarkup;
        }
        IReplyMarkup GetButtonsHappyBirthday()
        {
            List<KeyboardButton> row1 = new List<KeyboardButton>() { new KeyboardButton(HAPPY_BIRTHDAY_TO_MEN), new KeyboardButton(HAPPY_BIRTHDAY_TO_WOMEN), new KeyboardButton(HAPPY_BIRTHDAY_TO_HUSBENT) };
            List<KeyboardButton> row2 = new List<KeyboardButton>() { new KeyboardButton(HAPPY_BIRTHDAY_TO_WIFE), new KeyboardButton(HAPPY_BIRTHDAY_TO_MALE_FRIEND), new KeyboardButton(HAPPY_BIRTHDAY_TO_FEMALE_FRIEND) };
            List<KeyboardButton> row3 = new List<KeyboardButton>() { new KeyboardButton(BACK_BUTTON1), new KeyboardButton(HAPPY_BIRTHDAY_TO_SISTER) };
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>() { row1, row2, row3 };
            IReplyMarkup replyMarkup = new ReplyKeyboardMarkup(keyboardButtons);
            return replyMarkup;
        }
        IReplyMarkup GetButtonsAnniversary()
        {
            List<KeyboardButton> row1 = new List<KeyboardButton>() { new KeyboardButton(ANNIVERSARY_TO_MEN), new KeyboardButton(ANNIVERSARY_TO_WOMEN), new KeyboardButton(ANNIVERSARY_TO_MEN_50) };
            List<KeyboardButton> row2 = new List<KeyboardButton>() { new KeyboardButton(ANNIVERSARY_TO_WOMEN_50), new KeyboardButton(ANNIVERSARY_TO_MEN_55), new KeyboardButton(ANNIVERSARY_TO_WOMEN_55) };
            List<KeyboardButton> row3 = new List<KeyboardButton>() { new KeyboardButton(ANNIVERSARY_TO_MEN_60), new KeyboardButton(ANNIVERSARY_TO_WOMEN_60), new KeyboardButton(BACK_BUTTON1) };
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>() { row1, row2, row3 };
            IReplyMarkup replyMarkup = new ReplyKeyboardMarkup(keyboardButtons);
            return replyMarkup;
        }
        IReplyMarkup GetButtonsParents()
        {
            List<KeyboardButton> row1 = new List<KeyboardButton>() { new KeyboardButton(PARENTS_EACH), new KeyboardButton(PARENTS_MOTHER), new KeyboardButton(PARENTS_FATHER) };
            List<KeyboardButton> row2 = new List<KeyboardButton>() { new KeyboardButton(BACK_BUTTON2) };
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>() { row1, row2 };
            IReplyMarkup replyMarkup = new ReplyKeyboardMarkup(keyboardButtons);
            return replyMarkup;
        }

        public string GetRandomToastFrom(string[] toastBase)
        {
            Random r = new Random();
            int random = r.Next(0, toastBase.Length + 1);
            return toastBase[random];
        }
    }
}