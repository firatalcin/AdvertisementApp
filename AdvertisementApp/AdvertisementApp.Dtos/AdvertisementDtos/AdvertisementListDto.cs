﻿using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.AdvertisementDtos
{
    public class AdvertisementListDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public bool Status { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
