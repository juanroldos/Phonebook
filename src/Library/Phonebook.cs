using System.Collections.Generic;

namespace Library;

public class Phonebook
{
    private List<Contact> persons;

    public Phonebook(Contact owner)
    {
        this.Owner = owner;
        this.persons = new List<Contact>();
    }

    public Contact Owner { get; }

    public List<Contact> Search(string[] names)
    {
        List<Contact> result = new List<Contact>();

        foreach (Contact person in this.persons)
        {
            foreach (string name in names)
            {
                if (person.Name.Equals(name))
                {
                    result.Add(person);
                }
            }
        }
        return result;
    }
    public void AddContact(Contact contact)
    {
        this.persons.Add(contact);
    }
    public void RemoveContact(Contact contact)
    {
        this.persons.Remove(contact);
    }
    public void SendMessage(string[] names, string text, IMessageChannel channel)
    {
        List<Contact> receivers = this.Search(names);

        foreach (Contact receiver in receivers)
        {
            string from = channel.GetAddress(this.Owner);
            string to = channel.GetAddress(receiver);

            Message message = new Message(from, to);
            message.Text = text;

            channel.Send(message);
        }
    }
}