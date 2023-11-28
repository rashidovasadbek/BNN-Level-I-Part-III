using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var botClient = new TelegramBotClient("5946841023:AAFQXjV54sTmXlQoogwQ5cFWsnYQ5rmqn7U");
//var me = await botClient.GetMeAsync();
//Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

/*using CancelationTokenSourse srs = new();

ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>()
};

botClient.StartReceiving(
    updateHandler:);*/

ChatId chatId = new (1);
CancellationTokenSource cancellationToken = new CancellationTokenSource();

Message message = await botClient.SendTextMessageAsync(
    chatId: chatId,
    text: "Hello, World!");

