﻿using AdvertisementApp.Dtos.Interfaces;

namespace AdvertisementApp.Dtos.ProvidedServiceDtos
{
    public class ProvidedServiceUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }
    }
}
