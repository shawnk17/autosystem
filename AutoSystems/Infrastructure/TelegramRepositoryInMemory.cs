using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class TelegramRepositoryInMemory : ITelegramRepository
    {
        private static List<Telegram> _telegrams;
        private static int _nextId = 1;

        public TelegramRepositoryInMemory()
        {
            if(_telegrams == null)
            {
                _telegrams = new List<Telegram>();
            }
        }
        public void Add(Telegram newTelegram)
        {
            newTelegram.Id = _nextId++;
            _telegrams.Add(newTelegram);
        }

        public void Delete(Telegram telegramToDelete)
        {
            var origTelegram = GetById(telegramToDelete.Id);

            _telegrams.Remove(origTelegram);
        }

        public void Edit(Telegram editedTelegram)
        {
            var origTelegram = GetById(editedTelegram.Id);

            origTelegram.Content = editedTelegram.Content;
            origTelegram.Receiver = editedTelegram.Receiver;
            origTelegram.Sender = editedTelegram.Sender;
            origTelegram.Title = editedTelegram.Title;
        }

        public Telegram GetById(int id)
        {
            return _telegrams.Find(t => t.Id == id);
        }

        public List<Telegram> ListAll()
        {
            return _telegrams;
        }
    }
}
