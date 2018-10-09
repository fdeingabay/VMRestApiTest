using System;
using System.Collections.Generic;
using Domain;

namespace Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Delete(int id)
        {
            var existingUser = this.GetByID(id);

            if (existingUser == null)
            {
                throw new InvalidOperationException("El usuario no existe");
            }

            this.userRepository.Delete(existingUser);
            this.userRepository.SaveChanges();
        }

        public IEnumerable<Entities.User> GetAll()
        {
            var users = this.userRepository.GetAll();
            return users;
        }

        public Entities.User GetByID(int id)
        {
            var user = this.userRepository.GetByID(id);
            return user;
        }

        public void Insert(Entities.User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("El usuario no puede ser nulo");
            }

            if (string.IsNullOrEmpty(user.Apellido))
            {
                throw new ArgumentNullException("Apellido");
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new ArgumentNullException("Email");
            }

            if (string.IsNullOrEmpty(user.Nombre))
            {
                throw new ArgumentNullException("Nombre");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentNullException("Password");
            }

            this.userRepository.Insert(user);
            this.userRepository.SaveChanges();
        }

        public void Update(Entities.User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("El usuario no puede ser nulo");
            }

            if (string.IsNullOrEmpty(user.Apellido))
            {
                throw new ArgumentNullException("Apellido");
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new ArgumentNullException("Email");
            }

            if (string.IsNullOrEmpty(user.Nombre))
            {
                throw new ArgumentNullException("Nombre");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentNullException("Password");
            }

            var existingUser = this.GetByID(user.Id);

            if (existingUser == null)
            {
                throw new InvalidOperationException("El usuario no existe");
            }

            existingUser.Apellido = user.Apellido;
            existingUser.Email = user.Email;
            existingUser.Nombre = user.Nombre;
            existingUser.Password = user.Password;

            this.userRepository.Update(existingUser);
            this.userRepository.SaveChanges();
        }
    }
}
