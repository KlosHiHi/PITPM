private decimal CalculateOrderTotal(Order order)
{
    decimal subtotal = order.Items.Sum(item => item.Quantity * item.UnitPrice);
    decimal discount = CalculateDiscount(order.CustomerId, subtotal);
    return subtotal - discount;
}

private decimal CalculateDiscount(Customer customer, decimal subtotal)
{
    if (customer.IsPremium && subtotal > 1000)
        return subtotal * 0.1m;
    
    if (!string.IsNullOrEmpty(customer.PromoCode))
        return ApplyPromoCode(customer.PromoCode, subtotal);
    
    return 0;
}
