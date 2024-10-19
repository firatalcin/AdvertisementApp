﻿using AdvertisementApp.Dtos.AdvertisementAppUserStatusDtos;
using AdvertisementApp.Dtos.AdvertisementDtos;
using AdvertisementApp.Dtos.AppUserDtos;
using AdvertisementApp.Dtos.Interfaces;
using AdvertisementApp.Dtos.MilitaryStatusDtos;

namespace AdvertisementApp.Dtos.AdvertisementAppUserDtos
{
    public class AdvertisementAppUserListDto : IDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public AdvertisementListDto Advertisement { get; set; }

        public int AppUserId { get; set; }

        public AppUserListDto AppUser { get; set; }

        public int AdvertisementAppUserStatusId { get; set; }

        public AdvertisementAppUserStatusListDto AdvertisementAppUserStatus { get; set; }

        public int MilitaryStatusId { get; set; }

        public MilitaryStatusListDto MilitaryStatus { get; set; }

        public DateTime? EndDate { get; set; }

        public int WorkExperience { get; set; }

        public string CvPath { get; set; }
    }
}
