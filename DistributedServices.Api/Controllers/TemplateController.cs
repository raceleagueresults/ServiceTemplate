using Application.Services.Templates;
using DistributedServices.Api.Filters;
using DistributedServices.Api.Helpers;
using DistributedServices.Entities;
using Infrastructure.Common.Caching;
using Infrastructure.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DistributedServices.Api.Controllers
{
    [BasicAuthorizationFilter]
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class TemplateController : ApiController
    {
        private readonly ITemplateService _templateService;

        private readonly IMapper<Domain.Entities.Template, DistributedServices.Entities.TemplateDto> _mapper;

        private readonly ICache<DistributedServices.Entities.TemplateDto> _cache;

        private const string TemplateCacheIdFormat = "template-{0}";

        // Test for jenkins
        public TemplateController(ITemplateService templateService, IMapper<Domain.Entities.Template, DistributedServices.Entities.TemplateDto> mapper, ICache<DistributedServices.Entities.TemplateDto> cache)
        {
            _templateService = templateService;

            _mapper = mapper;

            _cache = cache;
        }

        [Route("templates")]
        public Response<List<TemplateDto>> GetAll()
        {
            var items = _templateService.GetAll();

            return items.Any()
                    ? ApiResponse<List<TemplateDto>>.Success(_mapper.Map(items))
                    : ApiResponse<List<TemplateDto>>.NotFound("No templates exist.");
        }

        [Route("templates/{id}")]
        public Response<TemplateDto> GetBy(int id)
        {
            var item = _cache.Get(string.Format(TemplateCacheIdFormat, id));

            if (item != null)
                return ApiResponse<TemplateDto>.Success(item);

            var mappedItem = _mapper.Map(_templateService.GetBy(i => i.Id == id));

            return mappedItem != null
                    ? ApiResponse<TemplateDto>.Success(mappedItem)
                    : ApiResponse<TemplateDto>.NotFound(string.Format("No template with id {0} can be found.", id));
        }

        [Route("templates")]
        public Response<TemplateDto> Post(TemplateDto template, string clientToken)
        {
            var mappedItem = _mapper.Map(template);

            var addedItem = _templateService.Add(mappedItem);

            var mappedAddedItem = _mapper.Map(addedItem);

            _cache.Add(mappedAddedItem, string.Format(TemplateCacheIdFormat, addedItem.Id));

            return ApiResponse<TemplateDto>.Success(mappedAddedItem);
        }

        [Route("templates/{id}")]
        public Response<TemplateDto> Put(int id, TemplateDto item)
        {
            var itemToUpdate = _templateService.GetBy(i => i.Id == id);

            if (itemToUpdate == null)
                return ApiResponse<TemplateDto>.BadRequest(string.Format("No template with id {0} can be found.", id));

            item.Id = id;

            var mappedItem = _mapper.Map(item);

            var updatedItem = _templateService.Update(mappedItem);

            var mappedUpdatedItem = _mapper.Map(updatedItem);

            _cache.Update(mappedUpdatedItem, string.Format(TemplateCacheIdFormat, mappedUpdatedItem.Id));

            return ApiResponse<TemplateDto>.Success(mappedUpdatedItem);
        }

        [Route("templates/{id}")]
        public Response<TemplateDto> Delete(int id)
        {
            var itemToDelete = _templateService.GetBy(i => i.Id == id);

            if (itemToDelete == null)
                return ApiResponse<TemplateDto>.BadRequest(string.Format("No template with id {0} can be found.", id));

            var deletedItem = _templateService.Delete(id);

            _cache.Remove(string.Format(TemplateCacheIdFormat, id));

            return ApiResponse<TemplateDto>.Success(_mapper.Map(deletedItem));
        }

        [Route("template/test")]
        public string Test(string text, int number)
        {
            var combo = text + number.ToString();

            return combo;
        }
    }
}
