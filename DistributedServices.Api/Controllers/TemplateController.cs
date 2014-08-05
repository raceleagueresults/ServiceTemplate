using Application.Services.Templates;
using DistributedServices.Entities;
using Infrastructure.Common.Caching;
using Infrastructure.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DistributedServices.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class TemplateController : ApiController
    {
        private readonly ITemplateService _templateService;

        private readonly IMapper<Domain.Entities.Template, DistributedServices.Entities.TemplateDto> _mapper;

        private readonly ICache<DistributedServices.Entities.TemplateDto> _cache;

        private const string TemplateCacheIdFormat = "template-{0}";

        public TemplateController(ITemplateService templateService, IMapper<Domain.Entities.Template, DistributedServices.Entities.TemplateDto> mapper, ICache<DistributedServices.Entities.TemplateDto> cache)
        {
            _templateService = templateService;

            _mapper = mapper;

            _cache = cache;
        }

        [Route("templates")]
        public List<TemplateDto> GetAll()
        {
            var items = _templateService.GetAll();

            return _mapper.Map(items);
        }

        [Route("templates/{id}")]
        public TemplateDto GetBy(int id)
        {
            var item = _cache.Get(string.Format(TemplateCacheIdFormat, id));

            if (item != null)
                return item;

            item = _mapper.Map(_templateService.GetBy(i => i.Id == id));

            return item;
        }

        [Route("templates")]
        public TemplateDto Post(TemplateDto hypermedia, string clientToken)
        {
            var mappedItem = _mapper.Map(hypermedia);

            var addedItem = _templateService.Add(mappedItem);

            var mappedAddedItem = _mapper.Map(addedItem);

            _cache.Add(mappedAddedItem, string.Format(TemplateCacheIdFormat, addedItem.Id));

            return mappedAddedItem;
        }

        [Route("templates/{id}")]
        public TemplateDto Put(string clientToken, int id, TemplateDto item)
        {
            item.Id = id;

            var mappedItem = _mapper.Map(item);

            var updatedItem = _templateService.Update(mappedItem);

            var mappedUpdatedItem = _mapper.Map(updatedItem);

            _cache.Update(mappedUpdatedItem, string.Format(TemplateCacheIdFormat, clientToken, mappedUpdatedItem.Id));

            return mappedUpdatedItem;
        }

        [Route("templates/{id}")]
        public TemplateDto Delete(string clientToken, int id)
        {
            var deletedItem = _templateService.Delete(id);

            _cache.Remove(string.Format(TemplateCacheIdFormat, clientToken, deletedItem.Id));

            return _mapper.Map(deletedItem);
        }
    }
}
