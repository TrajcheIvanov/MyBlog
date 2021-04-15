using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services
{
    public class EventsLikeService : IEventsLikeService
    {
        private IEventsLikeRepository _eventsLikeRepository;
        public EventsLikeService(IEventsLikeRepository eventsLikeRepository)
        {
            _eventsLikeRepository = eventsLikeRepository;
        }

        public void Add(int eventId, int userId)
        {
            var like = _eventsLikeRepository.Get(eventId, userId);

            if (like == null)
            {
                var newLike = new EventLike();
                newLike.EventId = eventId;
                newLike.UserId = userId;

                _eventsLikeRepository.Add(newLike);
            }
        }

        public void Remove(int eventId, int userId)
        {
            var like = _eventsLikeRepository.Get(eventId, userId);

            if (like == null)
            {

                _eventsLikeRepository.Delete(like);
            }
        }
    }
}
