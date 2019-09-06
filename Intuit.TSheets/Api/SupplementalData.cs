// *******************************************************************************
// <copyright file="SupplementalData.cs" company="Intuit">
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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Intuit.TSheets.Model;
    using Intuit.TSheets.Model.Exceptions;

    /// <summary>
    /// Additional objects related to the entities returned, contained with the <see cref="ResultsMeta"/> object.
    /// </summary>
    /// <remarks>
    /// Supplemental data is available only if enabled within <see cref="RequestOptions"/> (enabled by default).
    /// To reduce payload size and improve response time, the value can be disabled.
    /// </remarks>
    public class SupplementalData
    {
        private readonly Dictionary<Type, Dictionary<int, IIdentifiable>> supplementalData
            = new Dictionary<Type, Dictionary<int, IIdentifiable>>();

        /// <summary>
        /// Returns a supplemental data entity of given type, having the provided id.
        /// </summary>
        /// <typeparam name="T">The type of entity to retrieve.</typeparam>
        /// <param name="id">The id of the entity to retrieve.</param>
        /// <returns>The entity with given id.</returns>
        /// <exception cref="NotFoundException">
        /// Not found exception is thrown if no entity with given id exists for the provided type.
        /// </exception>
        public T GetById<T>(int id)
            where T : IIdentifiable
        {
            Type type = typeof(T);

            if (!this.supplementalData.ContainsKey(type) || !this.supplementalData[type].ContainsKey(id))
            {
                throw new NotFoundException($"Type {type} with id# {id} not found in supplemental data.");
            }

            return (T)this.supplementalData[type][id];
        }

        /// <summary>
        /// Returns all supplemental data items of given entity type.
        /// </summary>
        /// <typeparam name="T">The type of data entity.</typeparam>
        /// <returns>The list of supplemental data items.</returns>
        public IReadOnlyList<T> GetAll<T>()
            where T : IIdentifiable
        {
            Type type = typeof(T);

            return this.supplementalData.ContainsKey(type)
                ? this.supplementalData[type].Values.Cast<T>().ToList().AsReadOnly()
                : new List<T>().AsReadOnly();
        }

        /// <summary>
        /// Returns all supplemental data items, regardless of entity type.
        /// </summary>
        /// <returns>The list of supplemental data items.</returns>
        public IReadOnlyList<IIdentifiable> GetAll()
        {
            return this.supplementalData.Values.SelectMany(v => v.Values).ToList().AsReadOnly();
        }

        /// <summary>
        /// Adds or updates (if already exists) an entity, keyed by type and id.
        /// </summary>
        /// <param name="entity">The item to be added or updated.</param>
        /// <remarks>
        /// Not a thread-safe method.
        /// </remarks>
        internal void AddOrUpdate(IIdentifiable entity)
        {
            Type type = entity.GetType();
            if (!this.supplementalData.ContainsKey(type))
            {
                this.supplementalData.Add(type, new Dictionary<int, IIdentifiable>());
            }

            this.supplementalData[type][entity.Id] = entity;
        }

        /// <summary>
        /// Adds or updates (if already exists) multiple entities, keyed by type and id.
        /// </summary>
        /// <param name="entities">The items to be added or updated.</param>
        /// <remarks>
        /// Not a thread-safe method.
        /// </remarks>
        internal void AddOrUpdate(IEnumerable<IIdentifiable> entities)
        {
            foreach (IIdentifiable entity in entities)
            {
                AddOrUpdate(entity);
            }
        }
    }
}
