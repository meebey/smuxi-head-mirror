﻿//-----------------------------------------------------------------------
// <copyright file="CreateSavedSearchCommand.cs" company="Patrick 'Ricky' Smith">
//  This file is part of the Twitterizer library (http://www.twitterizer.net/)
// 
//  Copyright (c) 2010, Patrick "Ricky" Smith (ricky@digitally-born.com)
//  All rights reserved.
//  
//  Redistribution and use in source and binary forms, with or without modification, are 
//  permitted provided that the following conditions are met:
// 
//  - Redistributions of source code must retain the above copyright notice, this list 
//    of conditions and the following disclaimer.
//  - Redistributions in binary form must reproduce the above copyright notice, this list 
//    of conditions and the following disclaimer in the documentation and/or other 
//    materials provided with the distribution.
//  - Neither the name of the Twitterizer nor the names of its contributors may be 
//    used to endorse or promote products derived from this software without specific 
//    prior written permission.
// 
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
//  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
//  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
//  IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
//  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
//  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
//  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
//  WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
//  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
//  POSSIBILITY OF SUCH DAMAGE.
// </copyright>
// <author>David Golden</author>
// <summary>The create saved search command class.</summary>
//-----------------------------------------------------------------------

namespace Twitterizer.Commands
{
    using System;
    using System.Globalization;
    using Twitterizer.Core;

    /// <summary>
    /// The Create Saved Search Command class. Creates the Saved Search with the query provided as the authenticating user. Returns the saved search when successful.
    /// </summary>
    [AuthorizedCommandAttribute]
#if !SILVERLIGHT
    [Serializable]
#endif
    internal sealed class CreateSavedSearchCommand : TwitterCommand<TwitterSavedSearch>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSavedSearchCommand"/> class.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="query">The query.</param>
        /// <param name="options">The options.</param>
        public CreateSavedSearchCommand(OAuthTokens tokens, string query, OptionalProperties options) :
            base(HTTPVerb.POST, "saved_searches/create.json", tokens, options)
        {
            if (tokens == null)
            {
                throw new ArgumentNullException("tokens");
            }

            if (String.IsNullOrEmpty(query))
            {
                throw new ArgumentException("Query is required.");
            }

            this.Query = query;
        }

        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>The query.</value>
        public string Query { get; internal set; }

        /// <summary>
        /// Initializes the command.
        /// </summary>
        public override void Init()
        {
            if (!String.IsNullOrEmpty(this.Query))
            {
                this.RequestParameters.Add("query", this.Query.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}
