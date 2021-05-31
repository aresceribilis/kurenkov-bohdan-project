using System;

namespace Vismy
{
    enum UserStatus
    {
        User,
        Moderator,
        Administrator
    }

    class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age => DateTime.Today.Year - BirthDate.Year;
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string ProfilePhotoAdress { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        internal UserStatus Status { get; set; }

        public User(in string name, in string surname, in string nickname, in string password,
            in UserStatus status = UserStatus.User)
        {
            Name = name;
            Surname = surname;
            Nickname = nickname;
            Password = password;
            Followers = 0;
            Following = 0;
            Status = status;
        }

        public User(in string name, in string surname, in string nickname, in string password,
            in UserStatus status = UserStatus.User,
            params object[] props) : this(name,
            surname, nickname, password)
        {
            BirthDate = (DateTime) props[0];
            PhoneNumber = (string) props[1];
            EMail = (string) props[2];
            ProfilePhotoAdress = (string) props[3];
        }
    }
}