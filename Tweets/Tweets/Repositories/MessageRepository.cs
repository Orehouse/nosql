using System;
using System.Collections.Generic;
using System.Configuration;
<<<<<<< HEAD
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
=======
using System.Data.Linq.Mapping;
>>>>>>> dc96e533460e2c89708379c6b599b92bc5b340c1
using System.Linq;
using Tweets.ModelBuilding;
using Tweets.Models;

namespace Tweets.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly string connectionString;
        private readonly AttributeMappingSource mappingSource;
        private readonly IMapper<Message, MessageDocument> messageDocumentMapper;

        public MessageRepository(IMapper<Message, MessageDocument> messageDocumentMapper)
        {
            this.messageDocumentMapper = messageDocumentMapper;
            mappingSource = new AttributeMappingSource();
            connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        }

        public void Save(Message message)
        {
<<<<<<< HEAD
            //TODO: Здесь нужно реализовать вставку сообщения в базу
            var messageDocument = messageDocumentMapper.Map(message);
            var dataContext = new DataContext(connectionString, mappingSource);
            var messageTable = dataContext.GetTable<MessageDocument>();
            messageTable.InsertOnSubmit(messageDocument);
            dataContext.SubmitChanges();
=======
            var messageDocument = messageDocumentMapper.Map(message);
            //TODO: Здесь нужно реализовать вставку сообщения в базу
>>>>>>> dc96e533460e2c89708379c6b599b92bc5b340c1
        }

        public void Like(Guid messageId, User user)
        {
<<<<<<< HEAD
            //TODO: Здесь нужно реализовать вставку одобрения в базу
            var likeDocument = new LikeDocument {MessageId = messageId, UserName = user.Name, CreateDate = DateTime.UtcNow};
            var dataContext = new DataContext(connectionString, mappingSource);
            var likeTable = dataContext.GetTable<LikeDocument>();
            likeTable.InsertOnSubmit(likeDocument);
            dataContext.SubmitChanges();
=======
            var likeDocument = new LikeDocument {MessageId = messageId, UserName = user.Name, CreateDate = DateTime.UtcNow};
            //TODO: Здесь нужно реализовать вставку одобрения в базу
>>>>>>> dc96e533460e2c89708379c6b599b92bc5b340c1
        }

        public void Dislike(Guid messageId, User user)
        {
            //TODO: Здесь нужно реализовать удаление одобрения из базы
<<<<<<< HEAD
            var dataContext = new DataContext(connectionString, mappingSource);
            var likeTable = dataContext.GetTable<LikeDocument>();
            var isLiked = likeTable.FirstOrDefault(like => like.MessageId.Equals(messageId) && like.UserName.Equals(user.Name));
            if (isLiked != null)
            {
                likeTable.DeleteOnSubmit(isLiked);
                dataContext.SubmitChanges();
            }
=======
>>>>>>> dc96e533460e2c89708379c6b599b92bc5b340c1
        }

        public IEnumerable<Message> GetPopularMessages()
        {
            //TODO: Здесь нужно возвращать 10 самых популярных сообщений
<<<<<<< HEAD
            var dataContext = new DataContext(connectionString, mappingSource);
            var messageTable = dataContext.GetTable<MessageDocument>();
            var likesTable = dataContext.GetTable<LikeDocument>();
            var messages = messageTable
                .Select(message => new Message()
                {
                    CreateDate = message.CreateDate,
                    Id = message.Id,
                    Text = message.Text,
                    User = new User() { Name = message.UserName},
                    Likes = likesTable.Count(like => like.MessageId.Equals(message.Id))
                })
                .Take(10)
                .OrderByDescending(message => message.Likes)
                .AsEnumerable()
                .ToArray();
            return messages;
=======
            return Enumerable.Empty<Message>();
>>>>>>> dc96e533460e2c89708379c6b599b92bc5b340c1
        }

        public IEnumerable<UserMessage> GetMessages(User user)
        {
            //TODO: Здесь нужно получать все сообщения конкретного пользователя
<<<<<<< HEAD
            var dataContext = new DataContext(connectionString, mappingSource);
            var messageTable = dataContext.GetTable<MessageDocument>();
            var likesTable = dataContext.GetTable<LikeDocument>();
            var messages = messageTable
                .Where(message => message.UserName.Equals(user.Name))
                .Select(message => new UserMessage()
                {
                    CreateDate = message.CreateDate,
                    Id = message.Id,
                    Text = message.Text,
                    User = user,
                    Likes = likesTable.Count(like => like.MessageId.Equals(message.Id)),
                    Liked = likesTable.Count(like => like.MessageId.Equals(message.Id) && like.UserName.Equals(message.UserName)) != 0
                })
                .OrderByDescending(message => message.CreateDate)
                .AsEnumerable();
            return messages;
=======
            return Enumerable.Empty<UserMessage>();
>>>>>>> dc96e533460e2c89708379c6b599b92bc5b340c1
        }
    }
}