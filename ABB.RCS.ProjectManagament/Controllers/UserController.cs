using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABB.RCS.ProjectManagament.Models;
using ABB.RCS.ProjectManagament.UserRoleRepository;
using ABB.RCS.SystemManagament.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABB.RCS.ProjectManagament.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly ABBRCSContext UserContext;
        public UserController(ABBRCSContext UserRepository)
        {
            UserContext = UserRepository;
        }

        /// <summary>
        /// GetUsers api method is used get all users
        /// </summary>
        /// <returns></returns>
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Users> GetUsers()
        {
            return UserContext.Users.ToList();
        }

        /// <summary>
        /// Post this api method is used to save user data into database
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        // POST api/<controller>
        [HttpPost]
        public int Post([FromBody]Users users)
        {
            int SaveReturn = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    UserContext.Users.Add(users);
                    SaveReturn = UserContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return SaveReturn;
        }

        /// <summary>
        /// FindUser this api method is used to find the user
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        //[HttpGet]
        //public string FindUser([FromBody]Users users)
        //{
        //    String FindUser = string.Empty;

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            FindUser = UserContext.Users.Find(users.Username).ToString();

        //            if(string.IsNullOrEmpty(FindUser))
        //            {
        //                FindUser = "User is not exist in this app;ication.";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return FindUser;
        //}

        /// <summary>
        /// Put this method is used to update/edit user data into database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="users"></param>
        /// <returns></returns>
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody]Users users)
        {
            int UpdateReturn = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    UserContext.Entry(users).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    UpdateReturn = UserContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return UpdateReturn;
        }

        /// <summary>
        /// Delete this method is used delete the userd data from the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="users"></param>
        /// <returns></returns>
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public int Delete(int id, [FromBody]Users users)
        {
            int DeleteReturn = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    UserContext.Entry(User).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    UserContext.Users.Remove(users);
                    DeleteReturn = UserContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return DeleteReturn;
        }
    }
}
