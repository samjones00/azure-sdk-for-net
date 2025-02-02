// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class representing collection of PolicySetDefinition and their operations over its parent. </summary>
    public partial class SubscriptionPolicySetDefinitionCollection : ArmCollection, IEnumerable<SubscriptionPolicySetDefinition>, IAsyncEnumerable<SubscriptionPolicySetDefinition>
    {
        private readonly ClientDiagnostics _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics;
        private readonly PolicySetDefinitionsRestOperations _subscriptionPolicySetDefinitionPolicySetDefinitionsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionPolicySetDefinitionCollection"/> class for mocking. </summary>
        protected SubscriptionPolicySetDefinitionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionPolicySetDefinitionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SubscriptionPolicySetDefinitionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Resources", SubscriptionPolicySetDefinition.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(SubscriptionPolicySetDefinition.ResourceType, out string subscriptionPolicySetDefinitionPolicySetDefinitionsApiVersion);
            _subscriptionPolicySetDefinitionPolicySetDefinitionsRestClient = new PolicySetDefinitionsRestOperations(_subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, subscriptionPolicySetDefinitionPolicySetDefinitionsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        /// <summary>
        /// This operation creates or updates a policy set definition in the given subscription with the given name.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to create. </param>
        /// <param name="parameters"> The policy set definition properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<SubscriptionPolicySetDefinition>> CreateOrUpdateAsync(bool waitForCompletion, string policySetDefinitionName, PolicySetDefinitionData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policySetDefinitionName, nameof(policySetDefinitionName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _subscriptionPolicySetDefinitionPolicySetDefinitionsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, policySetDefinitionName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ResourcesArmOperation<SubscriptionPolicySetDefinition>(Response.FromValue(new SubscriptionPolicySetDefinition(Client, response), response.GetRawResponse()));
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation creates or updates a policy set definition in the given subscription with the given name.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to create. </param>
        /// <param name="parameters"> The policy set definition properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<SubscriptionPolicySetDefinition> CreateOrUpdate(bool waitForCompletion, string policySetDefinitionName, PolicySetDefinitionData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policySetDefinitionName, nameof(policySetDefinitionName));
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _subscriptionPolicySetDefinitionPolicySetDefinitionsRestClient.CreateOrUpdate(Id.SubscriptionId, policySetDefinitionName, parameters, cancellationToken);
                var operation = new ResourcesArmOperation<SubscriptionPolicySetDefinition>(Response.FromValue(new SubscriptionPolicySetDefinition(Client, response), response.GetRawResponse()));
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation retrieves the policy set definition in the given subscription with the given name.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_Get
        /// </summary>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        public async virtual Task<Response<SubscriptionPolicySetDefinition>> GetAsync(string policySetDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policySetDefinitionName, nameof(policySetDefinitionName));

            using var scope = _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionCollection.Get");
            scope.Start();
            try
            {
                var response = await _subscriptionPolicySetDefinitionPolicySetDefinitionsRestClient.GetAsync(Id.SubscriptionId, policySetDefinitionName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new SubscriptionPolicySetDefinition(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation retrieves the policy set definition in the given subscription with the given name.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_Get
        /// </summary>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        public virtual Response<SubscriptionPolicySetDefinition> Get(string policySetDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policySetDefinitionName, nameof(policySetDefinitionName));

            using var scope = _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionCollection.Get");
            scope.Start();
            try
            {
                var response = _subscriptionPolicySetDefinitionPolicySetDefinitionsRestClient.Get(Id.SubscriptionId, policySetDefinitionName, cancellationToken);
                if (response.Value == null)
                    throw _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SubscriptionPolicySetDefinition(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation retrieves a list of all the policy set definitions in a given subscription that match the optional given $filter. Valid values for $filter are: &apos;atExactScope()&apos;, &apos;policyType -eq {value}&apos; or &apos;category eq &apos;{value}&apos;&apos;. If $filter is not provided, the unfiltered list includes all policy set definitions associated with the subscription, including those that apply directly or from management groups that contain the given subscription. If $filter=atExactScope() is provided, the returned list only includes all policy set definitions that at the given subscription. If $filter=&apos;policyType -eq {value}&apos; is provided, the returned list only includes all policy set definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn and Custom. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all policy set definitions whose category match the {value}.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions
        /// Operation Id: PolicySetDefinitions_List
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: &apos;atExactScope()&apos;, &apos;policyType -eq {value}&apos; or &apos;category eq &apos;{value}&apos;&apos;. If $filter is not provided, no filtering is performed. If $filter=atExactScope() is provided, the returned list only includes all policy set definitions that at the given scope. If $filter=&apos;policyType -eq {value}&apos; is provided, the returned list only includes all policy set definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all policy set definitions whose category match the {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SubscriptionPolicySetDefinition" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SubscriptionPolicySetDefinition> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SubscriptionPolicySetDefinition>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _subscriptionPolicySetDefinitionPolicySetDefinitionsRestClient.ListAsync(Id.SubscriptionId, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionPolicySetDefinition(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SubscriptionPolicySetDefinition>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _subscriptionPolicySetDefinitionPolicySetDefinitionsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, filter, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionPolicySetDefinition(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// This operation retrieves a list of all the policy set definitions in a given subscription that match the optional given $filter. Valid values for $filter are: &apos;atExactScope()&apos;, &apos;policyType -eq {value}&apos; or &apos;category eq &apos;{value}&apos;&apos;. If $filter is not provided, the unfiltered list includes all policy set definitions associated with the subscription, including those that apply directly or from management groups that contain the given subscription. If $filter=atExactScope() is provided, the returned list only includes all policy set definitions that at the given subscription. If $filter=&apos;policyType -eq {value}&apos; is provided, the returned list only includes all policy set definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn and Custom. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all policy set definitions whose category match the {value}.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions
        /// Operation Id: PolicySetDefinitions_List
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: &apos;atExactScope()&apos;, &apos;policyType -eq {value}&apos; or &apos;category eq &apos;{value}&apos;&apos;. If $filter is not provided, no filtering is performed. If $filter=atExactScope() is provided, the returned list only includes all policy set definitions that at the given scope. If $filter=&apos;policyType -eq {value}&apos; is provided, the returned list only includes all policy set definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter=&apos;category -eq {value}&apos; is provided, the returned list only includes all policy set definitions whose category match the {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SubscriptionPolicySetDefinition" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SubscriptionPolicySetDefinition> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<SubscriptionPolicySetDefinition> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _subscriptionPolicySetDefinitionPolicySetDefinitionsRestClient.List(Id.SubscriptionId, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionPolicySetDefinition(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SubscriptionPolicySetDefinition> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _subscriptionPolicySetDefinitionPolicySetDefinitionsRestClient.ListNextPage(nextLink, Id.SubscriptionId, filter, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SubscriptionPolicySetDefinition(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_Get
        /// </summary>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string policySetDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policySetDefinitionName, nameof(policySetDefinitionName));

            using var scope = _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(policySetDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_Get
        /// </summary>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        public virtual Response<bool> Exists(string policySetDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policySetDefinitionName, nameof(policySetDefinitionName));

            using var scope = _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(policySetDefinitionName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_Get
        /// </summary>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        public async virtual Task<Response<SubscriptionPolicySetDefinition>> GetIfExistsAsync(string policySetDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policySetDefinitionName, nameof(policySetDefinitionName));

            using var scope = _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _subscriptionPolicySetDefinitionPolicySetDefinitionsRestClient.GetAsync(Id.SubscriptionId, policySetDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SubscriptionPolicySetDefinition>(null, response.GetRawResponse());
                return Response.FromValue(new SubscriptionPolicySetDefinition(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}
        /// Operation Id: PolicySetDefinitions_Get
        /// </summary>
        /// <param name="policySetDefinitionName"> The name of the policy set definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policySetDefinitionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policySetDefinitionName"/> is null. </exception>
        public virtual Response<SubscriptionPolicySetDefinition> GetIfExists(string policySetDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policySetDefinitionName, nameof(policySetDefinitionName));

            using var scope = _subscriptionPolicySetDefinitionPolicySetDefinitionsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _subscriptionPolicySetDefinitionPolicySetDefinitionsRestClient.Get(Id.SubscriptionId, policySetDefinitionName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SubscriptionPolicySetDefinition>(null, response.GetRawResponse());
                return Response.FromValue(new SubscriptionPolicySetDefinition(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SubscriptionPolicySetDefinition> IEnumerable<SubscriptionPolicySetDefinition>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SubscriptionPolicySetDefinition> IAsyncEnumerable<SubscriptionPolicySetDefinition>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
