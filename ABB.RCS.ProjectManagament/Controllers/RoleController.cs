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
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly ABBRCSContext RoleContext;
        public RoleController(ABBRCSContext RoleRepository)
        {
            RoleContext = RoleRepository;
        }

        /// <summary>
        /// GetRoles this api method is used to get the user roles from the database
        /// </summary>
        /// <returns></returns>
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Roles> GetRoles()
        {
            return RoleContext.Roles.ToList();
        }

        /// <summary>
        /// Post this api method is used to save the user roles into database
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        // POST api/<controller>
        [HttpPost]
        public int Post([FromBody]Roles roles)
        {
            int SaveReturn = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    RoleContext.Roles.Add(roles);
                    SaveReturn = RoleContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return SaveReturn;
        }

        /// <summary>
        /// FindRole thie api method is used to find the user role in the database
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        //[HttpGet]
        //public string FindRole([FromBody]Roles roles)
        //{
        //    String FindRole = string.Empty;

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            FindRole = RoleContext.Roles.Find(roles.RoleName).ToString();

        //            if (string.IsNullOrEmpty(FindRole))
        //            {
        //                FindRole = "Role is not exist in this app;ication.";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return FindRole;
        //}

        /// <summary>
        /// Put api method is used to update/edit user roles into database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody]Roles roles)
        {
            int UpdateReturn = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    RoleContext.Entry(roles).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    UpdateReturn = RoleContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return UpdateReturn;
        }

        /// <summary>
        /// Delete thie api is used to delete roles from the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public int Delete(int id, [FromBody]Roles roles)
        {
            int DeleteReturn = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    RoleContext.Entry(User).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    RoleContext.Roles.Remove(roles);
                    DeleteReturn = RoleContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
            return DeleteReturn;
        }
    }
}
