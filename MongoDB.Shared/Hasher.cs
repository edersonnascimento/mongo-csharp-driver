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

using System.Collections;

namespace MongoDB.Shared
{
    internal class Hasher
    {
        // private fields
        private int _hashCode;

        // constructors
        public Hasher()
        {
            _hashCode = 17;
        }

        public Hasher(int seed)
        {
            _hashCode = seed;
        }

        // public methods
        public override int GetHashCode()
        {
            return _hashCode;
        }

        // this overload added to avoid boxing
        public Hasher Hash(bool obj)
        {
            _hashCode = 37 * _hashCode + obj.GetHashCode();
            return this;
        }

        // this overload added to avoid boxing
        public Hasher Hash(int obj)
        {
            _hashCode = 37 * _hashCode + obj.GetHashCode();
            return this;
        }

        // this overload added to avoid boxing
        public Hasher Hash(long obj)
        {
            _hashCode = 37 * _hashCode + obj.GetHashCode();
            return this;
        }

        public Hasher Hash(object obj)
        {
            _hashCode = 37 * _hashCode + ((obj == null) ? 0 : obj.GetHashCode());
            return this;
        }

        public Hasher HashElements(IEnumerable sequence)
        {
            if (sequence == null)
            {
                _hashCode = 37 * _hashCode + 0;
            }
            else
            {
                foreach (var obj in sequence)
                {
                    _hashCode = 37 * _hashCode + ((obj == null) ? 0 : obj.GetHashCode());
                }
            }
            return this;
        }
    }
}