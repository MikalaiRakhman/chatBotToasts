
namespace chatBotToasts
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot bot = new Bot();
            Toasts tost = new Toasts();
            List<string> all = tost.GetAllToasts();

            bot.RunBot();
        }
    }
}