﻿/* Copyright 2010-2013 10gen Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoDB.Driver.Core
{
    /// <summary>
    /// Represents a serializer for a CommandResult.
    /// </summary>
    public class CommandResultSerializer<TCommandResult> : BsonBaseSerializer<TCommandResult> where TCommandResult : CommandResult
    {
        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResultSerializer{TCommandResult}"/> class.
        /// </summary>
        public CommandResultSerializer()
        {
        }

        // public methods
        /// <summary>
        /// Deserializes a value.
        /// </summary>
        /// <param name="context">The deserialization context.</param>
        /// <returns>
        /// An object.
        /// </returns>
        public override TCommandResult Deserialize(BsonDeserializationContext context)
        {
            var response = BsonDocumentSerializer.Instance.Deserialize(context.CreateChild(typeof(BsonDocument)));
            return (TCommandResult)Activator.CreateInstance(typeof(TCommandResult), response);
        }
    }
}