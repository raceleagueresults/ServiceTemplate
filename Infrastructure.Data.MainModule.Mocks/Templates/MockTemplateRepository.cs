using Infrastructure.Data.MainModule.Hypermedia;
using Infrastructure.Data.MainModule.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.MainModule.Mocks.Templates
{
    public class MockTemplateRepository : ITemplateRepository
    {
        private static List<Domain.Entities.Template> _templates = new List<Domain.Entities.Template>
            {
                new Domain.Entities.Template 
                {
                    Property1 = (new Random()).Next().ToString(),
                    Property2 = (new Random()).Next(),
                    DateCreated = DateTime.Now,
                    Id = 1
                },
                new Domain.Entities.Template 
                {
                    Property1 = (new Random()).Next().ToString(),
                    Property2 = (new Random()).Next(),
                    DateCreated = DateTime.Now.AddDays(1),
                    Id = 2
                }
            };

        public List<Domain.Entities.Template> GetManyBy(Func<Domain.Entities.Template, bool> predicate)
        {
            return _templates;
        }

        public Domain.Entities.Template GetBy(Func<Domain.Entities.Template, bool> predicate)
        {
            return _templates.First();
        }

        public Domain.Entities.Template Add(Domain.Entities.Template item)
        {
            _templates.Add(item);

            return item;
        }

        public Domain.Entities.Template Update(Domain.Entities.Template item)
        {
            var templateToUpdate = _templates.FirstOrDefault(i => i.Id == item.Id);

            _templates.Remove(templateToUpdate);

            _templates.Add(item);

            return item;
        }

        public Domain.Entities.Template Delete(int id)
        {
            var templateToRemove = _templates.FirstOrDefault(i => i.Id == id);

            _templates.Remove(templateToRemove);

            return templateToRemove;
        }

        public List<Domain.Entities.Template> GetAll()
        {
            return _templates;
        }
    }
}
