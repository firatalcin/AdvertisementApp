﻿using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.AppUserDtos
{
    public class AppUserUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }

        public string Surname { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public int GenderId { get; set; }
    }
}
