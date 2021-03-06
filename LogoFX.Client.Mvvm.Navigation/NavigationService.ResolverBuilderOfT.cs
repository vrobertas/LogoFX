﻿using System;

namespace LogoFX.Client.Mvvm.Navigation
{
    internal sealed partial class NavigationService
    {
        private sealed class ResolverBuilder<T> : RootableNavigationBuilder<T>
        {
            private readonly Func<T> _createFunc;

            public ResolverBuilder(INavigationService service, Func<T> createFunc)
            {
                _createFunc = createFunc;
            }

            protected override T GetValueInternal()
            {
                return _createFunc();
            }
        }

    }
}