﻿using System;
using System.Net;
using System.Reflection;
using System.Net.Http;
using System.Collections.Generic;

namespace SteamMini
{
  public  class Controller : IDisposable
    {
        public string BASE_URL { get; private set; }
        public static Uri BASE_URI { get; private set; }

        public Controller()
        {
            Init(49911);
        }

        protected void Init(int port)
        {
            // BASE_URL = $"http://gamestorecrosplatform.azurewebsites.net";
            BASE_URL = "http://localhost:49911/";
            BASE_URI = new Uri(BASE_URL);
        }

        public void Dispose()
        {
        }
    }
}
