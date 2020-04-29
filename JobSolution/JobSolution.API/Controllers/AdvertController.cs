﻿using AutoMapper;
using JobSolution.DTO.DTO;
using JobSolution.Infrastructure.Pagination;
using JobSolution.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSolution.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertServices _advertService;
        private readonly ICategoryService _categoryService;
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _context;


        public AdvertController(IAdvertServices advertServices, ICategoryService categoryService, ICityService cityService, IMapper mapper, IHttpContextAccessor context)
        {
            _advertService = advertServices;
            _categoryService = categoryService; ;
            _cityService = cityService;
            _mapper = mapper;
            _context = context;

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_advertService.GetAll().Result.ToList()); 
        }


        [HttpGet("{advertId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int advertId)
        {
            var obj = await _advertService.GetByID(advertId);
            return Ok(obj);
        }

        [HttpPut("Update/{advertId}")]
        public async Task<IActionResult> Update([FromBody]AdvertDTO advert, int advertId)
        {
            if (ModelState.IsValid)
            {
                await _advertService.Update(advert, advertId);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Post([FromBody] AdvertDTO advertDTO)
        {
            if (ModelState.IsValid)
            {
                await _advertService.Add(advertDTO);

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int advertId)
        {
            await _advertService.Remove(advertId);
            return Ok();
        }

        [HttpPost("Student/Adverts")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPageForTableEmployer([FromBody] PagedRequest pagedRequest)
        {
            var result = await _advertService.GetAdvertsForStudent(pagedRequest, _mapper);
            return Ok(result);
        }
    }
}
