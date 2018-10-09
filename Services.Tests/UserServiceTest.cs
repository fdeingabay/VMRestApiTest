using Infrastructure.Cross.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        private IUserService userService;

        [TestInitialize]
        public void TestSetup()
        {
            userService = FactoryIoC.Container.Resolve<UserService>();
        }

        [TestMethod]
        public void Insert_Usuario_OK()
        {
            var userCount = this.userService.GetAll().Count();

            userService.Insert(new Entities.User()
            {
                Apellido = "Nuevo",
                Nombre = "Usuario",
                Email = "nuevo@usuario.com",
                Password = "8745"
            });

            var newUserCount = this.userService.GetAll().Count();

            Assert.AreEqual(userCount + 1, newUserCount);
        }

        [TestMethod]
        public void GetAll_Returns_More_Than_Cero_Users()
        {
            var previousExistingUsers = this.userService.GetAll();

            var userToInsert = new Entities.User()
            {
                Apellido = string.Format("Apellido for Test {0}", previousExistingUsers.Count() + 1),
                Nombre = string.Format("Nombre for Test {0}", previousExistingUsers.Count() + 1),
                Email = string.Format("Email for Test {0}", previousExistingUsers.Count() + 1),
                Password = string.Format("Password for Test {0}", previousExistingUsers.Count() + 1)
            };

            this.userService.Insert(userToInsert);

            var newExistingUsers = this.userService.GetAll();

            Assert.AreEqual(previousExistingUsers.Count() + 1, newExistingUsers.Count());
        }

        [TestMethod]
        public void Get_By_Id_OK()
        {
            var allUsers = this.userService.GetAll();

            var existingUser = this.userService.GetByID(allUsers.First().Id);

            Assert.AreEqual(allUsers.First().Id, existingUser.Id);
        }

        [TestMethod]
        public void Get_By_Unexisten_Id_Returns_Null()
        {
            var existingUser = this.userService.GetByID(-1);

            Assert.AreEqual(null, existingUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Insert_Usuario_Nombre_Nulo_Throws_ArgumentNullException()
        {
            userService.Insert(new Entities.User
            {
                Id = -12,
                Nombre = null,
                Apellido = "Lopez",
                Email = "lopez@lopez.com",
                Password = "111111"
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Insert_Usuario_Apellido_Nulo_Throws_ArgumentNullException()
        {
            userService.Insert(new Entities.User
            {
                Id = -12,
                Nombre = "Juan",
                Apellido = null,
                Email = "lopez@lopez.com",
                Password = "111111"
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Insert_Usuario_Email_Nulo_Throws_ArgumentNullException()
        {
            userService.Insert(new Entities.User
            {
                Id = -12,
                Nombre = "juan",
                Apellido = "Lopez",
                Email = null,
                Password = "111111"
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Insert_Usuario_Password_Nulo_Throws_ArgumentNullException()
        {
            userService.Insert(new Entities.User
            {
                Id = -12,
                Nombre = "juan",
                Apellido = "Lopez",
                Email = "lopez@lopez.com",
                Password = null
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Insert_Usuario_Nulo_Throws_ArgumentNullException()
        {
            userService.Insert(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Update_Usuario_Inexsitente_Throws_InvalidOperationException()
        {
            userService.Update(new Entities.User()
            {
                Id = -12,
                Nombre = "Juan",
                Apellido = "Lopez",
                Email = "lopez@lopez.com",
                Password = "111111"
            });
        }

        [TestMethod]
        public void Update_Usuario_OK()
        {
            var users = this.userService.GetAll();

            var modifiedUser = users.First();
            modifiedUser.Nombre = "Nuevo Nombre";

            userService.Update(modifiedUser);

            users = this.userService.GetAll();
            var firstUser = users.First();

            Assert.AreEqual(firstUser.Nombre, modifiedUser.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_Usuario_Nulo_Throws_ArgumentNullException()
        {
            userService.Update(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_Usuario_Nombre_Nulo_Throws_ArgumentNullException()
        {
            var users = this.userService.GetAll();

            var modifiedUser = users.First();
            modifiedUser.Nombre = null;

            userService.Update(modifiedUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_Usuario_Apellido_Nulo_Throws_ArgumentNullException()
        {
            var users = this.userService.GetAll();

            var modifiedUser = users.First();
            modifiedUser.Apellido = null;

            userService.Update(modifiedUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_Usuario_Email_Nulo_Throws_ArgumentNullException()
        {
            var users = this.userService.GetAll();

            var modifiedUser = users.First();
            modifiedUser.Email = null;

            userService.Update(modifiedUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_Usuario_Password_Nulo_Throws_ArgumentNullException()
        {
            var users = this.userService.GetAll();

            var modifiedUser = users.First();
            modifiedUser.Password = null;

            userService.Update(modifiedUser);
        }

        [TestMethod]
        public void Delete_Usuario_OK()
        {
            var users = this.userService.GetAll();

            var userToDelete = users.First();

            userService.Delete(userToDelete.Id);

            var deletedUser = this.userService.GetByID(userToDelete.Id);
            Assert.IsNull(deletedUser);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Delete_Usuario_Inexsitente_Throws_InvalidOperationException()
        {
            userService.Delete(-12);
        }
    }
}
