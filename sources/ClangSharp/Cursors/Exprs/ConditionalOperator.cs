// Copyright (c) Microsoft and Contributors. All rights reserved. Licensed under the University of Illinois/NCSA Open Source License. See LICENSE.txt in the project root for license information.

using System;
using System.Linq;
using ClangSharp.Interop;

namespace ClangSharp
{
    public sealed class ConditionalOperator : AbstractConditionalOperator
    {
        private readonly Lazy<Expr> _cond;
        private readonly Lazy<Expr> _lhs;
        private readonly Lazy<Expr> _rhs;

        internal ConditionalOperator(CXCursor handle) : base(handle, CXCursorKind.CXCursor_ConditionalOperator, CX_StmtClass.CX_StmtClass_ConditionalOperator)
        {
            _cond = new Lazy<Expr>(() => Children.OfType<Expr>().ElementAt(0));
            _lhs = new Lazy<Expr>(() => Children.OfType<Expr>().ElementAt(1));
            _rhs = new Lazy<Expr>(() => Children.OfType<Expr>().ElementAt(2));
        }

        public Expr Cond => _cond.Value;

        public Expr FalseExpr => RHS;

        public Expr LHS => _lhs.Value;

        public Expr RHS => _rhs.Value;

        public Expr TrueExpr => LHS;
    }
}
