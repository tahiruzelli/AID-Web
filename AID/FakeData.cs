using AID.Model;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataSet = AID.Model.DataSet;

namespace AID
{
    public class FakeData
    {
        private static List<User> _users;
        private static List<Avatar> _avatars;
        private static List<DataSet> _dataSets;
        private static List<Tag> _tags;
        private static List<Announcement> _announcements;
        private static List<Video> _videos;
        private static List<WithdrawRequest> _withdrawRequests;

        public static List<User> getUsers(int count)
        {
            _users = new Faker<User>()
                .RuleFor(u => u.id, f => f.IndexFaker)
                .RuleFor(u => u.name, f => f.Name.FullName())
                .RuleFor(u => u.email, f=> f.Person.Email)
                .RuleFor(u => u.password, f=> f.Random.Word())
                .RuleFor(u => u.avatarId, f=> f.IndexFaker)
                .RuleFor(u => u.balance, f=> f.Random.Double())
                .RuleFor(u => u.totalGain, f=> f.Random.Double())
                .RuleFor(u => u.totalVideoEditetTime, f => f.Random.Double())
                .RuleFor(u => u.createDate, f => f.Person.DateOfBirth)
                .Generate(count);
            return _users;
        }

        public static List<Avatar> getAvatars(int count)
        {
            _avatars = new Faker<Avatar>()
                .RuleFor(u => u.id, f => f.IndexFaker)
                .RuleFor(u => u.avatarUrl, f => f.Person.Avatar)
                .Generate(count);
            return _avatars;
        }
        public static List<Announcement> getAnnouncements(int count)
        {
            _announcements = new Faker<Announcement>()
                .RuleFor(u => u.id, f => f.IndexFaker)
                .RuleFor(u => u.photoUrl, f => f.Person.Avatar)
                .RuleFor(u => u.title, f => f.Name.JobTitle())
                .RuleFor(u => u.description, f => f.Name.JobDescriptor())
                .Generate(count);
            return _announcements;
        }
        public static List<DataSet> getDataSets(int count)
        {
            _dataSets = new Faker<DataSet>()
                .RuleFor(u => u.id, f => f.IndexFaker)
                .RuleFor(u => u.photoUrl, f => f.Person.Avatar)
                .RuleFor(u => u.createTime, f => f.Person.DateOfBirth)
                .RuleFor(u => u.tagId, f => f.IndexFaker)
                .RuleFor(u => u.userId, f => f.IndexFaker)
                .Generate(count);
            return _dataSets;
        }
        public static List<Video> getVideos(int count)
        {
            _videos = new Faker<Video>()
                .RuleFor(u => u.id, f => f.IndexFaker)
                .RuleFor(u => u.videoUrl, f => f.Name.Random.Word())
                .RuleFor(u => u.videoLength, f => f.Random.Double())
                .RuleFor(u => u.totalGain, f => f.Random.Double())
                .RuleFor(u => u.coverImageUrl, f => f.Name.Random.Word())
                .RuleFor(u => u.createTime, f => f.Person.DateOfBirth)
                .Generate(count);
            return _videos;
        }
        public static List<Tag> getTags(int count)
        {
            _tags = new Faker<Tag>()
                .RuleFor(u => u.id, f => f.IndexFaker)
                .RuleFor(u => u.name, f => f.Name.Random.Word())
                .RuleFor(u => u.createTime, f => f.Person.DateOfBirth)
                .Generate(count);
            return _tags;
        }
        public static List<WithdrawRequest> getWithdrawRequests(int count)
        {
            _withdrawRequests = new Faker<WithdrawRequest>()
                .RuleFor(u => u.id, f => f.IndexFaker)
                .RuleFor(u => u.balance, f => f.Random.Double())
                .RuleFor(u => u.cardHolder, f => f.Name.FullName())
                .RuleFor(u => u.cardNo, f => f.Random.Double().ToString())
                .RuleFor(u => u.cvv, f => f.Random.Double())
                .RuleFor(u => u.expDate, f => f.Random.Double().ToString())
                .RuleFor(u => u.userId, f => f.IndexFaker)
                .RuleFor(u => u.createTime, f => f.Person.DateOfBirth)
                .RuleFor(u => u.isApproved, f => f.Random.Bool())
                .Generate(count);
            return _withdrawRequests;
        }
    }
}
