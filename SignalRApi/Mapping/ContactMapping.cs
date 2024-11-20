﻿using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;
using SignalR.EntiyLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ContactMapping:Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();
        }
    }
}
