using System.Collections;
using System.Linq.Expressions;

namespace Cashing.Infra.Domain.Comparers;

public class OrderExpressionComparer<Tsourse> : IComparer<(Expression<Func<Tsourse, object>> KeySelecter, bool IsAscending)>
{
    public int Compare(
        (Expression<Func<Tsourse, object>> KeySelecter, bool IsAscending) x, 
        (Expression<Func<Tsourse, object>> KeySelecter, bool IsAscending) y)
    {
        if (ReferenceEquals(x.KeySelecter, y.KeySelecter)) return 0;
        if (ReferenceEquals(null, y.KeySelecter)) return 1;
        if (ReferenceEquals(null, x.KeySelecter)) return -1;

        var keySelectorComparison =
            string.Compare(x.KeySelecter.ToString(), y.KeySelecter.ToString(), StringComparison.Ordinal);

        return keySelectorComparison != 0
            ? keySelectorComparison
            : Comparer<bool>.Default.Compare(x.IsAscending, y.IsAscending);
    }
}