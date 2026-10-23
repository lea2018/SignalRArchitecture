using Microsoft.AspNetCore.SignalR;
using SignalR.Shared.Contracts;

namespace SignalR.HubServer.Hubs;

public sealed class ChatHub : Hub
{
    public async Task SendMessage(string sala, string user, string message)
    {
        sala = ValidarSala(sala);

        if (string.IsNullOrWhiteSpace(user) ||
            string.IsNullOrWhiteSpace(message))
        {
            throw new HubException(
                "El usuario y el mensaje son obligatorios.");
        }

        user = user.Trim();
        message = message.Trim();

        if (user.Length > 40 || message.Length > 1000)
        {
            throw new HubException(
                "El mensaje supera el límite permitido.");
        }

        var chatMessage = new ChatMessage(
            user,
            message,
            DateTimeOffset.UtcNow);

        await Clients.Group(sala)
            .SendAsync("ReceiveMessage", chatMessage);
    }

    public async Task UnirseASala(string sala)
    {
        sala = ValidarSala(sala);

        const string claveSalaActual = "SalaActual";

        if (Context.Items.TryGetValue(claveSalaActual, out var valor) &&
            valor is string salaAnterior &&
            salaAnterior != sala)
        {
            await Groups.RemoveFromGroupAsync(
                Context.ConnectionId,
                salaAnterior);
        }

        await Groups.AddToGroupAsync(
            Context.ConnectionId,
            sala);

        Context.Items[claveSalaActual] = sala;
    }

    private static string ValidarSala(string sala)
    {
        if (string.IsNullOrWhiteSpace(sala))
        {
            throw new HubException(
                "El nombre de la sala es obligatorio.");
        }

        sala = sala.Trim();

        if (sala != "Desarrollo" && sala != "Diseño")
        {
            throw new HubException("La sala no es válida.");
        }

        return sala;
    }
}
