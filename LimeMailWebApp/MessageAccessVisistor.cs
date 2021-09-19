using LimeMailWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LimeMailWebApp.Controllers
{
    public class MessageAccessVisistor : ExpressionVisitor
    {
        private readonly Type declaringType;
        private IList<string> messageNames = new List<string>();

        public MessageAccessVisistor(Type declaringType)
        {
            this.declaringType = declaringType;
        }

        public IEnumerable<string> MessageNames { get { return messageNames; } }

        [return: NotNullIfNotNull("node")]
        public override Expression Visit(Expression expr)
        {
            if(expr != null && expr.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpr = (MemberExpression)expr;
                if(memberExpr.Member.DeclaringType == declaringType)
                {
                    messageNames.Add(memberExpr.Member.Name);
                }
            }
            return base.Visit(expr);
        }
    }
}
