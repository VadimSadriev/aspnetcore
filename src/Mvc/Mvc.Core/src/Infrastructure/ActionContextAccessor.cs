// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading;

namespace Microsoft.AspNetCore.Mvc.Infrastructure
{
    public class ActionContextAccessor : IActionContextAccessor
    {
        internal static readonly IActionContextAccessor Null = new NullActionContextAccessor();

        private static readonly AsyncLocal<ActionContext> _storage = new AsyncLocal<ActionContext>();

        public ActionContext ActionContext
        {
            get { return _storage.Value; }
            set { _storage.Value = value; }
        }

        private class NullActionContextAccessor : IActionContextAccessor
        {
            public ActionContext ActionContext
            {
                get => null;
                set { }
            }
        }
    }
}