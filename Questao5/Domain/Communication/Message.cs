namespace Questao5.Domain.Communication
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        
        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}