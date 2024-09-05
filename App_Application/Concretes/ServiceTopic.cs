using App_Application.Services.Interfaces;
using App_DAL.Context;
using App_DAL.Interfaces;
using App_DAL.Repos;
using App_Domain.Concretes;
using System.Linq.Expressions;

namespace App_Application.Concretes
{
    public class ServiceTopic : IServiceTopic
    {
        private readonly AppDbContext _context;
        private readonly IRepoTopic repoTopic;

        public ServiceTopic(AppDbContext context)
        {
            _context = context;
            repoTopic = new RepoTopic(_context);
        }

        public int Create(Topic topic)
        {
            return repoTopic.Create(topic);
        }

        public int Delete(Topic topic)
        {
            return repoTopic.Delete(topic);
        }

        public IEnumerable<Topic> GetAll(Expression<Func<Topic, bool>> filter)
        {
            IList<Topic> allTopics = new List<Topic>();

            foreach (Topic topic in repoTopic.GetAll())
            {
                //topic herhangi diğer bir topic'in subTopic ise o main değildir. o halde bu koşulun dışındakiler maindir.
                if (!allTopics.Any(x => x.TopicName == topic.TopicName))
                {
                    allTopics.Add(topic);
                }
            }
            return allTopics;
        }

        public IEnumerable<Topic> GetAllFiltered(Expression<Func<Topic, bool>>? filter)
        {
            return repoTopic.GetAllFiltered(filter);
        }

        public bool GetAny(Expression<Func<Topic, bool>> filter)
        {
            return repoTopic.GetAny(filter);
        }

        public Topic GetById(int id)
        {
            return repoTopic.GetById(id);
        }

        public Topic GetFiltered(Expression<Func<Topic, bool>> filter)
        {
            return repoTopic.GetFiltered(filter);
        }

        public int Update(Topic topic)
        {
            return repoTopic.Update(topic);
        }

        public IList<Topic> GetParentTopics()
        {
            IList<Topic> allTopics = new List<Topic>();

            foreach (Topic topic in repoTopic.GetAll())
            {
                //topic herhangi diğer bir topic'in subTopic ise o main değildir. o halde bu koşulun dışındakiler maindir.
                if (!allTopics.Any(x => x.SubTopicName == topic.TopicName))
                {
                    allTopics.Add(topic);
                }
            }

            return repoTopic.GetAll(x => x.SubTopicName != null).ToList();
        }
        public IList<Topic> GetSubTopics(List<Topic> topic)
        {
            return repoTopic.GetAll(x => x.SubTopicName == null).ToList();
            //IList<Topic> subTopics= new List<Topic>();
            //foreach(var item in topic)
            //{
            //    if(repoTopic.GetAny(x=>x.))
            //}


        }
        public IList<Topic> GetMainTopics()
        {
            IList<Topic> allTopics = repoTopic.GetAll().ToList();
            IList<Topic> mainTopics = new List<Topic>();

            foreach (Topic topic in allTopics)
            {
                //topic herhangi diğer bir topic'in subTopic ise o main değildir. o halde bu koşulun dışındakiler maindir.
                if (!repoTopic.GetAny(x => x.SubTopicName == topic.TopicName))
                {
                    if (!mainTopics.Any(x => x.TopicName == topic.TopicName))
                        mainTopics.Add(topic);
                }
            }
            return mainTopics;
        }

        public IList<Topic> GetSubTopics()
        {
            throw new NotImplementedException();
        }


    }
}
