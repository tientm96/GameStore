﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Model
{
    public class User
    {

        public virtual ICollection<UserGame> Games { get; set; }
        public string Hobbies { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<WishGame> WishGames { get; set; }
        public ImageUser ImageUser { get; set; }
        public User()
        {
            this.Games = new Collection<UserGame>();
            this.WishGames = new Collection<WishGame>();
        }
    }
}
