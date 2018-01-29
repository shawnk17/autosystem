using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Infrastructure
{
    public class TelegramRepositoryFs : ITelegramRepository
    {
        private static List<Telegram> _telegrams;
        private static int _nextId = 1;

        private const string PATH = "data";
        private const string FILENAME = "telegramData.json";

        private readonly string _fileFullPath = Path.Combine(PATH, FILENAME);


        public TelegramRepositoryFs()
        {
            if (_telegrams == null)
            {
                _telegrams = LoadFile();

                if (_telegrams.Count > 0)
                {
                    _nextId = _telegrams.Max(t => t.Id) + 1;
                }
            }
        }
        public void Add(Telegram newTelegram)
        {
            newTelegram.Id = _nextId++;
            _telegrams.Add(newTelegram);

            SaveFile();
        }

        public void Delete(Telegram telegramToDelete)
        {
            var origTelegram = GetById(telegramToDelete.Id);

            _telegrams.Remove(origTelegram);

            SaveFile();
        }

        public void Edit(Telegram editedTelegram)
        {
            var origTelegram = GetById(editedTelegram.Id);

            origTelegram.Content = editedTelegram.Content;
            origTelegram.Receiver = editedTelegram.Receiver;
            origTelegram.Sender = editedTelegram.Sender;
            origTelegram.Title = editedTelegram.Title;

            SaveFile();
        }

        public Telegram GetById(int id)
        {
            return _telegrams.Find(t => t.Id == id);
        }

        public List<Telegram> ListAll()
        {
            return _telegrams;
        }

        public List<Telegram> LoadFile()
        {
            try
            {
                string rawListStr = File.ReadAllText(_fileFullPath);

                List<Telegram> rawTelgramList = JsonConvert.DeserializeObject<List<Telegram>>(rawListStr);

                return rawTelgramList;
            }
            catch (Exception ex)
            {
                // TODO Log the exception 
            }
            return new List<Telegram>();
        }

        public void SaveFile()
        {
            try
            {
                if (!Directory.Exists(PATH))
                {
                    Directory.CreateDirectory(PATH);
                }

                string rawListStr = JsonConvert.SerializeObject(_telegrams);

                File.WriteAllText(_fileFullPath, rawListStr);
            }
            catch (Exception ex)
            {
                // TODO Log the exception
            }
        }
    }
}
