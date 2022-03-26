﻿using System.Threading.Tasks;

namespace Camunda.Api.Client.Identity
{
    public class IdentityService
    {
        private IIdentityRestService _api;

        internal IdentityService(IIdentityRestService api) { _api = api; }

        /// <param name="userId">The id of the user whose group membership is to be retrieved.</param>
        public Task<IdentityGroupMembership> GetMembership(string userId) => _api.GetMembership(new IdentityQuery() { UserId = userId });

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="username">The user's profile</param>
        /// <param name="password">The user's password.</param>
        /// <returns></returns>
        public Task<IdentityVerifiedUser> Verify(string username, string password) => 
            _api.Verify(new IdentityUserCredentials() { Username = username, Password = password });

    }
}
