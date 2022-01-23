using System;

namespace ShoppingBasket {
    public static class Money {

        public static string ToPriceString(this int input) {
            return $"£{input / 100}.{(input % 100).ToString("00")}";
        }
    }
}
