using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendT3
{
    class NotificationService //NotificationService теперь зависит от абстракции Iservise
    {
        private IService service;    
        public NotificationService(IService service)     //Теперь NotificationService принимает уже инициализированную переменную
        {
            this.service = service;
        }
        public void Notify(string text, int receiver_id)
        {
            Console.WriteLine("Notifing contact " + receiver_id + ":");
            service.Send_Message(text);
        }
        public void NotifyAll(string text)
        {
            Console.WriteLine("Notifing all:");
            service.Send_Message(text);
        }
    }

    interface IService
    {
        void Send_Message(string message);
    }

    //Телеграм и эмейл исполняют контракт с IService
    //Взаимодействие с Telegram
    class Telegram_Service: IService
    {
        public void Send_Message(string message)
        {
            Console.WriteLine("Telegram: " + message + "\n" );
        }
    }

    //Взаимодействие с Email
    class Email_Service: IService
    {
        public void Send_Message(string message)
        {
            Console.WriteLine("Email: " + message + "\n");
        }
    }
    internal class Program
    {
        static void Main(string[] args)  
        {
            IService service = new Telegram_Service();
            IService service2 = new Email_Service();
            var notification_tg = new NotificationService(service);
            var notification_email = new NotificationService(service2);
            notification_tg.Notify("Привет!", 1);
            notification_tg.NotifyAll("Шалом!");
            notification_email.Notify("Салам!", 1);
        }
    }
}
