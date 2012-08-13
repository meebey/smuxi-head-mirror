﻿//-----------------------------------------------------------------------
// <copyright file="TwitterStatusAsync.cs" company="Patrick 'Ricky' Smith">
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
// <summary>The asynchronous Twitter Status class</summary>
//-----------------------------------------------------------------------
namespace Twitterizer
{
    using System;

    /// <summary>
    /// An asynchronous wrapper around the <see cref="TwitterStatus"/> class.
    /// </summary>
    public static class TwitterStatusAsync
    {
        /// <summary>
        /// Deletes the specified status.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="id">The id.</param>
        /// <param name="options">The options.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="function">The function.</param>
        /// <returns></returns>
        public static IAsyncResult Delete(OAuthTokens tokens, decimal id, OptionalProperties options, TimeSpan timeout, Action<TwitterAsyncResponse<TwitterStatus>> function)
        {
            return AsyncUtility.ExecuteAsyncMethod(tokens, id, options, timeout, TwitterStatus.Delete, function);
        }

        /// <summary>
        /// Retweets a tweet. Requires the id parameter of the tweet you are retweeting. (say that 5 times fast)
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="statusId">The status id.</param>
        /// <param name="options">The options.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="function">The function.</param>
        /// <returns></returns>
        public static IAsyncResult Retweet(OAuthTokens tokens, decimal statusId, OptionalProperties options, TimeSpan timeout, Action<TwitterAsyncResponse<TwitterStatus>> function)
        {
            return AsyncUtility.ExecuteAsyncMethod(tokens, statusId, options, timeout, TwitterStatus.Retweet, function);
        }

        /// <summary>
        /// Returns up to 100 of the first retweets of a given tweet.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="statusId">The status id.</param>
        /// <param name="options">The options.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="function">The function.</param>
        /// <returns></returns>
        public static IAsyncResult Retweets(OAuthTokens tokens, decimal statusId, RetweetsOptions options, TimeSpan timeout, Action<TwitterAsyncResponse<TwitterStatusCollection>> function)
        {
            return AsyncUtility.ExecuteAsyncMethod(tokens, statusId, options, timeout, TwitterStatus.Retweets, function);
        }

        /// <summary>
        /// Returns a single status, with user information, specified by the id parameter.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="statusId">The status id.</param>
        /// <param name="options">The options.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="function">The function.</param>
        /// <returns></returns>
        public static IAsyncResult Show(OAuthTokens tokens, decimal statusId, OptionalProperties options, TimeSpan timeout, Action<TwitterAsyncResponse<TwitterStatus>> function)
        {
            return AsyncUtility.ExecuteAsyncMethod(tokens, statusId, options, timeout, TwitterStatus.Show, function);
        }

        /// <summary>
        /// Updates the authenticating user's status. A status update with text identical to the authenticating user's text identical to the authenticating user's current status will be ignored to prevent duplicates.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="text">The text.</param>
        /// <param name="options">The options.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="function">The function.</param>
        /// <returns></returns>
        public static IAsyncResult Update(OAuthTokens tokens, string text, StatusUpdateOptions options, TimeSpan timeout, Action<TwitterAsyncResponse<TwitterStatus>> function)
        {
            return AsyncUtility.ExecuteAsyncMethod(tokens, text, options, timeout, TwitterStatus.Update, function);
        }

        /// <summary>
        /// Updates the twitter status, and includes media (typically an image) in that update.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="text">The text.</param>
        /// <param name="fileData">The file data.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="function">The function.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static IAsyncResult UpdateWithMedia(OAuthTokens tokens, string text, byte[] fileData, TimeSpan timeout, Action<TwitterAsyncResponse<TwitterStatus>> function, StatusUpdateOptions options = null)
        {
            Func<OAuthTokens, string, byte[], StatusUpdateOptions, TwitterResponse<TwitterStatus>> methodToCall = TwitterStatus.UpdateWithMedia;

            return methodToCall.BeginInvoke(
                tokens,
                text,
                fileData,
                options,
                result => AsyncUtility.ThreeParamsCallback(result, timeout, methodToCall, function),
                null);
        }

        /// <summary>
        /// Updates the twitter status, and includes media (typically an image) in that update.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <param name="text">The text.</param>
        /// <param name="fileLocation">The file location.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="function">The function.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static IAsyncResult UpdateWithMedia(OAuthTokens tokens, string text, string fileLocation, TimeSpan timeout, Action<TwitterAsyncResponse<TwitterStatus>> function, StatusUpdateOptions options = null)
        {
            Func<OAuthTokens, string, string, StatusUpdateOptions, TwitterResponse<TwitterStatus>> methodToCall = TwitterStatus.UpdateWithMedia;

            return methodToCall.BeginInvoke(
                tokens,
                text,
                fileLocation,
                options,
                result => AsyncUtility.ThreeParamsCallback(result, timeout, methodToCall, function),
                null);
        }
    }
}
