﻿using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntiyLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController:ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService,IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var value=_mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _featureService.TAdd(new Feature()
            {
                Title1 = createFeatureDto.Title1,   
                Description1 = createFeatureDto.Description1,   
                Title2 = createFeatureDto.Title2,   
                Description2 = createFeatureDto.Description2,       
                Title3 = createFeatureDto.Title3,   
                Description3 = createFeatureDto.Description3,   
            });
            return Ok("Öne Çıkanlar başarıyla eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value=_featureService.TGetByID(id); 
            _featureService.TDelete(value); 
            return Ok("Öne Çıkan Başarıyla Silindi");   
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.TUpdate(new Feature()
            {
                Title1 = updateFeatureDto.Title1,
                Description1 = updateFeatureDto.Description1,
                Title2 = updateFeatureDto.Title2,
                Description2 = updateFeatureDto.Description2,
                Title3 = updateFeatureDto.Title3,
                Description3 = updateFeatureDto.Description3,

            });
            return Ok("Öne çıkan başarıyla güncellendi");
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value= _featureService.TGetByID(id);    

            return Ok(value);   
        }


    }
}
