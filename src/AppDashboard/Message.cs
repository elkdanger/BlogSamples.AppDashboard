using System;

namespace AppDashboard
{
    public class Message
    {
        public Message()
            : this(string.Empty)
        {
        }

        public Message(string message, bool isError = false)
        {
            this.Date = DateTime.Now;
            this.Text = message;
            this.IsError = isError;
        }

        public DateTime Date { get; set; }

        public string DateText
        {
            get { return Date.ToShortTimeString(); }
        }

        public string Text { get; set; }

        public bool IsError { get; set; }
    }
}
