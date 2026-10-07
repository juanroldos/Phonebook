using WhatsAppApiUCU;

namespace Library;

public class WhatsAppChannel : IMessageChannel
{
    public void Send(Message message)
    {

    }
    public string GetAddress(Contact contact)
    {
        return contact.Phone;
    }
}