﻿using GameStore.Common;
using GameStore.DTOs;
using GameStore.Model;
using Newtonsoft.Json;
using SteamMini.Class;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace SteamMini
{
    public class AccountsControllerShould : Controller
    {
        public static string PostNewAccountController(object accountObject)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri baseAddress = new Uri("http://localhost:49911/");
                client.BaseAddress = baseAddress;

                HttpResponseMessage result = client.PostAsJsonAsync("api/accounts", accountObject).Result;

                var content = result.Content.ReadAsStringAsync().Result;
                Response<string> response = JsonConvert.DeserializeObject<Response<string>>(content);
                var rs = response.IsSuccess.ToString();

                if(rs == "False")
                {
                    return response.Message.Equals("Duplicate user") ? "email" : "user";
                }
                return "true";  
            }
        }

        public static string PostAccountLikeGameController(object gameObject, string Id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri baseAddress = new Uri("http://localhost:49911/");
                client.BaseAddress = baseAddress;

                HttpResponseMessage result = client.PostAsJsonAsync($"/api/Accounts/like/{Id}", gameObject).Result;
                var content = result.Content.ReadAsStringAsync().Result;
                Response<string> response = JsonConvert.DeserializeObject<Response<string>>(content);
                var rs = response.IsSuccess.ToString();

                return rs; // "True", "False"
            }
        }

        public static GetUserResponse UpdateAccountController(object accountObject, string Id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri baseAddress = new Uri("http://localhost:49911/");
                client.BaseAddress = baseAddress;

                HttpResponseMessage result = client.PutAsJsonAsync($"api/Accounts/edit-user/{Id}", accountObject).Result;

                var content = result.Content.ReadAsStringAsync().Result;

                var response = JsonConvert.DeserializeObject<GetUserResponse>(content);

                return response;
            }
        }

        public static GameStore.DTOs.PayloadBody GetUserByIdController(string Id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri baseAddress = new Uri("http://localhost:49911/");
                client.BaseAddress = baseAddress;

                HttpResponseMessage result = client.GetAsync($"api/accounts/{Id}").Result;
                var content = result.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<GetUserResponse>(content);

                return response.Payload;
            }
        }


        public static string UserBuyGameController(object accountObject, string iduser)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri baseAddress = new Uri("http://localhost:49911/");
                client.BaseAddress = baseAddress;

                //accountObject: contain id game
                HttpResponseMessage result = client.PostAsJsonAsync($"api/Accounts/buy/{iduser}", accountObject).Result;

                var content = result.Content.ReadAsStringAsync().Result;

                var response = JsonConvert.DeserializeObject<BuyGameDTO>(content);

                if(response.IsSuccess.ToString() == "False")
                {
                    if (response.Message.Equals("The input is not in right format"))
                    {
                        return "iduserwrong";
                    }
                    else if (response.Message.Equals("Your account don't enought money to buy this game"))
                    {
                        return "notenoughmoney";
                    }
                    else
                    {
                        return "youhavepurchase";
                    }
                }
                return response.Payload; //game id buy
            }
        }


        //add money user
        public static GetUserResponse UpdateMoneyAccountController(object accountObject, string Id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri baseAddress = new Uri("http://localhost:49911/");
                client.BaseAddress = baseAddress;

                HttpResponseMessage result = client.PutAsJsonAsync($"api/Accounts/recharge/{Id}", accountObject).Result;

                var content = result.Content.ReadAsStringAsync().Result;

                var response = JsonConvert.DeserializeObject<GetUserResponse>(content);

                return response;
            }
        }


        public static GetFreeCodeResponse PostEnterFreeCodeAccountController(object accountObject, string Id)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri baseAddress = new Uri("http://localhost:49911/");
                client.BaseAddress = baseAddress;

                HttpResponseMessage result = client.PostAsJsonAsync($"api/Accounts/buy/freecode/{Id}", accountObject).Result;

                var content = result.Content.ReadAsStringAsync().Result;

                var response = JsonConvert.DeserializeObject<GetFreeCodeResponse>(content);

                return response;
            }
        }


        //-----------------------------
        public void TestGetAllUsersController()
        {
            using (HttpClient client = new HttpClient())
            {
                Uri baseAddress = new Uri("http://localhost:49911/");
                client.BaseAddress = baseAddress;

                HttpResponseMessage result = client.GetAsync("api/accounts").Result;
                var content = result.Content.ReadAsStringAsync().Result;
                Responses<UserDTOs> freeCodeResponse = JsonConvert.DeserializeObject<Responses<UserDTOs>>(content);
            }
        }

    }
}
