﻿using GameStore.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.DTOs
{
    public class GameDTOs
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual TitlePublisher Publisher { get; set; }
        public virtual ICollection<TitleUser> Members { get; set; }
        public virtual ICollection<TitleUser> FavoriteMembers { get; set; }
        public float Rating { get; set; }
        public string VideoUrl { get; set; }
        public string Content { get; set; }
        public virtual ICollection<TitleCategory> Categories { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Price { get; set; }
        public ICollection<TitleImagePublisher> ImageGames { get; set; }
        public GameDTOs()
        {
            Members = new Collection<TitleUser>();
            FavoriteMembers = new Collection<TitleUser>();
            Categories = new Collection<TitleCategory>();
            ImageGames = new Collection<TitleImagePublisher>();
        }
    }

    public class BuyGameObject
    {
        public string IdGame { get; set; }
        public BuyGameObject(string idgame)
        {
            IdGame = idgame;
        }
    }
}
