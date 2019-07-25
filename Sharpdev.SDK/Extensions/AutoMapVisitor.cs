using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using AutoMapper;

namespace Sharpdev.SDK.Extensions
{
    /// <summary>
    ///     An <see cref="ExpressionVisitor" /> implementation which uses <see href="http://automapper.org">AutoMapper</see> to
    ///     remap property access from elements of type <typeparamref name="TSource" /> to elements of type
    ///     <typeparamref name="TDestination" />.
    /// </summary>
    /// <typeparam name="TSource">The type of the source element.</typeparam>
    /// <typeparam name="TDestination">The type of the destination element.</typeparam>
    public class AutoMapVisitor<TSource, TDestination> : ExpressionVisitor
    {
        private readonly ParameterExpression _newParameter;

        private readonly TypeMap _typeMap = Mapper.Configuration.FindTypeMapFor<TSource, TDestination>();

        /// <summary>
        ///     Initialises a new instance of the <see cref="AutoMapVisitor{TSource, TDestination}" /> class.
        /// </summary>
        /// <param name="newParameter">The new <see cref="ParameterExpression" /> to access.</param>
        public AutoMapVisitor(ParameterExpression newParameter)
        {
            Contract.Requires(newParameter != null);

            this._newParameter = newParameter;
            Contract.Assume(this._typeMap != null);
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this._typeMap != null);
            Contract.Invariant(this._newParameter != null);
        }

        /// <summary>
        ///     Visits the children of the <see cref="T:System.Linq.Expressions.MemberExpression" />.
        /// </summary>
        /// <returns>
        ///     The modified expression, if it or any subexpression was modified; otherwise, returns the original expression.
        /// </returns>
        /// <param name="node">The expression to visit.</param>
        protected override Expression VisitMember(MemberExpression node)
        {
            IEnumerable<PropertyMap> propertyMaps = this._typeMap.PropertyMaps;
            Contract.Assume(propertyMaps != null);

            // Find any mapping for this member
            PropertyMap propertyMap =
                propertyMaps.SingleOrDefault(map => map.SourceMember == node.Member);

            if (propertyMap == null)
                return base.VisitMember(node);

            MemberInfo destinationProperty = propertyMap.DestinationMember;

            Contract.Assume(destinationProperty != null);
            MemberInfo destinationMember = destinationProperty;

            Contract.Assume(destinationMember != null);

            // Check the new member is a property too
            PropertyInfo property = destinationMember as PropertyInfo;

            if (property == null)
                return base.VisitMember(node);

            // Access the new property
            MemberExpression newPropertyAccess = Expression.Property(this._newParameter, property);

            return base.VisitMember(newPropertyAccess);
        }
    }
}
