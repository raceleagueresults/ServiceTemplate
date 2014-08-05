using DistributedServices.Entities;
using Infrastructure.Data.MainModule.Hypermedia;
using Infrastructure.Data.MainModule.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Templates
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _templateRepository;

        public TemplateService(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public Domain.Entities.Template GetBy(Func<Domain.Entities.Template, bool> predicate)
        {
            var item = _templateRepository.GetBy(predicate);

            return item;
        }

        public Domain.Entities.Template Add(Domain.Entities.Template item)
        {
            var addedItem = _templateRepository.Add(item);

            return addedItem;
        }

        public Domain.Entities.Template Update(Domain.Entities.Template item)
        {
            var updatedItem = _templateRepository.Update(item);

            return updatedItem;
        }

        public Domain.Entities.Template Delete(int id)
        {
            var deletedItem = _templateRepository.Delete(id);

            return deletedItem;
        }

        public List<Domain.Entities.Template> GetManyBy(Func<Domain.Entities.Template, bool> predicate)
        {
            var items = _templateRepository.GetManyBy(predicate);

            return items;
        }

        public List<Domain.Entities.Template> GetAll()
        {
            var items = _templateRepository.GetAll();

            return items;
        }
    }
}
