﻿//-----------------------------------------------------------------------
// <copyright file="StatusUpdateOptions.cs" company="Patrick 'Ricky' Smith">
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
// <author>Ricky Smith</author>
// <summary>The status update options class</summary>
//-----------------------------------------------------------------------

namespace Twitterizer
{
    using System;

    /// <summary>
    /// The Status Update Options class
    /// </summary>
#if !SILVERLIGHT
    [Serializable]
#endif
    public sealed class StatusUpdateOptions : OptionalProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusUpdateOptions"/> class.
        /// </summary>
        public StatusUpdateOptions()
            : base()
        {
        }

        /// <summary>
        /// Gets or sets the in reply to status id.
        /// </summary>
        /// <value>The in reply to status id.</value>
        public decimal InReplyToStatusId { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not to put a pin on the exact coordinates a tweet has been sent from.
        /// </summary>
        /// <value><c>true</c> to put a pin on the exact coordinates; otherwise, <c>false</c>.</value>
        public bool PlacePin { get; set; }

        /// <summary>
        /// Gets or sets a place in the world. These IDs can be retrieved from geo/reverse_geocode.
        /// </summary>
        /// <value>The place id.</value>
        public string PlaceId { get; set; }
    }
}
