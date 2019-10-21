// *******************************************************************************
// <copyright file="DataService_Invitations.cs" company="Intuit">
// Copyright (c) 2019 Intuit
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
// *******************************************************************************

namespace Intuit.TSheets.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Intuit.TSheets.Client.Core;
    using Intuit.TSheets.Client.RequestFlow.Contexts;
    using Intuit.TSheets.Client.Utilities;
    using Intuit.TSheets.Model;

    /// <summary>
    /// Top-level service class for interacting with all TSheets API operations.
    /// </summary>
    /// <remarks>
    /// This file contains operations specific to the Invitations endpoint.
    /// </remarks>
    public partial class DataService
    {
        #region Create methods

        /// <summary>
        /// Create Invitations.
        /// </summary>
        /// <remarks>
        /// Invite a single user to your company.
        /// </remarks> 
        /// <param name="invitation">
        /// The <see cref="Invitation"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Invitation"/> object that was created, along with as output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (Invitation, ResultsMeta) CreateInvitation(Invitation invitation)
        {
            (IList<Invitation> invitations, ResultsMeta resultsMeta) = CreateInvitations(new[] { invitation });

            return (invitations.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Create Invitations.
        /// </summary>
        /// <remarks>
        /// Invite one or more users to your company.
        /// </remarks>
        /// <param name="invitations">
        /// The set of <see cref="Invitation"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Invitation"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public (IList<Invitation>, ResultsMeta) CreateInvitations(IEnumerable<Invitation> invitations)
        {
            return AsyncUtil.RunSync(() => CreateInvitationsAsync(invitations));
        }

        /// <summary>
        /// Asynchronously Create Invitations.
        /// </summary>
        /// <remarks>
        /// Invite a single user to your company.
        /// </remarks>
        /// <param name="invitation">
        /// The <see cref="Invitation"/> object to be created.
        /// </param>
        /// <returns>
        /// The <see cref="Invitation"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Invitation, ResultsMeta)> CreateInvitationAsync(
            Invitation invitation)
        {
            (IList<Invitation> invitations, ResultsMeta resultsMeta) = await CreateInvitationsAsync(new[] { invitation }, default).ConfigureAwait(false);

            return (invitations.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Invitations, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Invite a single user to your company.
        /// </remarks>
        /// <param name="invitation">
        /// The <see cref="Invitation"/> object to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The <see cref="Invitation"/> object that was created, along with an output
        /// instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(Invitation, ResultsMeta)> CreateInvitationAsync(
            Invitation invitation,
            CancellationToken cancellationToken)
        {
            (IList<Invitation> invitations, ResultsMeta resultsMeta) = await CreateInvitationsAsync(new[] { invitation }, cancellationToken).ConfigureAwait(false);

            return (invitations.FirstOrDefault(), resultsMeta);
        }

        /// <summary>
        /// Asynchronously Create Invitations.
        /// </summary>
        /// <remarks>
        /// Invite one or more users to your company.
        /// </remarks>
        /// <param name="invitations">
        /// The set of <see cref="Invitation"/> objects to be created.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Invitation"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Invitation>, ResultsMeta)> CreateInvitationsAsync(
            IEnumerable<Invitation> invitations)
        {
            return await CreateInvitationsAsync(invitations, default).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronously Create Invitations, with support for cancellation.
        /// </summary>
        /// <remarks>
        /// Invite one or more users to your company.
        /// </remarks>
        /// <param name="invitations">
        /// The set of <see cref="Invitation"/> objects to be created.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        /// <returns>
        /// The set of the <see cref="Invitation"/> objects that were created, along with
        /// an output instance of the <see cref="ResultsMeta"/> class containing additional data.
        /// </returns>
        public async Task<(IList<Invitation>, ResultsMeta)> CreateInvitationsAsync(
            IEnumerable<Invitation> invitations,
            CancellationToken cancellationToken)
        {
            var context = new CreateContext<Invitation>(EndpointName.Invitations, invitations);

            await ExecuteOperationAsync(context, cancellationToken).ConfigureAwait(false);

            return (context.Results.Items, context.ResultsMeta);
        }

        #endregion
    }
}
